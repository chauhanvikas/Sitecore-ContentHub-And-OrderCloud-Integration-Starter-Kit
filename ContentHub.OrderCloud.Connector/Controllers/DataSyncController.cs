using ContentHub.OrderCloud.Connector.Helper;
using ContentHub.OrderCloud.Connector.Model;
using ContentHub.OrderCloud.Connector.Model.OC;
using ContentHub.OrderCloud.Connector.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderCloud.SDK;
using Stylelabs.M.Sdk.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataSyncController : ControllerBase
    {

        private readonly ILogger<DataSyncController> _logger;
        private readonly AppSettings appSettings;
        public  IEntitySyncRepository _IProductRepository;
        protected readonly IConfiguration _configuration;


        public DataSyncController(AppSettings appSettings, IEntitySyncRepository productrepo, IConfiguration configuration,ILogger<DataSyncController> logger)
        {
            this.appSettings = appSettings;
            this._IProductRepository = productrepo;
            _configuration = configuration;
            // _logger = logger;
        }

        [HttpPost]
        public async Task<string> EntitySync([FromBody] Root entityMessage)
        {
            string msg = string.Empty;
            if (entityMessage != null && entityMessage.saveEntityMessage != null)
            {
                ImportEntity importEntity = new ImportEntity(entityMessage.saveEntityMessage, appSettings, _configuration);
                msg = await _IProductRepository.SynChEntityToOrderCLoud(importEntity);
            }
            else
            {
                msg = "entity message is null";
            }
           
            return null;

        }
    }
}
