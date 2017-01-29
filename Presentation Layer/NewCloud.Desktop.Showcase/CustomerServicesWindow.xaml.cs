using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.Desktop.Showcase
{
    /// <summary>
    ///     Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class CustomerServicesWindow : Window
    {
        public CustomerServicesWindow()
        {
            InitializeComponent();
        }

        private List<ProductOfferTemplate> ProductOfferTemplateList;

        protected override void OnClosing(CancelEventArgs e)
        {
            Owner.Left = Left;
            Owner.Top = Top;
            Owner.Show();
            base.OnClosing(e);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) => Close();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProductOfferTemplateList = new List<ProductOfferTemplate>();
            var userCustomerId = ((CustomerWindow)Owner).User.CustomerId;
            var serviceInstances = Config.Dao.ServiceInstanceDao.FindAllByCustomer(userCustomerId);
            var products = serviceInstances.Select(d => d.ProductOffer.Product);

            foreach (var product in products)
                foreach (var po in product.ProductOffer)
                {
                    var productOfferTemplate = new ProductOfferTemplate
                    {
                        Продукт = product.Name,
                        Название = po.Name,
                        Пробный = po.IsTrial,
                        ДатаНачала = po.StartRangeValue.ToLongDateString(),
                        ДатаОкончания = po.EndRangeValue.ToLongDateString(),
                        Версия = po.Version,
                        Статус = po.CatalogEntityStatus.Value,
                        Сервис = po.ServiceOffer.Name,
                        Дополнение = po.AddonOffer.Name,
                    };
                    ProductOfferTemplateList.Add(productOfferTemplate);
                }

            ProductOfferDataGrid.ItemsSource = ProductOfferTemplateList;
        }

        private struct ProductOfferTemplate
        {
            public string Продукт { get; set; }
            public string Название { get; set; }
            public bool Пробный { get; set; }
            public string ДатаНачала { get; set; }
            public string ДатаОкончания { get; set; }
            public int Версия { get; set; }
            public string Статус { get; set; }
            public string Сервис { get; set; }
            public string Дополнение { get; set; }
        }
    }
}