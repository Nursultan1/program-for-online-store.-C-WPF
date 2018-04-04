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

namespace WpfApplication3
{
    /// <summary>
    /// Логика взаимодействия для WindowForCreateNewAdmin.xaml
    /// </summary>
    public partial class WindowForCreateNewAdmin : Window
    {
        DB db = new DB();
        public WindowForCreateNewAdmin()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            db.insertAdmin(textBoxLogin.Text, MainWindow.GetHashString(textBoxPassword.Text));

        }
    }
}
