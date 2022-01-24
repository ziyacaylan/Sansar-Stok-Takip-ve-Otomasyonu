using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.Classlar
{
    class clsParaBirimi
    {
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.Classlar.Veritabani DBase = new SANSAR2013.Classlar.Veritabani();

        public void Ekle(string Stok_Birimi,string Kod, string Aciklama)
        {
            string query = "INSERT INTO tbl_para_birimleri (PARA_BIRIMI,KOD,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + Stok_Birimi.ToUpper() + "','" + Kod + "','" + Aciklama.ToUpper() + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            DBase.Insert(query);
        }

        public DataTable Listele()
        {
            string query = "SELECT * FROM tbl_para_birimleri";
            DataTable tablo = DBase.TabloCek(query);
            return tablo;
        }

        public void Guncelle(string Birim_ID, string Stok_Birimi,string Kod, string Aciklama)
        {
            string query = "UPDATE tbl_para_birimleri SET PARA_BIRIMI='" + Stok_Birimi.ToUpper() + "',KOD='"+Kod+"', ACIKLAMA='" + Aciklama.ToUpper() + "', EDIT_USER='" + AnaForm.UserId + "', EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE ID='" + Birim_ID + "'";
            DBase.Isle(query);
        }

        public DataRow Ac(string Id)
        {
            return DBase.SatirCek("SELECT * FROM tbl_para_birimleri WHERE ID=" + Id);
        }

        public Boolean sorgu_sonucu(string stok_birim_adi)
        {
            IDataReader reader;
            string sonuc = "";

            string query = "SELECT * FROM tbl_para_birimleri WHERE PARA_BIRIMI='" + stok_birim_adi + "'";
            reader = DBase.DataOku(query);
            while (reader.Read())
            {
                sonuc = reader["PARA_BIRIMI"].ToString();
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
        public Boolean TL_Sorgula(string kod)
        {
            IDataReader reader;
            string sonuc = "";

            string query = "SELECT * FROM tbl_para_birimleri WHERE KOD='" + kod + "'";
            reader = DBase.DataOku(query);
            while (reader.Read())
            {
                sonuc = reader["KOD"].ToString();
            }
            reader.Close();

            if (sonuc == kod)
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
            string query = "DELETE FROM tbl_para_birimleri WHERE ID='" + SecilenID + "'";
            DBase.Delete(query);
        }

        public string ParaBirimiAl(string Id)
        {
            //return Ac(Id)["KOD"].ToString();
            IDataReader reader;
            string sonuc = "";
            string query = "SELECT * FROM tbl_para_birimleri WHERE ID='" + Id + "'";
            reader = DBase.DataOku(query);
            while (reader.Read())
            {
                sonuc = reader["KOD"].ToString();
            }
            reader.Close();
            return sonuc;
        }
        public string Para_Birimi_ID_AL(string Para_Birimi)
        {
            string Urun_ID;
            string query = "SELECT * FROM tbl_para_birimleri WHERE KOD='" + Para_Birimi + "'";
            DataRow Satir = DBase.SatirCek(query);

            return Urun_ID = Satir["ID"].ToString();
        }
        public string ParaBirimiYukle_KOD(string ID)
        {
            IDataReader reader;
            string sonuc = "";
            string query = "SELECT * FROM tbl_para_birimleri WHERE ID='" + ID + "'";
            reader = DBase.DataOku(query);
            while (reader.Read())
            {
                sonuc = reader["KOD"].ToString();
            }
            reader.Close();
            return sonuc;
        }
        public string ParaBirimiYukle(string ID)
        {
            IDataReader reader;
            string sonuc = "";
            string query = "SELECT * FROM tbl_para_birimleri WHERE ID='" + ID + "'";
            reader = DBase.DataOku(query);
            while (reader.Read())
            {
                sonuc = reader["PARA_BIRIMI"].ToString();
            }
            reader.Close();
            return sonuc;
        }
        public Boolean ParaBirimleri_Kayit_Sorgula(string Adi)
        {
            IDataReader reader;
            string sonuc = "";
            string query = "SELECT * FROM tbl_para_birimleri WHERE PARA_BIRIMI='" + Adi + "'";
            reader = DBase.DataOku(query);
            while (reader.Read())
            {
                sonuc = reader["PARA_BIRIMI"].ToString();
            }
            reader.Close();

            if (sonuc == Adi)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataRow Para_Birim_SatirSayisi()
        {
            string query = "SELECT ID FROM tbl_para_birimleri ORDER BY ID DESC";
            DataRow drow = DBase.SatirCek(query);
            return drow;
        }
    }
}
