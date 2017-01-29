using System.Data.Entity;
using System.Linq;
using Mirea.ProCat.ApplicationServer.Dal;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.ApplicationServer.Dal
{
    public class PricePlanDao : DataMapperBase
    {
        public PricePlanDao(NewCloudModel model)
            : base(model)
        {
        }

        public PricePlan Find(long id)
        {
            return Model.PricePlanSpec.FirstOrDefault(d => d.PricePlanId == id);
        }

        public void Insert(PricePlan pricePlan)
        {
            Model.PricePlanSpec.Add(pricePlan);
        }

        public void Update(PricePlan pricePlan)
        {
            Model.Entry(pricePlan).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var item = Model.PricePlanSpec.FirstOrDefault(d => d.PricePlanId == id);
            if (item != null)
                Model.PricePlanSpec.Remove(item);
        }
    }
}