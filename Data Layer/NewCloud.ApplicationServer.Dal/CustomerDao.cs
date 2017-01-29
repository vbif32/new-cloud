using System.Data.Entity;
using System.Linq;
using Mirea.ProCat.ApplicationServer.Dal;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.ApplicationServer.Dal
{
    public class CustomerDao : DataMapperBase
    {
        public CustomerDao(NewCloudModel model)
            : base(model)
        {
        }

        public Customer Find(long id)
        {
            return Model.Customer.FirstOrDefault(d => d.CustomerId == id);
        }

        public Customer Find(string login)
        {
            return Model.Customer.FirstOrDefault(d => d.Login == login);
        }

        public void Insert(Customer customer)
        {
            Model.Customer.Add(customer);
        }

        public void Update(Customer customer)
        {
            Model.Entry(customer).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var item = Model.Customer.FirstOrDefault(d => d.CustomerId == id);
            if (item != null)
                Model.Customer.Remove(item);
        }
    }
}