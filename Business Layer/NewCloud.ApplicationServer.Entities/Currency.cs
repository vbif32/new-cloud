using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NewCloud.ApplicationServer.Entities
{
    public class Currency
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Currency()
        {
            PricePlanSpec = new HashSet<PricePlan>();
        }

        public long CurrencyId { get; set; }

        [Required]
        [StringLength(50)]
        public string Value { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PricePlan> PricePlanSpec { get; set; }
    }
}