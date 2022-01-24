using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.SiparisModulu.Classlar
{
    class clsSiparisHareketIcerik
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();

        public void Ekle(string Tarih, string SiparisNo, string Fis_no, string Musteri_kodu, DataTable Liste)
        {
            string Tipi, Turu, Stok_Kodu, Model_no, Stok_birim, Para_birimi;
            int Miktar;
            decimal Birim_Fiyat, Isk1, Isk2, Isk3, Kdv, ISK_BIR_FIYAT_USD, ISK_BIR_FIYAT_TL, TOPLAM_USD,Toplam;
            for (int i = 0; i <= Liste.Rows.Count - 1; i++)
            {
                Tipi = Liste.Rows[i]["TIPI"].ToString();
                Turu = Liste.Rows[i]["TURU"].ToString();
                Stok_Kodu = Liste.Rows[i]["STOK_KODU"].ToString();
                Model_no = Liste.Rows[i]["MODEL_NO"].ToString();
                Miktar = Convert.ToInt32(Liste.Rows[i]["MIKTAR"].ToString());
                Stok_birim = Liste.Rows[i]["STOK_BIRIMI"].ToString();
                Birim_Fiyat = Convert.ToDecimal(Liste.Rows[i]["BIRIM_FIYAT"].ToString());
                Para_birimi = Liste.Rows[i]["PARA_BIRIMI"].ToString();
                Isk1 = Convert.ToDecimal(Liste.Rows[i]["ISK_1"].ToString());
                Isk2 = Convert.ToDecimal(Liste.Rows[i]["ISK_2"].ToString());
                Isk3 = Convert.ToDecimal(Liste.Rows[i]["ISK_3"].ToString());
                Kdv = Convert.ToDecimal(Liste.Rows[i]["KDV"].ToString());
                Toplam = Convert.ToDecimal(Liste.Rows[i]["TOPLAM"].ToString());
                ISK_BIR_FIYAT_USD = Convert.ToDecimal(Liste.Rows[i]["ISK_BIR_FIYAT_USD"].ToString());
                ISK_BIR_FIYAT_TL = Convert.ToDecimal(Liste.Rows[i]["ISK_BIR_FIYAT_TL"].ToString());
                TOPLAM_USD = Convert.ToDecimal(Liste.Rows[i]["TOPLAM_USD"].ToString());

                string query = "INSERT INTO tbl_siparis_hareket_icerik (TARIH,SIPARIS_NO,FIS_NO,MUSTERI_KODU,TIPI,TURU,STOK_KODU,MODEL_NO,MIKTAR,STOK_BIRIMI,BIRIM_FIYAT,PARA_BIRIMI,ISK_1,ISK_2,ISK_3,KDV,ISK_BIR_FIYAT_USD ,ISK_BIR_FIYAT_TL,TOPLAM_USD,TOPLAM,SAVE_USER,SAVE_DATE) VALUES ('" + Formatlar.IngilizceTarihKısaFormat(Tarih) + "','" + SiparisNo + "','" + Fis_no + "','" + Musteri_kodu + "','" + Tipi + "','" + Turu + "','" + Stok_Kodu + "','" + Model_no + "','" + Miktar + "','" + Stok_birim + "','" + Birim_Fiyat.ToString().Replace(",", ".") + "','" + Para_birimi + "','" + Isk1.ToString().Replace(",", ".") + "','" + Isk2.ToString().Replace(",", ".") + "','" + Isk3.ToString().Replace(",", ".") + "','" + Kdv.ToString().Replace(",", ".") + "','" + ISK_BIR_FIYAT_USD.ToString().Replace(",", ".") + "','" + ISK_BIR_FIYAT_TL.ToString().Replace(",", ".") + "','" + TOPLAM_USD.ToString().Replace(",", ".") + "','" + Toplam.ToString().Replace(",", ".") + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
                //'" + FaturaNo + "','" + StokKodu + "','" + GcKodu + "'," + Miktar + "," + Fiyat.ToString().Replace(",", ".") + "," + Isk1.ToString().Replace(",", ".") + "," + Isk2.ToString().Replace(",", ".") + "," + Kdv.ToString().Replace(",", ".") + ",'"+Tipi+"','"+Tarih+"',"+KariyerMuhasebeSeti.frmAnaForm.UserId+"";
                Dbase.Insert(query);
            }
        }

        public void Sil_Icerik(string SiparisNo)
        {
            string query = "DELETE FROM tbl_siparis_hareket_icerik WHERE SIPARIS_NO='" + SiparisNo + "'";
            Dbase.Delete(query);
        }
        private int Stok_Miktar_Cek(string StokKodu)
        {
            int StokMiktar = 0;
            string query = "SELECT STOK_MIKTAR FROM tbl_genel_stoklar WHERE STOK_KODU='" + StokKodu + "'";
            StokMiktar = Convert.ToInt32(Dbase.SatirCek(query)["STOK_MIKTAR"].ToString());
            return StokMiktar;
        }
        private int StokHareketYap(string StokKodu, int miktar)
        {
            int stok_miktar = Stok_Miktar_Cek(StokKodu);
            int sonuc = stok_miktar - miktar;
            return sonuc;
        }
        private void StokGuncelle(string StokKodu, int sonMiktar)
        {
            string query = "UPDATE tbl_genel_stoklar SET STOK_MIKTAR='" + sonMiktar + "' WHERE STOK_KODU='" + StokKodu + "'";
            Dbase.Update(query);
        }
        void SiparisHareketSil(string siparis_no)
        {
            string query = "DELETE  FROM tbl_siparis_hareket WHERE SIPARIS_NO='" + siparis_no + "'";
            Dbase.Delete(query);
        }
        void SiparisHareketİcerik_SIL(string siparis_no)
        {
            string query = "DELETE  FROM tbl_siparis_hareket_icerik WHERE SIPARIS_NO='" + siparis_no + "'";
            Dbase.Delete(query);
        }
        public void Stok_Hareket_Icerik_Ekle(string Tarih, string Kayit_no, string Fis_no, string Musteri_kodu, DataTable Liste)
        {
            string Tipi, Turu, Stok_Kodu, Model_no, Stok_birim, Para_birimi;
            int Miktar;
            decimal Birim_Fiyat, Isk1, Isk2, Isk3, Kdv, ISK_BIR_FIYAT_USD, ISK_BIR_FIYAT_TL, TOPLAM_USD, Toplam;
            for (int i = 0; i <= Liste.Rows.Count - 1; i++)
            {
                Tipi = Liste.Rows[i]["TIPI"].ToString();
                Turu = Liste.Rows[i]["TURU"].ToString();
                Stok_Kodu = Liste.Rows[i]["STOK_KODU"].ToString();
                Model_no = Liste.Rows[i]["MODEL_NO"].ToString();
                Miktar = Convert.ToInt32(Liste.Rows[i]["MIKTAR"].ToString());
                Stok_birim = Liste.Rows[i]["STOK_BIRIMI"].ToString();
                Birim_Fiyat = Convert.ToDecimal(Liste.Rows[i]["BIRIM_FIYAT"].ToString());
                Para_birimi = Liste.Rows[i]["PARA_BIRIMI"].ToString();
                Isk1 = Convert.ToDecimal(Liste.Rows[i]["ISK_1"].ToString());
                Isk2 = Convert.ToDecimal(Liste.Rows[i]["ISK_2"].ToString());
                Isk3 = Convert.ToDecimal(Liste.Rows[i]["ISK_3"].ToString());
                Kdv = Convert.ToDecimal(Liste.Rows[i]["KDV"].ToString());
                Toplam = Convert.ToDecimal(Liste.Rows[i]["TOPLAM"].ToString());
                ISK_BIR_FIYAT_USD = Convert.ToDecimal(Liste.Rows[i]["ISK_BIR_FIYAT_USD"].ToString());
                ISK_BIR_FIYAT_TL = Convert.ToDecimal(Liste.Rows[i]["ISK_BIR_FIYAT_TL"].ToString());
                TOPLAM_USD = Convert.ToDecimal(Liste.Rows[i]["TOPLAM_USD"].ToString());

                if (Turu == "GENEL STOK")
                {
                    int StokHareketSonucuMiktar = StokHareketYap(Stok_Kodu, Miktar);
                    StokGuncelle(Stok_Kodu, StokHareketSonucuMiktar);
                }
                string query = "INSERT INTO tbl_stok_hareket_icerik (TARIH,SIPARIS_NO,FIS_NO,MUSTERI_KODU,TIPI,TURU,STOK_KODU,MODEL_NO,MIKTAR,STOK_BIRIMI,BIRIM_FIYAT,PARA_BIRIMI,ISK_1,ISK_2,ISK_3,KDV,ISK_BIR_FIYAT_USD, ISK_BIR_FIYAT_TL, TOPLAM_USD,TOPLAM,SAVE_USER,SAVE_DATE) VALUES ('" + Formatlar.IngilizceTarihKısaFormat(Tarih) + "','" + Kayit_no + "','" + Fis_no + "','" + Musteri_kodu + "','" + Tipi + "','" + Turu + "','" + Stok_Kodu + "','" + Model_no + "','" + Miktar + "','" + Stok_birim + "','" + Birim_Fiyat.ToString().Replace(",", ".") + "','" + Para_birimi + "','" + Isk1.ToString().Replace(",", ".") + "','" + Isk2.ToString().Replace(",", ".") + "','" + Isk3.ToString().Replace(",", ".") + "','" + Kdv.ToString().Replace(",", ".") + "','" + ISK_BIR_FIYAT_USD.ToString().Replace(",", ".") + "','" + ISK_BIR_FIYAT_TL.ToString().Replace(",", ".") + "','" + TOPLAM_USD.ToString().Replace(",", ".") + "','" + Toplam.ToString().Replace(",", ".") + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
                //'" + FaturaNo + "','" + StokKodu + "','" + GcKodu + "'," + Miktar + "," + Fiyat.ToString().Replace(",", ".") + "," + Isk1.ToString().Replace(",", ".") + "," + Isk2.ToString().Replace(",", ".") + "," + Kdv.ToString().Replace(",", ".") + ",'"+Tipi+"','"+Tarih+"',"+KariyerMuhasebeSeti.frmAnaForm.UserId+"";
                Dbase.Insert(query);
            }
            SiparisHareketSil(Kayit_no);
            SiparisHareketİcerik_SIL(Kayit_no);
        }
        public void SiparisIcerikIptal(string siparisNO)
        {
            string query = "DELETE FROM tbl_siparis_hareket_icerik WHERE SIPARIS_NO='"+siparisNO+"'";
            Dbase.Delete(query);
        }
    }
}