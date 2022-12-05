using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector
{
    public class AppSettings
    {
        public ContentHubSettings ContentHubSettings { get; set; } = new ContentHubSettings();
        public OrderCloudSettings OrderCloudSettings { get; set; } = new OrderCloudSettings();
    }

    public  class ContentHubSettings
    {
        public string ApiUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class OrderCloudSettings
    {


        public string BaseUrl { get; set; } = "https://sandboxapi.ordercloud.io/v1/";
        public string OauthUrl { get; set; } = "https://sandboxapi.ordercloud.io/oauth/token";
        public string ClientId { get; set; } 
        public string ClientSecret { get; set; } 
        public string AccessToken { get; set; }
        public int DefaultInventoryQuantity { get; set; } = 1000;
        public string DefaultCatalogId { get; set; }
        public string DefaultBuyerId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PriceScheduleName { get; set; }
        

    }
}
