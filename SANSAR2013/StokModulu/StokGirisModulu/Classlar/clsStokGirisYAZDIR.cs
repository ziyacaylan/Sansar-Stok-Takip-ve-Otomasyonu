using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.StokGirisModulu.Classlar
{
    class clsStokGirisYAZDIR
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();

        public void StokGirisYazdir(string KayitNO)
        {
            string query = "SELECT * FROM vw_stok_giris_hareket WHERE SIPARIS_NO='"+KayitNO+"'";
            DataSet dsStogGiris = new DataSet();
            dsStogGiris = Dbase.DataSetCEK(query);
            StokGirisModulu.Dizayn.rapYAZ_StokGiris rapor = new Dizayn.rapYAZ_StokGiris();
            rapor.DataSource = dsStogGiris;
            rapor.ShowPreview();
        }
    }
}
