using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql;
using System.Windows.Media.Imaging;
using System.IO;

namespace WpfApplication3
{
    class DB
    {
        MySqlConnection conn;
        MySqlCommand cmd;

        public DB()
        {
            string connStr = "server=127.0.0.1;user=root;database=store;password=12345";
            conn = new MySqlConnection(connStr);
        }
        public BitmapImage image(byte[] mass)
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

        public void INSERT(string name, int price, string size,string color, string articulPost, string articul, int nalichi, string comment, byte[] imgData)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO producty(name, price, size, color, articulPost, articul, img, nalichi, comment) VALUES(@name, @price, @size, @color,@articulPost, @articul, @img, @nalichi, @comment)", conn);
            command.Parameters.Add("@name", MySqlDbType.VarChar,500).Value = name;
            command.Parameters.Add("@price", MySqlDbType.Int32).Value = price;
            command.Parameters.Add("@size", MySqlDbType.VarChar, 1000).Value = size;
            command.Parameters.Add("@color", MySqlDbType.VarChar, 1000).Value = color;
            command.Parameters.Add("@articulPost", MySqlDbType.VarChar, 500).Value = articulPost;
            command.Parameters.Add("@articul", MySqlDbType.VarChar,500).Value = articul;
            command.Parameters.Add("@img", MySqlDbType.MediumBlob, imgData.Length).Value = imgData;
            command.Parameters.Add("@nalichi", MySqlDbType.VarChar,500).Value = nalichi;
            command.Parameters.Add("@comment", MySqlDbType.Text).Value = comment;
            command.ExecuteNonQuery();
            conn.Close();

        }
        public void INSERT(byte[] v1, string v2)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO image(imgData,name) Values(@imgData,@name)",conn);
            command.Parameters.Add("@imgData", MySqlDbType.MediumBlob, v1.Length).Value=v1;
            command.Parameters.Add("@name", MySqlDbType.VarChar, 500).Value = v2;
            conn.Open();
            command.ExecuteNonQuery();

        }

        public List<DataGrid> SELECT()
        {
            conn.Open();
            string query = "SELECT * FROM producty";
            cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<DataGrid> list = new List<DataGrid>();
            while (reader.Read())
            {
                list.Add(new DataGrid(
                    Convert.ToInt32(reader["id"]),
                    reader["name"].ToString(),
                    Convert.ToInt32(reader["price"]), 
                    reader["size"].ToString(),
                    reader["color"].ToString(),
                    reader["articulPost"].ToString(), 
                    reader["articul"].ToString(), 
                    Convert.ToInt32(reader["nalichi"]), 
                    reader["comment"].ToString(),
                    (byte[])reader["img"]
                    
                    ));
            }
            conn.Close();
            return list;
        }
        public List<Img> Select(int id)
        {
            conn.Open();
            List<Img> images = new List<Img>();
            string query ="SELECT id,name,img FROM producty where id="+id;
            cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int idP = reader.GetInt32(0);
                string filename = reader.GetString(1)+".jpg";
                string title = reader.GetString(1);
                byte[] data = (byte[])reader.GetValue(2);

                Img image = new Img(idP, filename, title, data);
                images.Add(image);
            }
            conn.Close();
            return images;
        }
        public void DELETE(int id)
        {
            conn.Open();
            string query = "delete from producty where id=" + id + "";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void UPDATE(int id,  string name, int price, string size, string color, string articulPost, string articul, int nalichi, string comment, byte[] imgData)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand("UPDATE producty set name=@name, price=@price, size=@size, color=@color articulPost=@articulPost, articul=@articul, img=@img, nalichi=@nalichi, comment=@comment where id=" + id + "", conn);
            command.Parameters.Add("@name", MySqlDbType.VarChar,500).Value = name;
            command.Parameters.Add("@price", MySqlDbType.Int32).Value = price;
            command.Parameters.Add("@size", MySqlDbType.VarChar, 1000).Value = size;
            command.Parameters.Add("@color", MySqlDbType.VarChar, 1000).Value = color;
            command.Parameters.Add("@articulPost", MySqlDbType.VarChar, 500).Value = articulPost;
            command.Parameters.Add("@articul", MySqlDbType.VarChar,500).Value = articul;
            command.Parameters.Add("@img", MySqlDbType.MediumBlob, imgData.Length).Value = imgData;
            command.Parameters.Add("@nalichi", MySqlDbType.VarChar,500).Value = nalichi;
            command.Parameters.Add("@comment", MySqlDbType.Text).Value = comment;
            command.ExecuteNonQuery();
            conn.Close();

        }
        public void UPDATE(int id, string name, int price, string size, string color, string articulPost, string articul, int nalichi, string comment)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand("UPDATE producty set name=@name, price=@price, size=@size, articulPost=@articulPost, articul=@articul, nalichi=@nalichi, comment=@comment where id="+id+"", conn);
            command.Parameters.Add("@name", MySqlDbType.VarChar, 500).Value = name;
            command.Parameters.Add("@price", MySqlDbType.Int32).Value = price;
            command.Parameters.Add("@size", MySqlDbType.VarChar, 1000).Value = size;
            command.Parameters.Add("@color", MySqlDbType.VarChar, 1000).Value = color;
            command.Parameters.Add("@articulPost", MySqlDbType.VarChar, 500).Value = articulPost;
            command.Parameters.Add("@articul", MySqlDbType.VarChar, 500).Value = articul;
            command.Parameters.Add("@nalichi", MySqlDbType.VarChar, 500).Value = nalichi;
            command.Parameters.Add("@comment", MySqlDbType.Text).Value = comment;
            command.ExecuteNonQuery();
            conn.Close();

        }

        //заказ

        public void insertZakaz(
            string fio, 
            string adres, 
            string adresComment, 
            string tel, 
            string ssylka, 
            string articul,
            string skidka,
            string comment, 
            int otpKur,
            string price_kur, 
            string predoplata, 
            string trek, 
            string status,
            string date)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO zakaz(fio, adres, adres_comment, mob_tel, ssylka, articul, skidka, comment, otp_kur, price_kur,predoplata,trek,status,dateZak)"+
                                                    " VALUES(@fio, @adres, @adres_comment, @mob_tel, @ssylka, @articul, @skidka, @comment, @otp_kur, @price_kur,@predoplata,@trek,@status,@dateZak)", conn);
            command.Parameters.Add("@fio", MySqlDbType.VarChar, 500).Value = fio;
            command.Parameters.Add("@adres", MySqlDbType.VarChar, 1000).Value = adres;
            command.Parameters.Add("@adres_comment", MySqlDbType.VarChar, 1000).Value = adresComment;
            command.Parameters.Add("@mob_tel", MySqlDbType.VarChar, 50).Value = tel;
            command.Parameters.Add("@ssylka", MySqlDbType.VarChar, 1100).Value = ssylka;
            command.Parameters.Add("@articul", MySqlDbType.VarChar, 1000).Value = articul;
            command.Parameters.Add("@skidka", MySqlDbType.VarChar, 500).Value = skidka;
            command.Parameters.Add("@comment", MySqlDbType.VarChar, 1000).Value = comment;
            command.Parameters.Add("@otp_kur", MySqlDbType.Int32, 10).Value = otpKur;
            command.Parameters.Add("@price_kur", MySqlDbType.VarChar, 500).Value = price_kur;
            command.Parameters.Add("@predoplata", MySqlDbType.VarChar, 500).Value = predoplata;
            command.Parameters.Add("@trek", MySqlDbType.VarChar, 1000).Value = trek;
            command.Parameters.Add("@status", MySqlDbType.VarChar, 50).Value = status;
            command.Parameters.Add("@dateZak", MySqlDbType.VarChar, 500).Value = date;
            command.ExecuteNonQuery();
            conn.Close();
        }



        //Новый заказ
        public void insertZakaz(
            string fio,
            string adres,
            string adresComment,
            string tel,
            string ssylka,
            string idTovata,
            string nameTovara,
            string sizeTovara,
            string colorTovara,
            string numbeTovara,
            byte[] imgTovara,
            string articul,
            string priceTovara,
            string skidka,
            string comment,
            int otpKur,
            string price_kur,
            string price_poch,
            string predoplata,
            string index,
            string trek,
            string status,
            string date)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO zakaz(fio, adres, adres_comment, mob_tel, ssylka, id_tovara, name_tovara, size_tovara, color_tovara, numbe_tovara, img_tovara,  articul, price_tovara, skidka, comment, otp_kur, price_kur,price_pochta,predoplata,index_tovara, trek,status,dateZak)" +
                                                    " VALUES('"+fio+"','"+adres+"', '"+adresComment+"', '"+tel+"', '" + ssylka+ "', '" + idTovata+ "', '" + nameTovara+ "', '" + sizeTovara+ "', '" + colorTovara+ "', '" +numbeTovara+ "',@img_tovara,'" +articul + "','"+priceTovara+"','" +skidka+ "','" +comment+"','"+otpKur+ "','"+price_kur+ "','"+price_poch+"','"+predoplata+ "','"+index+ "','"+trek+ "','"+status+ "','"+date+"')", conn);
            command.Parameters.Add("@img_tovara", MySqlDbType.MediumBlob, imgTovara.Length).Value = imgTovara;
            command.ExecuteNonQuery();
            conn.Close();
        }

        public List<DataGridZakaz> selectZakaz()
        {
            conn.Open();
            string query = "SELECT * FROM zakaz";
            cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<DataGridZakaz> list = new List<DataGridZakaz>();
            try
            {
                while (reader.Read())
                {
                    list.Add(new DataGridZakaz(
                        Convert.ToInt32(reader["id"]),
                        reader["fio"].ToString(),
                        reader["adres"].ToString(),
                        reader["adres_comment"].ToString(),
                        reader["mob_tel"].ToString(),
                        reader["ssylka"].ToString(),
                        reader["id_tovara"].ToString(),
                        reader["name_tovara"].ToString(),
                        reader["size_tovara"].ToString(),
                        reader["color_tovara"].ToString(),
                        reader["numbe_tovara"].ToString(),
                        reader["img_tovara"],
                        reader["articul"].ToString(),
                        reader["price_tovara"].ToString(),
                        reader["skidka"].ToString(),
                        reader["comment"].ToString(),
                        reader["otp_kur"].ToString(),
                        reader["price_kur"].ToString(),
                        reader["price_pochta"].ToString(),
                        reader["predoplata"].ToString(),
                        reader["index_tovara"].ToString(),
                        reader["trek"].ToString(),
                        reader["status"].ToString(),
                        reader["dateZak"].ToString()
                        ));
                }
            }
            catch
            {
            }
            conn.Close();
            return list;
        }


        //Возвращает только один заказ для изменения
        public DataGridZakaz selectZakaz(int id)
        {
            conn.Open();
            string query = "SELECT * FROM zakaz where id='"+id+"'";
            cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataGridZakaz list = new DataGridZakaz();
            try
            {
                while (reader.Read())
                {
                    list=new DataGridZakaz(
                        Convert.ToInt32(reader["id"]),
                        reader["fio"].ToString(),
                        reader["adres"].ToString(),
                        reader["adres_comment"].ToString(),
                        reader["mob_tel"].ToString(),
                        reader["ssylka"].ToString(),
                        reader["id_tovara"].ToString(),
                        reader["name_tovara"].ToString(),
                        reader["size_tovara"].ToString(),
                        reader["color_tovara"].ToString(),
                        reader["numbe_tovara"].ToString(),
                        reader["img_tovara"],
                        reader["articul"].ToString(),
                        reader["price_tovara"].ToString(),
                        reader["skidka"].ToString(),
                        reader["comment"].ToString(),
                        reader["otp_kur"].ToString(),
                        reader["price_kur"].ToString(),
                        reader["price_pochta"].ToString(),
                        reader["predoplata"].ToString(),
                        reader["index_tovara"].ToString(),
                        reader["trek"].ToString(),
                        reader["status"].ToString(),
                        reader["dateZak"].ToString()
                        );
                }
            }
            catch
            {
            }
            conn.Close();
            return list;
        }

       

        public List<DataGridZakaz> selectZakaz(string status)
        {
            conn.Open();
            string query = "SELECT * FROM zakaz where status='"+status+"'";
            cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<DataGridZakaz> list = new List<DataGridZakaz>();
            while (reader.Read())
            {
                list.Add(new DataGridZakaz(
                        Convert.ToInt32(reader["id"]),
                        reader["fio"].ToString(),
                        reader["adres"].ToString(),
                        reader["adres_comment"].ToString(),
                        reader["mob_tel"].ToString(),
                        reader["ssylka"].ToString(),
                        reader["id_tovara"].ToString(),
                        reader["name_tovara"].ToString(),
                        reader["size_tovara"].ToString(),
                        reader["color_tovara"].ToString(),
                        reader["numbe_tovara"].ToString(),
                        reader["img_tovara"],
                        reader["articul"].ToString(),
                        reader["price_tovara"].ToString(),
                        reader["skidka"].ToString(),
                        reader["comment"].ToString(),
                        reader["otp_kur"].ToString(),
                        reader["price_kur"].ToString(),
                        reader["price_pochta"].ToString(),
                        reader["predoplata"].ToString(),
                        reader["index_tovara"].ToString(),
                        reader["trek"].ToString(),
                        reader["status"].ToString(),
                        reader["dateZak"].ToString()
                        ));
            }
            conn.Close();
            return list;
        }
        public void updateStatuzZakaz(int id)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand("UPDATE zakaz set status='Оформленный' where id=" + id + "", conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void updateStatuzZakazFinish(int id)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand("UPDATE zakaz set status='Завершен' where id=" + id + "", conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        
        public void update(
            int id,
            string fio,
            string adres,
            string adresComment,
            string tel,
            string ssylka,
            string idTovata,
            string nameTovara,
            string sizeTovara,
            string colorTovara,
            string numbeTovara,
            byte[] imgTovara,
            string articul,
            string priceTovara,
            string skidka,
            string comment,
            int otpKur,
            string price_kur,
            string price_poch,
            string predoplata,
            string index,
            string trek,
            string status,
            string date)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand("UPDATE zakaz set fio='"+fio+ "', adres='"+adres+ "', adres_comment='"+adresComment+ "', mob_tel='"+tel+ "', ssylka='"+ssylka+"'" +
                ",id_tovara='"+idTovata+ "',name_tovara='"+nameTovara+ "',size_tovara='"+sizeTovara+ "',color_tovara='"+colorTovara+ "',numbe_tovara='"+numbeTovara+
                "',img_tovara=@img_tovara,  articul='" + articul+ "',price_tovara='"+priceTovara+ "', skidka='"+skidka+"', comment='"+comment+ "', otp_kur='"+otpKur+ "', price_kur='"+price_kur+ "',price_pochta='"+price_poch+ "',predoplata='"+predoplata+ "',index_tovara='"+index+ "',trek='"+trek+ "',status='"+status+ "',dateZak='"+date+"' where id='" + id + "'", conn);
            command.Parameters.Add("@img_tovara", MySqlDbType.MediumBlob, imgTovara.Length).Value = imgTovara;
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void deleteZakaz(int id)
        {
            conn.Open();
            string query = "delete from zakaz where id=" + id + "";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        

        public List<DataGridZakaz> selectZakazFiltpOnlyDate(string filtr)
        {
            conn.Open();
            string query = "SELECT * FROM zakaz  "+filtr+ "";
            cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<DataGridZakaz> list = new List<DataGridZakaz>();
            while (reader.Read())
            {
                list.Add(new DataGridZakaz(
                    Convert.ToInt32(reader["id"]),
                    reader["fio"].ToString(),
                    reader["adres"].ToString(),
                    reader["adres_comment"].ToString(),
                    reader["mob_tel"].ToString(),
                    reader["ssylka"].ToString(),
                    reader["articul"].ToString(),
                    reader["skidka"].ToString(),
                    reader["comment"].ToString(),
                    reader["otp_kur"].ToString(),
                    reader["price_kur"].ToString(),
                    reader["predoplata"].ToString(),
                    reader["trek"].ToString(),
                    reader["status"].ToString(),
                    reader["dateZak"].ToString()
                    ));
            }
            conn.Close();
            return list;
        }
        ///новый/

        
        //авторизация регистрация
        public Admin selectAdmin(string login)
        {
            conn.Open();
            string query = "SELECT * FROM zakaz where login='" + login + "'";
            cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            Admin list = new Admin();
            try
            {
                while (reader.Read())
                {
                    list = new Admin(
                        reader["login"].ToString(),
                        reader["password"].ToString()
                        );
                }
            }
            catch
            {}
            conn.Close();
            return list;
        }
        public void insertAdmin(string login, string password)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO admins(login, password) VALUES('"+login+"', '"+password+"')", conn);
            command.ExecuteNonQuery();
            conn.Close();
        }


        //все для плагинации
        public int numbeProduct()
        {
            conn.Open();
            string query = "SELECT COUNT(*) FROM producty";
            cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            int i=0;
            try
            {
                while (reader.Read())
                {
                    i =Convert.ToInt32( reader[0]);
                }
            }
            catch
            { }
            conn.Close();
            return i;
        }
    }


}
