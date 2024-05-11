using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KURSACH
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {
        public Administrator()
        {
            InitializeComponent();
        }
        MainWindow authorization = new MainWindow();

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdministratorPages.AdministratorClientsPage());
        }

        private void Sells_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdministratorPages.AdministratorSellPage());
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdministratorPages.AdministratorProductsPage());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            authorization.Show();
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdministratorPages.AdministratorReportsPage());
        }
    }
}
