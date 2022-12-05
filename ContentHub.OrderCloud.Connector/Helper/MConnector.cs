using Stylelabs.M.Sdk.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector.Helper
{
    public  class MConnector
    {

        private static  AppSettings _appSettings;
        public MConnector(AppSettings appsetting)
        {
           
            _appSettings = appsetting;
           ;
        }
        private static Lazy<IWebMClient> _client { get; set; }

        public static IWebMClient Client
        {
            get
            {
                if (_client == null)
                {
                    var auth = new Stylelabs.M.Sdk.WebClient.Authentication.OAuthPasswordGrant()
                    {
                      

                        ClientId = _appSettings.ContentHubSettings.ClientId,
                        ClientSecret = _appSettings.ContentHubSettings.ClientSecret,
                        UserName = _appSettings.ContentHubSettings.UserName,
                        Password =_appSettings.ContentHubSettings.Password

                    };
                    _client = new Lazy<IWebMClient>(() => MClientFactory.CreateMClient(new Uri(_appSettings.ContentHubSettings.ApiUrl), auth));
                }

                return _client.Value;
            }
        }
    }
}