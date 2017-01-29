using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NewCloud.ApplicationServer.Entities
{
    public class CatalogEntityStatus
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CatalogEntityStatus()
        {
            AddonOffer = new HashSet<AddonOffer>();
            Product = new HashSet<Product>();
            ProductOffer = new HashSet<ProductOffer>();
            ServiceOffer = new HashSet<ServiceOffer>();
            ServiceProvider = new HashSet<ServiceProvider>();
        }

        [Key]
        public long StatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string Value { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddonOffer> AddonOffer { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOffer> ProductOffer { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOffer> ServiceOffer { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceProvider> ServiceProvider { get; set; }
    }
}