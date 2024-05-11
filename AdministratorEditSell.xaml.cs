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

namespace KURSACH.AdministratorPages
{
    /// <summary>
    /// Логика взаимодействия для AdministratorEditSell.xaml
    /// </summary>
    public partial class AdministratorEditSell : Window
    {
        private Order _currentOrder = new Order();

        public AdministratorEditSell(Order selectedOrder)
        {
            InitializeComponent();
            DataContext = _currentOrder;

            if (selectedOrder != null)
                _currentOrder = selectedOrder;
            DataContext = _currentOrder;
        }


        private void Order_edit(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentOrder.OrderID == 0)
                Компьютерный_магазинEntities.GetContext().Order.Add(_currentOrder);

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