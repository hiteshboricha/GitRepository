using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Table;
using Home.Azure.Entities;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure;
using System.Configuration;

namespace Home.Azure.WebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([ServiceBusTrigger("pincodetopic", "pincodesubscription")] string message)
        {
            CloudStorageAccount storageAccount =
            CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].
            ToString());
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "pincodes" table.
            CloudTable table = tableClient.GetTableReference("pincodes");

            PinCodes pin = new PinCodes();
            pin.PartitionKey = "New Panvel";
            pin.PinCode = "410206";
            pin.City = "New Panvel";
            pin.RowKey = "faa419e4-4d1e-4632-a49e-7ed3a8ef3614";

            pin.Weather = "Shine and sunny";

            TableOperation updateOperation = TableOperation.InsertOrReplace(pin);
            table.Execute(updateOperation);
        }
    }
}