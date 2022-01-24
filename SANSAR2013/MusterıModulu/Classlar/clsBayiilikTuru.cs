using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.MusterıModulu.Classlar
{
    class clsBayiilikTuru
    {
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.Classlar.Veritabani DBase = new SANSAR2013.Classlar.Veritabani();

        public void Ekle(string Bayiilik_Turu, string Aciklama)
        {
            string query = "INSERT INTO tbl_bayii_turleri (BAYIILIK_TURU,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + Bayiilik_Turu.ToUpper() + "','" + Aciklama.ToUpper() + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            DBase.Insert(query);
        }

        public DataTable Listele()
        {
            string query = "SELECT * FROM tbl_bayii_turleri";
            DataTable tablo = DBase.TabloCek(query);
            return tablo;
        }
        public void Guncelle(string BayiilikTuru_ID, string Bayiilik_Turu, string Aciklama)
        {
            string query = "UPDATE tbl_bayii_turleri SET BAYIILIK_TURU='" + Bayiilik_Turu.ToUpper() + "', ACIKLAMA='" + Aciklama.ToUpper() + "', EDIT_USER='" + AnaForm.UserId + "', EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE ID='" + BayiilikTuru_ID + "'";
            DBase.Isle(query);
        }
        public Boolean sorgu_sonucu(string BayiilikTuru)
        {
            IDataReader reader;
            string sonuc = "";

            string query = "SELECT * FROM tbl_bayii_turleri WHERE BAYIILIK_TURU='" + BayiilikTuru + "'";
            reader = DBase.DataOku(query);
            while (reader.Read())
            {
                sonuc = reader["BAYIILIK_TURU"].ToString();
            }
            reader.Close();

            if (sonuc == BayiilikTuru)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataRow Ac(string Id)
        {
            return DBase.SatirCek("SELECT * FROM tbl_bayii_turleri WHERE ID=" + Id);
        }
        public void Sil(string SecilenID)
        {
            string query = "DELETE FROM tbl_bayii_turleri WHERE ID='" + SecilenID + "'";
            DBase.Delete(query);
        }
        public string BayiilikTuruAl(string Id)
        {
            return Ac(Id)["BAYIILIK_TURU"].ToString();
        }
    }
}
