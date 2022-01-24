using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace SANSAR2013.Classlar
{
   public  class Veritabani
    {
       MySqlDataReader okuyucu;
       private MySqlConnection connection;

       //private string server;
       //private string database;
       //private string user;
       //private string password;

        //public MySqlConnection Baglanti_2()
        //{
        //    string provider = "";
        //    MySqlConnection connection = new MySqlConnection(provider);
        //    connection.Open();
        //    return connection;
        //}
        //Initialize values
        //private void Initialize()
        //{
        //    server = "localhost";
        //    database = "connectcsharptomysql";
        //    user = "username";
        //    password = "password";
        //    string connectionString;
        //    connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        //    connection = new MySqlConnection(connectionString);
        //}
        //Veri Tabanı Bağlantısını Açma

        private bool Baglan()
        {
            string provider = "SERVER=" + SANSAR2013.Properties.Settings.Default.ServerIdAdresi + ";" + "DATABASE=" + SANSAR2013.Properties.Settings.Default.VeritabaniAdi + ";" + "UID=" + SANSAR2013.Properties.Settings.Default.VeritabaniKullaniciAdi + ";" + "PASSWORD=" + SANSAR2013.Properties.Settings.Default.VeritabaniSifresi + ";";
            connection = new MySqlConnection(provider);
            try
            {
                connection.Open();
                AnaForm.ErisimBilgisiHatasi = false;
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Bağlantı Kurulamadı, sistem yöneticinize başvurun...");
                        AnaForm.ErisimBilgisiHatasi = true;
                        break;

                    case 1045:
                        MessageBox.Show("Geçersiz Kullanıcı Adı ve Şifre, Tekrar Deneyiniz...");
                        AnaForm.ErisimBilgisiHatasi = true;
                        break;
                }
                return false;
            }
        }

        //Bağlantıyı Kapatma
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(string query)
        {
           //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.Baglan() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(string query)
        {
            //string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.Baglan() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        public void Resim_Isle(string query,string RESIM,byte[] resim_byte)
        {
            if (this.Baglan() == true)
            {
                MySqlCommand islem = new MySqlCommand(query, this.connection);
                islem.Parameters.AddWithValue("@RESIM", resim_byte);
                islem.ExecuteNonQuery();
                this.CloseConnection();
            }

        }

        //Delete statement
        public void Delete(string query)
        {
            //string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.Baglan() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Count statement
        public int Count(string query)
        {
            //string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.Baglan() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

       //Satır Çek
        public DataRow SatirCek(string query)
        {
            DataRow satir;
            try
            {
                satir = TabloCek(query).Rows[0];
                return satir;
            }
            catch (Exception)
            {

                return satir = null;
            }

        }

       //Tablo Çek
        public DataTable TabloCek(string query)
        {
            DataTable tb = new DataTable();
            //Open Connection
            if (this.Baglan() == true)
            {

                MySqlDataAdapter adap = new MySqlDataAdapter(query, connection);
                adap.Fill(tb);

                //close Connection
                this.CloseConnection();

                return tb;
            }
            else
            {
                return tb;
            }
        }
        public DataSet DataSetCEK(string query)
        {
            DataSet ds = new DataSet();
            //Open Connection
            if (this.Baglan() == true)
            {

                MySqlDataAdapter adap = new MySqlDataAdapter(query, connection);
                adap.Fill(ds);

                //close Connection
                this.CloseConnection();

                return ds;
            }
            else
            {
                return ds;
            }
        }
       //Bütün kayıt,güncelleme,silme işlemleri birarada kodu
        public void Isle(string query)
        {
            //string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.Baglan() == true)
            {
                MySqlCommand islem = new MySqlCommand(query, this.connection);
                islem.ExecuteNonQuery();
                this.CloseConnection();
            }

        }
        public string  DegerDondur(string query)
        {
            //string query = "DELETE FROM tableinfo WHERE name='John Smith'";
            string deger="0";
            if (this.Baglan() == true)
            {
                MySqlCommand islem = new MySqlCommand(query, this.connection);
                deger = islem.ExecuteScalar().ToString();
                this.CloseConnection();                
            }
            //if (deger=="-1")
            //{
            //    deger = "0";
            //}
            return deger;
        }
        public MySqlDataReader DataOku(string query)
        {
            
            if (this.Baglan()==true )
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    okuyucu = command.ExecuteReader();
                }

                catch (Exception e)
                {
                    MessageBox.Show("Sorgunuzu kontrol Ediniz." + e.Message);
                }
            }

            return okuyucu;

        }
   }
}
