using System.Data.Entity;
using System.Linq;
using Mirea.ProCat.ApplicationServer.Dal;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.ApplicationServer.Dal
{
    public class ResourceOfferDao : DataMapperBase
    {
        public ResourceOfferDao(NewCloudModel model)
            : base(model)
        {
        }

        public ResourceOffer Find(long id)
        {
            return Model.ResourceOffer.FirstOrDefault(d => d.ResourceOfferId == id);
        }
        public ResourceOffer Find(string name)
        {
            return Model.ResourceOffer.FirstOrDefault(d => d.Name == name);
        }

        public void Insert(ResourceOffer resourceOffer)
        {
            Model.ResourceOffer.Add(resourceOffer);
        }

        public void Update(ResourceOffer resourceOffer)
        {
            Model.Entry(resourceOffer).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var item = Model.ResourceOffer.FirstOrDefault(d => d.ResourceOfferId == id);
            if (item != null)
                Model.ResourceOffer.Remove(item);
        }
    }
}