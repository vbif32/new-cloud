using System.Data.Entity;
using System.Linq;
using Mirea.ProCat.ApplicationServer.Dal;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.ApplicationServer.Dal
{
    public class CatalogEntityStatusDao : DataMapperBase
    {
        public CatalogEntityStatusDao(NewCloudModel model)
            : base(model)
        {
        }

        public CatalogEntityStatus Find(long id)
        {
            return Model.CatalogEntityStatus.FirstOrDefault(d => d.StatusId == id);
        }

        public void Insert(CatalogEntityStatus catalogEntityStatus)
        {
            Model.CatalogEntityStatus.Add(catalogEntityStatus);
        }

        public void Update(CatalogEntityStatus catalogEntityStatus)
        {
            Model.Entry(catalogEntityStatus).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var item = Model.CatalogEntityStatus.FirstOrDefault(d => d.StatusId == id);
            if (item != null)
                Model.CatalogEntityStatus.Remove(item);
        }
    }
}