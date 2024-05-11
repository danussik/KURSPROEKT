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

namespace KURSACH.ManagerPages
{
    /// <summary>
    /// Логика взаимодействия для ManagerAddClients.xaml
    /// </summary>
    public partial class ManagerAddClients : Window
    {
        private Client _currentClient = new Client();

        public ManagerAddClients()
        {
            InitializeComponent();
            DataContext = _currentClient;

        }

        private void Button_Click(object sender, object e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClient.Name))
                errors.AppendLine("Укажите имя клиента");
            if (string.IsNullOrWhiteSpace(_currentClient.Surname))
                errors.AppendLine("Укажите фамилию клиента");
            if (string.IsNullOrWhiteSpace(_currentClient.PhoneNumber))
                errors.AppendLine("Укажите номер телефона клиента");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentClient.ClientID == 0)
                Компьютерный_магазинEntities.GetContext().Client.Add(_currentClient);

            try
            {
                Компьютерный_магазинEntities.GetContext().SaveChanges();
                MessageBox.Show("Клиент добавлен");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
