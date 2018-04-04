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
    /// Логика взаимодействия для WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        MainWindow MainWindow = new MainWindow();
        public WindowLogin()
        {
            InitializeComponent();
            ///на Время
            MainWindow = new MainWindow();
            MainWindow.Show();
            this.Hide();
            //на время
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxLogin.Text == "admin")
            {
                if (textBoxPassword.Text == "admin")
                {
                    MainWindow = new MainWindow();
                    MainWindow.Show();
                    this.Hide();
                }
                else
                    labelPassword.Content="Не правильный логин или пароль";
            }
            else
                labelPassword.Content = "Не правильный логин или пароль";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
