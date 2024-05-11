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

namespace KURSACH.ManagerPages
{
    /// <summary>
    /// Логика взаимодействия для ManagerClientsPage.xaml
    /// </summary>
    public partial class ManagerClientsPage : Page
    {
        ManagerPages.ManagerAddClients managerAddClients = new ManagerPages.ManagerAddClients();
        public ManagerClientsPage()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = Компьютерный_магазинEntities.GetContext().Client.ToList();
            
        }
        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            var clientRemoving = DGrid_Clients.SelectedItems.Cast<Client>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Компьютерный_магазинEntities.GetContext().Client.RemoveRange((IEnumerable<Client>)clientRemoving);
                    Компьютерный_магазинEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGrid_Clients.ItemsSource = Компьютерный_магазинEntities.GetContext().Client.ToList();
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
                AdministratorPages.AdministratorEditClients administratorEditClients
                    = new AdministratorPages.AdministratorEditClients((sender as Button).DataContext as Client);
                administratorEditClients.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            managerAddClients.Show();
        }
    }
}

