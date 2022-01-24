using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.StokGirisModulu.Classlar
{
    class clsStokGirisListesi
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();

        public DataTable TedarikListesiniGetir(string Tipi)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE TIPI='" + Tipi + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataRow TedarikBilgileri(string KayitNO)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE SIPARIS_NO='" + KayitNO + "'";
            DataRow drow = Dbase.SatirCek(query);
            return drow;
        }
        public DataTable FirmaSorgula(string FirmaAdi, string Tipi)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE FIRMA_ADI LIKE '%" + FirmaAdi + "%' AND TIPI='" + Tipi + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public DataTable KayitNoSorgula(string KayitNo, string Tipi)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE SIPARIS_NO='" + KayitNo + "' AND TIPI='" + Tipi + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public DataTable FaturaNOSorgula(string FaturaNo, string Tipi)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE FATURA_NO='" + FaturaNo + "' AND TIPI='" + Tipi + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public DataTable IlkTarihSorgula(string Tarih, string Tipi)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE TARIH='" + Tarih + "' AND TIPI='" + Tipi + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public DataTable IkiTarihArasiSorgula(string Tarih1, string Tarih2, string Tipi)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE TIPI='" + Tipi + "' AND TARIH BETWEEN '" + Tarih1 + "' AND '" + Tarih2 + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public string TedarikciMusteriKoduCek(string kayit_No)
        {
            string musteri_kodu = "";
            string query = "SELECT * FROM tbl_stok_hareket WHERE SIPARIS_NO='" + kayit_No + "'";
            DataRow drow = Dbase.SatirCek(query);
            try
            {
                return musteri_kodu = drow["MUSTERI_KODU"].ToString();
            }
            catch (Exception)
            {

                return musteri_kodu;
            }
        }
    }
}