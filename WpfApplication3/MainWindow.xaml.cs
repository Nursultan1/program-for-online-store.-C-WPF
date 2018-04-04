using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Security.Cryptography;
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfApplication3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DB db=new DB();
        Add WindowForAddProduct;
        
        WindowForConfirm WindowForConfirm;
        OpenFileDialog okno = new OpenFileDialog();


        // для получения даты обратном порядке
        public static string dateReverse(string date)
        {
            string[] arrayDate = date.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            string newDate = "";
            for (int i = 0; i < arrayDate.Length; i++)
            {
                newDate += arrayDate[arrayDate.Length - 1 - i] + ".";
            }
            return newDate.Remove(newDate.Length - 1);
        }
        //зашифровать пароль
        public static string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
        int nambeProductInPage = 5;
        int nambePage;
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("Количество"+db.numbeProduct());
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            double temp = db.numbeProduct() / nambeProductInPage;
            dataGrid.ItemsSource = db.SELECT();
            nambePage =Convert.ToInt32(Math.Ceiling(temp));
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WindowForAddProduct = new Add();
            if (WindowForAddProduct.ShowDialog() == true)
            {
                dataGrid.ItemsSource = db.SELECT();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataGrid current = dataGrid.SelectedItem as DataGrid;
            WindowForAddProduct = new Add(current.id,current.name,current.price,current.size,current.color, current.articulPost,current.articul,current.nalichi,current.comment);
            if (WindowForAddProduct.ShowDialog() == true)
            {
                dataGrid.ItemsSource = db.SELECT();
            }
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            DataGrid current = dataGrid.SelectedItem as DataGrid;
            WindowForConfirm = new WindowForConfirm("Вы действительно хотите удалить товар?");
            if (WindowForConfirm.ShowDialog() == true)
            {
                db.DELETE(current.id);
                dataGrid.ItemsSource = db.SELECT();
            }
        }
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            DataGrid current = dataGrid.SelectedItem as DataGrid;
            if (current.nalichi1)
            {
                WindowForAddNewZakaz addNewZakaz = new WindowForAddNewZakaz(current.id, current.name, current.size, current.color, current.articulPost, current.arrayByteImgTovara);
                addNewZakaz.Show();
            }
            else
                MessageBox.Show("Товара нет в наличии");


        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataGrid current = dataGrid.SelectedItem as DataGrid;
            WindowForVueImg VImg = new WindowForVueImg(current.dis);
            VImg.Show();
        } 
        public  void updateDataGrid() {
            dataGrid.ItemsSource = db.SELECT();
        }
        //Заказы   
        private void dataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = db.selectZakaz();
        }

        private void buttonForAddNewZakaz_Click(object sender, RoutedEventArgs e)
        {
            WindowForAddNewZakaz WindowForAddNewZakaz = new WindowForAddNewZakaz();
            if(WindowForAddNewZakaz.ShowDialog()==true)
            {
                MessageBox.Show("Заказ успешно добавлен");
                dataGrid1.ItemsSource = db.selectZakaz();
            }
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            if (selectedItem.Text == "Завершенные")
            {
                dataGrid1.ItemsSource = db.selectZakaz("Завершен");
            }
            else if (selectedItem.Text == "Все")
            {
                dataGrid1.ItemsSource = db.selectZakaz();
            }
            else if (selectedItem.Text == "Оформленные")
            {
                dataGrid1.ItemsSource = db.selectZakaz("Оформленный");
            }
            else if (selectedItem.Text == "Неоформленные")
            {
                dataGrid1.ItemsSource = db.selectZakaz("Неоформленный");
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            DataGridZakaz current = dataGrid1.SelectedItem as DataGridZakaz;;
            WindowForAddNewZakaz WindowForAddNewZakaz = new WindowForAddNewZakaz(current.id);
            if (WindowForAddNewZakaz.ShowDialog() == true)
            {
                MessageBox.Show("Заказ успешно изменен");
                dataGrid1.ItemsSource = db.selectZakaz();
            }
        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridZakaz current = dataGrid1.SelectedItem as DataGridZakaz;
                WindowForConfirm = new WindowForConfirm("Вы действительно хотите удалить заказ");
                if (WindowForConfirm.ShowDialog() == true)
                {
                    db.deleteZakaz(Convert.ToInt32(current.id));
                    dataGrid1.ItemsSource = db.selectZakaz();
                }
            }
            catch
            {
                MessageBox.Show("Выберите заказ");
            }
        }

        private void buttonProvestiZakaz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridZakaz current = dataGrid1.SelectedItem as DataGridZakaz;
                if (current.status == "Неоформленный")
                {


                    db.updateStatuzZakaz(Convert.ToInt32(current.id));
                    dataGrid1.ItemsSource = db.selectZakaz();

                    Excel.Application excelApp;
                    Excel.Workbooks excelappworkbooks;
                    Excel.Workbook excelappworkbook;
                    Excel.Sheets excelsheets;
                    Excel.Worksheet excelworksheet;
                    Excel.Range excelcells;

                    excelApp = new Excel.Application();
                    excelApp.Visible = true;
                    excelappworkbooks = excelApp.Workbooks;
                    excelApp.SheetsInNewWorkbook = 1;
                    excelappworkbook = excelappworkbooks.Add(Type.Missing);
                    excelsheets = excelappworkbook.Worksheets;
                    excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                    excelworksheet.Activate();

                    excelcells = (Excel.Range)excelworksheet.Cells[1, 1];
                    excelcells.Value2 = "Наименования товара";
                    excelcells = (Excel.Range)excelworksheet.Cells[1, 2];
                    excelcells.Value2 = "Количесиво товара";
                    excelcells = (Excel.Range)excelworksheet.Cells[1, 3];
                    excelcells.Value2 = "Размер товара";
                    excelcells = (Excel.Range)excelworksheet.Cells[1, 4];
                    excelcells.Value2 = "Цвет  товара";
                    excelcells = (Excel.Range)excelworksheet.Cells[1, 5];
                    excelcells.Value2 = "Артикуль  товара";

                    excelcells = (Excel.Range)excelworksheet.Cells[2, 1];
                    excelcells.Value2 = current.nameTovara;
                    excelcells = (Excel.Range)excelworksheet.Cells[2, 2];
                    excelcells.Value2 = current.numbeTovara;
                    excelcells = (Excel.Range)excelworksheet.Cells[2, 3];
                    excelcells.Value2 = current.sizeTovara;
                    excelcells = (Excel.Range)excelworksheet.Cells[2, 4];
                    excelcells.Value2 = current.colorTovara;
                    excelcells = (Excel.Range)excelworksheet.Cells[2, 5];
                    excelcells.Value2 = current.articul;
                }
                else
                    MessageBox.Show("Заказ уже оформлен");
            }
            catch
            {
                MessageBox.Show("Выберите заказ");
            }
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridZakaz current = dataGrid1.SelectedItem as DataGridZakaz;
                db.updateStatuzZakazFinish(Convert.ToInt32(current.id));
                dataGrid1.ItemsSource = db.selectZakaz();
            }
            catch
            {
                MessageBox.Show("Выберите заказ");
            }
        }





        private void DG_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = (Hyperlink)e.OriginalSource;
            Process.Start(new ProcessStartInfo(link.NavigateUri.AbsoluteUri));
        }




        //Статистика
        string activComboBoxTextStatus="";
        string activComboBoxTextUsers="";
        
        public string filtr()
        {
            if(activComboBoxTextUsers=="")
            {
                if(activComboBoxTextStatus=="")
                {
                    if(DatePicker1.Text=="" && DatePicker2.Text=="")
                    {
                        return "";
                    }
                    else
                    {
                        return "where dateZak BETWEEN '" + dateReverse( DatePicker1.Text) + "' and  '" + dateReverse(DatePicker2.Text) + "'";
                    }
                }
                else
                {
                    if (DatePicker1.Text == "" && DatePicker2.Text == "")
                    {
                        return "where status='" + activComboBoxTextStatus + "'";
                    }
                    else
                    {
                        return " where dateZak BETWEEN '" + dateReverse(DatePicker1.Text )+ "' and  '" + dateReverse(DatePicker2.Text) + "' and status='" + activComboBoxTextStatus + "'";
                    }
                }
            }
            else
            {
                if (activComboBoxTextStatus == "")
                {
                    if (DatePicker1.Text == "" && DatePicker2.Text == "")
                    {
                        return "where adminName='" + activComboBoxTextUsers + "'";
                    }
                    else
                    {
                        return "where dateZak  BETWEEN '" + dateReverse(DatePicker1.Text) + "' and  '" + dateReverse(DatePicker2.Text) + "' and adminName='"+ activComboBoxTextUsers + "'";
                    }
                }
                else
                {
                    if (DatePicker1.Text == "" && DatePicker2.Text == "")
                    {
                        return "where status='" + activComboBoxTextStatus + "' and adminName='"+ activComboBoxTextUsers + "'";
                    }
                    else
                    {
                        return "where dateZak BETWEEN '" + dateReverse(DatePicker1.Text) + "' and  '" + dateReverse(DatePicker2.Text) + "' and status='" + activComboBoxTextStatus + "' and adminName='"+ activComboBoxTextUsers + "'";
                    }
                }
            }
        }
        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excelApp;
            Excel.Workbooks excelappworkbooks;
            Excel.Workbook excelappworkbook;
            Excel.Sheets excelsheets;
            Excel.Worksheet excelworksheet;
            Excel.Range excelcells;

            excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelappworkbooks = excelApp.Workbooks;
            excelApp.SheetsInNewWorkbook = 1;
            excelappworkbook= excelappworkbooks.Add(Type.Missing);
            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
            excelworksheet.Activate();

            excelcells = (Excel.Range)excelworksheet.Cells[1, 1];
            excelcells.Value2 = "Наименования товара";
            excelcells = (Excel.Range)excelworksheet.Cells[1, 2];
            excelcells.Value2 = "Количесиво товара";
            excelcells = (Excel.Range)excelworksheet.Cells[1, 3];
            excelcells.Value2 = "Размер товара";
            excelcells = (Excel.Range)excelworksheet.Cells[1, 4];
            excelcells.Value2 = "Цвет  товара";
            excelcells = (Excel.Range)excelworksheet.Cells[1, 5];
            excelcells.Value2 = "Артикуль  товара";

            excelcells = (Excel.Range)excelworksheet.Cells[2, 1];
            excelcells.Value2 = "Наименования товара";
            excelcells = (Excel.Range)excelworksheet.Cells[2, 2];
            excelcells.Value2 = "Количесиво товара";
            excelcells = (Excel.Range)excelworksheet.Cells[2, 3];
            excelcells.Value2 = "Размер товара";
            excelcells = (Excel.Range)excelworksheet.Cells[2, 4];
            excelcells.Value2 = "Цвет  товара";
            excelcells = (Excel.Range)excelworksheet.Cells[2, 5];
            excelcells.Value2 = "Артикуль  товара";
            /*
            excelcells = (Excel.Range)excelworksheet.Cells[2, 6];
            Clipboard.SetDataObject(img, true);
            excelworksheet.Paste(excelcells, missing);
            Clipboard.Clear();*/

            //excelcells = (Excel.Range)excelworksheet.Shapes.AddPicture("C:\\csharp-xl-picture.JPG", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 50, 300, 45);

        }

        private void dataGridStatistika_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridStatistika.ItemsSource = db.selectZakaz();
            //DatePicker1.Text = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
        }
        private void buttonSortDate_Click(object sender, RoutedEventArgs e)
        {
            dataGridStatistika.ItemsSource = db.selectZakazFiltpOnlyDate(filtr());
            
        }
        private void comboBoxStatistika_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            if (selectedItem.Text == "Завершенные")
            {
                activComboBoxTextStatus = "Завершен";
                dataGridStatistika.ItemsSource = db.selectZakazFiltpOnlyDate(filtr());
            }
            else if (selectedItem.Text == "Все")
            {
                activComboBoxTextStatus = "";
                dataGridStatistika.ItemsSource = db.selectZakazFiltpOnlyDate(filtr());
            }
            else if (selectedItem.Text == "Оформленные")
            {
                activComboBoxTextStatus = "Оформленный";
                dataGridStatistika.ItemsSource = db.selectZakazFiltpOnlyDate(filtr());
            }
            else if (selectedItem.Text == "Неоформленные")
            {
                activComboBoxTextStatus = "Неоформленный";
                dataGridStatistika.ItemsSource = db.selectZakazFiltpOnlyDate(filtr());
            }
        }
        private void comboBoxStatistikaUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            activComboBoxTextUsers = selectedItem.Text;
        }
        //профил

        private void buttonCreateNewAdmin_Click(object sender, RoutedEventArgs e)
        {
            WindowForCreateNewAdmin newAdmin = new WindowForCreateNewAdmin();
            newAdmin.Show();
        }

        
    }
}
