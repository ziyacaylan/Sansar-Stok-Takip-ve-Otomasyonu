using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.Classlar
{
    class clsStokKodLisitesi
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        public DataTable Listele()
        {
            string sql = "SELECT * FROM tbl_genel_stoklar ";
            DataTable dt = Dbase.TabloCek(sql);
            return dt;
        }
        public DataTable Sorgula(string StokKodu, string Model_No, string Urun_Grubu)
        {
            if (StokKodu!="")
            {
             string sql = "SELECT * FROM tbl_genel_stoklar WHERE STOK_KODU LIKE '%" + StokKodu + "%'";
            DataTable dt = Dbase.TabloCek(sql);
            return dt;               
            }
            else if (Model_No != "")
            {
                string sql = "SELECT * FROM tbl_genel_stoklar WHERE MODEL_NO LIKE '%" + Model_No + "%'";
                DataTable dt = Dbase.TabloCek(sql);
                return dt;
            }
            else
            {
                string sql = "SELECT * FROM tbl_genel_stoklar WHERE URUN_GRUBU LIKE '%" + Urun_Grubu + "%'";
                DataTable dt = Dbase.TabloCek(sql);
                return dt;  
            }
        }
    }
}
