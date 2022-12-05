using ContentHub.OrderCloud.Connector.Helper;
using ContentHub.OrderCloud.Connector.Model;
using Stylelabs.M.Framework.Essentials.LoadConfigurations;
using Stylelabs.M.Sdk.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector.Repositories
{
    public interface IEntitySyncRepository
    {

        //public Task<IEntity> FetchEntity(ImportEntity importEntity);
        //public Task<IEntity> FetchEntity(ImportEntity importEntity, EntityLoadConfiguration loadconfig);
        
        public Task<string> SynChEntityToOrderCLoud(ImportEntity importEntity);

        public Task<ImportEntity> CreateOrUpdateProduct(ImportEntity importEntity);
        public Task<bool> CreateOrUpdateAssets(ImportEntity importEntity);

    }
}
