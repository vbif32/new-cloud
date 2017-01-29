using System.Windows;

namespace NewCloud.Desktop.Showcase
{
    /// <summary>
    ///     Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new CustomerWindow {Owner = this, Left = Left, Top = Top};
            Hide();
            window.ShowDialog();
        }

        private void ProducerButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProviderWindow {Owner = this};
            Hide();
            window.ShowDialog();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}