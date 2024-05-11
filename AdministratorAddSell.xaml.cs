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
    /// Логика взаимодействия для AdministratorAddSell.xaml
    /// </summary>
    public partial class AdministratorAddSell : Window
    {
        private Order _currentOrder = new Order();

        public AdministratorAddSell()
        {
            InitializeComponent();
            DataContext = _currentOrder;
        }

        private void Button_Click(object sender, object e)
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
                MessageBox.Show("Заказ добавлен");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
