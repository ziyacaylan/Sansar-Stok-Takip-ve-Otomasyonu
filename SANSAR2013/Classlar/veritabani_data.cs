using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SANSAR2013.Classlar
{
    class veritabani_data
    {
        //MySqlDataReader okuyucu;
        private MySqlConnection connection;

        //private string query = "";
        private string parameter = "";
        private string value = "";
        private int t = 0;

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

        public void insert_parametre(string parameter, string value)
        {

            if (t == 0)
            {

                this.parameter = parameter;
                this.value = @"'" + value + "'";

            }
            else
            {

                this.parameter = parameter + "," + this.parameter;
                this.value = "'" + value + "'" + ",@" + this.value;
            }
            t++;

        }
        public void insert_parametreler()
        {
        
        }
    }
}
