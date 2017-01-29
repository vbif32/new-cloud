using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NewCloud.ApplicationServer.Entities
{
    public class ProductOffer
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductOffer()
        {
            ServiceInstance = new HashSet<ServiceInstance>();
        }

        public long ProductOfferId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsTrial { get; set; }

        public DateTime StartRangeValue { get; set; }

        public DateTime EndRangeValue { get; set; }

        public int Version { get; set; }

        public long ProductId { get; set; }

        public long StatusId { get; set; }

        public long ServiceOfferId { get; set; }

        public long AddonOfferId { get; set; }
        
        public virtual CatalogEntityStatus CatalogEntityStatus { get; set; }

        public virtual Product Product { get; set; }

        public virtual ServiceOffer ServiceOffer { get; set; }

        public virtual AddonOffer AddonOffer { get; set; }
        
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceInstance> ServiceInstance { get; set; }
    }
}