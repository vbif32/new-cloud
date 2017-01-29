using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NewCloud.ApplicationServer.Entities
{
    public partial class NewCloudModel : DbContext
    {
        static NewCloudModel()
        {
            Database.SetInitializer(new SampleInitializer());
        }

        public NewCloudModel()
            : base("name=ACERV3_NewCloudConnection")
        {
        }

        public virtual DbSet<AddonOffer> AddonOffer { get; set; }
        public virtual DbSet<CatalogEntityStatus> CatalogEntityStatus { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<PricePlan> PricePlanSpec { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductOffer> ProductOffer { get; set; }
        public virtual DbSet<ResourceOffer> ResourceOffer { get; set; }
        public virtual DbSet<ServiceInstance> ServiceInstance { get; set; }
        public virtual DbSet<ServiceOffer> ServiceOffer { get; set; }
        public virtual DbSet<ServiceProvider> ServiceProvider { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<CatalogEntityStatus>()
                .HasMany(e => e.AddonOffer)
                .WithRequired(e => e.CatalogEntityStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CatalogEntityStatus>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.CatalogEntityStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CatalogEntityStatus>()
                .HasMany(e => e.ServiceOffer)
                .WithRequired(e => e.CatalogEntityStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CatalogEntityStatus>()
                .HasMany(e => e.ServiceProvider)
                .WithRequired(e => e.CatalogEntityStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.PricePlanSpec)
                .WithRequired(e => e.Currency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductOffer)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductOffer>()
                .HasMany(e => e.ServiceInstance)
                .WithRequired(e => e.ProductOffer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ResourceOffer>()
                .HasMany(e => e.AddonOffer)
                .WithRequired(e => e.ResourceOffer)
                .WillCascadeOnDelete(false);
            ;

            modelBuilder.Entity<ResourceOffer>()
                .HasMany(e => e.ServiceOffer)
                .WithRequired(e => e.ResourceOffer)
                .WillCascadeOnDelete(false);
            ;

            modelBuilder.Entity<ServiceProvider>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.ServiceProvider)
                .WillCascadeOnDelete(false);
        }
    }
}