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

namespace KURSACH
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Worker workerWindow = new Worker();
            Manager1 managerWindow = new Manager1();
            Administrator administratorWindow = new Administrator();

            string login = Login.Text;
            string password = Password.Password;

            if (login == "Manager" && password == "8888")
            {
                this.Close();
                managerWindow.Show();
            }
            else if (login == "Worker" && password == "2222")
            {
                this.Close();
                workerWindow.Show();
            }
            else if (login == "Administrator" && password == "1111")
            {
                this.Close();
                administratorWindow.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
