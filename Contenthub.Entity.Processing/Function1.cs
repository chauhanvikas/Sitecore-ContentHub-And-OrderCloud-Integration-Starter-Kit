using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
namespace Contenthub.Entity.Processing
{

    public class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync([ServiceBusTrigger("pim", Connection = "QueueConnectionString")] Message myQueueItem, MessageReceiver messageReceiver, ILogger log)
        {
            // messageReceiver.DeadLetterAsync(msg.SystemProperties.LockToken);


            log.LogInformation("------------------------------Method: Message Recived ----------------------------");

            try
            {
                string payload = Encoding.UTF8.GetString(myQueueItem.Body);
                ContentHubChangeMessage contentHubChangeMsg = JsonConvert.DeserializeObject<ContentHubChangeMessage>(payload);

                if (null != contentHubChangeMsg.SaveEntityMessage.ChangeSet)
                {
                    //if (contentHubChangeMsg.SaveEntityMessage.TargetDefinition == "M.Asset")
                    //{
                    //    System.Threading.Thread.Sleep(5000);
                    //}
                    log.LogInformation("-- Entity ID" + contentHubChangeMsg.SaveEntityMessage.TargetId + "processing started");
                    string product = await SyncData(contentHubChangeMsg, log);

                    var result = JsonConvert.DeserializeObject<dynamic>(product);
                    if (!string.IsNullOrEmpty(result))
                    {
                        log.LogInformation($"Processed complete products: {contentHubChangeMsg.SaveEntityMessage.TargetId}");


                    }
                    await messageReceiver.CompleteAsync(myQueueItem.SystemProperties.LockToken);
                }
                else
                    log.LogInformation($"No ChangeSet for property Change found for Entity: {contentHubChangeMsg.SaveEntityMessage.TargetId}");
            }
            catch (Exception ex)
            {
                await messageReceiver.DeadLetterAsync(myQueueItem.SystemProperties.LockToken);

                log.LogError($"Exception in RunAsync:  {ex.Message}");
            }
            log.LogInformation("------------------------------RunAsync End ----------------------------");
        }

        /// <summary>
        /// Replace the Actual Ordercloud data sync API
        /// </summary>
        /// <param name="entityMessage">SaveEntityMessage Object</param>
        /// <returns>response</returns>
        private static async Task<string> SyncData(ContentHubChangeMessage entityMessage, ILogger log)
        {
            // log.LogInformation("------------------------------Method: SyncData Start ----------------------------");
            var client = new HttpClient();
            string contentString = string.Empty;

            try
            {
                string URI = "https://localhost:44329/DataSync";
                var content = entityMessage.AsJson();
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(URI, content);

                if (response.Content != null)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    // log.LogInformation($"Reading SyncData Response");
                }
            }
            catch (Exception ex)
            {
                log.LogError($"Exception in SyncData: {ex.Message}");
            }
            // log.LogInformation("------------------------------Method End: SyncData ----------------------------");
            return contentString;
        }
    }
}