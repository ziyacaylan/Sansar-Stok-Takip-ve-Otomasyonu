using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.TeknikServisModulu.TS_OlayModulu.Classlar
{
    class clsTS_Olaylar
    {
        SANSAR2013.Classlar.Veritabani Dbase=new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        TeknikServisModulu.ServisGirisi.Classlar.clsServisGirisi ServisGiris = new ServisGirisi.Classlar.clsServisGirisi();

        public DataRow ServisBilgileriniCEK(string servis_no)
        {
            string query = "SELECT * FROM tbl_arizalilar WHERE SERVIS_NO='" + servis_no + "'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
        public DataRow ServisCikisBilgileriCEK(string servis_no)
        {
            string query = "SELECT * FROM tbl_arizalilar_gonderilen WHERE SERVIS_NO='" + servis_no + "'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
        public DataTable Arizali_Cikis_Icerik_CEK(string servis_no)
        {
            string query = "SELECT * FROM tbl_arizali_icerik_gonderilen WHERE SERVIS_NO='" + servis_no + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataTable Arizali_Icerik_CEK(string servis_no)
        {
            string query = "SELECT * FROM tbl_arizali_icerik WHERE SERVIS_NO='" + servis_no + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataRow MusteriBilgileri(string musteri_kodu)
        {
            string query = "SELECT * FROM tbl_musteriler WHERE MUSTERI_KODU='" + musteri_kodu + "'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
        void EkleArizali_Icerik(string SERVIS_NO, string MUSTERI_KODU, DataTable Tablo_Icerik)
        {
            string stok_kodu, model_no, miktar, stok_birimi, urun_seri_no, garanti_durumu, aksesuarlar, sikayet, aciklama,yapilan_islem,servis_aciklama,ariza_kodu,tamir_kapsami,fiyat,para_birim;

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
                yapilan_islem = Tablo_Icerik.Rows[i]["YAPILAN_ISLEM"].ToString();
                servis_aciklama = Tablo_Icerik.Rows[i]["SERVIS_ACIKLAMA"].ToString();
                ariza_kodu = Tablo_Icerik.Rows[i]["ARIZA_KODU"].ToString();
                tamir_kapsami = Tablo_Icerik.Rows[i]["TAMIR_KAPSAMI"].ToString();
                fiyat = Tablo_Icerik.Rows[i]["FIYAT"].ToString();
                para_birim = Tablo_Icerik.Rows[i]["PARA_BIRIM"].ToString();

                string query = "INSERT INTO tbl_arizali_icerik (SERVIS_NO,MUSTERI_KODU,STOK_KODU,MODEL_NO,MIKTAR,STOK_BIRIMI,URUN_SERI_NO,GARANTI_DURUMU,AKSESUARLAR,SIKAYET,ACIKLAMA,YAPILAN_ISLEM,SERVIS_ACIKLAMA,ARIZA_KODU,TAMIR_KAPSAMI,FIYAT,PARA_BIRIM,SAVE_USER,SAVE_DATE) VALUES ('" + SERVIS_NO + "','" + MUSTERI_KODU + "','" + stok_kodu + "','" + model_no + "','" + miktar + "','" + stok_birimi + "','" + urun_seri_no + "','" + garanti_durumu + "','" + aksesuarlar + "','" + sikayet + "','" + aciklama + "','"+yapilan_islem+"','"+servis_aciklama+"','"+ariza_kodu+"','"+tamir_kapsami+"','"+fiyat+"','"+para_birim+"','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
                Dbase.Insert(query);
            }
        }

        public void ServisOlayGUNCELLE(string TIPI, string SERVIS_NO, string MUSTERI_KODU, string ISLEM_YAPAN, string SERVIS_CIK_TARIH, string CIKIS_IRSALIYE_NO, string GONDERILME_SEKLI, string SERVIS_ACIKLAMA, DataTable TabloArizalilar)
        {
            string query = "UPDATE tbl_arizalilar SET SERVIS_CIK_TARIH='" + Formatlar.IngilizceTarihKısaFormat(SERVIS_CIK_TARIH) + "',CIKIS_IRSALIYE_NO='" + CIKIS_IRSALIYE_NO + "', ISLEM_YAPAN='" + ISLEM_YAPAN + "',GONDERILME_SEKLI='" + GONDERILME_SEKLI + "',SERVIS_ACIKLAMA='" + SERVIS_ACIKLAMA + "',EDIT_USER='" + AnaForm.UserId + "',EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE SERVIS_NO='" + SERVIS_NO + "'";
            Dbase.Insert(query);

            ServisGiris.IcerikSIL(SERVIS_NO);
            EkleArizali_Icerik(SERVIS_NO, MUSTERI_KODU, TabloArizalilar);
        }
        public void CikisArizaliİcerik(string SERVIS_NO, string MUSTERI_KODU, DataTable Tablo_Icerik)
        {
            string stok_kodu, model_no, miktar, stok_birimi, urun_seri_no, garanti_durumu, aksesuarlar, sikayet, aciklama, yapilan_islem, servis_aciklama, ariza_kodu, tamir_kapsami, fiyat, para_birim;

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
                yapilan_islem = Tablo_Icerik.Rows[i]["YAPILAN_ISLEM"].ToString();
                servis_aciklama = Tablo_Icerik.Rows[i]["SERVIS_ACIKLAMA"].ToString();
                ariza_kodu = Tablo_Icerik.Rows[i]["ARIZA_KODU"].ToString();
                tamir_kapsami = Tablo_Icerik.Rows[i]["TAMIR_KAPSAMI"].ToString();
                fiyat = Tablo_Icerik.Rows[i]["FIYAT"].ToString();
                para_birim = Tablo_Icerik.Rows[i]["PARA_BIRIM"].ToString();

                string query = "INSERT INTO tbl_arizali_icerik_gonderilen (SERVIS_NO,MUSTERI_KODU,STOK_KODU,MODEL_NO,MIKTAR,STOK_BIRIMI,URUN_SERI_NO,GARANTI_DURUMU,AKSESUARLAR,SIKAYET,ACIKLAMA,YAPILAN_ISLEM,SERVIS_ACIKLAMA,ARIZA_KODU,TAMIR_KAPSAMI,FIYAT,PARA_BIRIM,SAVE_USER,SAVE_DATE) VALUES ('" + SERVIS_NO + "','" + MUSTERI_KODU + "','" + stok_kodu + "','" + model_no + "','" + miktar + "','" + stok_birimi + "','" + urun_seri_no + "','" + garanti_durumu + "','" + aksesuarlar + "','" + sikayet + "','" + aciklama + "','" + yapilan_islem + "','" + servis_aciklama + "','" + ariza_kodu + "','" + tamir_kapsami + "','" + fiyat + "','" + para_birim + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
                Dbase.Insert(query);
            }
        }
        
        void IcerikSIL(string SERVIS_NO)
        {
            string query = "DELETE FROM tbl_arizali_icerik WHERE SERVIS_NO='" + SERVIS_NO + "'";
            Dbase.Delete(query);
        }
        void ServisGirisSil(string SERVIS_NO)
        {
            string query = "DELETE FROM tbl_arizalilar WHERE SERVIS_NO='" + SERVIS_NO + "'";
            Dbase.Delete(query);
        }
        public void ServisCikisYAP(string TIPI, string SERVIS_NO, string SERVIS_GIR_TARIH, string GIRIS_IRSALIYE_NO, string SERVIS_CIK_TARIH, string CIKIS_IRSALIYE_NO, string MUSTERI_KODU, string FIRMA_ADI, string TESLIM_ALAN, string ISLEM_YAPAN, string TESLIM_SEKLI, string GONDERILME_SEKLI, string ACIKLAMA, string SERVIS_ACIKLAMA, DataTable TabloArizalilar)
        {

            string query = "INSERT INTO tbl_arizalilar_gonderilen (TIPI,SERVIS_NO,SERVIS_GIR_TARIH,GIRIS_IRSALIYE_NO,SERVIS_CIK_TARIH,CIKIS_IRSALIYE_NO,MUSTERI_KODU,FIRMA_ADI,TESLIM_ALAN,ISLEM_YAPAN,TESLIM_SEKLI,GONDERILME_SEKLI,ACIKLAMA,SERVIS_ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + TIPI + "','" + SERVIS_NO + "','" + Formatlar.IngilizceTarihKısaFormat(SERVIS_GIR_TARIH) + "','" + GIRIS_IRSALIYE_NO + "','" + Formatlar.IngilizceTarihKısaFormat(SERVIS_CIK_TARIH) + "','" + CIKIS_IRSALIYE_NO + "','" + MUSTERI_KODU + "','" + FIRMA_ADI + "','" + TESLIM_ALAN + "','" + ISLEM_YAPAN + "','" + TESLIM_SEKLI + "','" + GONDERILME_SEKLI + "','" + ACIKLAMA + "','" + SERVIS_ACIKLAMA + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            Dbase.Insert(query);

            CikisArizaliİcerik(SERVIS_NO, MUSTERI_KODU, TabloArizalilar);
            IcerikSIL(SERVIS_NO);
            ServisGirisSil(SERVIS_NO);
        }
    }
}
