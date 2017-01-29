using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NewCloud.ApplicationServer.Entities
{
    public class ResourceOffer
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ResourceOffer()
        {
            AddonOffer = new HashSet<AddonOffer>();
            ServiceOffer = new HashSet<ServiceOffer>();
        }

        public long ResourceOfferId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Version { get; set; }

        public int GracePeriodDays { get; set; }

        public long StatusId { get; set; }

        public long PricePlanId { get; set; }

        public virtual CatalogEntityStatus CatalogEntityStatus { get; set; }

        public virtual PricePlan PricePlan { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddonOffer> AddonOffer { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOffer> ServiceOffer { get; set; }
    }
}