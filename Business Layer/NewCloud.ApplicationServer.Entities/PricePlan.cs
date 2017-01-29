namespace NewCloud.ApplicationServer.Entities
{
    public class PricePlan
    {
        public long PricePlanId { get; set; }

        public int Price { get; set; }

        public long CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }
    }
}