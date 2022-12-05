# Overview
The Sitecore Content hub and Order Cloud are integrated using this starter kit. This starter kit's objectives include syncing Products with all of their associated assets to Order Cloud. The author of the content hub will use PCM modules to manage the products and map the necessary assets to products. 
Once published, it will use the is starting kit to sync to Order cloud.

# Following are some already available functions.
- Sync product at the time of Creation.
- Product update with related assets.

# To-do
- Deleted products sync
- Deleted assets sync
- Product Category sync

# Components Involved in Integration
- Content Hub
- Order Cloud
- Azure Bus (Queue)
- Azure Function
- .Net Core API

# Integartion Flow
![image](https://user-images.githubusercontent.com/10286938/205552912-6b535a16-ff66-4e4e-8f27-62d53e2ea8b2.png)
# Azure Service Bus 
 The message was sent to the service bus by the content hub, which then queued it up as a message in the Azure service bus.Please follow the following links to   configure the Azure Bus.
 https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-quickstart-portal 
https://docs.stylelabs.com/contenthub/4.2.x/content/integrations/integration-components/actions/action-type-azure-service-bus.html

# Azure Function 
Azure Functions are a subset of Azure Service Bus Triggers, and its primary function is to listen for queue events and activate 
the Product Synchronization API to sync products. **"Contenthub.Entity.Processing"** project is implemented for Azure function. Setup the ** connectionstring** in **local.setting.json** file and **URI" property with the Web API end point in function1 class line no #73  of Azure function project.
Please refer to this link for deployment of Azure function  https://learn.microsoft.com/en-us/azure/azure-functions/functions-deployment-technologies
# Web API : 
The Product Sync API is a.NET Core Web API that contains all the logic necessary to extract product entity data from the Content Hub and sync it with the Order cloud. This API connects the system and all necessary operations between the Content Hub and Order cloud SDK.
# Setup
  - **Content Hub API** : Refer to this link for creating a user in Content hub and apply **M.Builtin.ContentAdministrators** role - https://docs.stylelabs.com/en-us/contenthub/3.3.x/content/user-documentation/administration/security/users/account-management/manage-users-manually.html 
  https://docs.stylelabs.com/contenthub/3.4.x/content/integrations/web-sdk/authentication.html 
 - **Content Hub Action** : Refer to this link to configure the Action
  https://doc.sitecore.com/xp/en/developers/100/sitecore-experience-commerce/walkthrough--configuring-the-sitecore-content-hub-to-sitecore-commerce-connector.html
 
 - **Content Hub Trigger** : Refer to this link to configure the Trigger
 https://doc.sitecore.com/xp/en/developers/100/sitecore-experience-commerce/walkthrough--configuring-the-sitecore-content-hub-to-sitecore-commerce-connector.html
 
 - **Web API Project Setup** :  Please set the below settings to connect the Conetent hub and Order cloud in **appsettings.json file**.
 ![image](https://user-images.githubusercontent.com/10286938/205563833-63db7ffc-6acc-45f8-9db9-ca385f8ac08f.png)

 - **Product fields Mapping** : Maps Content Hub products fields to target fields of Order Cloud fields in **appsettings.json** file which needs to be synced
 
 ![image](https://user-images.githubusercontent.com/10286938/205587712-edaf7260-e4bc-4a34-8315-39fc19018401.png)

