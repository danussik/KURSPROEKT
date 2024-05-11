using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Linq;

namespace KURSACH.ManagerPages
{
    /// <summary>
    /// Логика взаимодействия для ManagerReportsPage.xaml
    /// </summary>
    public partial class ManagerReportsPage : System.Windows.Controls.Page
    {
        public ManagerReportsPage()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = Компьютерный_магазинEntities.GetContext().Product.ToList();
        }

        private void Button_Click_Word(object sender, RoutedEventArgs e)
        {
            Word.Application word = new Word.Application();
            word.Visible = false;
            Word.Document document = word.Documents.Add();

            Word.Paragraph para = document.Content.Paragraphs.Add();
            para.Range.Text = "Отчет";

            Word.Table table = document.Tables.Add(para.Range, DGrid_Clients.Items.Count + 1, DGrid_Clients.Columns.Count);
            table.Borders.Enable = 1;

            for (int j = 0; j < DGrid_Clients.Columns.Count; j++)
            {
                table.Cell(1, j + 1).Range.Text = DGrid_Clients.Columns[j].Header.ToString();
            }

            for (int i = 0; i < DGrid_Clients.Items.Count; i++)
            {
                for (int j = 0; j < DGrid_Clients.Columns.Count; j++)
                {
                    TextBlock b = DGrid_Clients.Columns[j].GetCellContent(DGrid_Clients.Items[i]) as TextBlock;
                    table.Cell(i + 2, j + 1).Range.Text = b.Text;
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                document.SaveAs2(filePath);
                document.Close();
                word.Quit();
            }
        }

        private void Button_Click_Excel(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = false;
            Workbook workbook = excel.Workbooks.Add();
            Worksheet worksheet = workbook.ActiveSheet;
            if (DGrid_Clients != null)
            {
                for (int j = 0; j < DGrid_Clients.Columns.Count; j++)
                {
                    worksheet.Cells[2, j + 1] = DGrid_Clients.Columns[j].Header.ToString();
                }

                for (int i = 0; i < DGrid_Clients.Items.Count; i++)
                {
                    for (int j = 0; j < DGrid_Clients.Columns.Count; j++)
                    {
                        TextBlock b = DGrid_Clients.Columns[j].GetCellContent(DGrid_Clients.Items[i]) as TextBlock;
                        worksheet.Cells[i + 2, j + 1] = b.Text;
                    }
                }
            }
            else
            {
                MessageBox.Show("datagridkolvo не инициализирован или равен null.");
                worksheet.Cells[1, 1] = "Отчет";
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                workbook.SaveAs(filePath);
                workbook.Close();
                excel.Quit();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недостаточно прав");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недостаточно прав");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недостаточно прав");
        }

        private void DGrid_Clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
