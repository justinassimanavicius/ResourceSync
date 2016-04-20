using System;
using System.ComponentModel.DataAnnotations;
using ResourceSync.Engine.Entities;

namespace ResourceSync.Engine.Dto
{
    public class ResourceValue
    {
        public int ResourceValueID { get; set; }

        public string Value { get; set; }

        public DateTime LastModified { get; set; }

        public int? ResourceKey_ID { get; set; }

        public int? Language_LanguageID { get; set; }
    }
}