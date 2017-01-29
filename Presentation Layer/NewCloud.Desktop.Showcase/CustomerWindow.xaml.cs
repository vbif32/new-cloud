using System.ComponentModel;
using System.Windows;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.Desktop.Showcase
{
    /// <summary>
    ///     Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
        {
            InitializeComponent();
        }

        public Customer User { get; set; }

        protected override void OnClosing(CancelEventArgs e)
        {
            Owner.Left = Left;
            Owner.Top = Top;
            Owner.Show();
            base.OnClosing(e);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) => Close();

        private void LoginHyperlink_Click(object sender, RoutedEventArgs e)
        {
            var window = new CustomerLoginWindow {Owner = this, Left = Left, Top = Top };

            User = null;
            UserNameRun.Text = "Вход не выполнен";
            OrderButton.IsEnabled = false;
            ServicesButton.IsEnabled = false;

            Hide();
            window.ShowDialog();

            if (User != null)
            {
                UserNameRun.Text = User.Login;
                OrderButton.IsEnabled = true;
                ServicesButton.IsEnabled = true;
            }
        }

        private void QuitHyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            User = null;
            UserNameRun.Text = "Вход не выполнен";
            OrderButton.IsEnabled = false;
            ServicesButton.IsEnabled = false;
            GuestTextBlock.Visibility = Visibility.Visible;
            UserTextBlock.Visibility = Visibility.Collapsed;
        }

        private void RegistrationHyperlink_Click(object sender, RoutedEventArgs e)
        {
            var window = new CustomerRegistrationWindow {Owner = this, Left = Left, Top = Top };
            Hide();
            window.ShowDialog();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new CustomerOrderWindow {Owner = this, Left = Left, Top = Top };
            Hide();
            window.ShowDialog();
        }

        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new CustomerServicesWindow {Owner = this, Left = Left, Top = Top };
            Hide();
            window.ShowDialog();
        }
    }
}