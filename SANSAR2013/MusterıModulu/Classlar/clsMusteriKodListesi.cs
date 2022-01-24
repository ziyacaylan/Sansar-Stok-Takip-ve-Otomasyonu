using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.MusterıModulu.Classlar
{
    class clsMusteriKodListesi
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        public DataTable Listele()
        {
            string sql = "SELECT * FROM tbl_musteriler ";
            DataTable dt = Dbase.TabloCek(sql);
            return dt;
        }
        public DataTable Sorgula(string MusteriKodu, string FirmaAdi, string Sehir,string BayiilikTuru)
        {
            string sql = "SELECT * FROM tbl_musteriler WHERE MUSTERI_KODU LIKE '%" + MusteriKodu + "%' AND FIRMA_ADI LIKE '%" + FirmaAdi + "%' AND IL_1 LIKE '%" + Sehir + "%' AND BAYIILIK_TURU LIKE '%" + BayiilikTuru + "%'";
            DataTable dt = Dbase.TabloCek(sql);
            return dt;
        }
    }
}
