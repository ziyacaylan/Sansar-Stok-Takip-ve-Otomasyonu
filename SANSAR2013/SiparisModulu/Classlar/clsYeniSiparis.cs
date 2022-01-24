using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.SiparisModulu.Classlar
{
    class clsYeniSiparis
    {
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
      //  SANSAR2013.Kullanicilar.Classlar.clsKullanicilar Kullanicilar = new Kullanicilar.Classlar.clsKullanicilar();
        Classlar.clsSiparisHareketIcerik Siparis_Icerik = new clsSiparisHareketIcerik();
        //private string siparis="";

        //public string TeslimAdresi(string MusteriID)
        //{
        //    string query = "SELECT * FROM tbl_musteriler    WHERE ID='" + MusteriID + "'";
        //    DataRow satir = Dbase.SatirCek(query);
        //    string adres = satir["ADRES_2"].ToString();
        //    string Ilce = satir["ILCE_2"].ToString();
        //    string Sehir = satir["IL_2"].ToString();
        //    string Toplam = "" + adres + " " + Ilce + " " + Sehir + "";
        //    return Toplam;
        //}
        public string TeslimAdresi_M_Kodu(string Musteri_Kodu)
        {
            string query = "SELECT * FROM tbl_musteriler    WHERE MUSTERI_KODU='" + Musteri_Kodu + "'";
            DataRow satir = Dbase.SatirCek(query);
            string adres = satir["ADRES_2"].ToString();
            string Ilce = satir["ILCE_2"].ToString();
            string Sehir = satir["IL_2"].ToString();
            string Toplam = "" + adres + " " + Ilce + " " + Sehir + "";
            return Toplam;
        }
        public DataRow KurCek_SonGuncelleme()
        {
            string query = "SELECT * FROM tbl_doviz_kurlari ORDER BY ID DESC";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
        public void Ekle_Siparis_Hareket(string Tarih, string Tipi, string Siparis_no, string Fis_no, string Fatura_no, string Musteri_kodu, string Firma_adi, string Siparis_veren, string Siparis_giren, string Stok_onay, string Satis_onay, string sevk_adresi, string Teslim_sekli, string Aciklama, string kdv_oran, string kur_tarih, string kdv_eklimi, string sip_kalem_adet, DataTable Tablo)
        {
            string query = "INSERT INTO tbl_siparis_hareket (TARIH,TIPI,SIPARIS_NO,FIS_NO,FATURA_NO,MUSTERI_KODU,FIRMA_ADI,SIPARIS_VEREN,SIPARIS_GIREN,STOK_ONAY,SATIS_ONAY,SEVK_ADRES,TESLIM_SEKLI,ACIKLAMA,KDV_ORAN,KUR_TARIH,KDV_EKLIMI,SIP_KALEM_ADET,SAVE_USER,SAVE_DATE) VALUES ('" + Formatlar.IngilizceTarihKısaFormat(Tarih) + "','" + Tipi + "','" + Siparis_no + "','" + Fis_no + "','" + Fatura_no + "','" + Musteri_kodu + "','" + Firma_adi + "','" + Siparis_veren + "','" + Siparis_giren + "','" + Stok_onay + "','" + Satis_onay + "','"+sevk_adresi+"','" + Teslim_sekli + "','" + Aciklama + "','" + kdv_oran + "','" + Formatlar.IngilizceTarihKısaFormat(kur_tarih) + "','" + kdv_eklimi + "','" + sip_kalem_adet + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            Dbase.Insert(query);

            Siparis_Icerik.Ekle(Tarih, Siparis_no, Fis_no, Musteri_kodu, Tablo);
        }
        public void Guncelle_Siparis_Hareket(string Tarih, string Tipi, string Siparis_no, string Fis_no, string Fatura_no, string Musteri_kodu, string Firma_adi, string Siparis_veren, string Siparis_giren, string Stok_onay, string Satis_onay, string sevk_adresi, string Teslim_sekli, string Aciklama, string kdv_oran, string kur_tarih, string kdv_eklimi, string sip_kalem_adet, DataTable Tablo)
        {
            string query = "UPDATE tbl_siparis_hareket SET TARIH='" + Formatlar.IngilizceTarihKısaFormat(Tarih) + "',TIPI='" + Tipi + "',SIPARIS_NO='" + Siparis_no + "',FIS_NO='" + Fis_no + "',FATURA_NO='" + Fatura_no + "',MUSTERI_KODU='" + Musteri_kodu + "',FIRMA_ADI='" + Firma_adi + "',SIPARIS_VEREN='" + Siparis_veren + "',SIPARIS_GIREN='" + Siparis_giren + "',STOK_ONAY='" + Stok_onay + "',SATIS_ONAY='" + Satis_onay + "',SEVK_ADRES='" + sevk_adresi + "',TESLIM_SEKLI='" + Teslim_sekli + "',ACIKLAMA='" + Aciklama + "',KDV_ORAN='" + kdv_oran + "',KUR_TARIH='" +Formatlar.IngilizceTarihKısaFormat(kur_tarih) + "',KDV_EKLIMI='" + kdv_eklimi + "',SIP_KALEM_ADET='" + sip_kalem_adet + "',EDIT_USER='" + AnaForm.UserId + "',EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE SIPARIS_NO='" + Siparis_no + "'";
            Dbase.Update(query);

            Siparis_Icerik.Sil_Icerik(Siparis_no);
            Siparis_Icerik.Ekle(Tarih, Siparis_no, Fis_no, Musteri_kodu, Tablo);
        }
        public Boolean KurTablosuBosmu()
        {
            string query = "SELECT * FROM tbl_doviz_kurlari";
            DataTable tablo = Dbase.TabloCek(query);

            if (tablo.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GüncelKurTarihi()
        {
            string sql = "SELECT  Count(*) FROM tbl_doviz_kurlari ";
            string satir_sayisi = Convert.ToString(Dbase.Count(sql));

            IDataReader reader;
            string son_KUR_tarih = "";
            string query = "SELECT * FROM tbl_doviz_kurlari WHERE ID='"+satir_sayisi+"'";
            reader = Dbase.DataOku(query);
            while (reader.Read())
            {
                son_KUR_tarih = reader["TARIH"].ToString();
            }
            reader.Close();
            if (son_KUR_tarih == "")
            {
                son_KUR_tarih = "0001-01-01";
            }
            return son_KUR_tarih;        
        }
        public DataRow StokHareketBilgileriniYukle(string siparisID)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE ID='" + siparisID + "'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
        public DataTable StokHareketIverikYukle(string siparisNo)
        {
            string query = "SELECT * FROM tbl_stok_hareket_icerik WHERE SIPARIS_NO='" + siparisNo + "'";
            DataTable tablo = Dbase.TabloCek(query);
            return tablo;
        }
        public DataRow SiparisBilgileriYukle(string siparisID)
        {
            string query = "SELECT * FROM tbl_siparis_hareket WHERE ID='"+siparisID+"'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
        public DataTable SiparisIcerikleriniYukle(string siparisNo)
        {
            string query = "SELECT * FROM tbl_siparis_hareket_icerik WHERE SIPARIS_NO='" + siparisNo + "'";
            DataTable tablo = Dbase.TabloCek(query);
            return tablo;
        }
        public Boolean FisNoKayitKontrol(string FisNo)
        {
            string query = "SELECT * FROM tbl_siparis_hareket WHERE FIS_NO='" + FisNo + "'";
            DataRow drow = Dbase.SatirCek(query);
            if (drow != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean SiparisNoKontrol(string SiparisNo)
        {
            string query = "SELECT * FROM tbl_siparis_hareket WHERE SIPARIS_NO='" + SiparisNo + "'";
            DataRow drow = Dbase.SatirCek(query);
            try
            {
                string siparisno = drow["SIPARIS_NO"].ToString();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
         }
        public void Stok_Hareket_Ekle(string Tarih, string Tipi, string Kayit_no, string Fis_no, string Fatura_no, string Musteri_kodu, string Firma_adi, string Siparis_veren, string Siparis_giren, string Stok_onay, string Satis_onay, string sevk_adresi, string Teslim_sekli, string Aciklama, string kdv_oran, string kur_tarih, string kdv_eklimi, string sip_kalem_adet, DataTable Tablo)
        {
            string query = "INSERT INTO tbl_stok_hareket (TARIH,TIPI,SIPARIS_NO,FIS_NO,FATURA_NO,MUSTERI_KODU,FIRMA_ADI,SIPARIS_VEREN,SIPARIS_GIREN,STOK_ONAY,SATIS_ONAY,SEVK_ADRES,TESLIM_SEKLI,ACIKLAMA,KDV_ORAN,KUR_TARIH,KDV_EKLIMI,SIP_KALEM_ADET,SAVE_USER,SAVE_DATE) VALUES ('" + Formatlar.IngilizceTarihKısaFormat(Tarih) + "','" + Tipi + "','" + Kayit_no + "','" + Fis_no + "','" + Fatura_no + "','" + Musteri_kodu + "','" + Firma_adi + "','" + Siparis_veren + "','" + Siparis_giren + "','" + Stok_onay + "','" + Satis_onay + "','" + sevk_adresi + "','" + Teslim_sekli + "','" + Aciklama + "','" + kdv_oran + "','" + Formatlar.IngilizceTarihKısaFormat(kur_tarih) + "','" + kdv_eklimi + "','" + sip_kalem_adet + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            Dbase.Insert(query);

            Siparis_Icerik.Stok_Hareket_Icerik_Ekle(Tarih, Kayit_no, Fis_no, Musteri_kodu, Tablo);
        }
        public void Guncelle_Stok_Hareket(string Tarih, string Tipi, string Kayit_no, string Fis_no, string Fatura_no, string Musteri_kodu, string Firma_adi, string Siparis_veren, string Siparis_giren, string Stok_onay, string Satis_onay, string sevk_adresi, string Teslim_sekli, string Aciklama, string kdv_oran, string kur_tarih, string kdv_eklimi, string sip_kalem_adet, DataTable Tablo)
        {
            string query = "UPDATE tbl_stok_hareket SET TARIH='" + Formatlar.IngilizceTarihKısaFormat(Tarih) + "',TIPI='" + Tipi + "',SIPARIS_NO='" + Kayit_no + "',FIS_NO='" + Fis_no + "',FATURA_NO='" + Fatura_no + "',MUSTERI_KODU='" + Musteri_kodu + "',FIRMA_ADI='" + Firma_adi + "',SIPARIS_VEREN='" + Siparis_veren + "',SIPARIS_GIREN='" + Siparis_giren + "',STOK_ONAY='" + Stok_onay + "',SATIS_ONAY='" + Satis_onay + "',SEVK_ADRES='" + sevk_adresi + "',TESLIM_SEKLI='" + Teslim_sekli + "',ACIKLAMA='" + Aciklama + "',KDV_ORAN='" + kdv_oran + "',KUR_TARIH='" + Formatlar.IngilizceTarihKısaFormat(kur_tarih) + "',KDV_EKLIMI='" + kdv_eklimi + "',SIP_KALEM_ADET='" + sip_kalem_adet + "',EDIT_USER='" + AnaForm.UserId + "',EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE KAYIT_NO='" + Kayit_no + "'";
            Dbase.Update(query);
        }
        public Boolean SatisOnayYetkisiVarmı(string UserID)
        {
            Boolean KullaniciID = true;
            //string query = "SELECT * FROM tbl_yetkiler WHERE FIS_NO='" + FisNo + "'";
           // KullaniciID = "0";
            return KullaniciID;
        }
        public void SiparisIptal(string siparisNO)
        {
            string query = "DELETE FROM tbl_siparis_hareket WHERE SIPARIS_NO='"+siparisNO+"'";
            Dbase.Delete(query);
            Siparis_Icerik.SiparisIcerikIptal(siparisNO);
        }
        public string GenelStok_Miktar(string Stok_Kodu)
        {
            string miktar="0";
            string query = "SELECT * FROM tbl_genel_stoklar WHERE STOK_KODU='"+Stok_Kodu+"'";
            DataRow drow = Dbase.SatirCek(query);
            try
            {
                miktar = drow["STOK_MIKTAR"].ToString();
                return miktar;
            }
            catch (Exception)
            {

                return miktar = "0";
            }
        }
        public string DefoluStok_Miktar(string Stok_Kodu)
        {
            string miktar = "0";
            string query = "SELECT SUM(STOK_MIKTAR) FROM tbl_defolu_stoklari WHERE STOK_KODU='" + Stok_Kodu + "'";
            try
            {
                miktar = Dbase.DegerDondur(query);
                if (miktar == "")
                {
                    miktar = "0";
                }
                return miktar;
            }
            catch (Exception)
            {

               return miktar = "0";
            }
            }
        public string MuhtelifStok_Miktar(string Stok_Kodu)
        {
            string miktar = "0";
            string query = "SELECT SUM(MIKTAR) FROM tbl_siparis_hareket_icerik WHERE STOK_KODU LIKE'" + Stok_Kodu + "' AND TIPI LIKE'KNS.SP'";
            try
            {
                miktar = Dbase.DegerDondur(query);
                if (miktar == "")
                {
                    miktar = "0";
                }
                return miktar;
            }
            catch (Exception)
            {

                return miktar = "0";
            }
        }
        public string GunlukSatislar_Miktari(string Stok_Kodu)
        {
            string miktar = "0";
            string query = "SELECT SUM(MIKTAR) FROM tbl_siparis_hareket_icerik WHERE STOK_KODU='" + Stok_Kodu + "' AND TIPI='SP'";
            try
            {
                miktar = Dbase.DegerDondur(query);
                if (miktar=="")
                {
                    miktar = "0";
                }
                return miktar;
            }
            catch (Exception)
            {

                return miktar = "0";
            }
        }
        public int GenelStok_KritikStokMiktar(string stok_kodu)
        {
            int miktar = 0;
            string query = "SELECT * FROM tbl_genel_stoklar WHERE STOK_KODU='" + stok_kodu + "'";
            DataRow drow = Dbase.SatirCek(query);
            try
            {
                miktar = Convert.ToInt32(drow["KRITIK_STOK_SEVIYESI"].ToString());
                return miktar;
            }
            catch (Exception)
            {

                return miktar = 0;
            }
        }
        public DataRow StokHareketCET_siparisNO_ile(string siparisNO)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE SIPARIS_NO='"+siparisNO+"'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
        public DataTable Stok_Hareket_Icerik_SiparisNO(string siparisNO)
        {
            string query = "SELECT * FROM tbl_stok_hareket_icerik WHERE SIPARIS_NO='" + siparisNO + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
    }
}