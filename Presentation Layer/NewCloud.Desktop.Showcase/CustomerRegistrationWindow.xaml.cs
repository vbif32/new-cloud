using System;
using System.ComponentModel;
using System.Windows;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.Desktop.Showcase
{
    /// <summary>
    ///     Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class CustomerRegistrationWindow : Window
    {
        public CustomerRegistrationWindow()
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

            var fio = FioTextBox.Text.Split(Convert.ToChar(" "));
            var customer = new Customer
            {
                Login = LoginTextBox.Text.Trim(),
                Password = PasswordBox.Password.Trim(),
                Surname = fio[0].Trim(),
                Name = fio[1].Trim(),
                MiddleName = fio[2].Trim(),
                AccountNumber = long.Parse(InnTextBox.Text.Trim())
            };
            var model = Config.Model;
            if (Config.Dao.CustomerDao.Find(customer.Login) != null)
            {
                ErrorLabel.Content = "Такой пользователь \nуже зарегистрирован";
            }
            else
            {
                Config.Dao.CustomerDao.Insert(customer);
                Config.Model.SaveChanges();
                ErrorLabel.Content = "Пользователь успешно \nзарегистрирован";
            }
        }

        private bool IsFieldRight()
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                ErrorLabel.ContentStringFormat = "поле \"Логин\" не заполнено";
                return false;
            }
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                ErrorLabel.ContentStringFormat = "поле \"Пароль\" не заполнено";
                return false;
            }
            if (string.IsNullOrWhiteSpace(FioTextBox.Text) && FioTextBox.Text.Split(Convert.ToChar(" ")).Length == 3)
            {
                ErrorLabel.ContentStringFormat = "поле \"ФИО\" не заполнено";
                return false;
            }
            if (string.IsNullOrWhiteSpace(InnTextBox.Text))
            {
                ErrorLabel.ContentStringFormat = "поле \"ИНН\" не заполнено";
                return false;
            }
            return true;
        }
    }
}