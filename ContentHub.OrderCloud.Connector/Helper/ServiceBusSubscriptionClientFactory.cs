using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector.Helper
{
    public class ServiceBusSubscriptionClientFactory
    {
        // connection string to your Service Bus namespace
        static string connectionString = "<NAMESPACE CONNECTION STRING>";

        // name of your Service Bus queue
        static string queueName = "<QUEUE NAME>";

        // the client that owns the connection and can be used to create senders and receivers
        static ServiceBusClient client;

       
        static ServiceBusReceiver receiver;

        
        private const int numOfMessages = 3;

        
        public static ServiceBusClient CreateAzureBusClient(string connectionString)
        {


            var clientOptions = new ServiceBusClientOptions() { TransportType = ServiceBusTransportType.AmqpWebSockets };
            var client = new ServiceBusClient(connectionString, clientOptions);
          
            return client;
        }
    }
}
