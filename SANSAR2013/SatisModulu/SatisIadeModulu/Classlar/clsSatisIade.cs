using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.SatisModulu.SatisIadeModulu.Classlar
{
    class clsSatisIade
    {
        private string stokMIKTAR="";

        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();

        public Boolean IadeKaydiYapıldımı(string MusteriKodu, string FirmaAdi, string FaturaNO,string SiparisNO)
        {
            string query = "SELECT * FROM tbl_siparis_hareket WHERE FATURA_NO='" + FaturaNO + "' AND MUSTERI_KODU='" + MusteriKodu + "' AND FIRMA_ADI='" + FirmaAdi + "' AND SIPARIS_NO='" + SiparisNO + "'";
            DataRow drow = Dbase.SatirCek(query);
            if (drow == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        void SatisIadeKalemleriEkle(string Tarih,string SiparisNO,string MusteriKodu, DataTable Liste)
        {
            string Turu, Stok_Kodu, Model_no, Stok_birim, Aciklama;
            int Miktar;
            for (int i = 0; i <= Liste.Rows.Count - 1; i++)
            {
                Turu = Liste.Rows[i]["TURU"].ToString();
                Stok_Kodu = Liste.Rows[i]["STOK_KODU"].ToString();
                Model_no = Liste.Rows[i]["MODEL_NO"].ToString();
                Miktar = Convert.ToInt32(Liste.Rows[i]["MIKTAR"].ToString());
                Stok_birim = Liste.Rows[i]["STOK_BIRIMI"].ToString();
                Aciklama = Liste.Rows[i]["ACIKLAMA"].ToString();

                string query = "INSERT INTO tbl_siparis_hareket_icerik (TARIH,SIPARIS_NO,MUSTERI_KODU,TURU,STOK_KODU,MODEL_NO,MIKTAR,STOK_BIRIMI,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + Formatlar.IngilizceTarihKısaFormat(Tarih) + "','" + SiparisNO + "','" + MusteriKodu + "','" + Turu + "','" + Stok_Kodu + "','" + Model_no + "','" + Miktar + "','" + Stok_birim + "','" + Aciklama + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
                Dbase.Insert(query);
            }
        }
        public void SatisIadeKaydet(string Tarih,string Tipi,string SiparisNO,string FaturaNO,string MusteriKodu,string FirmaAdi,string TeslimSekli,string Aciklama,string Stok_Ekleme_Durumu,int SipKalemAdet,DataTable TabloKalemler)
        {
            string query = "INSERT INTO tbl_siparis_hareket (TARIH,TIPI,SIPARIS_NO,FATURA_NO,MUSTERI_KODU,FIRMA_ADI,TESLIM_SEKLI,ACIKLAMA,KDV_EKLIMI,SIP_KALEM_ADET,SAVE_USER,SAVE_DATE) VALUES ('" + Formatlar.IngilizceTarihKısaFormat(Tarih) + "','" + Tipi + "','" + SiparisNO + "','" + FaturaNO + "','" + MusteriKodu + "','" + FirmaAdi + "','" + TeslimSekli + "','" + Aciklama + "','" + Stok_Ekleme_Durumu + "','" + SipKalemAdet + "','" + Convert.ToInt32(AnaForm.UserId) + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            Dbase.Insert(query);

            SatisIadeKalemleriEkle(Tarih, SiparisNO, MusteriKodu, TabloKalemler);
        }
        string StokMiktarCEK(string stokKODU)
        {
            string query = "SELECT* FROM tbl_genel_stoklar  WHERE STOK_KODU='"+stokKODU+"'";
            DataRow drow = Dbase.SatirCek(query);
            if (drow != null)
            {
                stokMIKTAR = drow["STOK_MIKTAR"].ToString();
                return stokMIKTAR;
            }
            else
            {
              return   stokMIKTAR = "0";
            }
        }
        void stok_iade_ekle(string toplam, string stok_Kodu)
        {
            string query = "UPDATE tbl_genel_stoklar SET  STOK_MIKTAR='" + toplam + "' WHERE STOK_KODU='" + stok_Kodu + "'";
            Dbase.Update(query);
        }
        void SatisIadeKalemlerini_STOGA_Ekle(string Tarih, string SiparisNO, string MusteriKodu, DataTable Liste)
        {
            string Turu, Stok_Kodu, Model_no, Stok_birim, Aciklama;
            int Miktar;
            for (int i = 0; i <= Liste.Rows.Count - 1; i++)
            {
                Turu = Liste.Rows[i]["TURU"].ToString();
                Stok_Kodu = Liste.Rows[i]["STOK_KODU"].ToString();
                Model_no = Liste.Rows[i]["MODEL_NO"].ToString();
                Miktar = Convert.ToInt32(Liste.Rows[i]["MIKTAR"].ToString());
                Stok_birim = Liste.Rows[i]["STOK_BIRIMI"].ToString();
                Aciklama = Liste.Rows[i]["ACIKLAMA"].ToString();

                string query = "INSERT INTO tbl_stok_hareket_icerik (TARIH,SIPARIS_NO,MUSTERI_KODU,TURU,STOK_KODU,MODEL_NO,MIKTAR,STOK_BIRIMI,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + Formatlar.IngilizceTarihKısaFormat(Tarih) + "','" + SiparisNO + "','" + MusteriKodu + "','" + Turu + "','" + Stok_Kodu + "','" + Model_no + "','" + Miktar + "','" + Stok_birim + "','" + Aciklama + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
                Dbase.Insert(query);

                //stok işleme merkezı*******************************
                int stoktaki_miktar = Convert.ToInt32(StokMiktarCEK(Stok_Kodu));
                if (Turu == "GENEL STOK")
                {
                 int toplam =stoktaki_miktar + Miktar;

                stok_iade_ekle(Convert.ToString(toplam), Stok_Kodu);                   
                }

                //stok işleme merkezı*******************************
            }
        }
        public void SatisIade_STOK_Kaydet(string Tarih, string Tipi, string SiparisNO, string FaturaNO, string MusteriKodu, string FirmaAdi, string TeslimSekli, string Aciklama, string Stok_Ekleme_Durumu, int SipKalemAdet, DataTable TabloKalemler)
        {
            string query = "INSERT INTO tbl_stok_hareket (TARIH,TIPI,SIPARIS_NO,FATURA_NO,MUSTERI_KODU,FIRMA_ADI,TESLIM_SEKLI,ACIKLAMA,KDV_EKLIMI,SIP_KALEM_ADET,SAVE_USER,SAVE_DATE) VALUES ('" + Formatlar.IngilizceTarihKısaFormat(Tarih) + "','" + Tipi + "','" + SiparisNO + "','" + FaturaNO + "','" + MusteriKodu + "','" + FirmaAdi + "','" + TeslimSekli + "','" + Aciklama + "','" + Stok_Ekleme_Durumu + "','" + SipKalemAdet + "','" + Convert.ToInt32(AnaForm.UserId) + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            Dbase.Insert(query);

            SatisIadeKalemlerini_STOGA_Ekle(Tarih, SiparisNO, MusteriKodu, TabloKalemler);
        }

        public void SatisIadeKalemleriniSil(string SiparisNO, string MusteriKodu)
        {
            string query = "DELETE FROM tbl_siparis_hareket_icerik WHERE SIPARIS_NO='" + SiparisNO + "' AND MUSTERI_KODU='"+MusteriKodu+"'";
            Dbase.Delete(query);
        }
        public void SatisIadeSil(string SiparisNO,string MusteriKodu)
        {
            string query = "DELETE FROM tbl_siparis_hareket WHERE SIPARIS_NO='" + SiparisNO + "' AND MUSTERI_KODU='" + MusteriKodu + "'";
            Dbase.Delete(query);
        }
        public void SatiIadeGuncelle(string Tarih, string Tipi, string SiparisNO, string FaturaNO, string MusteriKodu, string FirmaAdi, string TeslimSekli, string Aciklama, string Stok_Ekleme_Durumu, int SipKalemAdet, DataTable TabloKalemler)
        {
            string query = "UPDATE tbl_siparis_hareket SET TARIH='" + Formatlar.IngilizceTarihKısaFormat(Tarih) + "',TIPI='" + Tipi + "',SIPARIS_NO='" + SiparisNO + "',FATURA_NO='" + FaturaNO + "',MUSTERI_KODU='" + MusteriKodu + "',FIRMA_ADI='" + FirmaAdi + "',TESLIM_SEKLI='" + TeslimSekli + "',ACIKLAMA='" + Aciklama + "',KDV_EKLIMI='" + Stok_Ekleme_Durumu + "',SIP_KALEM_ADET='" + SipKalemAdet + "',EDIT_USER='" + Convert.ToInt32(AnaForm.UserId) + "',EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE SIPARIS_NO='" + SiparisNO + "'";
            Dbase.Update(query);

            SatisIadeKalemleriniSil(SiparisNO, MusteriKodu);
            SatisIadeKalemleriEkle(Tarih, SiparisNO, MusteriKodu, TabloKalemler);
        }
        public DataRow IadeBilgileriniCEK(string KayitNO, Boolean ekleme_durumu)
        {
            if (ekleme_durumu)
            {
                string query1 = "SELECT * FROM tbl_stok_hareket WHERE SIPARIS_NO='" + KayitNO + "'";
                DataRow drow1 = Dbase.SatirCek(query1);
                return drow1;
            }
            else
            {
                string query = "SELECT * FROM tbl_siparis_hareket WHERE SIPARIS_NO='" + KayitNO + "'";
                DataRow drow = Dbase.SatirCek(query);
                return drow;
            }
        }
        public DataRow MusteriBilgileri(string musteriKodu)
        {
            string query = "SELECT * FROM tbl_musteriler WHERE MUSTERI_KODU='"+musteriKodu+"'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
        public DataTable SatisIade_Kalemleri_CEK(string KayitNO)
        {
            string query = "SELECT * FROM tbl_siparis_hareket_icerik WHERE SIPARIS_NO='" + KayitNO + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            if (Tablo.Rows.Count > 0)
            {
                return Tablo;
            }
            else
            {
                string query1 = "SELECT * FROM tbl_stok_hareket_icerik WHERE SIPARIS_NO='" + KayitNO + "'";
                Tablo = Dbase.TabloCek(query1);
                return Tablo;
            }
        }

        public Boolean Stok_Eklimi(string KayitNO)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE SIPARIS_NO='" + KayitNO + "' AND KDV_EKLIMI='"+"E"+"'";
            DataRow drow = Dbase.SatirCek(query);
            if (drow == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
