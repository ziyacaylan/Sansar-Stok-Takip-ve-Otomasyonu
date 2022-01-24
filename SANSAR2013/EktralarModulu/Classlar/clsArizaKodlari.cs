using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.EktralarModulu.Classlar
{
    class clsArizaKodlari
    {
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.Classlar.Veritabani DBase = new SANSAR2013.Classlar.Veritabani();

        public void Ekle(string Ariza_kodu,string Aciklama)
        {
            string query = "INSERT INTO tbl_ariza_kodlari (ARIZA_KODU,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + Ariza_kodu + "','" + Aciklama + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            DBase.Insert(query);
        }
        public void Guncelle(string SecilenID, string Ariza_kodu, string Aciklama)
        {
            string query = "UPDATE tbl_ariza_kodlari SET ARIZA_KODU='" + Ariza_kodu + "',ACIKLAMA='" + Aciklama + "',EDIT_USER='" + AnaForm.UserId + "',EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE ID='" + SecilenID + "'";
            DBase.Update(query);
        }
        public void Sil(string SecilenID)
        {
            string query = "DELETE FROM tbl_ariza_kodlari WHERE ID='" + SecilenID + "'";
            DBase.Delete(query);
        }
        public DataTable Listele()
        {
            string query = "SELECT * FROM tbl_ariza_kodlari";
            DataTable tablo = DBase.TabloCek(query);
            return tablo;
        }
        public DataRow Ac(string Id)
        {
            return DBase.SatirCek("SELECT * FROM tbl_ariza_kodlari WHERE ID=" + Id);
        }
        public string ArizaKodu_IsminiAl(string Id)
        {
            DataRow Satir;
            string query = "SELECT * FROM tbl_ariza_kodlari WHERE ID='" + Id + "'";
            Satir = DBase.SatirCek(query);
            try
            {
            string ali = Satir["ARIZA_KODU"].ToString();
            return ali;
            }
            catch (Exception)
            {

                string Ali = "";
                return Ali;
            }

        }
        public string Ariza_kodu_ID_AL(string Ariza_kodu)
        {
            string Urun_ID;
            string query = "SELECT * FROM tbl_ariza_kodlari WHERE TESLIM='" + Ariza_kodu + "'";
            DataRow Satir = DBase.SatirCek(query);

            return Urun_ID = Satir["ID"].ToString();
        }
        public int ArizaKodlariListeToplamı()
        {
            string query = "SELECT Count(Ariza_kodu) FROM tbl_ariza_kodlari";

            return DBase.Count(query);
        }
    }
}
