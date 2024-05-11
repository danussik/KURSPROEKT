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

namespace KURSACH.WorkerPages
{
    /// <summary>
    /// Логика взаимодействия для WorkerProductsPage.xaml
    /// </summary>
    public partial class WorkerProductsPage : Page
    {
        WorkerPages.WorkerAddProducts workerAddProducts = new WorkerPages.WorkerAddProducts();
        public WorkerProductsPage()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = Компьютерный_магазинEntities.GetContext().Product.ToList();
        }
        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            var productRemoving = DGrid_Clients.SelectedItems.Cast<Product>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {productRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Компьютерный_магазинEntities.GetContext().Product.RemoveRange((IEnumerable<Product>)productRemoving);
                    Компьютерный_магазинEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGrid_Clients.ItemsSource = Компьютерный_магазинEntities.GetContext().Product.ToList();
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
                WorkerPages.WorkerEditProducts workerEditProducts
                    = new WorkerPages.WorkerEditProducts((sender as Button).DataContext as Product);
                workerEditProducts.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            workerAddProducts.Show();
        }
    }
}
