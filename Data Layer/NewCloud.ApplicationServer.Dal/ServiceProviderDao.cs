using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Mirea.ProCat.ApplicationServer.Dal;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.ApplicationServer.Dal
{
    public class ServiceProviderDao : DataMapperBase
    {
        public ServiceProviderDao(NewCloudModel model)
            : base(model)
        {
        }

        public ServiceProvider Find(long id)
        {
            return Model.ServiceProvider.FirstOrDefault(d => d.ServiceProviderId == id);
        }

        public ServiceProvider Find(string login)
        {
            return Model.ServiceProvider.FirstOrDefault(d => d.Login == login);
        }

        public IEnumerable<Product> FindAllProducts(long id)
        {
            return Model.Product.Where(d => d.ServiceProvider.ServiceProviderId == id);
        }

        public IEnumerable<Product> FindAllProducts(string firmName)
        {
            return Model.Product.Where(d => d.ServiceProvider.FirmName == firmName);
        }

        public void Insert(ServiceProvider serviceProvider)
        {
            Model.ServiceProvider.Add(serviceProvider);
        }

        public void Update(ServiceProvider serviceProvider)
        {
            Model.Entry(serviceProvider).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var item = Model.ServiceProvider.FirstOrDefault(d => d.ServiceProviderId == id);
            if (item != null)
                Model.ServiceProvider.Remove(item);
        }
    }
}