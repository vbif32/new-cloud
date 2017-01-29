using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NewCloud.ApplicationServer.Entities
{
    public class Product
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductOffer = new HashSet<ProductOffer>();
        }

        public long ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Version { get; set; }

        public long StatusId { get; set; }

        public long ServiceProviderId { get; set; }

        public virtual CatalogEntityStatus CatalogEntityStatus { get; set; }

        public virtual ServiceProvider ServiceProvider { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOffer> ProductOffer { get; set; }
    }
}