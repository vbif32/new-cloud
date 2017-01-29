namespace NewCloud.ApplicationServer.Entities
{
    public class ServiceInstance
    {
        public long ServiceInstanceId { get; set; }

        public long ProductOfferId { get; set; }

        public long CustomerId { get; set; }

        public virtual ProductOffer ProductOffer { get; set; }

        public virtual Customer Customer { get; set; }
    }
}