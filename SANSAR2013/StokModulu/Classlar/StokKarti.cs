using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.Classlar
{
    class StokKarti
    {
        IDataReader okuyucu;
        //IDbCommand cmd;
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();

        public void Ekle(string Stok_Kodu, string Model_No, string Urun_Grubu, string Stok_Birimi, string Iskonto_Grubu, string Stok_Turu, decimal Alis_Fiyati, string Alis_Para_Birimi, decimal Satis_Fiyati, string Satis_Para_Birimi, decimal Satis_Fiyati_1, string Satis_Para_Birimi_1, int Kritik_Stok_Seviyesi, string Etiket_Rengi, string Depo_No, string Raf_No, string Goz_No, string Aciklama, int fileLength, string fileName, byte[] rawdata)
        {
            string query = "INSERT INTO tbl_genel_stoklar (STOK_KODU,MODEL_NO,URUN_GRUBU,STOK_MIKTAR,STOK_BIRIMI,ISKONTO_GRUBU,STOK_TURU,ALIS_FIYAT,ALIS_FIYAT_PARA_BIRIMI,SATIS_FIYAT,SATIS_FIYAT_PARA_BIRIMI,SATIS_FIYAT_1,SATIS_FIYAT_PARA_BIRIMI_1,KRITIK_STOK_SEVIYESI,ETIKET_RENGI,DEPO_NO,RAF_NO,GOZ_NO,ACIKLAMA,BOYUT,RESIM_ADI,SAVE_USER,SAVE_DATE) VALUES('" + Stok_Kodu + "','" + Model_No + "','" + Urun_Grubu + "','" + Convert.ToInt32("0") + "','" + Stok_Birimi + "','" + Iskonto_Grubu + "','" + Stok_Turu + "','" + Alis_Fiyati + "','" + Alis_Para_Birimi + "','" + Satis_Fiyati + "','" + Satis_Para_Birimi + "','"+Satis_Fiyati_1+"','"+Satis_Para_Birimi_1+"','" + Kritik_Stok_Seviyesi + "','" + Etiket_Rengi + "','" + Depo_No + "','" + Raf_No + "','" + Goz_No + "','" + Aciklama + "','" + fileLength + "','" + fileName + "','" + AnaForm.UserId.ToString() + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            Dbase.Isle(query);

            if (fileName!="")
            {

            //KAYDEDİLEN SATIR NOSUNU BUL
            int urun_id=0;
            DataRow Satir = Stok_Karti_Urun_ID(Model_No);
            urun_id = Convert.ToInt32(Satir["ID"].ToString());
            //KAYDEDİLEN SATIR NOSUNU BUL

            string komut_satiri = "UPDATE tbl_genel_stoklar SET RESIM=@RESIM WHERE ID=" + urun_id + "";
            Dbase.Resim_Isle(komut_satiri, "RESIM", rawdata);   
            }
        }
        public void Guncelle(string Urun_ID, string Stok_Kodu, string Model_No, string Urun_Grubu, string Stok_Birimi, string Iskonto_Grubu, string Stok_Turu, decimal Alis_Fiyati, string Alis_Para_Birimi, decimal Satis_Fiyati, string Satis_Para_Birimi, decimal Satis_Fiyati_1, string Satis_Para_Birimi_1, int Kritik_Stok_Seviyesi, string Etiket_Rengi, string Depo_No, string Raf_No, string Goz_No, string Aciklama, int fileLength, string fileName, byte[] rawdata)
        {
            string query = "UPDATE tbl_genel_stoklar SET STOK_KODU='" + Stok_Kodu + "',MODEL_NO='" + Model_No + "',URUN_GRUBU='" + Urun_Grubu + "',STOK_BIRIMI='" + Stok_Birimi + "',ISKONTO_GRUBU='" + Iskonto_Grubu + "',STOK_TURU='" + Stok_Turu + "',ALIS_FIYAT='" + Alis_Fiyati.ToString().Replace(",", ".") + "',ALIS_FIYAT_PARA_BIRIMI='" + Alis_Para_Birimi + "',SATIS_FIYAT='" + Satis_Fiyati.ToString().Replace(",", ".") + "',SATIS_FIYAT_PARA_BIRIMI='" + Satis_Para_Birimi + "',SATIS_FIYAT_1='" + Satis_Fiyati_1.ToString().Replace(",", ".") + "',SATIS_FIYAT_PARA_BIRIMI_1='" + Satis_Para_Birimi_1 + "',KRITIK_STOK_SEVIYESI='" + Kritik_Stok_Seviyesi + "',ETIKET_RENGI='" + Etiket_Rengi + "',DEPO_NO='" + Depo_No + "',RAF_NO='" + Raf_No + "',GOZ_NO='" + Goz_No + "',ACIKLAMA='" + Aciklama + "',BOYUT='" + fileLength + "',RESIM_ADI='" + fileName + "',EDIT_USER='" + AnaForm.UserId.ToString() + "',EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE ID='" + Urun_ID + "'";
            Dbase.Update(query);

            if (fileName != "")
            {

                //KAYDEDİLEN SATIR NOSUNU BUL
                int urun_id = 0;
                DataRow Satir = Stok_Karti_Urun_ID(Model_No);
                urun_id = Convert.ToInt32(Satir["ID"].ToString());
                //KAYDEDİLEN SATIR NOSUNU BUL

                string komut_satiri = "UPDATE tbl_genel_stoklar SET RESIM=@RESIM WHERE ID=" + urun_id + "";
                Dbase.Resim_Isle(komut_satiri, "RESIM", rawdata);
            }
        }
       public int Stok_Birimleri_SatirGetir()
        {
            string query = "SELECT Count(STOK_BIRIMI) FROM tbl_stok_birimi";
           
          return   Dbase.Count(query);

            //string query_1 = "SELECT STOK_BIRIMI FROM tbl_stok_birimi WHERE ID='" + i + "'";                                  
        }
        public  string stokbirimi(int i )
        {
            DataRow Satir;
            string query = "SELECT STOK_BIRIMI FROM tbl_stok_birimi WHERE ID='" + i + "'";
            Satir = Dbase.SatirCek(query);
            string ali = Satir["STOK_BIRIMI"].ToString();
            return ali ;
            
        }
        public int UrunGrubuAdetCek()
        {
            string query = "SELECT Count(URUN_GRUBU) FROM tbl_urun_grubu";

            return Dbase.Count(query);

            //string query_1 = "SELECT STOK_BIRIMI FROM tbl_stok_birimi WHERE ID='" + i + "'";                                  
        }
        public int Iskonto_GrubuGetir()
        {
            string query = "SELECT Count(ISKONTO_GRUBU) FROM tbl_iskonto_grubu";

            return Dbase.Count(query);

            //string query_1 = "SELECT STOK_BIRIMI FROM tbl_stok_birimi WHERE ID='" + i + "'";                                  
        }
        public string iskonto_grubu(int i)
        {
            DataRow Satir;
            string query = "SELECT ISKONTO_GRUBU FROM tbl_iskonto_grubu WHERE ID='" + i + "'";
            Satir = Dbase.SatirCek(query);
            string ali = Satir["ISKONTO_GRUBU"].ToString();
            return ali;

        }

        public int Stok_Turu_Getır()
        {
            string query = "SELECT Count(STOK_TURU) FROM tbl_stok_turleri";

            return Dbase.Count(query);                            
        }
        public string stok_turu(int i)
        {
            DataRow Satir;
            string query = "SELECT STOK_TURU FROM tbl_stok_turleri WHERE ID='" + i + "'";
            Satir = Dbase.SatirCek(query);
            string ali = Satir["STOK_TURU"].ToString();
            return ali;

        }

        public int Etiket_Rengi_Getir()
        {
            string query = "SELECT Count(ETIKET_RENGI) FROM tbl_etiketler";

            return Dbase.Count(query);
        }
        public string Etiket_Rengi(int i)
        {
            DataRow Satir;
            string query = "SELECT ETIKET_RENGI FROM tbl_etiketler WHERE ID='" + i + "'";
            Satir = Dbase.SatirCek(query);
            string ali = Satir["ETIKET_RENGI"].ToString();
            return ali;

        }
        public DataRow Stok_Karti_bilgilerini_cek(string ID)
        {
            DataRow satir;
            string query = "SELECT * FROM tbl_genel_stoklar WHERE ID='" + ID + "'";
            return satir = Dbase.SatirCek(query);
        }
        private  DataRow Stok_Karti_Urun_ID(string Model_No)
        {
            DataRow satir;
            string query = "SELECT ID FROM tbl_genel_stoklar WHERE MODEL_NO='" + Model_No + "'";
            return satir = Dbase.SatirCek(query);
        }
        public IDataReader ResimCek(string ID)
        {
            string query = "SELECT * FROM tbl_genel_stoklar WHERE ID='" + ID + "'";
            okuyucu=Dbase.DataOku(query);
            return okuyucu;
        }
        public Boolean Urun_kayit_sorgula(string stok_kodu,string model_no)
        {
            IDataReader reader;
            string sonuc_stok_kodu = "";
            string sonuc_model_no = "";

            string query = "SELECT * FROM tbl_genel_stoklar WHERE STOK_KODU='" + stok_kodu + "' || MODEL_NO='" + model_no + "'";
            reader = Dbase.DataOku(query);
            while (reader.Read())
            {
                sonuc_stok_kodu = reader["STOK_KODU"].ToString();
                sonuc_model_no = reader["MODEL_NO"].ToString();
            }
            reader.Close();

            if (sonuc_stok_kodu == stok_kodu || sonuc_model_no==model_no)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public string UrunGrubu(int i)
        {
            DataRow Satir;
            string query = "SELECT URUN_GRUBU FROM tbl_urun_grubu WHERE ID='" + i + "'";
            Satir = Dbase.SatirCek(query);
            string ali = Satir["URUN_GRUBU"].ToString();
            return ali;
        }
        public Boolean UrunStokHareketVarmi(string StokKodu, string ModelNo)
        {
            string query = "SELECT * FROM tbl_stok_hareket_icerik WHERE STOK_KODU='" + StokKodu + "' AND MODEL_NO='" + ModelNo + "'";
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
        public void UrunSil(string StokKodu,string ModelNo)
        {
            string query = "DELETE FROM tbl_genel_stoklar WHERE STOK_KODU='" + StokKodu + "' AND MODEL_NO='" + ModelNo + "'";
            Dbase.Delete(query);
        }
    }
}
