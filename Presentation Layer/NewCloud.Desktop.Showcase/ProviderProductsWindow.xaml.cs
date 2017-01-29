using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using NewCloud.Desktop.Showcase.NewCloudDataSetTableAdapters;

namespace NewCloud.Desktop.Showcase
{
    /// <summary>
    ///     Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class ProviderProductsWindow : Window
    {
        public ProviderProductsWindow()
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
            var providerId = ((ProviderWindow) Owner).User.ServiceProviderId;
            var products = Config.Dao.ProductDao.FindAllFromProvider(providerId);

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