using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ResourceSync.Engine.Entities
{
    public class TextResources__Environment
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TextResources__Environment()
        {
            TextResources__ResourceFile = new HashSet<TextResources__ResourceFile>();
            TextResources__ResourceKey = new HashSet<TextResources__ResourceKey>();
        }

        [Key]
        public int TextResourcesEnvironmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsLocal { get; set; }

        public DateTime LastResourceChangeDate { get; set; }

        [StringLength(1024)]
        public string EnvironmentWebServiceUrl { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TextResources__ResourceFile> TextResources__ResourceFile { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TextResources__ResourceKey> TextResources__ResourceKey { get; set; }
    }
}