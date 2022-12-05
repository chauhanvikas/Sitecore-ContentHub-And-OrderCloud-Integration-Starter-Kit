using ContentHub.OrderCloud.Connector.Model;
using Stylelabs.M.Framework.Essentials.LoadConfigurations;
using Stylelabs.M.Sdk.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector.Services
{
    public interface IContentHubService
    {
        public Task<IEntity> FetchEntity(ImportEntity importEntity);
        public Task<IEntity> FetchEntity(ImportEntity importEntity, EntityLoadConfiguration loadconfig);

    }
}
