using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.DefolularStokgu.Classlar
{
    class clsDefoluGiris
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
  

        public DataRow StokBilgileri(string ID)
        {
            string query = "SELECT * FROM tbl_genel_stoklar WHERE ID='"+ID+"'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
        public void Defolu_EKLE(string TARIH,string STOK_KODU,string MODEL_NO,string URUN_GRUBU,string MIKTAR,string STOK_BIRIMI,string STOK_TURU,string ETIKET_RENGI,string DEPO_NO,string RAF_NO,string GOZ_NO,string ACIKLAMA,string KOLI_NO)
        {
            string query = "INSERT INTO tbl_defolu_stoklari (TARIH,STOK_KODU,MODEL_NO,URUN_GRUBU,MIKTAR,STOK_BIRIMI,STOK_TURU,ETIKET_RENGI,DEPO_NO,RAF_NO,GOZ_NO,KOLI_NO,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + Formatlar.IngilizceTarihKısaFormat(TARIH) + "','" + STOK_KODU + "','" + MODEL_NO + "','" + URUN_GRUBU + "','" + MIKTAR + "','" + STOK_BIRIMI + "','" + STOK_TURU + "','" + ETIKET_RENGI + "','" + DEPO_NO + "','" + RAF_NO + "','" + GOZ_NO + "','" + KOLI_NO + "','" + ACIKLAMA + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            Dbase.Insert(query);
        }
        public void Defolu_GUNCELLE(string ID, string TARIH, string STOK_KODU, string MODEL_NO, string URUN_GRUBU, string MIKTAR, string STOK_BIRIMI, string STOK_TURU, string ETIKET_RENGI, string DEPO_NO, string RAF_NO, string GOZ_NO, string ACIKLAMA, string KOLI_NO)
        {
            string query = "UPDATE tbl_defolu_stoklari SET TARIH='" + Formatlar.IngilizceTarihKısaFormat(TARIH) + "',STOK_KODU='" + STOK_KODU + "',MODEL_NO='" + MODEL_NO + "',URUN_GRUBU='" + URUN_GRUBU + "',MIKTAR='" + MIKTAR + "',STOK_BIRIMI='" + STOK_BIRIMI + "',STOK_TURU='" + STOK_TURU + "',ETIKET_RENGI='" + ETIKET_RENGI + "',DEPO_NO='" + DEPO_NO + "',RAF_NO='" + RAF_NO + "',GOZ_NO='" + GOZ_NO + "',KOLI_NO='" + KOLI_NO + "',ACIKLAMA='" + ACIKLAMA + "',EDIT_USER='" + AnaForm.UserId + "',EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE ID='" + ID + "'";
            Dbase.Insert(query);
        }
        public DataRow DefoluBilgileri(string ID)
        {
            string query = "SELECT * FROM tbl_defolu_stoklari WHERE ID='"+ID+"'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
    }
}
