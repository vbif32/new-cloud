using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.Desktop.Showcase
{
    /// <summary>
    ///     Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class ProviderCreateProductWindow : Window
    {
        public ProviderCreateProductWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Owner.Left = Left;
            Owner.Top = Top;
            Owner.Show();
            base.OnClosing(e);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) => Close();

        private void NoTrialRadioButton_Checked(object sender, RoutedEventArgs e)
            => YesTrialRadioButton.IsChecked = false;

        private void YesTrialRadioButton_Checked(object sender, RoutedEventArgs e)
            => NoTrialRadioButton.IsChecked = false;

        private void NewProductButton_Click(object sender, RoutedEventArgs e)
        {
            NewProductAndProductOfferStackPanel.Visibility = Visibility.Hidden;
            AddProductStackPanel.Visibility = Visibility.Visible;
        }

        private void NewProductOfferButton_Click(object sender, RoutedEventArgs e)
        {
            NewProductAndProductOfferStackPanel.Visibility = Visibility.Hidden;
            AddProductOfferStackPanel.Visibility = Visibility.Visible;
            NewServiceAndAddonStackPanel.Visibility = Visibility.Visible;
        }

        private void NewServiceButton_Click(object sender, RoutedEventArgs e)
        {
            NewServiceAndAddonStackPanel.Visibility = Visibility.Hidden;
            AddServiceStackPanel.Visibility = Visibility.Visible;
            NewResourceButton.Visibility = Visibility.Visible;
        }

        private void NewAddonButton_Click(object sender, RoutedEventArgs e)
        {
            NewServiceAndAddonStackPanel.Visibility = Visibility.Hidden;
            AddAddonStackPanel.Visibility = Visibility.Visible;
            NewResourceButton.Visibility = Visibility.Visible;
        }

        private void NewResourceButton_Click(object sender, RoutedEventArgs e)
        {
            NewResourceButton.Visibility = Visibility.Hidden;
            AddResourceStackPanel.Visibility = Visibility.Visible;
        }

        private void CancelAddProductButton_Click(object sender, RoutedEventArgs e)
        {
            AddProductStackPanel.Visibility = Visibility.Hidden;
            NewProductAndProductOfferStackPanel.Visibility = Visibility.Visible;
        }

        private void ConfirmAddProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new Product
                {
                    Name = NewProductNameTextBox.Text.Trim(),
                    ServiceProvider =  ((ProviderWindow)Owner).User,
                    Version = 1,
                    StatusId = 1
                };
                if (Config.Dao.ProductDao.Find(product.Name) != null)
                {
                    InfoRun.Text = "Такой продукт уже есть";
                }
                else
                {
                    Config.Dao.ProductDao.Insert(product);
                    Config.Model.SaveChanges();
                    InfoRun.Text = "Продукт успешно добавлен";
                }
                var newCloudDataSet = (NewCloudDataSet)FindResource("NewCloudDataSet");
                // Load data into the table Product. You can modify this code as needed.
                var newCloudDataSetProductTableAdapter = new NewCloudDataSetTableAdapters.ProductTableAdapter();
                newCloudDataSetProductTableAdapter.Fill(newCloudDataSet.Product);
                var productViewSource = (System.Windows.Data.CollectionViewSource)FindResource("ProductViewSource");
                productViewSource.View.MoveCurrentToFirst();
            }
            catch (Exception exception)
            {
                InfoRun.Text = exception.ToString();
                Console.WriteLine(exception);
            }
        }

        private void CancelAddProductOfferButton_Click(object sender, RoutedEventArgs e)
        {
            AddProductOfferStackPanel.Visibility = Visibility.Hidden;
            NewProductAndProductOfferStackPanel.Visibility = Visibility.Visible;
            NewServiceAndAddonStackPanel.Visibility = Visibility.Hidden;
            AddServiceStackPanel.Visibility = Visibility.Hidden;
            AddResourceStackPanel.Visibility = Visibility.Hidden;
            NewResourceButton.Visibility = Visibility.Hidden;
        }

        private void ConfirmAddProductOfferButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var productOffer = new ProductOffer()
                {
                    ProductId = (long) ProductComboBox.SelectedValue,
                    ServiceOfferId = (long)ServiceComboBox.SelectedValue,
                    AddonOfferId = (long)AddonComboBox.SelectedValue,
                    Name = NewProductOfferNameTextBox.Text.Trim(),
                    IsTrial = YesTrialRadioButton.IsChecked.Value,
                    StartRangeValue = StartRangeDatePicker.DisplayDate,
                    EndRangeValue = EndRangeDatePicker.DisplayDate,
                    Version = 1,
                    StatusId = 1
                };
                if (Config.Dao.ProductOfferDao.Find(productOffer.Name) != null)
                {
                    InfoRun.Text = "Такое предложение уже есть";
                }
                else
                {
                    Config.Dao.ProductOfferDao.Insert(productOffer);
                    Config.Model.SaveChanges();
                    InfoRun.Text = "Предложение успешно добавлено";
                }
                var newCloudDataSet = (NewCloudDataSet)FindResource("NewCloudDataSet");
                // Load data into the table ProductOffer. You can modify this code as needed.
                var newCloudDataSetProductOfferTableAdapter = new NewCloudDataSetTableAdapters.ProductOfferTableAdapter();
                newCloudDataSetProductOfferTableAdapter.Fill(newCloudDataSet.ProductOffer);
                var productOfferViewSource = (System.Windows.Data.CollectionViewSource)FindResource("ProductOfferViewSource");
                productOfferViewSource.View.MoveCurrentToFirst();
            }
            catch (Exception exception)
            {
                InfoRun.Text = exception.ToString();
                Console.WriteLine(exception);
            }
        }

        private void CancelAddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            AddServiceStackPanel.Visibility = Visibility.Hidden;
            NewServiceAndAddonStackPanel.Visibility = Visibility.Visible;
            AddResourceStackPanel.Visibility = Visibility.Hidden;
            NewResourceButton.Visibility = Visibility.Hidden;
        }

        private void ConfirmAddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var service = new ServiceOffer()
                {
                    Name = NewServiceTextBox.Text.Trim(),
                    ResourceOfferId = (long) NewServiceResourceComboBox.SelectedValue,
                    Version = 1,
                    StatusId = 1
                };
                if (Config.Dao.ServiceOfferDao.Find(service.Name) != null)
                {
                    InfoRun.Text = "Такой сервис уже есть";
                }
                else
                {
                    Config.Dao.ServiceOfferDao.Insert(service);
                    Config.Model.SaveChanges();
                    InfoRun.Text = "Сервис успешно добавлен";
                }
                var newCloudDataSet = (NewCloudDataSet)FindResource("NewCloudDataSet");
                // Load data into the table ServiceOffer. You can modify this code as needed.
                var newCloudDataSetServiceOfferTableAdapter = new NewCloudDataSetTableAdapters.ServiceOfferTableAdapter();
                newCloudDataSetServiceOfferTableAdapter.Fill(newCloudDataSet.ServiceOffer);
                var serviceOfferViewSource = (System.Windows.Data.CollectionViewSource)FindResource("ServiceOfferViewSource");
                serviceOfferViewSource.View.MoveCurrentToFirst();
            }
            catch (Exception exception)
            {
                InfoRun.Text = exception.ToString();
                Console.WriteLine(exception);
            }
        }

        private void CancelAddAddonButton_Click(object sender, RoutedEventArgs e)
        {
            AddAddonStackPanel.Visibility = Visibility.Hidden;
            NewServiceAndAddonStackPanel.Visibility = Visibility.Visible;
            AddResourceStackPanel.Visibility = Visibility.Hidden;
            NewResourceButton.Visibility = Visibility.Hidden;
        }

        private void ConfirmAddAddonButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var addon = new AddonOffer()
                {
                    Name = NewAddonTextBox.Text.Trim(),
                    ResourceOfferId = (long)NewServiceResourceComboBox.SelectedValue,
                    Version = 1,
                    StatusId = 1
                };
                if (Config.Dao.AddonOfferDao.Find(addon.Name) != null)
                {
                    InfoRun.Text = "Такое дополнение уже есть";
                }
                else
                {
                    Config.Dao.AddonOfferDao.Insert(addon);
                    Config.Model.SaveChanges();
                    InfoRun.Text = "Дополнение успешно добавлено";
                }
            }
            catch (Exception exception)
            {
                InfoRun.Text = exception.ToString();
                Console.WriteLine(exception);
            }
            var newCloudDataSet = (NewCloudDataSet)FindResource("NewCloudDataSet");
            // Load data into the table AddonOffer. You can modify this code as needed.
            var newCloudDataSetAddonOfferTableAdapter = new NewCloudDataSetTableAdapters.AddonOfferTableAdapter();
            newCloudDataSetAddonOfferTableAdapter.Fill(newCloudDataSet.AddonOffer);
            var addonOfferViewSource = (System.Windows.Data.CollectionViewSource)FindResource("AddonOfferViewSource");
            addonOfferViewSource.View.MoveCurrentToFirst();
        }

        private void CancelAddResourceButton_Click(object sender, RoutedEventArgs e)
        {
            AddResourceStackPanel.Visibility = Visibility.Hidden;
            NewResourceButton.Visibility = Visibility.Visible;
        }

        private void ConfirmAddResourceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var resource = new ResourceOffer()
                {
                    Name = NewResourceTextBox.Text.Trim(),
                    GracePeriodDays = int.Parse(NewResourceGracePeriodTextBox.Text),
                    PricePlan = new PricePlan
                    {
                        CurrencyId = (long) NewResourcePricePlanComboBox.SelectedValue,
                        Price = int.Parse(NewResourcePricePlanTextBox.Text)
                    },
                    Version = 1,
                    StatusId = 1
                };
                if (Config.Dao.ResourceOfferDao.Find(resource.Name) != null)
                {
                    InfoRun.Text = "Такой ресурс уже есть";
                }
                else
                {
                    Config.Dao.ResourceOfferDao.Insert(resource);
                    Config.Model.SaveChanges();
                    InfoRun.Text = "Ресурс успешно добавлен";
                }
                var newCloudDataSet = (NewCloudDataSet)FindResource("NewCloudDataSet");
                // Load data into the table ResourceOffer. You can modify this code as needed.
                var newCloudDataSetResourceOfferTableAdapter = new NewCloudDataSetTableAdapters.ResourceOfferTableAdapter();
                newCloudDataSetResourceOfferTableAdapter.Fill(newCloudDataSet.ResourceOffer);
                var resourceOfferViewSource = (System.Windows.Data.CollectionViewSource)FindResource("ResourceOfferViewSource");
                resourceOfferViewSource.View.MoveCurrentToFirst();
            }
            catch (Exception exception)
            {
                InfoRun.Text = exception.ToString();
                Console.WriteLine(exception);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var newCloudDataSet = (NewCloudDataSet)FindResource("NewCloudDataSet");
            // Load data into the table Product. You can modify this code as needed.
            var newCloudDataSetProductTableAdapter = new NewCloudDataSetTableAdapters.ProductTableAdapter();
            newCloudDataSetProductTableAdapter.Fill(newCloudDataSet.Product);
            var productViewSource = (System.Windows.Data.CollectionViewSource)FindResource("ProductViewSource");
            productViewSource.View.MoveCurrentToFirst();
            // Load data into the table ProductOffer. You can modify this code as needed.
            var newCloudDataSetProductOfferTableAdapter = new NewCloudDataSetTableAdapters.ProductOfferTableAdapter();
            newCloudDataSetProductOfferTableAdapter.Fill(newCloudDataSet.ProductOffer);
            var productOfferViewSource = (System.Windows.Data.CollectionViewSource)FindResource("ProductOfferViewSource");
            productOfferViewSource.View.MoveCurrentToFirst();
            // Load data into the table ServiceOffer. You can modify this code as needed.
            var newCloudDataSetServiceOfferTableAdapter = new NewCloudDataSetTableAdapters.ServiceOfferTableAdapter();
            newCloudDataSetServiceOfferTableAdapter.Fill(newCloudDataSet.ServiceOffer);
            var serviceOfferViewSource = (System.Windows.Data.CollectionViewSource)FindResource("ServiceOfferViewSource");
            serviceOfferViewSource.View.MoveCurrentToFirst();
            // Load data into the table AddonOffer. You can modify this code as needed.
            var newCloudDataSetAddonOfferTableAdapter = new NewCloudDataSetTableAdapters.AddonOfferTableAdapter();
            newCloudDataSetAddonOfferTableAdapter.Fill(newCloudDataSet.AddonOffer);
            var addonOfferViewSource = (System.Windows.Data.CollectionViewSource)FindResource("AddonOfferViewSource");
            addonOfferViewSource.View.MoveCurrentToFirst();
            // Load data into the table ResourceOffer. You can modify this code as needed.
            var newCloudDataSetResourceOfferTableAdapter = new NewCloudDataSetTableAdapters.ResourceOfferTableAdapter();
            newCloudDataSetResourceOfferTableAdapter.Fill(newCloudDataSet.ResourceOffer);
            var resourceOfferViewSource = (System.Windows.Data.CollectionViewSource)FindResource("ResourceOfferViewSource");
            resourceOfferViewSource.View.MoveCurrentToFirst();
            // Load data into the table PricePlan. You can modify this code as needed.
            var newCloudDataSetPricePlanTableAdapter = new NewCloudDataSetTableAdapters.PricePlanTableAdapter();
            newCloudDataSetPricePlanTableAdapter.Fill(newCloudDataSet.PricePlan);
            var pricePlanViewSource = (System.Windows.Data.CollectionViewSource)FindResource("PricePlanViewSource");
            pricePlanViewSource.View.MoveCurrentToFirst();
            // Load data into the table Currency. You can modify this code as needed.
            var newCloudDataSetCurrencyTableAdapter = new NewCloudDataSetTableAdapters.CurrencyTableAdapter();
            newCloudDataSetCurrencyTableAdapter.Fill(newCloudDataSet.Currency);
            var currencyViewSource = (System.Windows.Data.CollectionViewSource)FindResource("CurrencyViewSource");
            currencyViewSource.View.MoveCurrentToFirst();
        }
    }
}