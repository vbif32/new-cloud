using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NewCloud.ApplicationServer.Entities
{
    public class ServiceOffer
    {
        public long ServiceOfferId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Version { get; set; }

        public long ResourceOfferId { get; set; }

        public long StatusId { get; set; }

        public virtual CatalogEntityStatus CatalogEntityStatus { get; set; }

        public virtual ResourceOffer ResourceOffer { get; set; }
    }
}