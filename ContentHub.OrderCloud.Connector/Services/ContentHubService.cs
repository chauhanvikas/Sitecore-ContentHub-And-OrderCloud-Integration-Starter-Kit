using ContentHub.OrderCloud.Connector.Model;
using Stylelabs.M.Framework.Essentials.LoadConfigurations;
using Stylelabs.M.Sdk.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector.Services
{
    public class ContentHubService: IContentHubService
    {


        /// <summary>
        /// Get the Contenthub entity 
        /// </summary>
        /// <param name="importEntity"> ImportEntity parameter containg the Azure bus entity message and Contenthub connetcion</param>
        /// <returns></returns>
        public async Task<IEntity> FetchEntity(ImportEntity importEntity)
        {
            IEntity entity = null;
            try
            {
                entity = await importEntity.WebCHClient.Entities.GetAsync(importEntity.TargetId, EntityLoadConfiguration.Full);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return entity;
        }


        public Task<IEntity> FetchEntity(ImportEntity importEntity, EntityLoadConfiguration loadconfig)
        {
            throw new NotImplementedException();
        }

    }
}
