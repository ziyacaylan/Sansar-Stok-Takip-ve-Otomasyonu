using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.TeknikServisModulu.TS_OlayModulu.Dizaynlar.Classlar
{
    class clsCikisYazdir
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();

        public void ServisCikisYazdir(string SiparisNO)
        {
            string query = "SELECT * FROM vw_arizalilar_gonderilen WHERE SERVIS_NO='" + SiparisNO + "'";
            DataSet Arizali = new DataSet();
            Arizali = Dbase.DataSetCEK(query);
            rapCikisYazdir_ rapor = new rapCikisYazdir_();
            rapor.DataSource = Arizali;
            rapor.ShowPreview();
        }
        public void ServisIslemYazdir(string SiparisNO)
        {
            string query = "SELECT * FROM vw_arizalilar WHERE SERVIS_NO='" + SiparisNO + "'";
            DataSet Arizali = new DataSet();
            Arizali = Dbase.DataSetCEK(query);
            rapCikisYazdir_ rapor = new rapCikisYazdir_();
            rapor.DataSource = Arizali;
            rapor.ShowPreview();
        }
    }
}
