using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.TeknikServisModulu.ServisCikis.Classlar
{
    class clsServisCikis
    {
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();

        public DataTable Listele()
        {
            string query = "SELECT * FROM tbl_arizalilar_gonderilen ";
            return Dbase.TabloCek(query);
        }
        public string ArizaliMusteriKoduCek(string kayit_No)
        {
            string musteri_kodu = "";
            string query = "SELECT * FROM tbl_arizalilar_gonderilen WHERE SERVIS_NO='" + kayit_No + "'";
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
        public DataTable FirmaAdiSorgula(string FirmaAdi)
        {
            string query = "SELECT * FROM tbl_arizalilar_gonderilen WHERE FIRMA_ADI LIKE '%" + FirmaAdi + "%'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataTable ServisNoSorgula(string kayit_No)
        {
            string query = "SELECT * FROM tbl_arizalilar_gonderilen WHERE SERVIS_NO LIKE '%" + kayit_No + "%'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataTable IrsaliyeNOSorgula(string GIRIS_IRSALIYE_NO)
        {
            string query = "SELECT * FROM tbl_arizalilar_gonderilen WHERE GIRIS_IRSALIYE_NO LIKE '%" + GIRIS_IRSALIYE_NO + "%'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataTable IlkTarihSorgula(string Tarih)
        {
            string query = "SELECT * FROM tbl_arizalilar_gonderilen WHERE SERVIS_GIR_TARIH='" + Tarih + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
        public DataTable IkiTarihArasiSorgula(string Tarih1, string Tarih2)
        {
            string query = "SELECT * FROM tbl_arizalilar_gonderilen WHERE SERVIS_GIR_TARIH BETWEEN '" + Tarih1 + "' AND '" + Tarih2 + "'";
            DataTable dt = Dbase.TabloCek(query);
            return dt;
        }
    }
}
