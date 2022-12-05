using ContentHub.OrderCloud.Connector.Helper;
using ContentHub.OrderCloud.Connector.Model;
using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector.Services
{
    public class OrdercloudService : IOrdercloudService
    {
        /// <summary>
        /// Patch the Order cloud Product
        /// </summary>
        /// <param name="importEntity"></param>
        /// <param name="pro"></param>
        /// <returns></returns>
        public async Task<Product> CreateOrdercloudProduct(ImportEntity importEntity, Product pro)
        {
            OrderCloudConnect oh = new OrderCloudConnect();
            Product pr = null;
            bool issucces = false;
            try
            {
                var token = Task.Run(() => oh.Gettoken()); // repsonse also includes ExpiresUtc and RefreshToken.
               
                if (token != null)
                {
                    pr = await importEntity.OcClient.Products.CreateAsync(pro, token.Result.AccessToken);


                }
            }
            catch (Exception ex) { throw ex; }

            return pr;
        }

        /// <summary>
        /// Patch the Order cloud Product
        /// </summary>
        /// <param name="importEntity"></param>
        /// <param name="pro"></param>
        /// <returns></returns>
        public async Task<Product> PatchOrdercloudProduct(ImportEntity importEntity,string id, PartialProduct pro)
        {
            OrderCloudConnect oh = new OrderCloudConnect();
            Product pr = null;
            bool issucces = false;
            try
            {
                var token = Task.Run(() => oh.Gettoken()); // repsonse also includes ExpiresUtc and RefreshToken.
                var product = importEntity.OcClient.Products.GetAsync(id, token.Result.AccessToken);
                if (product != null)
                {
                     pr = await importEntity.OcClient.Products.PatchAsync(id,
                      pro, token.Result.AccessToken);

                    
                }
            }
            catch (Exception ex) { throw ex; }

            return pr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>

        public async Task<Product> GetProductAsync(string productId)
        {
            Product pro = null;
            try
            {
                var ocClient = OrderCloudConnect.Client;
               
                bool tt = ocClient.IsAuthenticated;

                OrderCloudConnect oh = new OrderCloudConnect();
                var token = await oh.Gettoken(); // repsonse also includes ExpiresUtc and RefreshToken.
                pro = await ocClient.Products.GetAsync(productId, token.AccessToken);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return pro;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="importEntity"></param>
        /// <param name="productId"></param>
        /// <param name="pro"></param>
        /// <returns></returns>
       public async Task<Product> UpdateProductAssets(ImportEntity importEntity, string productId, PartialProduct pro)
        {
            OrderCloudConnect oh = new OrderCloudConnect();
            Product product = null;
            try
            {
                var token = Task.Run(() => oh.Gettoken()); // repsonse also includes ExpiresUtc and RefreshToken.

                product = await importEntity.OcClient.Products.PatchAsync(productId,
                  pro, token.Result.AccessToken);

               

            }
            catch (Exception ex) { throw ex; }

            return product;
        }
    }
}
