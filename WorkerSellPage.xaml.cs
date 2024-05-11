﻿using System;
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
    /// Логика взаимодействия для WorkerSellPage.xaml
    /// </summary>
    public partial class WorkerSellPage : Page
    {
        public WorkerSellPage()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = Компьютерный_магазинEntities.GetContext().Order.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недостаточно прав");
        }

        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недостаточно прав");
        }
    }
}
