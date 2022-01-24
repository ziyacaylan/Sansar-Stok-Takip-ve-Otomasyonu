using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.Classlar
{
    class clsIskontoGrubu
    {
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.Classlar.Veritabani DBase = new SANSAR2013.Classlar.Veritabani();

        public DataTable Listele()
        {
            string query = "SELECT * FROM tbl_iskonto_grubu";
            DataTable tablo = DBase.TabloCek(query);
            return tablo;
        }

        public void Ekle(string Iskonto_Grubu, string Aciklama)
        {
            string query = "INSERT INTO tbl_iskonto_grubu (ISKONTO_GRUBU,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + Iskonto_Grubu.ToUpper() + "','" + Aciklama.ToUpper() + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            DBase.Insert(query);
        }

        public void Guncelle(string Birim_ID, string Iskonto_Grubu, string Aciklama)
        {
            string query = "UPDATE tbl_iskonto_grubu SET ISKONTO_GRUBU='" + Iskonto_Grubu.ToUpper() + "', ACIKLAMA='" + Aciklama.ToUpper() + "', EDIT_USER='" + AnaForm.UserId + "', EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE ID='" + Birim_ID + "'";
            DBase.Isle(query);
        }

        public DataRow Ac(string Id)
        {
            return DBase.SatirCek("SELECT * FROM tbl_iskonto_grubu WHERE ID=" + Id);
        }

        public Boolean sorgu_sonucu(string iskonto_grup_adi)
        {
            IDataReader reader;
            string sonuc = "";

            string query = "SELECT * FROM tbl_iskonto_grubu WHERE ISKONTO_GRUBU='" + iskonto_grup_adi + "'";
            reader = DBase.DataOku(query);
            while (reader.Read())
            {
                sonuc = reader["ISKONTO_GRUBU"].ToString();
            }
            reader.Close();

            if (sonuc == iskonto_grup_adi)
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
            string query = "DELETE FROM tbl_stok_birimi WHERE ID='" + SecilenID + "'";
            DBase.Delete(query);
        }

        public string StokBirimiAl(string Id)
        {
            return Ac(Id)["ISKONTO_GRUBU"].ToString();
        }

        public string Iskonto_Grubu_ID_AL(string Iskonto_Grubu)
        {
            string Urun_ID;
            string query = "SELECT * FROM tbl_iskonto_grubu WHERE ISKONTO_GRUBU='" + Iskonto_Grubu + "'";
            DataRow Satir = DBase.SatirCek(query);

            return Urun_ID = Satir["ID"].ToString();
        }
    }
}
