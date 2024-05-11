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

namespace KURSACH.AdministratorPages
{
    /// <summary>
    /// Логика взаимодействия для AdministratorSellPage.xaml
    /// </summary>
    public partial class AdministratorSellPage : Page
    {
        AdministratorAddSell administratorAddSell = new AdministratorAddSell();
        public AdministratorSellPage()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = Компьютерный_магазинEntities.GetContext().Order.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Компьютерный_магазинEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid_Clients.ItemsSource = Компьютерный_магазинEntities.GetContext().Order.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            administratorAddSell.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            administratorAddSell.Show();
        }

        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            var sellRemoving = DGrid_Clients.SelectedItems.Cast<Order>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {sellRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Компьютерный_магазинEntities.GetContext().Order.RemoveRange((IEnumerable<Order>)sellRemoving);
                    Компьютерный_магазинEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGrid_Clients.ItemsSource = Компьютерный_магазинEntities.GetContext().Order.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void Button_edit_data(object sender, RoutedEventArgs e)
        {
            try
            {
                AdministratorPages.AdministratorEditSell administratorEditSell
                    = new AdministratorPages.AdministratorEditSell((sender as Button).DataContext as Order);
                administratorEditSell.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
