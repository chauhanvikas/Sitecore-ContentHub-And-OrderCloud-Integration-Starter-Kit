using Azure.Messaging.ServiceBus;
using ContentHub.OrderCloud.Connector.Helper;
using ContentHub.OrderCloud.Connector.Model;
using ContentHub.OrderCloud.Connector.Repositories;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceBusMessage = ContentHub.OrderCloud.Connector.Model.ServiceBusMessage;

namespace ContentHub.OrderCloud.Connector.Services
{
    public class InitializeServiceBus
    {
        //private readonly ILogger<InitializeServiceBus> _logger;
        //private readonly AppSettings appSettings;
        //public IProductRepository _IProductRepository;

        //public InitializeServiceBus(AppSettings appSettings, IProductRepository productrepo, ILogger<InitializeServiceBus> logger)
        //{
        //    this.appSettings = appSettings;
        //    this._IProductRepository = productrepo;

        //    // _logger = logger;
        //}
        //public  async Task<string> ExecuteAzureBusservice()
        //{
           
        //    try
        //    {
        //        var _subscriptionClient = ServiceBusSubscriptionClientFactory.CreateAzureBusClient("Endpoint=sb://hclcontenthub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5wCdImr/mIGNy4+RhYvNWZFrq2uMOkN0e3x3AeZ2rSA=");

        //        //ServiceBusProcessorOptions _serviceBusProcessorOptions = new ServiceBusProcessorOptions
        //        //{
        //        //    MaxConcurrentCalls = 1,
        //        //    AutoCompleteMessages = false,
        //        //};

               


        //      //  var receiver = _subscriptionClient.CreateProcessor("pim", _serviceBusProcessorOptions);
        //        var receiver = _subscriptionClient.CreateReceiver("pim");
        //        if (receiver != null && !receiver.IsClosed)
        //        {
        //            IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(maxMessages: 1);
        //            foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
        //            {
        //                // get the message body as a string
        //                string body = receivedMessage.Body.ToString();

        //                await receiver.CompleteMessageAsync(receivedMessage);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
                
        //    }

        //    return string.Empty;
        //}

        //private async Task ProcessMessageAsync(ServiceBusReceivedMessage message, CancellationToken token)
        //{
        //    var model = JsonConvert.DeserializeObject<ServiceBusMessage>(Encoding.UTF8.GetString(message.Body));

        //    if(model!=null)
        //    {
        //        ImportEntity importEntity = new ImportEntity(model.SaveEntityMessage);
        //        var iEntity = await _IProductRepository.SynChEntityToOrderCLoud(importEntity);

        //    }
           

            
        //}

     
    }
}
