using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.DefolularStokgu.Classlar
{
    class clsDefolularListesi
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();

        public DataTable Defolu_Listele()
        {
            string query = "SELECT * FROM tbl_defolu_stoklari";
           DataTable Tablo= Dbase.TabloCek(query);
           return Tablo;
        }
        public DataTable StokKoduSOR(string stok_kodu)
        {
            string query = "SELECT * FROM tbl_defolu_stoklari WHERE STOK_KODU LIKE '%"+stok_kodu+"%'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataTable Model_NO_SOR(string Model_NO)
        {
            string query = "SELECT * FROM tbl_defolu_stoklari WHERE MODEL_NO LIKE '%" + Model_NO + "%'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataTable Urun_Grubu_SOR(string Urun_Grubu)
        {
            string query = "SELECT * FROM tbl_defolu_stoklari WHERE URUN_GRUBU LIKE '%" + Urun_Grubu + "%'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public void DefoluSIL(string Urun_ID)
        {
            string query = "DELETE FROM tbl_defolu_stoklari WHERE ID='" + Urun_ID + "'";
            Dbase.Delete(query);
        }
    }
}
