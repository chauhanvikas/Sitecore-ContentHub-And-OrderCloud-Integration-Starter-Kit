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
 The message was sent to the service bus by the content hub, which then queued it up as a message in the Azure service bus.
# Azure Function 
Azure Functions are a subset of Azure Service Bus Triggers, and its primary function is to listen for queue events and activate 
the Product Synchronization API to sync products. "Contenthub.Entity.Processing" project is implemented for Azure function.
# Web API : 
The Product Sync API is a.NET Core Web API that contains all the logic necessary to extract product entity data from the Content Hub and sync it with the Order cloud. This API connects the system and all necessary operations between the Content Hub and Order cloud SDK.
# Setup
