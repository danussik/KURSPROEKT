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

namespace KURSACH.WorkerPages
{
    /// <summary>
    /// Логика взаимодействия для WorkerEditProducts.xaml
    /// </summary>
    public partial class WorkerEditProducts : Window
    {
        private Product _currentProduct = new Product();

        public WorkerEditProducts(Product selectedProduct)
        {
            InitializeComponent();
            DataContext = _currentProduct;

            if (selectedProduct != null)
                _currentProduct = selectedProduct;
            DataContext = _currentProduct;
        }

        private void Edit_Product(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentProduct.Name))
                errors.AppendLine("Укажите название продукта");
            if (string.IsNullOrWhiteSpace(_currentProduct.Description))
                errors.AppendLine("Укажите описание продукта");
            if (string.IsNullOrWhiteSpace(_currentProduct.Category))
                errors.AppendLine("Укажите категорию продукта");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentProduct.ProductID == 0)
                Компьютерный_магазинEntities.GetContext().Product.Add(_currentProduct);

            try
            {
                Компьютерный_магазинEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные изменены");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
