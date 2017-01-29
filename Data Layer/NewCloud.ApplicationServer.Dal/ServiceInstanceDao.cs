using System.Data.Entity;
using System.Linq;
using Mirea.ProCat.ApplicationServer.Dal;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.ApplicationServer.Dal
{
    public class ServiceInstanceDao : DataMapperBase
    {
        public ServiceInstanceDao(NewCloudModel model)
            : base(model)
        {
        }

        public ServiceInstance Find(long id)
        {
            return Model.ServiceInstance.FirstOrDefault(d => d.ServiceInstanceId == id);
        }

        public IQueryable<ServiceInstance> FindAllByCustomer(long customerId)
        {
            return Model.ServiceInstance.Where(d => d.CustomerId == customerId);
        }

        public void Insert(ServiceInstance serviceInstance)
        {
            Model.ServiceInstance.Add(serviceInstance);
        }

        public void Update(ServiceInstance serviceInstance)
        {
            Model.Entry(serviceInstance).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var item = Model.ServiceInstance.FirstOrDefault(d => d.ServiceInstanceId == id);
            if (item != null)
                Model.ServiceInstance.Remove(item);
        }
    }
}