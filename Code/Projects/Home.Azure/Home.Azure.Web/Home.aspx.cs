using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

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
            
            if(!IsPostBack)
            {
                BindBlobGrid();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //CloudBlobContainer container = CreateContainer();
            CloudBlockBlob blockblob = CreateBlockBlob(container);
            
            using (var fileStream = flupld.FileContent)
            {
                blockblob.UploadFromStream(fileStream);
            }

            BindBlobGrid();
        }

        private void BindBlobGrid()
        {
            var blobs = container.ListBlobs(null, true, BlobListingDetails.All).Cast<CloudBlockBlob>();

            grdBlob.DataSource = blobs;
            grdBlob.DataBind();
        }

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
    }
}