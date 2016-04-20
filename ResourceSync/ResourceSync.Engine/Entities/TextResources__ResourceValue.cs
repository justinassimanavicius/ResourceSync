using System;
using System.ComponentModel.DataAnnotations;

namespace ResourceSync.Engine.Entities
{
    public class TextResources__ResourceValue
    {
        public virtual TextResources__ResourceKey TextResources__ResourceKey { get; set; }

        [Key]
        public int ResourceValueID { get; set; }

        [Required]
        public string Value { get; set; }

        public DateTime LastModified { get; set; }

        public int? ResourceKey_ID { get; set; }

        public int? Language_LanguageID { get; set; }

        public virtual TextResources__Language TextResources__Language { get; set; }
        
    }
}