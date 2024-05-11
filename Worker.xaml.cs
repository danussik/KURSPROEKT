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
    /// Логика взаимодействия для Worker.xaml
    /// </summary>
    public partial class Worker : Window
    {
        public Worker()
        {
            InitializeComponent();
        }
        MainWindow authorazation = new MainWindow();

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new WorkerPages.WorkerClientsPage());
        }

        private void Sells_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new WorkerPages.WorkerSellPage());
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new WorkerPages.WorkerProductsPage());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            authorazation.Show();
        }
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new WorkerPages.WorkerReportsPage());
        }
    }
}
