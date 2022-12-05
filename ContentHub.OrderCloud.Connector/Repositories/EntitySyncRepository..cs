using ContentHub.OrderCloud.Connector.Helper;
using ContentHub.OrderCloud.Connector.Model;

using Microsoft.Extensions.Logging;
using OrderCloud.SDK;
using Stylelabs.M.Framework.Essentials.LoadConfigurations;
using Stylelabs.M.Framework.Essentials.LoadOptions;
using Stylelabs.M.Sdk.Contracts.Base;
using Stylelabs.M.Sdk.Models.Logging;
using Stylelabs.M.Sdk.WebClient.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stylelabs.M.Sdk.Models.Typed;
using System.Text;
using System.Reflection;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using ContentHub.OrderCloud.Connector.Services;
using ContentHub.OrderCloud.Connector.Model.OC;
using Stylelabs.M.Base.Querying;
using Stylelabs.M.Base.Querying.Linq;
using Inventory = OrderCloud.SDK.Inventory;

namespace ContentHub.OrderCloud.Connector.Repositories
{
    public class EntitySyncRepository:IEntitySyncRepository
    {
      
        private readonly AppSettings _appSettings;
        private readonly ILogger<EntitySyncRepository> _logger;
        private readonly IContentHubService _contentHubService;
        private readonly IOrdercloudService _ordercloudService;
        public EntitySyncRepository(AppSettings appsetting,
            ILogger<EntitySyncRepository> logger, IContentHubService contentHubService, IOrdercloudService ordercloudService)
        {
           
            _appSettings = appsetting;
            _logger = logger;
            _contentHubService = contentHubService;
            _ordercloudService = ordercloudService;
            
        }

        public async Task<string> SynChEntityToOrderCLoud(ImportEntity importEntity)
        {
            string result = "Updated "  + importEntity.TargetId + " Successfully";
            try
            {
                var entity = await _contentHubService.FetchEntity(importEntity);
                if (entity != null)
                {
                    importEntity.Entity = entity;
                    switch (importEntity.TargetDefination)
                    {


                        case "M.PCM.Product":
                            if (importEntity.Message.ChangeSet != null)
                            {
                                importEntity = await CreateOrUpdateProduct(importEntity);

                            }
                            break;
                        case "M.Asset":
                            if (importEntity.Message.ChangeSet != null)
                            {
                                var xs = await CreateOrUpdateAssets(importEntity);


                            }
                            break;
                        case "M.PCM.ProductCategory": break;
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
          return  result;
        }
      
      

       
        /// <summary>
        /// Create the new produst in Ordercloud if the entity type is new
        /// Update the product in Ordercloud
        /// </summary>
        /// <param name="importEntity"></param>
        /// <returns></returns>
        public async Task<ImportEntity> CreateOrUpdateProduct(ImportEntity importEntity)
        {
            if(importEntity.Message.IsNew)
            {
                var product = await CreateProduct(importEntity);


                if (product != null)
                    await CreatePriceSchedule(product,importEntity);
            }
            else 
            {
                importEntity= await   UpdateProduct(importEntity);
            }
            return importEntity;
        }
        /// <summary>
        /// Create the Price schedule in Order CLoud
        /// </summary>
        /// <param name="product"></param>
        /// <param name="importEntity"></param>
        /// <returns></returns>
        private async Task<PriceSchedule> CreatePriceSchedule(Product product, ImportEntity importEntity)
        {
            // PriceSchedule priceSchedule = new PriceSchedule();
            OrderCloudConnect oh = new OrderCloudConnect();
            var priceSchedule = new PriceSchedule
            {
                ID = product.ID,
                Name = $"{_appSettings.OrderCloudSettings.PriceScheduleName}_{product.ID}",
                Currency = ""
            };
            priceSchedule.PriceBreaks.Add(new PriceBreak { Quantity = 1, Price = 0 });
            var token = Task.Run(() => oh.Gettoken());
           
            if (token != null)
            {
                priceSchedule =await importEntity.OcClient.PriceSchedules.CreateAsync(priceSchedule, token.Result.AccessToken);

            }
            return priceSchedule;
        }

        /// <summary>
        /// Create the Products in Order CLoud as Product content change in Content Hub.
        /// </summary>
        /// <param name="importEntity"></param>
        /// <returns></returns>
        private async Task<Product> CreateProduct(ImportEntity importEntity)
        {
            Product product = new Product();
            try
            {
               
                if (importEntity.PropertiesToBeSync != null && importEntity.PropertiesToBeSync.Count > 0)
                {

                    foreach (var propertyKey in importEntity.PropertiesToBeSync)
                    {
                        foreach (PropertyChange propertyChange in importEntity.Message.ChangeSet.PropertyChanges)
                        {
                            if (propertyKey.Key.ToString().ToLower() == propertyChange.Property.ToLower())
                            {
                                var propertyInfo = product.GetType().GetProperty(propertyKey.Value.Trim());
                                if (propertyInfo != null)
                                {
                                    var type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                                    var safeValue = (propertyChange.NewValue == null) ? null : Convert.ChangeType(propertyChange.NewValue, type);
                                    propertyInfo.SetValue(product, safeValue, null);
                                }
                            }
                        }
                    }
                    Inventory Inventory = new Inventory
                    {
                        Enabled = true,
                        VariantLevelTracking = true,
                        QuantityAvailable =_appSettings.OrderCloudSettings.DefaultInventoryQuantity
                    };
                    product.Inventory = Inventory;

                   

                    product.DefaultPriceScheduleID = importEntity.TargetId.ToString();
                    var pr = await _ordercloudService.CreateOrdercloudProduct(importEntity,  product);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return product;
        }


        /// <summary>
        /// Update the Products in Order CLoud as Product content change in Content Hub.
        /// </summary>
        /// <param name="importEntity"></param>
        /// <returns></returns>
        private async Task<ImportEntity> UpdateProduct(ImportEntity importEntity)
        {
            try
            {
                var pro = new PartialProduct();
                if (importEntity.PropertiesToBeSync != null && importEntity.PropertiesToBeSync.Count > 0)
                {

                    foreach (var propertyKey in importEntity.PropertiesToBeSync)
                    {
                        foreach (PropertyChange propertyChange in importEntity.Message.ChangeSet.PropertyChanges)
                        {
                            if (propertyKey.Key.ToString().ToLower() == propertyChange.Property.ToLower())
                            {
                                var propertyInfo = pro.GetType().GetProperty(propertyKey.Value.Trim());
                                if (propertyInfo != null)
                                {
                                    var type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                                    var safeValue = (propertyChange.NewValue == null) ? null : Convert.ChangeType(propertyChange.NewValue, type);
                                    propertyInfo.SetValue(pro, safeValue, null);
                                }
                            }
                        }
                    }
                   var pr =  await _ordercloudService.PatchOrdercloudProduct(importEntity, importEntity.TargetId.ToString(), pro);
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return importEntity;
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="importEntity"></param>
        /// <returns></returns>
        public async Task<ImportEntity> GetAssets(ImportEntity importEntity)
        {
            var assetIds = (await importEntity.Entity.GetRelationAsync<IParentToManyChildrenRelation>
              (ContentHubConstants.EntityToAssetRelationName).ConfigureAwait(false))?.Children;
            
            if (assetIds != null && assetIds.Any())
            {
               
                var assets = await importEntity.WebCHClient.Entities.GetManyAsync(assetIds, EntityLoadConfiguration.Full).ConfigureAwait(false);
                importEntity.Assets = assets;
            }

            return importEntity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="importEntity"></param>
        /// <returns></returns>
        public async Task<ImportEntity> GetAssetsPublicLinks(ImportEntity importEntity)
        {
            if (importEntity.Assets == null || !importEntity.Assets.Any())
            {
                return importEntity;
            }
            var images = await GetImagesAsync(importEntity.Assets).ConfigureAwait(false);
            if (!images.Any())
            {
                return importEntity;
            }
            var linkIdToEntityMappings = await GetPublicLinkRelationIdsAsync(images,ContentHubConstants.AssetToPublicLinkRelationName).ConfigureAwait(false);

            if (linkIdToEntityMappings.Any())
            {
                var linkEntities = await importEntity.WebCHClient.Entities.GetManyAsync(linkIdToEntityMappings.Keys, EntityLoadConfiguration.Full).ConfigureAwait(false);

                importEntity.PublicLinkToImageMappings = linkEntities?.Where(link => link.Id.HasValue)
                    .ToDictionary(link => link, link => linkIdToEntityMappings[link.Id.Value]);
            }

            return importEntity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assets"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        private static async Task<IList<IEntity>> GetImagesAsync(IList<IEntity> assets)
        {
            var images = new List<IEntity>();

            foreach (var asset in assets)
            {
                var filePropsJson = await asset.GetPropertyValueAsync<JToken>(ContentHubConstants.AssetFilePropertiesPropertyName).ConfigureAwait(false);
                var fileProperties = filePropsJson?[ContentHubConstants.FilePropertiesFieldName]?.ToObject<FileProperties>();
                if (fileProperties != null && ( fileProperties.Group.ToLower()==ContentHubConstants.ImagesGroupName ||
                    fileProperties.Group.ToLower()==ContentHubConstants.DocumentsGroupName))
                {
                    images.Add(asset);
                }
            }

            return images;
        }

     

        /// <summary>
        /// 
        /// </summary>
        /// <param name="images"></param>
        /// <param name="assetToPublicLinkRelationName"></param>
        /// <returns></returns>
        private static async Task<IDictionary<long, IEntity>> GetPublicLinkRelationIdsAsync(IEnumerable<IEntity> images,
            string assetToPublicLinkRelationName)
        {
            var ids = new Dictionary<long, IEntity>();

            foreach (var entity in images)
            {
                var relation = await entity.GetRelationAsync<IParentToManyChildrenRelation>(assetToPublicLinkRelationName).ConfigureAwait(false);
                var children = relation?.Children;
                if (children != null && children.Any())
                {
                    foreach (var linkId in children)
                    {
                        ids.Add(linkId, entity);
                    }
                }
            }

            return ids;
        }
        //35890
        public async Task<IEntity> FetchEntity22(ImportEntity importEntity)
        {

            DiagnosticsClient.Logger = new Stylelabs.M.Sdk.Models.Logging.ConsoleLogger
            {
                MinimumLogLevel = Stylelabs.M.Sdk.Contracts.Logging.LogLevel.Debug
            };

            //DiagnosticsClient.HttpLogging = HttpLogging.Full;

            ////   var mClient = _clientFactory.CreateClient(_appSettings);
            //MConnector.Client.TestConnectionAsync().Wait();
            ////var loadConfig = new EntityLoadConfiguration
            ////{
            ////    CultureLoadOption = CultureLoadOption.None,
            ////    RelationLoadOption = new RelationLoadOption("PCMProductToMasterAsset"),
            ////    PropertyLoadOption = PropertyLoadOption.All
            ////};
             
          
           // IEntity entity =await  MConnector.Client.Entities.GetAsync(importEntity.TargetId, EntityLoadConfiguration.Full);
            IEntity entity = await importEntity.WebCHClient.Entities.GetAsync(importEntity.TargetId, EntityLoadConfiguration.Full);
            var ocClient=OrderCloudConnect.Client;

           bool tt= ocClient.IsAuthenticated;
            
            OrderCloudConnect oh = new OrderCloudConnect(_appSettings);
           var token = await oh.Gettoken(); // repsonse also includes ExpiresUtc and RefreshToken.
            var product= await ocClient.Products.GetAsync("35890", token.AccessToken);
            if (product != null)
            {
                var pp = await ocClient.Products.PatchAsync("35890",
                    new PartialProduct { Description = "Plant Based Veg Vitamin D3 Supplement Lichen Source." },token.AccessToken);
            }
           
            // var t=mClient.;
            if (entity == null)
            {
               // var message = $"{ContentHubConstants.ContentHubEntityNotFoundError} : The Entity (id: {entityId}) was not found in Content Hub.";
              //  MConnector.Client.Logger.Debug(message);
            }
           
            return entity;
        }

        public async Task<bool> CreateOrUpdateAssets(ImportEntity importEntity)
        {
           
            List<int> ids = new List<int>();
            foreach (RelationChange relationChange in importEntity.Message.ChangeSet.RelationChanges)
            {
                if(relationChange.Relation.ToLower()==ContentHubConstants.EntityToAssetRelationName.ToLower())
                {
                    ids =  relationChange.NewValues.ToList();
                }
            }
          
            if (!ids.Any())
            {
                var message = $"{ContentHubConstants.ContentHubEntityMappingMismatch}: The Public Link Entity (id: {importEntity.Entity.Id}) " +
                    $"does not have related assets.";
                //_logger.LogError(message,  LogLevel.Error);
            }
            else
            {
                //IList<IEntity> assetsList = new List<IEntity>();
                //assetsList.Add(importEntity.Entity);
                //importEntity.Assets = assetsList;
                var partialProduct = await GetImageForOrderCloudFromContentHub(importEntity);
                var tasks = new List<Task>();
                foreach (var e in ids)
                {
                    tasks.Add(_ordercloudService.PatchOrdercloudProduct(importEntity,e.ToString(), partialProduct));
                }

                await Task.WhenAll(tasks).ConfigureAwait(false);
                List<Product> results = new List<Product>();
              
                foreach (var task in tasks)
                {
                    var result = ((Task<Product>)task).Result;
                    results.Add(result);
                }
            }
            return true;
        }

        private async Task<PartialProduct> GetImageForOrderCloudFromContentHub(ImportEntity importEntity)
        {
            Product product = await _ordercloudService.GetProductAsync("36725");

            List<dynamic> imgList = product?.xp?.Images;
            dynamic img = new ExpandoObject();

           
            img.Id = importEntity.Entity.Id;
            img.FileName = importEntity.Entity.GetPropertyValue<string>("FileName"); 
           
            imgList.Add(img);
           

            IParentToManyChildrenRelation assetRelation = await importEntity.Entity.GetRelationAsync<IParentToManyChildrenRelation>
         (ContentHubConstants.AssetToPublicLinkRelationName);
            List<string> links = new List<string>();

            foreach (long publicLinkId in assetRelation.Children)
            {
                Query q = Query.CreateQuery(entities =>
                  from e in entities
                  where e.Id == publicLinkId
                  select e.LoadConfiguration(QueryLoadConfiguration.Default)
              .WithProperties(PropertyLoadOption.All));

                IEntity entity = importEntity.WebCHClient.Querying.SingleAsync(q).Result;
                var relativeUrl = entity.GetPropertyValue<string>("RelativeUrl"); 
                var versionHash = entity.GetPropertyValue<string>("VersionHash");
                var publicLink = $"api/public/content/{relativeUrl}?v={versionHash}";
                var publicurl= entity.GetPropertyValue<string>("public_link");
                links.Add(publicLink);
                img.ThumbnailUrl = publicurl;
                img.Url = publicurl;
                break;
            }

            PartialProduct partialProduct = new PartialProduct();
            partialProduct.xp = new ExpandoObject(); ;
            partialProduct.xp.Images = new List<dynamic>();
            partialProduct.xp.Images = imgList;

            return partialProduct;
        }

        //private async dynamic GetAssetObject(IEntity assetentity)
        //{
        //    Image img = new Image();
          
        //    var filePropsJson = await assetentity.GetPropertyValueAsync<JToken>(ContentHubConstants.AssetFilePropertiesPropertyName).ConfigureAwait(false);
        //    var fileProperties = filePropsJson?[ContentHubConstants.FilePropertiesFieldName]?.ToObject<FileProperties>();
        //    if (fileProperties != null && (fileProperties.Group.ToLower() == ContentHubConstants.ImagesGroupName ||
        //        fileProperties.Group.ToLower() == ContentHubConstants.DocumentsGroupName))
        //    {
        //        img.FileName = await assetentity.GetPropertyValueAsync<string>("FileName");
        //        img.Id = assetentity.Id.ToString();
        //        img.Title = await assetentity.GetPropertyValueAsync<string>("Title");
        //        img.ThumbnailUrl = await assetentity.GetPropertyValueAsync<string>("FileName");

        //    }
        //}
    }
}
