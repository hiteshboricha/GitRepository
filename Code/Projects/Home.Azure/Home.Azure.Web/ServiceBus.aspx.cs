using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ServiceBus.Messaging;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using System.Text;
using Microsoft.Azure;

namespace Home.Azure.Web
{
    public partial class ServiceBus : System.Web.UI.Page
    {
        private DataTable issues;
        private List<BrokeredMessage> MessageList;

        //Credentials
        //private string ServiceNamespace;
        //private string saskeyname;
        //private string saskeyvalue;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //issues = ParseCSVFile();
            //MessageList = GenerateMessages(issues);

            //CollectUserInput();
            //Queue();

            //Subscribe(MessageList);
            CreateSubscription();
            CreateTopic();
        }

        private DataTable ParseCSVFile()
        {
            DataTable tableIssues = new DataTable("Issues");
            string path = Server.MapPath("~/Uploads/data.csv");

            try
            {
                using (StreamReader readFile = new StreamReader(path))
                {
                    string line;
                    string[] row;

                    // create the columns
                    line = readFile.ReadLine();
                    foreach (string columnTitle in line.Split(','))
                    {
                        tableIssues.Columns.Add(columnTitle);
                    }

                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(',');
                        tableIssues.Rows.Add(row);
                    }
                }
            }
            catch (Exception e)
            {
                DisplayMessage(e.StackTrace + " - " + e.StackTrace);
            }

            return tableIssues;
        }

        private List<BrokeredMessage> GenerateMessages(DataTable table)
        {
            //Instantiate the brokered list object
            List<BrokeredMessage> result = new List<BrokeredMessage>();

            //Loop datatable and add brokered msg for each row
            foreach (DataRow row in table.Rows)
            {
                BrokeredMessage msg = new BrokeredMessage();

                foreach (DataColumn column in table.Columns)
                {
                    msg.Properties.Add(column.ColumnName, row[column]);
                }

                result.Add(msg);
            }

            return result;
        }

        private void CollectUserInput()
        {
            //ServiceNamespace = "homeazuresnamespace";
            //saskeyname = "RootManageSharedAccessKey";
            //saskeyvalue = "D3s/kKFJTpXHTsLMFMvhAmY/MvNQsplptzOPofyZuHs=";
            //saskeyvalue = "Endpoint=sb://homeazuresnamespace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=D3s/kKFJTpXHTsLMFMvhAmY/MvNQsplptzOPofyZuHs=";
        }

        //private void Subscribe(List<BrokeredMessage> list)
        private void CreateTopic()
        {
            // Create the topic if it does not exist already.
            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.TopicExists("addresstopic"))
            {
                namespaceManager.CreateTopic("addresstopic");
            }

            TopicClient client = TopicClient.CreateFromConnectionString(connectionString, "addresstopic");
            client.Send(new BrokeredMessage());

            //foreach (BrokeredMessage msg in list)
            //{
            //    client.Send(msg);
            //}
        }

        private void CreateSubscription()
        {
            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.SubscriptionExists("addresstopic", "addresssubscription"))
            {
                namespaceManager.CreateSubscription("addresstopic", "addresssubscription");
            }
        }

        //async Task Queue()
        //{
        //    try
        //    {
        //        string _connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

        //        //Create management credentials
        //        TokenProvider credentials = TokenProvider.CreateSharedAccessSignatureTokenProvider(saskeyname, saskeyvalue);
                
        //        //NamespaceManager namespaceClient =
        //        //    new NamespaceManager(ServiceBusEnvironment.CreateServiceUri("http", ServiceNamespace, string.Empty));

        //        NamespaceManager namespaceClient = NamespaceManager.CreateFromConnectionString(_connectionString);

        //        QueueDescription myQueue;

        //        if (namespaceClient.QueueExists("IssueTrackingQueue"))
        //        {
        //            namespaceClient.DeleteQueue("IssueTrackingQueue");
        //        }

        //        myQueue = namespaceClient.CreateQueue("IssueTrackingQueue");

        //        MessagingFactory factory =
        //            MessagingFactory.Create(ServiceBusEnvironment.CreateServiceUri("sb", ServiceNamespace, string.Empty), credentials);

        //        QueueClient queueclient = factory.CreateQueueClient("IssueTrackingQueue");
        //        //QueueClient queueclient = QueueClient.CreateFromConnectionString("ServiceBusConnectionString", "IssueTrackingQueue");

        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("Now sending messages to the queue.");
        //        DisplayMessage(sb);

        //        for (int i = 0; i < 6; i++)
        //        {
        //            var issue = MessageList[i];

        //            issue.Label = issue.Properties["IssueTitle"].ToString();

        //            try
        //            {
        //                queueclient.Send(issue);
        //            }
        //            catch(Exception ex)
        //            {
        //                DisplayMessage(ex.Message);
        //            }

        //            sb.Append(string.Format("Message sent: {0}, {1}", issue.Label, issue.MessageId));
        //            DisplayMessage(sb);
        //        }

        //        //Create a receiver and receive messages from the queue
        //        BrokeredMessage msg;

        //        while ((msg = queueclient.Receive(new TimeSpan(hours: 0, minutes: 0, seconds: 5))) != null)
        //        {
        //            sb.Append(string.Format("Message received: {0}, {1}, {2}", msg.SequenceNumber, msg.Label, msg.MessageId));
        //            DisplayMessage(sb);
        //            msg.Complete();

        //            sb.Append("Processing message (sleeping...)");
        //            DisplayMessage(sb);
        //            Thread.Sleep(1000);
        //        }

        //        factory.Close();
        //        queueclient.Close();
        //        namespaceClient.DeleteQueue("IssueTrackingQueue");
        //    }
        //    catch (Exception e)
        //    {
        //        DisplayMessage(e.StackTrace + " - " + e.StackTrace);
        //    }
        //}

        private void DisplayMessage(StringBuilder sb)
        {
            sb.Append("<br />");
            lblMessage.Text = sb.ToString();
        }

        private void DisplayMessage(string text)
        {
            lblMessage.Text = text;
        }
    }
}