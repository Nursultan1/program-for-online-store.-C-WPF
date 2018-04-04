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
    /// Логика взаимодействия для WindowForAddNewZakaz.xaml
    /// </summary>
    public partial class WindowForAddNewZakaz : Window
    { 
        //картинка для загруски по умолчанию
        byte[] imgData = { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 201, 0, 0, 0, 107, 8, 2, 0, 0, 0, 82, 112, 49, 183, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 14, 195, 0, 0, 14, 195, 1, 199, 111, 168, 100, 0, 0, 4, 81, 73, 68, 65, 84, 120, 94, 237, 218, 235, 149, 155, 48, 20, 133, 209, 212, 69, 65, 174, 199, 213, 208, 140, 139, 153, 92, 244, 0, 73, 92, 100, 17, 56, 241, 44, 175, 111, 255, 202, 232, 253, 56, 99, 67, 146, 63, 63, 128, 6, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 202, 61, 217, 154, 31, 127, 28, 211, 243, 53, 88, 143, 111, 116, 227, 231, 214, 107, 126, 78, 41, 53, 143, 217, 75, 205, 235, 77, 61, 190, 203, 173, 223, 137, 57, 60, 143, 57, 21, 52, 222, 213, 227, 171, 144, 45, 168, 144, 45, 168, 144, 45, 168, 252, 154, 108, 217, 155, 192, 99, 138, 213, 102, 122, 60, 183, 199, 125, 255, 45, 115, 115, 248, 190, 185, 235, 152, 91, 190, 108, 174, 170, 96, 241, 154, 139, 5, 88, 213, 84, 191, 113, 188, 230, 180, 194, 208, 167, 108, 108, 139, 45, 26, 142, 172, 118, 215, 38, 156, 136, 87, 122, 161, 165, 191, 217, 241, 1, 47, 251, 29, 217, 178, 139, 178, 27, 74, 87, 185, 190, 111, 166, 195, 89, 122, 109, 215, 28, 79, 33, 159, 91, 174, 77, 63, 236, 89, 6, 194, 88, 203, 164, 219, 16, 211, 244, 140, 7, 62, 61, 83, 215, 102, 216, 118, 165, 86, 29, 11, 140, 69, 233, 177, 70, 127, 29, 63, 183, 28, 94, 109, 158, 162, 104, 109, 156, 82, 111, 11, 126, 233, 232, 102, 135, 167, 190, 70, 146, 173, 119, 234, 44, 132, 94, 78, 81, 110, 56, 63, 202, 202, 246, 182, 150, 198, 213, 231, 70, 43, 157, 247, 214, 195, 78, 187, 109, 159, 230, 43, 203, 83, 183, 114, 234, 109, 85, 85, 247, 106, 177, 39, 86, 235, 204, 176, 22, 214, 165, 110, 75, 183, 52, 149, 117, 55, 107, 198, 167, 190, 226, 243, 159, 91, 161, 176, 237, 145, 91, 238, 15, 38, 158, 128, 119, 96, 7, 154, 115, 180, 145, 157, 206, 203, 7, 231, 242, 201, 153, 126, 52, 105, 5, 101, 91, 167, 40, 218, 221, 232, 170, 183, 218, 102, 97, 198, 114, 103, 218, 82, 175, 229, 194, 43, 109, 202, 252, 205, 158, 153, 250, 138, 143, 103, 43, 151, 249, 142, 238, 209, 191, 45, 87, 121, 142, 246, 165, 209, 253, 6, 13, 94, 225, 209, 47, 116, 170, 39, 58, 204, 150, 123, 205, 65, 111, 181, 109, 167, 248, 137, 230, 13, 229, 15, 255, 174, 101, 103, 179, 227, 83, 95, 241, 241, 108, 197, 13, 141, 239, 39, 182, 63, 159, 173, 172, 215, 115, 185, 13, 91, 97, 120, 138, 79, 15, 125, 255, 45, 91, 249, 187, 210, 27, 170, 217, 66, 173, 215, 242, 104, 179, 227, 83, 95, 241, 75, 178, 213, 187, 241, 218, 217, 246, 229, 137, 165, 63, 122, 157, 195, 47, 185, 85, 173, 207, 82, 78, 144, 132, 217, 202, 215, 235, 15, 229, 15, 255, 166, 101, 250, 163, 59, 119, 217, 181, 63, 245, 21, 191, 229, 59, 209, 239, 50, 231, 109, 111, 226, 1, 248, 183, 229, 170, 78, 236, 224, 192, 157, 83, 253, 135, 108, 157, 169, 48, 219, 164, 246, 252, 191, 182, 112, 150, 226, 150, 13, 180, 76, 63, 28, 46, 107, 100, 234, 43, 62, 255, 44, 159, 118, 100, 133, 237, 17, 88, 243, 221, 72, 199, 247, 123, 164, 62, 177, 188, 132, 106, 0, 239, 80, 157, 137, 14, 231, 142, 21, 206, 154, 186, 171, 205, 179, 154, 98, 98, 111, 45, 94, 217, 72, 75, 119, 179, 139, 241, 169, 175, 184, 53, 91, 105, 113, 135, 171, 203, 123, 173, 235, 115, 169, 157, 65, 145, 175, 240, 236, 179, 31, 200, 31, 162, 39, 45, 106, 61, 95, 103, 4, 239, 80, 83, 179, 242, 90, 114, 207, 246, 170, 98, 119, 111, 69, 221, 213, 250, 167, 229, 173, 197, 43, 235, 182, 236, 109, 118, 49, 62, 245, 21, 55, 102, 235, 204, 255, 177, 217, 221, 78, 174, 41, 56, 201, 218, 134, 40, 99, 216, 99, 17, 141, 29, 138, 53, 109, 39, 123, 80, 98, 157, 242, 223, 186, 47, 183, 100, 27, 11, 229, 219, 250, 183, 217, 243, 115, 90, 179, 161, 168, 183, 218, 117, 97, 85, 87, 123, 248, 137, 165, 197, 226, 188, 45, 140, 183, 220, 111, 246, 196, 212, 215, 220, 147, 173, 117, 79, 149, 109, 233, 239, 234, 205, 114, 73, 249, 234, 118, 255, 222, 18, 120, 131, 244, 127, 199, 118, 61, 242, 140, 69, 69, 42, 178, 147, 205, 57, 88, 230, 182, 178, 28, 140, 34, 71, 177, 100, 122, 206, 246, 91, 148, 215, 106, 205, 139, 127, 158, 218, 116, 87, 187, 171, 12, 53, 94, 233, 133, 150, 254, 102, 199, 7, 188, 236, 214, 239, 196, 47, 183, 102, 203, 137, 18, 246, 200, 214, 56, 178, 117, 14, 217, 26, 71, 182, 206, 33, 91, 227, 200, 214, 57, 100, 107, 212, 219, 215, 96, 52, 200, 214, 136, 221, 107, 148, 185, 227, 77, 234, 187, 145, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 104, 252, 252, 252, 5, 41, 208, 105, 171, 3, 129, 183, 206, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 };
        int id; //id товара которого надо изменить
        string status; //статус изменяемого товара
        DB db = new DB();
        int otpKur;
        private bool flagForConst = true; //для опредения добавить новый продукт или изменить существуюший
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
        //Функция для получения изображения из байт массива
        public BitmapImage imageFunc(byte[] mass)
        {
            MemoryStream memorystream = new MemoryStream(mass, 0, mass.Length);
            memorystream.Position = 0;
            BitmapImage imgsource = new BitmapImage();
            imgsource.BeginInit();
            imgsource.CacheOption = BitmapCacheOption.OnLoad;
            imgsource.StreamSource = memorystream;
            imgsource.EndInit();
            return imgsource; // реальный Image
        }
        //конструктор по умолчанию
        public WindowForAddNewZakaz()
        {
            InitializeComponent();
            date.Text = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
        }

        public WindowForAddNewZakaz(int id, string nameTovra, string sizeTovara, string colorTovara, string articulTovara, byte[] arrayByteImgTovara )
        {
            InitializeComponent();
            textBoxIdTovara.Text = id.ToString();
            textBoxNameTovara.Text = nameTovra;
            textBoxSizeTovara.Text = sizeTovara;
            textBoxColorTovara.Text = colorTovara;
            articul.Text = articulTovara;
            ImgTovara.Source = imageFunc(arrayByteImgTovara);
        }

        //вызвын из контексной меню
        public WindowForAddNewZakaz(int id)
        {
            InitializeComponent();
            flagForConst = false;
            this.id = id;
            DataGridZakaz currentUpdateZakaz = db.selectZakaz(id);
            this.status = currentUpdateZakaz.status;

            string[] arrayAdres = currentUpdateZakaz.adresForUpdate.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
            this.adresStrana.Text = arrayAdres[0].Replace("Страна: ", "");
            this.AdresGorod.Text = arrayAdres[1].Replace(" город: ", "");
            this.adreskray.Text = arrayAdres[2].Replace(" край: ", "");
            this.adresOblast.Text = arrayAdres[3].Replace(" область: ", "");
            this.adresRayon.Text = arrayAdres[4].Replace(" район: ", "");
            this.adresUlitsa.Text = arrayAdres[5].Replace(" улица: ", "");
            this.adresDom.Text = arrayAdres[6].Replace(" дом: ", "");
            this.adresKorpus.Text = arrayAdres[7].Replace(" корпус: ", "");
            this.adresKvartira.Text = arrayAdres[8].Replace(" кв: ", "");
            adresComment.Text = currentUpdateZakaz.adresComment;

            this.date.Text = currentUpdateZakaz.dateZak;
            textBoxNameTovara.Text = currentUpdateZakaz.nameTovara;
            textBoxIdTovara.Text = currentUpdateZakaz.idTovara;
            articul.Text = currentUpdateZakaz.articul;
            textBoxSizeTovara.Text = currentUpdateZakaz.sizeTovara;
            textBoxColorTovara.Text = currentUpdateZakaz.colorTovara;
            textBoxNumbeTovara.Text = currentUpdateZakaz.numbeTovara;
            ImgTovara.Source = imageFunc(currentUpdateZakaz.imgTovara);
            imgData = currentUpdateZakaz.imgTovara;
            fio.Text = currentUpdateZakaz.fio;
            this.tel.Text = currentUpdateZakaz.tel;
            this.ssylka.Text = currentUpdateZakaz.ssylkaNaSosSeti;
            textBoxPriceTovara.Text = currentUpdateZakaz.priceTovara;
            this.skidka.Text = currentUpdateZakaz.skidka;    
            this.priceKur.Text = currentUpdateZakaz.priceKur;
            this.pricePochta.Text = currentUpdateZakaz.priceDeliveryPochta;
            textBoxIndex.Text = currentUpdateZakaz.index;
            this.trek.Text = currentUpdateZakaz.trek;
            this.predoplata.Text = currentUpdateZakaz.predOplata;
            this.comment.Text = currentUpdateZakaz.comment;
        }

        private void buttonForAddNewZakaz_Click(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked == true)
            {
                otpKur = 1;
            }
            else otpKur = 0;
            string adres = "Страна: " + adresStrana.Text.Trim() + ",$ город: " + AdresGorod.Text + ",$ край: " + adreskray.Text.Trim() + ",$ область: " + adresOblast.Text.Trim() + ",$ район: " + adresRayon.Text.Trim() + ",$ улица: " + adresUlitsa.Text.Trim() + ",$ дом: " + adresDom.Text.Trim() + ",$ корпус: " + adresKorpus.Text.Trim() + ",$ кв: " + adresKvartira.Text.Trim();
            if (flagForConst == false)
            {
                db.update(id, fio.Text,
                    adres,
                    adresComment.Text,
                    tel.Text,
                    ssylka.Text,
                    textBoxIdTovara.Text.Trim(),
                    textBoxNameTovara.Text.Trim(),
                    textBoxSizeTovara.Text.Trim(),
                    textBoxColorTovara.Text.Trim(),
                    textBoxNumbeTovara.Text.Trim(),
                    imgData,
                    articul.Text.Trim(),
                    textBoxPriceTovara.Text.Trim(),
                    skidka.Text.Trim(),
                    comment.Text,
                    otpKur,
                    priceKur.Text,
                    pricePochta.Text,
                    predoplata.Text.Trim(),
                    textBoxIndex.Text.Trim(),
                    trek.Text,
                    this.status,
                    dateReverse(date.Text));
            }
            else
            {
                db.insertZakaz(fio.Text,
                    adres,
                    adresComment.Text,
                    tel.Text,
                    ssylka.Text,
                    textBoxIdTovara.Text.Trim(),
                    textBoxNameTovara.Text.Trim(),
                    textBoxSizeTovara.Text.Trim(),
                    textBoxColorTovara.Text.Trim(),
                    textBoxNumbeTovara.Text.Trim(),
                    imgData,
                    articul.Text.Trim(),
                    textBoxPriceTovara.Text.Trim(),
                    skidka.Text.Trim(),
                    comment.Text,
                    otpKur,
                    priceKur.Text,
                    pricePochta.Text,
                    predoplata.Text.Trim(),
                    textBoxIndex.Text.Trim(),
                    trek.Text,
                    "Неоформленный",
                    dateReverse(date.Text));
            }
            DialogResult = true;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            priceKur.IsReadOnly = false;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            priceKur.Text = "0";
            priceKur.IsReadOnly = true;
        }
        

        private void buttonForAddImgTovZakaz_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog okno = new OpenFileDialog();
            okno.Filter = "(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (okno.ShowDialog() == true)
            {
                
                string fileName = okno.FileName;
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    imgData = new byte[fs.Length];
                    fs.Read(imgData, 0, imgData.Length);
                    ImgTovara.Source = imageFunc(imgData);
                }

            }
        }
    }
}
