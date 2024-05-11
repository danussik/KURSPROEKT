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
    /// Логика взаимодействия для AdministratorClientsPage.xaml
    /// </summary>
    public partial class AdministratorClientsPage : Page
    {
        AdministratorAddClient administratorAddClient = new AdministratorAddClient();

        public AdministratorClientsPage()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = Компьютерный_магазинEntities.GetContext().Client.ToList();
            
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Компьютерный_магазинEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid_Clients.ItemsSource = Компьютерный_магазинEntities.GetContext() .Client.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            administratorAddClient.Show();
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
    }
}

