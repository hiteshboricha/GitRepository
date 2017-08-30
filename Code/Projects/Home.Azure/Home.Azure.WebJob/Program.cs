using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.ServiceBus;
using Microsoft.Azure.WebJobs.Host;

namespace Home.Azure.WebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    public class Program
    {
        private static string _servicesBusConnectionString;
        private static NamespaceManager _namespaceManager;
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        public static void Main()
        {
            _servicesBusConnectionString = AmbientConnectionStringProvider.Instance.GetConnectionString(ConnectionStringNames.ServiceBus);
            _namespaceManager = NamespaceManager.CreateFromConnectionString(_servicesBusConnectionString);


            // The following code ensures that the WebJob will be running continuously

            Functions.ProcessQueueMessage("Web job tests", out Microsoft.Azure.NotificationHubs.Notification notification);

            JobHostConfiguration config = new JobHostConfiguration();
            ServiceBusConfiguration serviceBusConfig = new ServiceBusConfiguration
            {
                ConnectionString = _servicesBusConnectionString
            };
            config.UseServiceBus(serviceBusConfig);
            config.UseNotificationHubs();

            notification = new Microsoft.Azure.NotificationHubs.GcmNotification("test hub notification");
            var host = new JobHost(config);
            host.RunAndBlock();
        }
    }
}
