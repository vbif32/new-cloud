using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Mirea.ProCat.ApplicationServer.Dal;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.ApplicationServer.Dal
{
    public class ProductOfferDao : DataMapperBase
    {
        public ProductOfferDao(NewCloudModel model)
            : base(model)
        {
        }

        public ProductOffer Find(long id)
        {
            return Model.ProductOffer.FirstOrDefault(d => d.ProductOfferId == id);
        }

        public ProductOffer Find(string name)
        {
            return Model.ProductOffer.FirstOrDefault(d => d.Name == name);
        }

        public IEnumerable<ProductOffer> FindByProduct(long id)
        {
            return Model.ProductOffer.Where(d => d.ProductId == id);
        }

        public IEnumerable<ProductOffer> FindByProduct(string name)
        {
            return Model.ProductOffer.Where(d => d.Product.Name == name);
        }

        public IEnumerable<ProductOffer> FindByProvider(long id)
        {
            return Model.ProductOffer.Where(d => d.Product.ServiceProvider.ServiceProviderId == id);
        }

        public IEnumerable<ProductOffer> FindByProvider(string name)
        {
            return Model.ProductOffer.Where(d => d.Product.ServiceProvider.FirmName == name);
        }


        public void Insert(ProductOffer productOffer)
        {
            Model.ProductOffer.Add(productOffer);
        }

        public void Update(ProductOffer productOffer)
        {
            Model.Entry(productOffer).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var item = Model.ProductOffer.FirstOrDefault(d => d.ProductOfferId == id);
            if (item != null)
                Model.ProductOffer.Remove(item);
        }
    }
}