using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    class Img
    {
        public int id { get; private set; }
        public string fileName { get; private set; }
        public string titel { get; private set; }
        public byte[] data { get; private set; }
        public Img(int id, string fileName, string titel, byte[] data)
        {
            this.id = id;
            this.fileName = fileName;
            this.titel = titel;
            this.data = data;

        }
    }
}
