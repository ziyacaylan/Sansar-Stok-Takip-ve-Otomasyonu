using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.MusterıModulu.Classlar
{
    class clsMusteriKarti
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        public int Bayiilik_Turleri_SatirGetir()
        {
            string query = "SELECT Count(BAYIILIK_TURU) FROM tbl_bayii_turleri";

            return Dbase.Count(query);

            //string query_1 = "SELECT STOK_BIRIMI FROM tbl_stok_birimi WHERE ID='" + i + "'";                                  
        }
        public string bayiilikTuru(int i)
        {
            DataRow Satir;
            string query = "SELECT BAYIILIK_TURU FROM tbl_bayii_turleri WHERE ID='" + i + "'";
            Satir = Dbase.SatirCek(query);
            string ali = Satir["BAYIILIK_TURU"].ToString();
            return ali;

        }

        public void Ekle(string MusteriKodu,string FirmaAdi,string Adres_1,string Il_1,string Ilce_1,string Adres_2,string Il_2,string Ilce_2,string Ulke,string Tel_1,string Tel_2,string Fax,string Mail,string CepTel,string YetkiliKisi,string BayiilikTuru,string VergiDairesi,string VergiNo,string isk_1,string isk_2,string isk_3,string isk_4,string isk_5,string isk_6,string Aciklama_1,string Aciklama_2)
        {
            string query = "INSERT INTO tbl_musteriler (MUSTERI_KODU,FIRMA_ADI,ADRES_1,ILCE_1,IL_1,ADRES_2,ILCE_2,IL_2,ULKE,TEL_1,TEL_2,CEP_TEL,FAX,MAIL,YETKILI_KISI,BAYIILIK_TURU,VERGI_DAIRESI,VERGI_NO,ISK_1,ISK_2,ISK_3,ISK_4,ISK_5,ISK_6,ACIKLAMA_1,ACIKLAMA_2,SAVE_USER,SAVE_DATE) VALUES('" + MusteriKodu + "','" + FirmaAdi + "','" + Adres_1 + "','" + Ilce_1 + "','" + Il_1 + "','" + Adres_2 + "','" + Ilce_2 + "','" + Il_2 + "','" + Ulke + "','" + Tel_1 + "','" + Tel_2 + "','" + CepTel + "','" + Fax + "','" + Mail + "','" + YetkiliKisi + "','" + BayiilikTuru + "','" + VergiDairesi + "','" + VergiNo + "','" + isk_1 + "','" + isk_2 + "','" + isk_3 + "','" + isk_4 + "','" + isk_5 + "','" + isk_6 + "','" + Aciklama_1 + "','" + Aciklama_2 + "','" + AnaForm.UserId.ToString() + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            Dbase.Isle(query);
        }
        public void Gulcelle(string MusteriID,string MusteriKodu, string FirmaAdi, string Adres_1, string Il_1, string Ilce_1, string Adres_2, string Il_2, string Ilce_2, string Ulke, string Tel_1, string Tel_2, string Fax, string Mail, string CepTel, string YetkiliKisi, string BayiilikTuru, string VergiDairesi, string VergiNo, string isk_1, string isk_2, string isk_3, string isk_4, string isk_5, string isk_6, string Aciklama_1, string Aciklama_2)
        {
            string query = "UPDATE  tbl_musteriler SET MUSTERI_KODU='"+MusteriKodu+"',FIRMA_ADI='"+FirmaAdi+"',ADRES_1='"+Adres_1+"',ILCE_1='"+Ilce_1+"',IL_1='"+Il_1+"',ADRES_2='"+Adres_2+"',ILCE_2='"+Ilce_2+"',IL_2='"+Il_2+"',ULKE='"+Ulke+"',TEL_1='"+Tel_1+"',TEL_2='"+Tel_2+"',CEP_TEL='"+CepTel+"',FAX='"+Fax+"',MAIL='"+Mail+"',YETKILI_KISI='"+YetkiliKisi+"',BAYIILIK_TURU='"+BayiilikTuru+"',VERGI_DAIRESI='"+VergiDairesi+"',VERGI_NO='"+VergiNo+"',ISK_1='"+isk_1+"',ISK_2='"+isk_2+"',ISK_3='"+isk_3+"',ISK_4='"+isk_4+"',ISK_5='"+isk_5+"',ISK_6='"+isk_6+"',ACIKLAMA_1='"+Aciklama_1+"',ACIKLAMA_2='"+Aciklama_2+"',EDIT_USER='"+AnaForm.UserId.ToString()+"',EDIT_DATE='"+Formatlar.IngiliceTarihFormati(DateTime.Now.ToString())+"' WHERE ID='"+MusteriID+"'";
            Dbase.Update(query);
        }
        public Boolean MusteriKayitSorgu(string MusteriKodu, string FirmaAdi)
        {
            IDataReader reader;
            string sonuc_musteri_kodu = "";
            string sonuc_firma_adi = "";

            string query = "SELECT * FROM tbl_musteriler WHERE MUSTERI_KODU='" + MusteriKodu + "' || FIRMA_ADI='" + FirmaAdi + "'";
            reader = Dbase.DataOku(query);
            while (reader.Read())
            {
                sonuc_musteri_kodu = reader["MUSTERI_KODU"].ToString();
                sonuc_firma_adi = reader["FIRMA_ADI"].ToString();
            }
            reader.Close();

            if (sonuc_musteri_kodu == MusteriKodu || sonuc_firma_adi == FirmaAdi)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Boolean MusteriKayitlimi(string MusteriKodu, string FirmaAdi)
        {
            string query = "SELECT * FROM tbl_musteriler WHERE MUSTERI_KODU='" + MusteriKodu + "' || FIRMA_ADI='" + FirmaAdi + "'";
            DataRow drow= Dbase.SatirCek(query);
            if (drow==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DataRow Musteri_Karti_bilgileriniCek(string musteri_kodu)
        {
            DataRow satir;
            string query = "SELECT * FROM tbl_musteriler WHERE MUSTERI_KODU='" + musteri_kodu + "'";
            satir = Dbase.SatirCek(query);
            return satir;
        }
        public DataRow Musteri_Karti_bilgilerini_cek(string ID)
        {
            DataRow satir;
            string query = "SELECT * FROM tbl_musteriler WHERE ID='" + ID + "'";
            return satir = Dbase.SatirCek(query);
        }
        public Boolean MusteriKartiStokHareketiVarmi(string MusteriKodu)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE MUSTERI_KODU='" + MusteriKodu + "'";
            DataRow drow = Dbase.SatirCek(query);
            if (drow==null)
            {
                return false;
            }
            else
            {
            return true ;
            }
        }
        public void MusteriKartiSil(string MusteriKodu)
        {
            string query = "DELETE FROM tbl_musteriler WHERE MUSTERI_KODU='"+MusteriKodu+"'";
            Dbase.Delete(query);
        }
        public Boolean Musteri_Kodu_Sorgulama(string MusteriKodu)
        {
            string query = "SELECT * FROM tbl_musteriler WHERE MUSTERI_KODU='"+MusteriKodu+"'";
           DataRow drow= Dbase.SatirCek(query);
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
