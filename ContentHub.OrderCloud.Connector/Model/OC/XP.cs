using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentHub.OrderCloud.Connector.Model.OC
{
    public class XP
    {

        // DO NOT DELETE
        public Dictionary<string, List<string>> Facets { get; set; } = new Dictionary<string, List<string>>();

        
        public string Note { get; set; }

        public TaxCategorization Tax { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; } = new UnitOfMeasure();

        public ProductType ProductType { get; set; }

        public SizeTier SizeTier { get; set; }

      
        public CurrencyCode? Currency { get; set; } = null;

        public bool FreeShipping { get; set; }

        public string FreeShippingMessage { get; set; }

        public List<Image> Images { get; set; }

        public List<Document> Documents { get; set; }

        public List<string> RelatedProductIDs { get; set; }

        public List<string> BundledProducts { get; set; }
    }
    /// <summary>
    /// Product Images
    /// </summary>
    public class Image
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Url { get; set; }
        public string Tags { get; set; }
    }

    /// <summary>
    /// A Tax categorization for a product.
    /// </summary>
    public class TaxCategorization
    {
        /// <summary>
        /// A code that represents this categorization.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// A reasonable short name for this categorization.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A full description for this categorization.
        /// </summary>
        public string LongDescription { get; set; }
    }

    /// <summary>
    /// Product Images
    /// </summary>
    public class Document
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Tags { get; set; }
    }
    /// <summary>
    /// Tax Section
    /// </summary>
    public class Tax
    {
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Code { get; set; }
    }

    /// <summary>
    /// Product Inventory section
    /// </summary>
    public class Inventory
    {
        public bool Enabled { get; set; }
        public bool OrderCanExceed { get; set; }
        public int QuantityAvailable { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UnitOfMeasure
    {
        public int Qty { get; set; }
        public string Unit { get; set; }
    }

    /// <summary>
    /// Product Facets
    /// </summary>
    public class Facets
    {
        /// <summary>
        /// Constructor to initialize class instance
        /// </summary>
        public Facets()
        {
            brand = new List<string>();
            family = new List<string>();
        }
        public List<string> brand { get; set; }
        public List<string> family { get; set; }
        //public List<string> Region { get; set; }
        //public List<string> Supplier { get; set; }
    }

    public enum ProductType
    {
        Standard,
        Quote,
        Bundle,
    }
    public enum SizeTier
    {
        // ships alone
        G,

        // 2-5
        A,

        // 5-15
        B,

        // 15-49
        C,

        // 50-99
        D,

        // 100-999
        E,

        // 1000+
        F,
    }
    public enum CurrencyCode
    {
        CAD,
        HKD,
        ISK,
        PHP,
        DKK,
        HUF,
        CZK,
        GBP,
        RON,
        SEK,
        IDR,
        INR,
        BRL,
        RUB,
        HRK,
        JPY,
        THB,
        CHF,
        EUR,
        MYR,
        BGN,
        TRY,
        CNY,
        NOK,
        NZD,
        ZAR,
        USD,
        MXN,
        SGD,
        AUD,
        ILS,
        KRW,
        PLN,
    }
}
