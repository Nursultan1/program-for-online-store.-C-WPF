using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApplication3
{
    class DataGrid
    {

        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public string articulPost { get; set; }
        public string articul { get; set; }
        public int nalichi;
        public bool nalichi1=true;
        public string comment { get; set; }
        public byte[] arrayByteImgTovara;
        BitmapImage image { get; set; }
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
        public bool ButtonEnabled
        {
            get { return this.nalichi1; }

        }
        public DataGrid(int id,  string name, int price,  string size, string color, string articulPost, string articul,  int nalichi,  string comment,  byte[] image)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.size = size;
            this.color = color;
            this.articulPost = articulPost;
            this.articul = articul;
            this.comment = comment;
            this.nalichi = nalichi;
            if (nalichi == 0) {
                this.nalichi1 = false;
            }
            this.arrayByteImgTovara = image;
            this.image = imageFunc(image);
        }
        public BitmapImage dis
        {
            get { return this.image; }
        }
    }
}
