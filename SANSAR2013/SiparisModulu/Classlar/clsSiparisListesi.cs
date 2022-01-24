using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.SiparisModulu.Classlar
{
    class clsSiparisListesi
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        public DataTable Listele()
        {
            string tipi="SP";
            string sql = "SELECT * FROM tbl_siparis_hareket WHERE TIPI='"+tipi+"'";
            DataTable dt = Dbase.TabloCek(sql);
            return dt;
        }
        public string MusteriKoduCek(string Id)
        {
            string musteri_kodu="";
            string query = "SELECT * FROM tbl_siparis_hareket WHERE ID='" + Id + "'";
            DataRow drow = Dbase.SatirCek(query);
            if (drow != null)
            {
                musteri_kodu = drow["MUSTERI_KODU"].ToString();
                return musteri_kodu;
            }
            else
            {
                return musteri_kodu;
            }
        }
        public DataTable FirmaSorgula(string FirmaAdi)
        {
            string Tipi="SP";
            string query = "SELECT * FROM tbl_siparis_hareket WHERE FIRMA_ADI LIKE '%" + FirmaAdi + "%' AND TIPI='"+Tipi+"'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public DataTable FisNoSorgula(string FisNo)
        {
            string Tipi = "SP";
            string query = "SELECT * FROM tbl_siparis_hareket WHERE FIS_NO LIKE '%" + FisNo + "%' AND TIPI='" + Tipi + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public DataTable FaturaNoSorgula(string FatNo)
        {
            string Tipi = "SP";
            string query = "SELECT * FROM tbl_siparis_hareket WHERE FATURA_NO LIKE '%" + FatNo + "%' AND TIPI='" + Tipi + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public DataTable SiparisNoSorgula(string SiparisNo)
        {
            string Tipi = "SP";
            string query = "SELECT * FROM tbl_siparis_hareket WHERE SIPARIS_NO LIKE '%" + SiparisNo + "%' AND TIPI='" + Tipi + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
    }
}
