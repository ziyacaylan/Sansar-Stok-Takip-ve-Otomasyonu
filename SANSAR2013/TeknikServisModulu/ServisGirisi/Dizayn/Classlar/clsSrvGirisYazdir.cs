using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.TeknikServisModulu.ServisGirisi.Dizayn.Classlar
{
    class clsSrvGirisYazdir
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();

        public void ServisGirisYazdir(string SiparisNO)
        {
            string query = "SELECT * FROM vw_arizalilar WHERE SERVIS_NO='" + SiparisNO + "'";
            DataSet Arizali = new DataSet();
            Arizali = Dbase.DataSetCEK(query);
            rapYAZDIR rapor = new rapYAZDIR();
            rapor.DataSource = Arizali;
            rapor.ShowPreview();
        }
    }
}
