using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.DefolularStokgu.Dizaynlar
{
    class clsYAZDIR
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();

        public void DefoluYazdir_STOK_KODU(string stok_kodu)
        {
            string query = "SELECT * FROM tbl_defolu_stoklari WHERE STOK_KODU LIKE '%" + stok_kodu + "%'";
            DataSet dsStogGiris = new DataSet();
            dsStogGiris = Dbase.DataSetCEK(query);
            Dizaynlar.rapYAZDIR rapor = new rapYAZDIR();
            rapor.DataSource = dsStogGiris;
            rapor.ShowPreview();
        }
        public void DefoluYazdir_MODEL_NO(string model_no)
        {
            string query = "SELECT * FROM tbl_defolu_stoklari WHERE MODEL_NO LIKE '%" + model_no + "%'";
            DataSet dsStogGiris = new DataSet();
            dsStogGiris = Dbase.DataSetCEK(query);
            Dizaynlar.rapYAZDIR rapor = new rapYAZDIR();
            rapor.DataSource = dsStogGiris;
            rapor.ShowPreview();
        }
        public void DefoluYazdir_URUN_GRUBU(string urun_grubu)
        {
            string query = "SELECT * FROM tbl_defolu_stoklari WHERE URUN_GRUBU LIKE '%" + urun_grubu + "%'";
            DataSet dsStogGiris = new DataSet();
            dsStogGiris = Dbase.DataSetCEK(query);
            Dizaynlar.rapYAZDIR rapor = new rapYAZDIR();
            rapor.DataSource = dsStogGiris;
            rapor.ShowPreview();
        }
        public void DefoluYazdir()
        {
            string query = "SELECT * FROM tbl_defolu_stoklari ";
            DataSet dsStogGiris = new DataSet();
            dsStogGiris = Dbase.DataSetCEK(query);
            Dizaynlar.rapYAZDIR rapor = new rapYAZDIR();
            rapor.DataSource = dsStogGiris;
            rapor.ShowPreview();
        }
    }
}
