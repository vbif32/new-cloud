using System.Data.Entity;
using System.Linq;
using Mirea.ProCat.ApplicationServer.Dal;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.ApplicationServer.Dal
{
    public class ProductDao : DataMapperBase
    {
        public ProductDao(NewCloudModel model)
            : base(model)
        {
        }

        public Product Find(long id)
        {
            return Model.Product.FirstOrDefault(d => d.ProductId == id);
        }

        public Product Find(string name)
        {
            return Model.Product.FirstOrDefault(d => d.Name == name);
        }


        public IQueryable<Product> FindAll(bool readOnly = false)
        {
            if (readOnly)
                return Model.Product.AsNoTracking();
            return Model.Product;
        }

        public IQueryable<Product> FindAllFromProvider(long serviceProviderId)
        {
            return Model.Product.Where(d => d.ServiceProviderId == serviceProviderId);
        }

        public void Insert(Product product)
        {
            Model.Product.Add(product);
        }

        public void Update(Product product)
        {
            Model.Entry(product).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var item = Model.Product.FirstOrDefault(d => d.ProductId == id);
            if (item != null)
                Model.Product.Remove(item);
        }
    }
}