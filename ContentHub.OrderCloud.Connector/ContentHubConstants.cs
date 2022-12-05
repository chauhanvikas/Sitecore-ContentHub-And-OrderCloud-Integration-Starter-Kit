using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector
{
    public static class ContentHubConstants
    {
        public const string SETTINGS_CATEGORY_ORDERCLOUD = "OrderCloud";
        public const string SETTINGS_CONFIGURATION_ORDERCLOUD = "OrderCloudConfiguration";
        public const string SETTINGS_CONFIGURATION_PROPERTIESMAPPING = "ProductPropertiesMapping";
        public const string EntityToAssetRelationName = "PCMProductToAsset";
        public const string AssetToPublicLinkRelationName = "AssetToPublicLink";

        
        /// <summary>
        /// Public Link Relative URL
        /// </summary>
        public const string PublicLinkRelativeUrl = "RelativeUrl";

        /// <summary>
        /// Public Link Version Hash
        /// </summary>
        public const string PublicLinkVersionHash = "VersionHash";

        /// <summary>
        /// Name of the status for completed Public link
        /// </summary>
        public const string PublicLinkCompletedStatusName = "Completed";

        /// <summary>
        /// Content Hub Version Property Name
        /// </summary>
        public const string ContentHubEntityVersionProperty = "Version";

        /// <summary>
        /// Name of the Status property of a Content Hub public link <see cref="IEntity"/>.
        /// </summary>
        public const string PublicLinkStatusPropertyName = "Status";

        /// <summary>
        /// Name of the FileKey property of a Content Hub public link <see cref="IEntity"/>.
        /// </summary>
        public const string PublicLinkFileKeyPropertyName = "FileKey";

        /// <summary>
        /// Name of the ConversionConfiguration property of a Content Hub public link <see cref="IEntity"/>.
        /// </summary>
        public const string PublicLinkConversionConfigurationPropertyName = "ConversionConfiguration";

        /// <summary>
        /// Name of the FileProperties property of a Content Hub asset <see cref="IEntity"/>.
        /// </summary>
        public const string AssetFilePropertiesPropertyName = "FileProperties";

        /// <summary>
        /// Name of the Renditions property of a Content Hub asset <see cref="IEntity"/>.
        /// </summary>
        public const string AssetRenditionsPropertyName = "Renditions";

        /// <summary>
        /// Name of the DownloadOriginal Content Hub <see cref="IRendition"/>.
        /// </summary>
        public const string DownloadOriginalRenditionName = "downloadOriginal";

        /// <summary>
        /// Name of the Width property of a Content Hub <see cref="IRendition"/>.
        /// </summary>
        public const string RenditionWidthPropertyName = "width";

        /// <summary>
        /// Name of the Height property of a Content Hub <see cref="IRendition"/>.
        /// </summary>
        public const string RenditionHeightPropertyName = "height";

        /// <summary>
        /// Name of the Properties field in Json for <see cref="FileProperties"/>.
        /// </summary>
        public const string FilePropertiesFieldName = "properties";

        /// <summary>
        /// Name of the images group provided in <see cref="FileProperties.Group"/>.
        /// </summary>
        public const string ImagesGroupName = "images";
        /// <summary>
        /// Name of the Documents group provided in <see cref="FileProperties.Group"/>.
        /// </summary>
        public const string DocumentsGroupName = "Documents";
        
        /// <summary>
        /// The default display name for the Sitecore DAM Assets <see cref="EntityView"/>.
        /// </summary>
        public const string ImagesEntityViewDisplayName = "Sitecore DAM Assets";

        /// <summary>
        /// The view name for the Sitecore DAM Assets <see cref="EntityView"/>.
        /// </summary>
        public const string ImagesEntityViewName = "SitecoreDAMAssets";

        /// <summary>
        /// The <see cref="ViewProperty"/> name for the image's public link.
        /// </summary>
        public const string ImagesEntityViewPublicLinkViewPropertyName = "Public link";

        /// <summary>
        /// The <see cref="ViewProperty"/> name for the image's alternate text.
        /// </summary>
        public const string ImagesEntityViewAlternateTextViewPropertyName = "Alternate Text";

        /// <summary>
        /// The <see cref="ViewProperty"/> name for the image.
        /// </summary>
        public const string ImagesEntityViewImageViewPropertyName = "Image";

        /// <summary>
        /// The <see cref="ViewProperty"/> name for the image width.
        /// </summary>
        public const string ImagesEntityViewWidthViewPropertyName = "Width";

        /// <summary>
        /// The <see cref="ViewProperty"/> name for the image height.
        /// </summary>
        public const string ImagesEntityViewHeightViewPropertyName = "Height";

        /// <summary>
        /// The <see cref="ViewProperty"/> name for the IsMasterFile property.
        /// </summary>
        public const string ImagesEntityViewIsMasterFileViewPropertyName = "IsMasterFile";

        /// <summary>
        /// The raw value string format of the image to be rendered.
        /// </summary>
        public const string ImageViewPropertyRawValueStringFormat = "<img alt='{0}' height={1} width={2} src='{3}'/>";

        /// <summary>
        /// The <see cref="ViewProperty"/> name for the image's public link that is to be rendered.
        /// </summary>
        public const string PublicLinkViewPropertyRawValueStringFormat = "<a href='{0}' target='_blank'>{0}<a/>";

        /// <summary>
        /// Defines the HTML <see cref="ViewProperty"/> UI type.
        /// </summary>
        public const string EntityViewPropertyUITypeHtml = "Html";

        /// <summary>
        /// Defines the default language token content hub uses to represent as the culture
        /// for non-localizable properties.
        /// </summary>
        public const string DefaultLanguageToken = "(Default)";

        /// <summary>
        /// The value to log messages when a entity not found error occur.
        /// </summary>
        public const string ContentHubEntityNotFoundError = "ContentHubEntityNotFoundError";

        /// <summary>
        /// The value to log messages when a mismatch error occur.
        /// </summary>
        public const string ContentHubEntityMappingMismatch = "ContentHubEntityMappingMismatch";

        /// <summary>
        /// The value to log messages when missing or invalid id error occur.
        /// </summary>
        public const string ContentHubProductIdMissingOrInvalid = "ContentHubProductIdMissingOrInvalid";

        /// <summary>
        /// The value to log messages when missing <see cref="SellableItem"/> error occur.
        /// </summary>
        public const string ContentHubSellableItemMissing = "ContentHubSellableItemMissing";

        /// <summary>
        /// Defines the <see cref="PipelineBlock"/> prefix for Content Hub blocks.
        /// </summary>
        private const string BlockPrefix = "ContentHub.block.";

        /// <summary>
        /// Defines the <see cref="IPipeline"/> prefix for Content Hub pipelines.
        /// </summary>
        private const string PipelinePrefix = "ContentHub.pipeline.";

       
          
       
    }
}
