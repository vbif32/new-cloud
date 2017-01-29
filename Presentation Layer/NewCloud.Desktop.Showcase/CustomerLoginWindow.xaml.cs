using System.ComponentModel;
using System.Windows;

namespace NewCloud.Desktop.Showcase
{
    /// <summary>
    ///     Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class CustomerLoginWindow : Window
    {
        public CustomerLoginWindow()
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
            var user = Config.Dao.CustomerDao.Find(LoginTextBox.Text);
            if (user == null)
            {
                ErrorLabel.Content = "Такого пользователя\nне существует";
                return;
            }
            if (user.Password != PasswordBox.Password)
            {
                ErrorLabel.Content = "Пароль не совпадает";
                return;
            }

            ((CustomerWindow) Owner).User = user;
            ErrorLabel.Content = "Вход выполнен";
            Close();
        }
    }
}