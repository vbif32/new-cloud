using System.ComponentModel;
using System.Windows;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.Desktop.Showcase
{
    /// <summary>
    ///     Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class ProviderRegistrationWindow : Window
    {
        public ProviderRegistrationWindow()
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

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFieldRight())
                return;

            var provider = new ServiceProvider
            {
                Login = LoginTextBox.Text.Trim(),
                Password = PasswordBox.Password.Trim(),
                FirmName = FirmNameTextBox.Text.Trim(),
                ContactName = ContactNameTextBox.Text.Trim(),
                ContactEmail = ContactEmailTextBox.Text.Trim(),
                ContactPhone = ContactPhoneTextBox.Text.Trim(),
                Version = 1,
                StatusId = 1
            };
            if (Config.Dao.ServiceProviderDao.Find(provider.Login) != null)
            {
                ErrorLabel.Content = "Такой пользователь\nуже зарегистрирован";
            }
            else
            {
                Config.Dao.ServiceProviderDao.Insert(provider);
                Config.Model.SaveChanges();
                ErrorLabel.Content = "Пользователь успешно\nзарегистрирован";
            }
        }

        private bool IsFieldRight()
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                ErrorLabel.ContentStringFormat = $"поле \n{LoginLabel.Content}\"\n не заполнено";
                return false;
            }
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                ErrorLabel.ContentStringFormat = $"поле \"{PasswordLabel.Content}\"\n не заполнено";
                return false;
            }
            if (string.IsNullOrWhiteSpace(FirmNameTextBox.Text))
            {
                ErrorLabel.ContentStringFormat = $"поле \"{FirmNameLabel.Content}\"\n не заполнено";
                return false;
            }
            if (string.IsNullOrWhiteSpace(ContactNameTextBox.Text))
            {
                ErrorLabel.ContentStringFormat = $"поле \"{ContactNameLabel.Content}\"\n не заполнено";
                return false;
            }
            if (string.IsNullOrWhiteSpace(ContactPhoneTextBox.Text))
            {
                ErrorLabel.ContentStringFormat = $"поле \"{ContactPhoneLabel.Content}\"\n не заполнено";
                return false;
            }
            if (string.IsNullOrWhiteSpace(ContactEmailTextBox.Text))
            {
                ErrorLabel.ContentStringFormat = $"поле \"{ContactEmailLabel.Content}\"\n не заполнено";
                return false;
            }
            return true;
        }
    }
}