using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ResourceSync.Engine.Entities
{
    public class TextResources__ResourceKey
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TextResources__ResourceKey()
        {
            TextResources__ResourceValue = new HashSet<TextResources__ResourceValue>();
        }

        public int ID { get; set; }

        public Guid ResourceKeyID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Comment { get; set; }

        public bool PlainText { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public DateTime? Deleted { get; set; }

        public int? TextResourcesEnvironment_TextResourcesEnvironmentID { get; set; }

        public int? ResourceFile_ID { get; set; }

        public virtual TextResources__Environment TextResources__Environment { get; set; }

        public virtual TextResources__ResourceFile TextResources__ResourceFile { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TextResources__ResourceValue> TextResources__ResourceValue { get; set; }
    }
}