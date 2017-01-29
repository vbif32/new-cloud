using System.Collections.Generic;
using System.Data.Entity;

namespace NewCloud.ApplicationServer.Entities
{
    public class SampleInitializer
        : CreateDatabaseIfNotExists<NewCloudModel>
    {
        protected override void Seed(NewCloudModel model)
        {
            var statuses = new List<CatalogEntityStatus>
            {
                new CatalogEntityStatus {Value = "Всё хорошо"},
                new CatalogEntityStatus {Value = "Всё плохо"}
            };
            foreach (var status in statuses)
                model.CatalogEntityStatus.Add(status);

            var currencies = new List<Currency>
            {
                new Currency {Value = "RUB"},
                new Currency {Value = "USD"},
                new Currency {Value = "EUR"}
            };
            foreach (var currency in currencies)
                model.Currency.Add(currency);

            model.SaveChanges();
            base.Seed(model);
        }
    }
}