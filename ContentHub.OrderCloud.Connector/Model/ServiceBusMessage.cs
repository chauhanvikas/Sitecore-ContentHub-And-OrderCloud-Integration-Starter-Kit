using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector.Model
{
    public class ServiceBusMessage
    {
        
            /// <summary>
            ///     Gets the definition of the target Content Hub entity.
            /// </summary>
            public string TargetDefinition => EntityMessage.TargetDefinition;

            /// <summary>
            ///     Gets the id of the target Content Hub entity.
            /// </summary>
            public long TargetId => EntityMessage.TargetId;

            /// <summary>
            ///     Gets, Sets the <see cref="ContentHub.EntityMessage"/> that contains information
            ///     about changed Content Hub entity.
            /// </summary>
            public EntityMessage EntityMessage { get; set; }

            /// <summary>
            ///     Gets the <see cref="ContentHub.SaveEntityMessage"/> that contains information
            ///     about changed Content Hub entity.
            /// </summary>
            [JsonProperty("saveEntityMessage")]
            public SaveEntityMessageazure SaveEntityMessage
            {
                get => EntityMessage as SaveEntityMessageazure;
                set => EntityMessage = value;
            }

            /// <summary>
            ///     Gets the <see cref="ContentHub.SaveEntityMessage"/> that contains information
            ///     about changed Content Hub entity.
            /// </summary>
            [JsonProperty("deleteEntityMessage")]
            public DeleteEntityMessage DeleteEntityMessage
            {
                get => EntityMessage as DeleteEntityMessage;
                set => EntityMessage = value;
            }

            /// <summary>
            ///     Gets the context of the current <see cref="ServiceBusMessage"/>.
            /// </summary>
            [JsonProperty("context")]
            public ServiceBusMessageContext Context { get; set; }
        }
    }
