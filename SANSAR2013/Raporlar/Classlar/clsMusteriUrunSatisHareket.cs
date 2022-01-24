using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.Raporlar.Classlar
{
    class clsMusteriUrunSatisHareket
    {
        SANSAR2013.Classlar.Veritabani dBASE = new SANSAR2013.Classlar.Veritabani();

        public DataRow StokBilgileriniCEK(string URUN_ID)
        {            
            string query = "SELECT * FROM tbl_genel_stoklar WHERE ID='" + URUN_ID + "'";
            DataRow drow = dBASE.SatirCek(query);
            return drow;
        }
        public DataTable SatisUrunHAREKET(string musteriKODU,string stokKODU,string modelNO)
        {
            if (stokKODU!="")
            {
             string query = "SELECT * FROM vw_musteri_urun_hareket WHERE MUSTERI_KODU='" + musteriKODU + "' AND STOK_KODU='" + stokKODU + "'";
             DataTable Tablo = dBASE.TabloCek(query);  
             return Tablo;
            }
            else
            {
                string query1 = "SELECT * FROM vw_musteri_urun_hareket WHERE MUSTERI_KODU='" + musteriKODU + "' AND MODEL_NO LIKE '%" + modelNO + "%'";
                DataTable Tablo1 = dBASE.TabloCek(query1);
                return Tablo1;
            }
        }
        public DataTable IkiTarihArasiSorgula(string musteriKODU, string stokKODU, string modelNO, string Tarih1, string Tarih2)
        {
            string Tipi = "SP";
            string query = "SELECT * FROM vw_musteri_urun_hareket WHERE MUSTERI_KODU='" + musteriKODU + "' AND MODEL_NO LIKE '%" + modelNO + "%' AND TARIH BETWEEN '" + Tarih1 + "' AND '" + Tarih2 + "'";
            DataTable dt = dBASE.TabloCek(query);
            return dt;
        }
    }
}
