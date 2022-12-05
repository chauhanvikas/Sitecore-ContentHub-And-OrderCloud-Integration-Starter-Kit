using ContentHub.OrderCloud.Connector.Model;
using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector.Services
{
    public interface IOrdercloudService
    {
        public Task<Product> PatchOrdercloudProduct(ImportEntity importEntity, string id,PartialProduct pro);
        public Task<Product> CreateOrdercloudProduct(ImportEntity importEntity, Product pro);
        public  Task<Product> GetProductAsync(string productId);
        public Task<Product> UpdateProductAssets(ImportEntity importEntity,string productId,PartialProduct pro);

    }
}
