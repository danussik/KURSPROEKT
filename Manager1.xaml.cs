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
using System.Windows.Shapes;

namespace KURSACH
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager1 : Window
    {
        public Manager1()
        {
            InitializeComponent();
        }
        MainWindow authorazation = new MainWindow();

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManagerPages.ManagerClientsPage());
        }

        private void Sells_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManagerPages.ManagerSellPage());
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManagerPages.ManagerProductsPage());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            authorazation.Show();
        }
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManagerPages.ManagerReportsPage());
        }
    }
}
