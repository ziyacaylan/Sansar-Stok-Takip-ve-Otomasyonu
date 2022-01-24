using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.TeknikServisModulu.ServisGirisi.Classlar
{
    class clsServisGirisi
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();

        public DataRow MusteriBilgileri(string musteri_ID)
        {
            string query = "SELECT * FROM tbl_musteriler WHERE ID='" + musteri_ID + "'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
        public DataRow MusteriBilgileriCEK(string musteri_Kodu)
        {
            string query = "SELECT * FROM tbl_musteriler WHERE MUSTERI_KODU='" + musteri_Kodu + "'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
        public void ServisGirisEKLE(string TIPI, string SERVIS_NO, string SERVIS_GIR_TARIH, string GIRIS_IRSALIYE_NO, string MUSTERI_KODU, string FIRMA_ADI, string TESLIM_ALAN, string TESLIM_SEKLI, string ACIKLAMA,DataTable TabloArizalilar)
        {
            string query = "INSERT INTO tbl_arizalilar (TIPI,SERVIS_NO,SERVIS_GIR_TARIH,GIRIS_IRSALIYE_NO,MUSTERI_KODU,FIRMA_ADI,TESLIM_ALAN,TESLIM_SEKLI,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + TIPI + "','" + SERVIS_NO + "','" + Formatlar.IngilizceTarihKısaFormat(SERVIS_GIR_TARIH) + "','" + GIRIS_IRSALIYE_NO + "','" + MUSTERI_KODU + "','" + FIRMA_ADI + "','" + TESLIM_ALAN + "','" + TESLIM_SEKLI + "','" + ACIKLAMA + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            Dbase.Insert(query);

            EkleArizali_Icerik(SERVIS_NO, MUSTERI_KODU, TabloArizalilar);
        }
        void EkleArizali_Icerik(string SERVIS_NO, string MUSTERI_KODU, DataTable Tablo_Icerik)
        {
            string stok_kodu,model_no,miktar,stok_birimi,urun_seri_no,garanti_durumu,aksesuarlar,sikayet,aciklama;

            for (int i = 0; i < Tablo_Icerik.Rows.Count; i++)
            {
                stok_kodu = Tablo_Icerik.Rows[i]["STOK_KODU"].ToString();
                model_no = Tablo_Icerik.Rows[i]["MODEL_NO"].ToString();
                miktar = Tablo_Icerik.Rows[i]["MIKTAR"].ToString();
                stok_birimi = Tablo_Icerik.Rows[i]["STOK_BIRIMI"].ToString();
                urun_seri_no = Tablo_Icerik.Rows[i]["URUN_SERI_NO"].ToString();
                garanti_durumu = Tablo_Icerik.Rows[i]["GARANTI_DURUMU"].ToString();
                aksesuarlar = Tablo_Icerik.Rows[i]["AKSESUARLAR"].ToString();
                sikayet = Tablo_Icerik.Rows[i]["SIKAYET"].ToString();
                aciklama = Tablo_Icerik.Rows[i]["ACIKLAMA"].ToString();

                string query = "INSERT INTO tbl_arizali_icerik (SERVIS_NO,MUSTERI_KODU,STOK_KODU,MODEL_NO,MIKTAR,STOK_BIRIMI,URUN_SERI_NO,GARANTI_DURUMU,AKSESUARLAR,SIKAYET,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + SERVIS_NO + "','" + MUSTERI_KODU + "','" + stok_kodu + "','" + model_no + "','" + miktar + "','" + stok_birimi + "','" + urun_seri_no + "','" + garanti_durumu + "','" + aksesuarlar + "','" + sikayet + "','" + aciklama + "','"+AnaForm.UserId+"','"+Formatlar.IngiliceTarihFormati(DateTime.Now.ToString())+"')";
                Dbase.Insert(query);
            }            
        }
        void ArizaliGirisSIL(string SERVIS_NO)
        {
            string query = "DELETE FROM tbl_arizalilar WHERE SERVIS_NO='" + SERVIS_NO + "'";
            Dbase.Delete(query);
        }
        public void IcerikSIL(string SERVIS_NO)
        {
            string query = "DELETE FROM tbl_arizali_icerik WHERE SERVIS_NO='" + SERVIS_NO + "'";
            Dbase.Delete(query);
        }
        public void ArizaliSIL(string SERVIS_NO)
        {
            string query = "DELETE FROM tbl_arizalilar WHERE SERVIS_NO='" + SERVIS_NO + "'";
            Dbase.Delete(query);
        }
        public void ServisGirisGUNCELLE(string TIPI, string SERVIS_NO, string SERVIS_GIR_TARIH, string GIRIS_IRSALIYE_NO, string MUSTERI_KODU, string FIRMA_ADI, string TESLIM_ALAN, string TESLIM_SEKLI, string ACIKLAMA, DataTable TabloArizalilar)
        {
            string query = "UPDATE tbl_arizalilar SET SERVIS_GIR_TARIH='" + Formatlar.IngilizceTarihKısaFormat(SERVIS_GIR_TARIH) + "',GIRIS_IRSALIYE_NO='" + GIRIS_IRSALIYE_NO + "',MUSTERI_KODU='" + MUSTERI_KODU + "',FIRMA_ADI='" + FIRMA_ADI + "',TESLIM_ALAN='" + TESLIM_ALAN + "',TESLIM_SEKLI='" + TESLIM_SEKLI + "',ACIKLAMA='" + ACIKLAMA + "',EDIT_USER='" + AnaForm.UserId + "',EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE SERVIS_NO='" + SERVIS_NO + "'";
            Dbase.Insert(query);

            IcerikSIL(SERVIS_NO);
            EkleArizali_Icerik(SERVIS_NO, MUSTERI_KODU, TabloArizalilar);
        }
        public DataTable ArizaliIcerikCEK(string SERVIS_NO)
        {
            string query = "SELECT * FROM tbl_arizali_icerik WHERE SERVIS_NO='" + SERVIS_NO + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataRow ServisGirisCEK(string servis_no)
        {
            string query = "SELECT * FROM tbl_arizalilar WHERE SERVIS_NO='" + servis_no + "'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
    }
}

