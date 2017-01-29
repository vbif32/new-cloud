using NewCloud.ApplicationServer.Entities;

namespace NewCloud.ApplicationServer.Dal
{
    public class DaoRegistry
    {
        private AddonOfferDao _addonOfferDao;

        private CatalogEntityStatusDao _catalogEntityStatusDao;

        private CurrencyDao _currencyDao;

        private CustomerDao _customerDao;

        private PricePlanDao _pricePlanDao;

        private ProductDao _productDao;

        private ProductOfferDao _productOfferDao;

        private ResourceOfferDao _resourceOfferDao;

        private ServiceInstanceDao _serviceInstanceDao;

        private ServiceOfferDao _serviceOfferDao;

        private ServiceProviderDao _serviceProviderDao;

        public DaoRegistry(NewCloudModel model)
        {
            Model = model;
        }

        public NewCloudModel Model { get; }
        public AddonOfferDao AddonOfferDao => _addonOfferDao ?? (_addonOfferDao = new AddonOfferDao(Model));

        public CatalogEntityStatusDao CatalogEntityStatusDao
            => _catalogEntityStatusDao ?? (_catalogEntityStatusDao = new CatalogEntityStatusDao(Model));

        public CurrencyDao CurrencyDao => _currencyDao ?? (_currencyDao = new CurrencyDao(Model));
        public CustomerDao CustomerDao => _customerDao ?? (_customerDao = new CustomerDao(Model));

        public PricePlanDao PricePlanDao
            => _pricePlanDao ?? (_pricePlanDao = new PricePlanDao(Model));

        public ProductDao ProductDao => _productDao ?? (_productDao = new ProductDao(Model));
        public ProductOfferDao ProductOfferDao => _productOfferDao ?? (_productOfferDao = new ProductOfferDao(Model));

        public ResourceOfferDao ResourceOfferDao
            => _resourceOfferDao ?? (_resourceOfferDao = new ResourceOfferDao(Model));

        public ServiceInstanceDao ServiceInstanceDao
            => _serviceInstanceDao ?? (_serviceInstanceDao = new ServiceInstanceDao(Model));

        public ServiceOfferDao ServiceOfferDao => _serviceOfferDao ?? (_serviceOfferDao = new ServiceOfferDao(Model));

        public ServiceProviderDao ServiceProviderDao
            => _serviceProviderDao ?? (_serviceProviderDao = new ServiceProviderDao(Model));
    }
}