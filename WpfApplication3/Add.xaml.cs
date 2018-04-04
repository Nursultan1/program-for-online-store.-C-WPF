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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        byte[] imgData;
        string massbyte = "";
        DB db = new DB();
        private bool flag = true;
        private int id;
        public Add()
        {
            InitializeComponent();
            flag = true;
        }
        public Add(int id, string name, int price, string size,string color, string articulPost, string articul, int nalichi, string comment)
        {
            InitializeComponent();
            textBoxName.Text = name;
            textBoxPrice.Text = price.ToString();
            textBoxSize.Text = size;
            textBoxColor.Text = color;
            textBoxArticulPost.Text = articulPost;
            textBoxArticul.Text = articul;
            textBoxComment.Text = comment;
            if (nalichi == 0)
            {
                checkBox.IsChecked = false;
            }
                
            flag = false;
            this.id = id;
            
        }
        private void buttonAddAll_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Введите имя товарв");
            }
            else if (textBoxPrice.Text == "")
            {
                MessageBox.Show("Введите цену товара");
            }
            else
            {
                int nalichi = 1;
                if (checkBox.IsChecked == false)
                {
                    nalichi = 0;
                }
                if (flag)
                {
                    if (imgData == null)
                    {
                        MessageBox.Show("Загрузите картинку");
                    }
                    else
                    {
                        db.INSERT(textBoxName.Text, Convert.ToInt32(textBoxPrice.Text), textBoxSize.Text, textBoxColor.Text, textBoxArticulPost.Text, textBoxArticul.Text, nalichi, textBoxComment.Text, imgData);
                        MessageBox.Show(textBoxColor.Text);
                        this.DialogResult = true;
                    }
                }
                else
                {
                    if (imgData == null)
                    {
                        db.UPDATE(id,
                                  textBoxName.Text,
                                  Convert.ToInt32(textBoxPrice.Text),
                                  textBoxSize.Text,
                                  textBoxColor.Text,
                                  textBoxArticulPost.Text,
                                  textBoxArticul.Text,
                                  nalichi,
                                  textBoxComment.Text);
                        this.DialogResult = true;
                    }
                    else
                    {
                        db.UPDATE(id,
                            textBoxName.Text,
                            Convert.ToInt32(textBoxPrice.Text),
                            textBoxSize.Text,
                            textBoxColor.Text,
                            textBoxArticulPost.Text,
                            textBoxArticul.Text,
                            nalichi,
                            textBoxComment.Text,
                            imgData);
                        DialogResult = true;

                    }
                }
                //this.Close();
            }
        }
        private void textBoxPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void textBoxNalichi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void buttonOpenPictureForAdd_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog okno = new OpenFileDialog();
            okno.Filter = "(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (okno.ShowDialog() == true)
            {
                string fileName = okno.FileName;
                using (System.IO.FileStream fs = new System.IO.FileStream(fileName, FileMode.Open))
                {
                    imgData = new byte[fs.Length];
                    fs.Read(imgData, 0, imgData.Length);
                }
            } 
        }

        private void buttonClearForWindowAdd_Click(object sender, RoutedEventArgs e)
        {
            textBoxName.Clear();
            textBoxPrice.Clear();
            textBoxSize.Clear();
            textBoxArticulPost.Clear();
            textBoxArticul.Clear();
            textBoxComment.Clear();
        }

        private void textBoxSize_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}
