using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.StokGirisModulu.Classlar
{

    class clsStokGirisi
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        Classlar.clsTedarikHareketIcerik TedarikHareket = new clsTedarikHareketIcerik();

        public void TedarikStokHareketEkle(string Tarih,string Tipi,string TedarikNO,string FaturaNo,string MusteriKodu,string FirmaAdi,string Adres,string Sehir,string Ilce,string Telefon,string BayiilikTuru,string VergiDairesi,string VergiNo,string TeslimAlmaSekli,string Aciklama,string TedarikKalemAdet,DataTable TabloKalemler)
        {
            string query = "INSERT INTO tbl_stok_hareket (TARIH,TIPI,SIPARIS_NO,FATURA_NO,MUSTERI_KODU,FIRMA_ADI,TESLIM_SEKLI,ACIKLAMA,SIP_KALEM_ADET,SAVE_USER,SAVE_DATE) VALUES ('"+Formatlar.IngilizceTarihKısaFormat(Tarih)+"','"+Tipi+"','"+TedarikNO+"','"+FaturaNo+"','"+MusteriKodu+"','"+FirmaAdi+"','"+TeslimAlmaSekli+"','"+Aciklama+"','"+Convert.ToInt32(TedarikKalemAdet)+"','"+Convert.ToInt32(AnaForm.UserId)+"','"+Formatlar.IngiliceTarihFormati(DateTime.Now.ToString())+"')";
            Dbase.Insert(query);

            TedarikHareket.TedarikIcerikEkle(Tarih,TedarikNO, MusteriKodu,TabloKalemler);
        }
        public  Boolean TedarikKayitSorgula(string Tipi,string FaturaNo,string FirmaAdi)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE TIPI='"+Tipi+"' AND FATURA_NO='"+FaturaNo+"' AND FIRMA_ADI='"+FirmaAdi+"'";
            DataRow drow = Dbase.SatirCek(query);
            if (drow == null)
            {
                return false;
            }
            else
            {
                return true ;
            }
        }
        public DataTable TedarikHareketIcerikYukle(string KayitNO)
        {
            string query = "SELECT * FROM tbl_stok_hareket_icerik WHERE SIPARIS_NO='" + KayitNO + "'";
            DataTable tablo = Dbase.TabloCek(query);
            return tablo;
        }
    }
}
