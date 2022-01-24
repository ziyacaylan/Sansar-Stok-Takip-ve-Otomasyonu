using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.MusterıModulu.Classlar
{
    class clsMusteriListesi
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        public DataTable Listele()
        {
            string sql = "SELECT * FROM tbl_musteriler ";
            DataTable dt = Dbase.TabloCek(sql);
            return dt;
        }
        public DataTable FirmaSorgula(string FirmaAdi)
        {
            string query = "SELECT * FROM tbl_musteriler WHERE FIRMA_ADI LIKE '%"+FirmaAdi+"%'";
            DataTable tablo=Dbase.TabloCek(query);
            return tablo;
        }
        public DataTable SehirSorgula(string Sehir)
        {
            string query = "SELECT * FROM tbl_musteriler WHERE IL_1 LIKE '%" + Sehir + "%'";
            DataTable tablo = Dbase.TabloCek(query);
            return tablo; 
        }
        public DataTable BayiilikTuruSorgula(string BayiilikTuru)
        {
            string query = "SELECT * FROM tbl_musteriler WHERE BAYIILIK_TURU LIKE '%" + BayiilikTuru + "%'";
            DataTable tablo = Dbase.TabloCek(query);
            return tablo;
        }
        }
}
