using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    class Admin
    {
        public string name;
        public string password;
        public Admin(string name, string pass)
        {
            this.name = name;
            this.password = pass;
        }
        public Admin()
        {
        }
    }
}
