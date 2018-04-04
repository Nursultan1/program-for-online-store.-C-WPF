using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApplication3
{
    /// <summary>
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        string fileName;
        public Test()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog okno = new OpenFileDialog();
            okno.ShowDialog();
            fileName = okno.FileName;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DB testDB = new DB();
            testDB.INSERT(GetPhoto(fileName), "test.jpg");
        }
        public static byte[] GetPhoto(string fp)
        {
            byte[] imgData;
            using (System.IO.FileStream fs = new System.IO.FileStream(fp, FileMode.Open))
            {
                imgData = new byte[fs.Length];
                fs.Read(imgData, 0, imgData.Length);
            }
            return imgData;
        }
    }
}
