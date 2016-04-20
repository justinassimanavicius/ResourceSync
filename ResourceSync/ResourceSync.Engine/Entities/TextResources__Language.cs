using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ResourceSync.Engine.Entities
{
    public class TextResources__Language
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TextResources__Language()
        {
            TextResources__ResourceValue = new HashSet<TextResources__ResourceValue>();
        }

        [Key]
        public int LanguageID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Culture { get; set; }

        public bool IsDefault { get; set; }

        public bool IsVisibleInUI { get; set; }

        public bool IsVisibleInAdmin { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TextResources__ResourceValue> TextResources__ResourceValue { get; set; }
    }
}