using Baker.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Baker.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddChek.xaml
    /// </summary>
    public partial class AddChek : Page
    {
        public List<Chek> cheks { get; set; }
        public Chek contextChek;
        public AddChek(Chek chek)
        {
            InitializeComponent();
            CmbGoods.ItemsSource = App.Connection.Goods.ToList();
            cheks = new List<Chek>(App.Connection.Chek.ToList());
            CmbCasher.ItemsSource = App.Connection.Cashier.ToList();
            DataContext = contextChek = chek;
            if (contextChek != null)
            {
                //CmbPet.Text = contextReseption.Pet.Name;
                DatePick.Text = contextChek.Data_sale.ToString();
                TxtKol_vo.Text = contextChek.Kol_vo.ToString();
                TxtSumma.Text = contextChek.Summa.ToString();
            }
        }

       
        private void ClEventAddNewProduct(object sender, RoutedEventArgs e)
        {
            var typecasher = CmbCasher.SelectedItem as Cashier;
            var typegoods = CmbGoods.SelectedItem as Goods;
            if (TxtKol_vo.Text.Trim() == "" || DatePick.SelectedDate == null || typecasher == null || TxtSumma.Text == null ||typegoods == null)
                MessageBox.Show("Заполните все поля!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                try
                {
                    contextChek.Id_goods = typegoods.Id;
                    contextChek.Id_Cashier = typecasher.Id;
                    contextChek.Data_sale =(DateTime)DatePick.SelectedDate;
                    contextChek.Kol_vo = Convert.ToInt32(TxtKol_vo.Text);
                    contextChek.Summa =Convert.ToDouble(TxtSumma.Text);
                    contextChek.IsDelete = false;

                    if (contextChek.Id == 0)
                        App.Connection.Chek.Add(contextChek);
                    App.Connection.SaveChanges();

                    MessageBox.Show("Вы внесли изменения в список", "", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void TxtKol_vo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtSumma_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CmbDoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbGoods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
