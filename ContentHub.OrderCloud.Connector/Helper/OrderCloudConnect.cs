using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector.Helper
{
    public class OrderCloudConnect
    {
        private static AppSettings _appSettings;
        public OrderCloudConnect()
        {

            

        }
        public OrderCloudConnect(AppSettings appsetting)
        {

            _appSettings = appsetting;
            
        }
        private static OrderCloudClient _client { get; set; }
        

        public static OrderCloudClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new OrderCloudClient(new OrderCloudClientConfig
                    {
                       
                        ClientId = _appSettings.OrderCloudSettings.ClientId,
                        ApiUrl = _appSettings.OrderCloudSettings.BaseUrl,
                        AuthUrl = _appSettings.OrderCloudSettings.OauthUrl,
                        // client credentials grant flow:
                        ClientSecret = _appSettings.OrderCloudSettings.ClientSecret,
                        Username = _appSettings.OrderCloudSettings.UserName,
                        Password = _appSettings.OrderCloudSettings.Password,


                        Roles = new[] {  ApiRole.BuyerReader,
            ApiRole.CatalogAdmin,
            ApiRole.MeAdmin,
            ApiRole.AdminUserAdmin,
            ApiRole.OrderAdmin,
            ApiRole.PasswordReset,
            ApiRole.PriceScheduleAdmin,
            ApiRole.ProductAdmin,
            ApiRole.ProductAssignmentAdmin,
            ApiRole.ShipmentAdmin }
                    });
                }

                return _client;
            }
        }

        public  async Task<TokenResponse> Gettoken()
        {
            var response = await Client.AuthenticateAsync("A06C9657-25D7-42AE-B510-A89DC45A5343",
            "admin", "Admin@12345", ApiRole.ProductAdmin);

            return response;
        }
    }
}
