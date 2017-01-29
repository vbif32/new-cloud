using System.ComponentModel;
using System.Windows;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.Desktop.Showcase
{
    /// <summary>
    ///     Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class ProviderWindow : Window
    {
        public ProviderWindow()
        {
            InitializeComponent();
        }

        public ServiceProvider User { get; set; }

        protected override void OnClosing(CancelEventArgs e)
        {
            Owner.Left = Left;
            Owner.Top = Top;
            Owner.Show();
            base.OnClosing(e);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) => Close();

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProviderCreateProductWindow {Owner = this, Left = Left, Top = Top };
            Hide();
            window.ShowDialog();
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProviderProductsWindow {Owner = this, Left = Left, Top = Top };
            Hide();
            window.ShowDialog();
        }


        private void LoginHyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new ProviderLoginWindow { Owner = this, Left = Left, Top = Top };

            User = null;
            UserNameRun.Text = "Вход не выполнен";
            CreateButton.IsEnabled = false;
            ProductsButton.IsEnabled = false;

            Hide();
            window.ShowDialog();
            if (User != null)
            {
                UserNameRun.Text = User.Login;
                CreateButton.IsEnabled = true;
                ProductsButton.IsEnabled = true;
                GuestTextBlock.Visibility = Visibility.Collapsed;
                UserTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void RegistrationHyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new ProviderRegistrationWindow { Owner = this, Left = Left, Top = Top };
            Hide();
            window.ShowDialog();
        }

        private void QuitHyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            User = null;
            UserNameRun.Text = "Вход не выполнен";
            CreateButton.IsEnabled = false;
            ProductsButton.IsEnabled = false;
            GuestTextBlock.Visibility = Visibility.Visible;
            UserTextBlock.Visibility = Visibility.Collapsed;
        }
    }
}