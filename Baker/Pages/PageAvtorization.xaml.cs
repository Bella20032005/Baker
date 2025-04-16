using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Baker.Connection;



namespace Baker.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAvtorization.xaml
    /// </summary>
    public partial class PageAvtorization : Page
    {
        public PageAvtorization()
        {
            InitializeComponent();
            CmbCashier.ItemsSource = App.Connection.Cashier.ToList();
            this.DataContext = this;
        }

        private void ClEventAutho(object sender, RoutedEventArgs e)
        {
            try
            {
                var userName = CmbCashier.SelectedItem as Cashier;
                var _sel = App.Connection.Cashier.Where(z => z.FIo == userName.FIo).FirstOrDefault();

                if (_sel != null)
                {
                    if (_sel !=  null)

                    {
                        MessageBox.Show($"Добро пожаловать");
                        NavigationService.Navigate(new CasherPage(_sel));
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нет записей");
            }

        }

        private void CmbCash_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
