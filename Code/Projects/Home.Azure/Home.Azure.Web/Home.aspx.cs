using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using Home.Azure.Entities;
using System.IO;
using System.Text;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.Azure.WebJobs;

namespace Home.Azure.Web
{
    public partial class Home : System.Web.UI.Page
    {
        // Parse the connection string and return a reference to the storage account.
        CloudStorageAccount storageAccount =
            CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        CloudBlobClient blobClient;
        CloudBlobContainer container;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (container == null)
            {
                container = CreateContainer();
            }

            if (!IsPostBack)
            {
                BindTableGrid();
                //BindBlobGrid();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                CloudBlockBlob blockblob = CreateBlockBlob(container);

                // Set the metadata into the blob
                blockblob.Metadata["FileName"] = Path.GetFileName(Server.MapPath("~/Uploads/pincodes.txt"));
                blockblob.SetMetadata();

                string filepath = Path.GetFullPath(Server.MapPath("~/Uploads/pincodes.txt"));
                using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    blockblob.UploadFromStream(fs);
                }

                lblMessage.Text += "File uploaded successfully!" + "<br />";

                ReadBlob();

                CreateSubscriptionAndTopic();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

            BindTableGrid();
            //BindBlobGrid();
        }

        //public static void TriggerNotification([ServiceBusTrigger("pincodetopic", "pincodesubscription")] string message,
        //    TextWriter logger)
        //{
        //    logger.WriteLine("Topic message: " + message);
        //}


        private void BindTableGrid()
        {
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "pincodes" table.
            CloudTable table = tableClient.GetTableReference("pincodes");

            var entities = table.ExecuteQuery(new TableQuery<PinCodes>()).ToList();

            var newlist = from e in entities
                          select new
                          {
                              GUID = e.RowKey,
                              Pin = e.PinCode,
                              City = e.City,
                              Date = e.Timestamp.ToString("dd-MM-yyyy hh:mm:ss tt")
                          };

            grdTable.DataSource = newlist.OrderByDescending(o => o.Date);
            grdTable.DataBind();
        }


        //private void BindBlobGrid()
        //{
        //    var blobs = container.ListBlobs(null, true, BlobListingDetails.All).Cast<CloudBlockBlob>();

        //    var newblobs = from b in blobs
        //                   select new
        //                    {
        //                        Name = b.Metadata["FileName"],
        //                        Uri = b.Uri,
        //                        Length = b.Properties.Length,
        //                        ContentType = b.Properties.ContentType
        //                    };

        //    grdBlob.DataSource = newblobs;
        //    grdBlob.DataBind();
        //}

        private CloudBlobContainer CreateContainer()
        {
            // Create the blob client.
            blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            container = blobClient.GetContainerReference("blobcontainer");

            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();
            BlobContainerPermissions permissions = new BlobContainerPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Blob;

            container.SetPermissions(permissions);

            return container;
        }

        private CloudBlockBlob CreateBlockBlob(CloudBlobContainer container)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("blockblob");
            return blockBlob;
        }

        private void ReadBlob()
        {
            try
            {
                // Retrieve reference to a previously created container.
                CloudBlobContainer container = blobClient.GetContainerReference("blobcontainer");

                // Retrieve reference to a blob named "myblob.txt"
                CloudBlockBlob blockBlob2 = container.GetBlockBlobReference("blockblob");

                using (var memoryStream = new MemoryStream())
                {
                    blockBlob2.DownloadToStream(memoryStream);

                    memoryStream.Position = 0;
                    List<string> rows = new List<string>();

                    using (var reader = new StreamReader(memoryStream, Encoding.ASCII))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            rows.Add(line);

                            InsertInTableBlob(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void InsertInTableBlob(string value)
        {
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "pincodes" table.
            CloudTable table = tableClient.GetTableReference("pincodes");
            table.CreateIfNotExists();

            // Create a new pincode entity.
            PinCodes pin = new PinCodes(value == "410206" ? "New Panvel" : "Mumbai");
            pin.PinCode = value;

            if (value == "410206")
            {
                pin.City = "New Panvel";
            }
            else if (value == "400010")
            {
                pin.City = "Mumbai";
            }

            // Create the TableOperation object that inserts the pincode entity.
            TableOperation insertOperation = TableOperation.Insert(pin);

            // Execute the insert operation.
            table.Execute(insertOperation);

            lblMessage.Text += "Pin code saved successfully!" + "<br />";
        }

        private void CreateSubscriptionAndTopic()
        {
            try
            {
                string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

                var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

                if (!namespaceManager.TopicExists("pincodetopic"))
                {
                    namespaceManager.CreateTopic("pincodetopic");
                }

                if (!namespaceManager.SubscriptionExists("pincodetopic", "pincodesubscription"))
                {
                    namespaceManager.CreateSubscription("pincodetopic", "pincodesubscription");
                }

                TopicClient client = TopicClient.CreateFromConnectionString(connectionString, "pincodetopic");
                BrokeredMessage msg = new BrokeredMessage();
                msg.Properties.Add("test key", "test value");
                client.Send(msg);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}