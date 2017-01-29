using System.Data.Entity;
using System.Linq;
using Mirea.ProCat.ApplicationServer.Dal;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.ApplicationServer.Dal
{
    public class CurrencyDao : DataMapperBase
    {
        public CurrencyDao(NewCloudModel model)
            : base(model)
        {
        }

        public Currency Find(long id)
        {
            return Model.Currency.FirstOrDefault(d => d.CurrencyId == id);
        }

        public void Insert(Currency currency)
        {
            Model.Currency.Add(currency);
        }

        public void Update(Currency currency)
        {
            Model.Entry(currency).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var item = Model.Currency.FirstOrDefault(d => d.CurrencyId == id);
            if (item != null)
                Model.Currency.Remove(item);
        }
    }
}