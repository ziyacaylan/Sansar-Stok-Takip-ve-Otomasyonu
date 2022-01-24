using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.Classlar
{
    class clsEtiketRengi
    {
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.Classlar.Veritabani DBase = new SANSAR2013.Classlar.Veritabani();

        public void Ekle(string Stok_Birimi, string Aciklama)
        {
            string query = "INSERT INTO tbl_etiketler (ETIKET_RENGI,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + Stok_Birimi.ToUpper() + "','" + Aciklama.ToUpper() + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            DBase.Insert(query);
        }

        public DataTable Listele()
        {
            string query = "SELECT * FROM tbl_etiketler";
            DataTable tablo = DBase.TabloCek(query);
            return tablo;
        }

        public void Guncelle(string Birim_ID, string Stok_Birimi, string Aciklama)
        {
            string query = "UPDATE tbl_etiketler SET ETIKET_RENGI='" + Stok_Birimi.ToUpper() + "', ACIKLAMA='" + Aciklama.ToUpper() + "', EDIT_USER='" + AnaForm.UserId + "', EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE ID='" + Birim_ID + "'";
            DBase.Isle(query);
        }

        public DataRow Ac(string Id)
        {
            return DBase.SatirCek("SELECT * FROM tbl_etiketler WHERE ID=" + Id);
        }

        public Boolean sorgu_sonucu(string stok_birim_adi)
        {
            IDataReader reader;
            string sonuc = "";

            string query = "SELECT * FROM tbl_etiketler WHERE ETIKET_RENGI='" + stok_birim_adi + "'";
            reader = DBase.DataOku(query);
            while (reader.Read())
            {
                sonuc = reader["ETIKET_RENGI"].ToString();
            }
            reader.Close();

            if (sonuc == stok_birim_adi)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Sil(string SecilenID)
        {
            string query = "DELETE FROM tbl_etiketler WHERE ID='" + SecilenID + "'";
            DBase.Delete(query);
        }

        public string StokBirimiAl(string Id)
        {
            return Ac(Id)["ETIKET_RENGI"].ToString();
        }
        public string Etiket_Rengi_ID_AL(string Etiket_Rengi)
        {
            string Urun_ID;
            string query = "SELECT * FROM tbl_etiketler WHERE ETIKET_RENGI='" + Etiket_Rengi + "'";
            DataRow Satir = DBase.SatirCek(query);

            return Urun_ID = Satir["ID"].ToString();
        }
    }
}
