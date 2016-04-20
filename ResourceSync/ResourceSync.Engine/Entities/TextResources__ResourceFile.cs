using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ResourceSync.Engine.Entities
{
    public class TextResources__ResourceFile
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TextResources__ResourceFile()
        {
            TextResources__ResourceKey = new HashSet<TextResources__ResourceKey>();
        }

        public int ID { get; set; }

        public Guid ResourceFileID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public DateTime? Deleted { get; set; }

        public int? TextResourcesEnvironment_TextResourcesEnvironmentID { get; set; }

        public bool IsFilledManualy { get; set; }

        public virtual TextResources__Environment TextResources__Environment { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TextResources__ResourceKey> TextResources__ResourceKey { get; set; }
    }
}