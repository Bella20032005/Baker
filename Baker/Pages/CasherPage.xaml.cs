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
    /// Логика взаимодействия для CasherPage.xaml
    /// </summary>
    public partial class CasherPage : Page
    {
        public static List<Chek> chek;
        Cashier  cashier1= new Cashier();
        public CasherPage( Cashier cashier)
        {
            InitializeComponent();
            cashier1 = cashier;
            refresh();
            this.DataContext = this;
            

        }

        private void refresh()
        {
            
            chek = new List<Chek>(App.Connection.Chek.Where(i => i.Id_Cashier == cashier1.Id && i.IsDelete == false).ToList());
            ListChek.ItemsSource = chek;
            this.DataContext = this;

        }

        private void ListChek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ListChek.SelectedItems.Count > 0)
            {
                ButtonEdit.Visibility = Visibility.Visible;
                ButtonDelite.Visibility = Visibility.Visible;
            }
            else
            {
                ButtonEdit.Visibility = Visibility.Collapsed;
                ButtonDelite.Visibility = Visibility.Visible;
            }
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ListChek.SelectedItems != null)
            {
                NavigationService.Navigate(new AddChek(ListChek.SelectedItem as Chek));
            }
        }

        private void TxtSerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtSerch.Text != "")
            {
                ListChek.ItemsSource = chek.Where(z => z.Goods.Name.Contains(TxtSerch.Text)).ToList();
            }

        }

        private void ClEventAddNewChek(object sender, RoutedEventArgs e)
        {
            Chek chekAdd = new Chek();
            NavigationService.Navigate(new AddChek(chekAdd));

        }
        private void DatePicker_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            List<Chek> datapicker = new List<Chek>(App.Connection.Chek.Where(i => i.Id_Cashier == cashier1.Id && i.IsDelete == false));

            if (dateChek.SelectedDate != null)
            {
                DateTime selectedDate = dateChek.SelectedDate.Value.Date;
                ListChek.ItemsSource = chek.FindAll(chek => chek.Data_sale.Value == selectedDate);
                //ListChek.ItemsSource = chek.Where(i => i.Data_sale == datecheks).ToList();
                refresh();
            }

        }
        private void ButtonDelite_Click(object sender, RoutedEventArgs e)
        {
            if (ListChek.SelectedItem != null)
            {
                var _sel = (ListChek.SelectedItem as Chek);
                if (System.Windows.MessageBox.Show($"вы уверенны, что хотите удалить запись \n{_sel.Goods.Name.ToString()}", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    _sel.IsDelete = true;
                    App.Connection.SaveChanges();
                    refresh();

                    MessageBox.Show("Удаление прошло успешно");

                }
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (CMBTarget.SelectedValue != null)
            //{
            //    var _sel = (CMBTarget.SelectedValue as ComboBoxItem).Content;
            //    switch (_sel.ToString())
            //    {
            //        case "Очно":
            //            {
            //                refresh();
            //                students = students.Where(z => z.Type_of_study == "Очно").ToList();
            //                ListApp.ItemsSource = students.ToList();
            //                LblCounter.Content = students.Count;
            //                break;
            //            }
            //        case "Заочно":
            //            {
            //                refresh();
            //                students = students.Where(z => z.Type_of_study == "Заочно").ToList();
            //                ListApp.ItemsSource = students.ToList();
            //                LblCounter.Content = students.Count;
            //                break;
            //            }
            //        case "все":
            //            {
            //                refresh();
            //                break;
            //            }
            //    }
            //}
        }

        
    }
}
