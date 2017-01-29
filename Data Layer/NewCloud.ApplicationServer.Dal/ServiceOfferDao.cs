using System.Data.Entity;
using System.Linq;
using Mirea.ProCat.ApplicationServer.Dal;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.ApplicationServer.Dal
{
    public class ServiceOfferDao : DataMapperBase
    {
        public ServiceOfferDao(NewCloudModel model)
            : base(model)
        {
        }

        public ServiceOffer Find(long id)
        {
            return Model.ServiceOffer.FirstOrDefault(d => d.ServiceOfferId == id);
        }

        public ServiceOffer Find(string name)
        {
            return Model.ServiceOffer.FirstOrDefault(d => d.Name == name);
        }

        public void Insert(ServiceOffer serviceOffer)
        {
            Model.ServiceOffer.Add(serviceOffer);
        }

        public void Update(ServiceOffer serviceOffer)
        {
            Model.Entry(serviceOffer).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var item = Model.ServiceOffer.FirstOrDefault(d => d.ServiceOfferId == id);
            if (item != null)
                Model.ServiceOffer.Remove(item);
        }
    }
}