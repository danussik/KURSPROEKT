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
    /// Логика взаимодействия для ManagerEditClients.xaml
    /// </summary>
    public partial class ManagerEditClients : Window
    {
        private Client _currentClient = new Client();
        public ManagerEditClients(Client selectedClient)
        {
            InitializeComponent();
            DataContext = _currentClient;

            if (selectedClient != null)
                _currentClient = selectedClient;
            DataContext = _currentClient;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
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
