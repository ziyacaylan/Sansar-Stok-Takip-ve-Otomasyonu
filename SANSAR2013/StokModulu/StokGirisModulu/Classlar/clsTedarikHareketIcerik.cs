using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.StokGirisModulu.Classlar
{
    class clsTedarikHareketIcerik
    {
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();

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
            int sonuc = stok_miktar + miktar;
            return sonuc;
        }
        private void StokGuncelle(string StokKodu, int sonMiktar)
        {
            string query = "UPDATE tbl_genel_stoklar SET STOK_MIKTAR='" + sonMiktar + "' WHERE STOK_KODU='" + StokKodu + "'";
            Dbase.Update(query);
        }
        public void TedarikIcerikEkle(string Tarih,string KayitNO,string MusteriKodu, DataTable Liste)
        {
            string Tipi,Turu,Stok_Kodu, Model_no, Stok_birim, Aciklama;
            int Miktar;
            for (int i = 0; i <= Liste.Rows.Count - 1; i++)
            {
                Tipi = Liste.Rows[i]["TIPI"].ToString();
                Turu = Liste.Rows[i]["TURU"].ToString();
                Stok_Kodu = Liste.Rows[i]["STOK_KODU"].ToString();
                Model_no = Liste.Rows[i]["MODEL_NO"].ToString();
                Miktar = Convert.ToInt32(Liste.Rows[i]["MIKTAR"].ToString());
                Stok_birim = Liste.Rows[i]["STOK_BIRIMI"].ToString();
                Aciklama = Liste.Rows[i]["ACIKLAMA"].ToString();

                if (Turu == "GENEL STOK")
                {
                    int StokHareketSonucuMiktar = StokHareketYap(Stok_Kodu, Miktar);
                    StokGuncelle(Stok_Kodu, StokHareketSonucuMiktar);
                }
                string query = "INSERT INTO tbl_stok_hareket_icerik (TARIH,SIPARIS_NO,MUSTERI_KODU,TIPI,TURU,STOK_KODU,MODEL_NO,MIKTAR,STOK_BIRIMI,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + Formatlar.IngilizceTarihKısaFormat(Tarih) + "','" + KayitNO + "','" + MusteriKodu + "','"+Tipi+"','" + Turu + "','" + Stok_Kodu + "','" + Model_no + "','" + Miktar + "','" + Stok_birim + "','" + Aciklama + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
                Dbase.Insert(query);
            }
        }
    }
}
