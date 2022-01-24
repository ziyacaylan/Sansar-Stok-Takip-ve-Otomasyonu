using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.SatisModulu.Classlar
{
    class SatisListesi
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();

        public DataTable SatisListesiniGetir(string Tipi,string Tipi2)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE TIPI='" + Tipi + "' || TIPI='"+Tipi2+"'";
           DataTable Tablo= Dbase.TabloCek(query);
           return Tablo;
        }
        public DataTable FirmaAdiSorgula(string FirmaAdi)
        {
            string Tipi = "SP";
            string query = "SELECT * FROM tbl_stok_hareket WHERE FIRMA_ADI LIKE '%"+FirmaAdi+"%' AND TIPI='" + Tipi + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataTable FisNoSorgula(string FisNo)
        {
            string Tipi = "SP";
            string query = "SELECT * FROM tbl_stok_hareket WHERE FIS_NO LIKE '%" + FisNo + "%' AND TIPI='" + Tipi + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataTable FaturaNoSorgula(string FaturaNO)
        {
            string Tipi = "SP";
            string query = "SELECT * FROM tbl_stok_hareket WHERE FATURA_NO LIKE '%" + FaturaNO + "%' AND TIPI='" + Tipi + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataTable KayitNOSorgula(string KayitNo)
        {
            string Tipi = "SP";
            string query = "SELECT * FROM tbl_stok_hareket WHERE SIPARIS_NO LIKE '%" + KayitNo + "%' AND TIPI='" + Tipi + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataTable IlkTarihSorgula(string Tarih)
        {
            string Tipi = "SP";
            string query = "SELECT * FROM tbl_stok_hareket WHERE TARIH='" + Tarih + "' AND TIPI='" + Tipi + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public DataTable IkiTarihArasiSorgula(string Tarih1, string Tarih2)
        {
            string Tipi = "SP";
            string query = "SELECT * FROM tbl_stok_hareket WHERE TIPI='" + Tipi + "' AND TARIH BETWEEN '" + Tarih1 + "' AND '" + Tarih2 + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public string SatisMusteriKoduCek(string kayit_No)
        {
            string musteri_kodu = "";
            string query = "SELECT * FROM tbl_stok_hareket WHERE SIPARIS_NO='" + kayit_No + "'";
            DataRow drow = Dbase.SatirCek(query);
            if (drow == null)
            {
                return musteri_kodu;
            }
            else
            {
                return musteri_kodu = drow["MUSTERI_KODU"].ToString();
            }
        }
    }
}
