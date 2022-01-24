using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.SatisModulu.SatisIadeModulu.Dizaynlar
{
    class clsYazdir
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();

        public void SatisIADEFaturasiYazdir(string SiparisNO)
        {
            string query = "SELECT * FROM vw_stok_hareket WHERE SIPARIS_NO='" + SiparisNO + "'";
            DataSet Siparis = new DataSet();
            Siparis = Dbase.DataSetCEK(query);
            rapSatisIADESI rapor = new rapSatisIADESI();
            rapor.DataSource = Siparis;
            rapor.ShowPreview();
        }
        public void SatisIADEFaturasiYazdir__Kayitsiz(string SiparisNO)
        {
            string query = "SELECT * FROM vw_rap_siparisler WHERE SIPARIS_NO='" + SiparisNO + "'";
            DataSet Siparis = new DataSet();
            Siparis = Dbase.DataSetCEK(query);
            rapSatisIADESI rapor = new rapSatisIADESI();
            rapor.DataSource = Siparis;
            rapor.ShowPreview();
        }
    }
}
