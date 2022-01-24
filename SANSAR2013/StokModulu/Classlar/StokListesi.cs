using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.Classlar
{
    class StokListesi
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        public DataTable Listele()
        {
            string sql = "SELECT * FROM tbl_genel_stoklar ";
            DataTable dt = Dbase.TabloCek(sql);
            return dt;
        }
        public DataTable StokKoduSorgula(string StokKodu)
        {
            string query = "SELECT * FROM tbl_genel_stoklar WHERE STOK_KODU LIKE '%" + StokKodu + "%'";
            DataTable tablo = Dbase.TabloCek(query);
            return tablo;
        }
        public DataTable ModelNoSorgula(string ModelNo)
        {
            string query = "SELECT * FROM tbl_genel_stoklar WHERE MODEL_NO LIKE '%" + ModelNo + "%'";
            DataTable tablo = Dbase.TabloCek(query);
            return tablo;
        }
        public DataTable UrunGrubuSorgula(string UrunGrubu)
        {
            string query = "SELECT * FROM tbl_genel_stoklar WHERE URUN_GRUBU LIKE '%" + UrunGrubu + "%'";
            DataTable tablo = Dbase.TabloCek(query);
            return tablo;
        }
    }
}
