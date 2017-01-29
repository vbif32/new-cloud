using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.Desktop.Showcase
{
    /// <summary>
    ///     Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class CustomerOrderWindow : Window
    {
        public CustomerOrderWindow()
        {
            InitializeComponent();
        }

        private List<string> _products;
        private List<string> _productOffers;

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
            _products = Config.Dao.ProductDao.FindAll().Select(s => s.Name).ToList();
            ProductComboBox.ItemsSource = _products;
        }

        private void ProductComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductComboBox.SelectedItem != null)
            {
                _productOffers =
    Config.Dao.ProductOfferDao.FindByProduct(((string)ProductComboBox.SelectedItem)).Select(s => s.Name).ToList();
                ProductOfferComboBox.IsEnabled = true;
                ProductOfferComboBox.ItemsSource = _productOffers;
            }
        }
        
        private void ProductOfferComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var po = Config.Dao.ProductOfferDao.Find((string) ProductOfferComboBox.SelectedItem);
            var service = po.ServiceOffer;
            var addon = po.AddonOffer;

            ServiceRun.Text = 
               $"Название сервиса: {service.Name}\n" +
               $"Статус сервиса {service.CatalogEntityStatus.Value}\n" +
               $"Версия сервиса {service.Version}\n" +
               $"Название ресурса сервиса {service.ResourceOffer.Name}\n" +
               $"Пробный период сервиса {service.ResourceOffer.GracePeriodDays}\n" +
               $"Цена сервиса {service.ResourceOffer.PricePlan.Price} " +
               $"{service.ResourceOffer.PricePlan.Currency.Value}";

            AddonRun.Text = 
               $"Название сервиса: {addon.Name}\n" +
               $"Статус сервиса {addon.CatalogEntityStatus.Value}\n" +
               $"Версия сервиса {addon.Version}\n" +
               $"Название ресурса сервиса {addon.ResourceOffer.Name}\n" +
               $"Пробный период сервиса {addon.ResourceOffer.GracePeriodDays}\n" +
               $"Цена сервиса {addon.ResourceOffer.PricePlan.Price} " +
               $"{addon.ResourceOffer.PricePlan.Currency.Value}";

            OkButton.IsEnabled = true;
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            var customerId = ((CustomerWindow) Owner).User.CustomerId;

            var si =new ServiceInstance
            {
                CustomerId = customerId,
                ProductOfferId = Config.Dao.ProductOfferDao.Find((string)ProductOfferComboBox.SelectedItem).ProductOfferId,
            };
            Config.Dao.ServiceInstanceDao.Insert(si);
            Config.Model.SaveChanges();
            InfoLabel.Content = "Сервис успешно куплен";
        }
    }
}