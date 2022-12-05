using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contenthub.Entity.Processing
{
    /// <summary>
    /// Content hub entity message properties
    /// </summary>
    public class ContentHubChangeMessage
    {
        #region Public Properties
        public SaveEntityMessage SaveEntityMessage { get; set; }

        /* Currently unknown type */
        public object Context { get; set; }
        #endregion
    }

    /// <summary>
    /// ChangeSet Class containing properties to hold property and relation changes for an entity 
    /// </summary>
    public class ChangeSet
    {
        /// <summary>
        /// PropertyChanges
        /// </summary>
        [JsonProperty("PropertyChanges")]
        public List<PropertyChange> PropertyChanges { get; set; }

        /// <sumCulturesmary>
        /// 
        /// </summary>
        [JsonProperty("Cultures")]
        public List<string> Cultures { get; set; }

        /// <summary>
        /// RelationChanges
        /// </summary>
        [JsonProperty("RelationChanges")]
        public List<RelationChange> RelationChanges { get; set; }

        /// <summary>
        /// inherits_security_original
        /// </summary>
        [JsonProperty("inherits_security_original")]
        public bool? InheritsSecurityOriginal { get; set; }

        /// <summary>
        /// inherits_security
        /// </summary>
        [JsonProperty("inherits_security")]
        public bool? InheritsSecurity { get; set; }

        /// <summary>
        /// is_root_taxonomy_item_original
        /// </summary>
        [JsonProperty("is_root_taxonomy_item_original")]
        public bool? IsRootTaxonomyItemOriginal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("is_root_taxonomy_item")]
        public bool? IsRootTaxonomyItem { get; set; }

        /// <summary>
        /// is_path_root_original
        /// </summary>
        [JsonProperty("is_path_root_original")]
        public bool? IsPathRootOriginal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("is_path_root")]
        public bool? IsPathRoot { get; set; }

        /// <summary>
        /// is_system_owned_original
        /// </summary>
        [JsonProperty("is_system_owned_original")]
        public bool? IsSystemOwnedOriginal { get; set; }

        /// <summary>
        /// is_system_owned
        /// </summary>
        [JsonProperty("is_system_owned")]
        public bool? IsSystemOwned { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Context
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class RelationChange
    {
        public string Relation { get; set; }
        public int Role { get; set; }
        public int Cardinality { get; set; }
        public List<int> NewValues { get; set; }
        public List<int> RemovedValues { get; set; }

        [JsonProperty("inherits_security_original")]
        public bool? InheritsSecurityOriginal { get; set; }

        [JsonProperty("inherits_security")]
        public bool? InheritsSecurity { get; set; }
    }

    /// <summary>
    /// PropertyChange Properties
    /// </summary>
    public class PropertyChange
    {
        public string Culture { get; set; }
        public string Property { get; set; }
        public string Type { get; set; }
        public string OriginalValue { get; set; }
        public string NewValue { get; set; }
    }

    /// <summary>
    /// SaveEntityMessage Properties
    /// </summary>
    public class SaveEntityMessage
    {
        public string EventType { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsNew { get; set; }
        public string TargetDefinition { get; set; }
        public int TargetId { get; set; }
        public string TargetIdentifier { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
        public int Version { get; set; }
        public ChangeSet ChangeSet { get; set; }
    }
}