using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.SiparisModulu.Classlar
{
    class clsKonsinyeSiparisListesi
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();

        public DataTable KonsinyeSiparisListesiniGetir(string Tipi)
        {
            string query = "SELECT * FROM tbl_siparis_hareket WHERE TIPI='" + Tipi + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public string SiparisMusteriKoduCek(string kayit_No)
        {
            string musteri_kodu = "";
            string query = "SELECT * FROM tbl_siparis_hareket WHERE SIPARIS_NO='" + kayit_No + "'";
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
        public DataTable FirmaSorgula(string FirmaAdi, string Tipi)
        {
            string query = "SELECT * FROM tbl_siparis_hareket WHERE FIRMA_ADI LIKE '%" + FirmaAdi + "%' AND TIPI='" + Tipi + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public DataTable SiparisNoSorgula(string KayitNo, string Tipi)
        {
            string query = "SELECT * FROM tbl_siparis_hareket WHERE SIPARIS_NO='" + KayitNo + "' AND TIPI='" + Tipi + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public DataTable FaturaNOSorgula(string FaturaNo, string Tipi)
        {
            string query = "SELECT * FROM tbl_siparis_hareket WHERE FATURA_NO='" + FaturaNo + "' AND TIPI='" + Tipi + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public DataTable FisNOSorgula(string FisNO, string Tipi)
        {
            string query = "SELECT * FROM tbl_siparis_hareket WHERE FIS_NO='" + FisNO + "' AND TIPI='" + Tipi + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
    }
}
