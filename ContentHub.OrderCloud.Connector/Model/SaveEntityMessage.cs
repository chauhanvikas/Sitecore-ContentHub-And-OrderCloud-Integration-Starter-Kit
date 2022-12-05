

using System;
using System.Collections.Generic;

namespace ContentHub.OrderCloud.Connector.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ChangeSet
    {
        public List<PropertyChange> PropertyChanges { get; set; }
        public List<string> Cultures { get; set; }
        public List<object> RelationChanges { get; set; }
        public bool inherits_security_original { get; set; }
        public bool inherits_security { get; set; }
        public bool is_root_taxonomy_item_original { get; set; }
        public bool is_root_taxonomy_item { get; set; }
        public bool is_path_root_original { get; set; }
        public bool is_path_root { get; set; }
        public bool is_system_owned_original { get; set; }
        public bool is_system_owned { get; set; }
    }

    public class Context
    {
    }

    public class PropertyChange
    {
        public string Culture { get; set; }
        public string Property { get; set; }
        public string Type { get; set; }
        public string OriginalValue { get; set; }
        public string NewValue { get; set; }
    }

    public class Root
    {
      public SaveEntityMessageazure saveEntityMessage { get; set; }
        public Context context { get; set; }
    }

    //public class SaveEntityMessage
    //{
    //    public string EventType { get; set; }
    //    public DateTime TimeStamp { get; set; }
    //    public bool IsNew { get; set; }
    //    public string TargetDefinition { get; set; }
    //    public int TargetId { get; set; }
    //    public string TargetIdentifier { get; set; }
    //    public DateTime CreatedOn { get; set; }
    //    public int UserId { get; set; }
    //    public int Version { get; set; }
    //    public ChangeSet ChangeSet { get; set; }
    //}




}