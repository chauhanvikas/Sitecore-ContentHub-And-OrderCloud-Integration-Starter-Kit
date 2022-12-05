using ContentHub.OrderCloud.Connector.Helper;

using Microsoft.Extensions.Configuration;
using OrderCloud.SDK;
using Stylelabs.M.Sdk.Contracts.Base;
using Stylelabs.M.Sdk.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector.Model
{
    public class ImportEntity
    {

        /// <summary>
        /// Initializes a new an instance of the <see cref="ImportEntityArgument"/> class.
        /// </summary>
        /// <param name="message">The <see cref="ServiceBusMessage"/> that contains information about changed entity.</param>
        /// <param name="clientPolicy">The <see cref="ContentHubClientPolicy"/> that contains connection information for the target Content Hub instance.</param>
        /// <param name="synchronizationPolicy">The <see cref="ContentHub.SynchronizationPolicy"/> that contains basic information needed to synchronize data from Content Hub.</param>
        /// <param name="productSynchronizationPolicy">The <see cref="ContentHub.ProductSynchronizationPolicy"/> that contains information needed to synchronize product data from Content Hub.</param>
        /// <param name="assetSynchronizationPolicy">The <see cref="ContentHub.AssetSynchronizationPolicy"/> that contains information needed to synchronize asset data from Content Hub.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="message"/>, <paramref name="clientPolicy"/>, or <paramref name="synchronizationPolicy"/>
        ///     is <see langword="null"/>.
        /// </exception>
        public ImportEntity(SaveEntityMessageazure message, AppSettings appSettings, IConfiguration configuration)
        {
            OrderCloudConnect OrderCloudConnect = new OrderCloudConnect(appSettings);
            MConnector MConnector = new MConnector(appSettings);
            Message = message;

            TargetId = message.TargetId;
            TargetIdentifier = message.TargetIdentifier;
            EventType = message.EventType;
            WebCHClient = MConnector.Client;
            OcClient = OrderCloudConnect.Client;
            TargetDefination = message.TargetDefinition;
            //PropertiesToBeSync = UtilityHelper.propertyMappingList;
            PropertiesToBeSync = configuration.GetSection("ProductFieldsMapping").Get<Dictionary<string, string>>();

        }

        /// <summary>
        /// The <see cref="ServiceBusMessage"/> received.
        /// </summary>
        public SaveEntityMessageazure Message { get; }

        public IWebMClient WebCHClient { get; }

        public OrderCloudClient OcClient { get; }

        /// <summary>
        /// Gets the id of the target Content Hub entity.
        /// </summary>
        public long TargetId { get; }

        /// <summary>
        /// Gets the identifier of the target Content Hub entity.
        /// </summary>
        public string TargetIdentifier { get; }
        /// <summary>
        /// Gets the Defination of the target Content Hub entity.
        /// </summary>
        public string TargetDefination { get; }
        /// <summary>
        /// Gets the type of the current event.
        /// </summary>
        public string EventType { get; }

        /// <summary>
        /// Gets the version of the Content Hub entity.
        /// </summary>
        public int Version { get; }

        /// <summary>
        /// Gets or sets the Content Hub <see cref="IEntity"/>.
        /// </summary>
        public IEntity Entity { get; set; }

        /// <summary>
        /// Gets or sets the assets related to <see cref="Entity"/>.
        /// </summary>
        public IList<IEntity> Assets { get; set; }



        /// <summary>
        /// Gets or sets the properties related to <see cref="Entity"/>.
        /// </summary>
        public IDictionary<string, string> PropertiesToBeSync { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IDictionary{TKey, TValue}"/>, where key is a Public Link
        ///     and value is a corresponding image.
        /// </summary>
        public IDictionary<IEntity, IEntity> PublicLinkToImageMappings { get; set; }

      

    }
}
