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
    /// Логика взаимодействия для WorkerAddProducts.xaml
    /// </summary>
    public partial class WorkerAddProducts : Window
    {
        private Product _currentProduct = new Product();
        public WorkerAddProducts()
        {
            InitializeComponent();
            DataContext = _currentProduct;
        }

        private void Button_Click(object sender, object e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentProduct.Name))
                errors.AppendLine("Укажите название товара");

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
                MessageBox.Show("Товар добавлен");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

