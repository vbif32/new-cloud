using System.Data.Entity;
using System.Linq;
using Mirea.ProCat.ApplicationServer.Dal;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.ApplicationServer.Dal
{
    public class AddonOfferDao : DataMapperBase
    {
        public AddonOfferDao(NewCloudModel model)
            : base(model)
        {
        }

        public AddonOffer Find(long id)
        {
            return Model.AddonOffer.FirstOrDefault(d => d.AddonOfferId == id);
        }

        public AddonOffer Find(string name)
        {
            return Model.AddonOffer.FirstOrDefault(d => d.Name == name);
        }

        public void Insert(AddonOffer addonOffer)
        {
            Model.AddonOffer.Add(addonOffer);
        }

        public void Update(AddonOffer addonOffer)
        {
            Model.Entry(addonOffer).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var item = Model.AddonOffer.FirstOrDefault(d => d.AddonOfferId == id);
            if (item != null)
                Model.AddonOffer.Remove(item);
        }
    }
}