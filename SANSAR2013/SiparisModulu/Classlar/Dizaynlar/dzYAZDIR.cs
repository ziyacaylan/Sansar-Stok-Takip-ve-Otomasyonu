using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.SiparisModulu.Classlar.Dizaynlar
{
    class dzYAZDIR
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();

        public void SatisFaturasiYazdir(string SiparisNO)
        {
            string query = "SELECT * FROM vw_rap_siparisler WHERE SIPARIS_NO='"+SiparisNO+"'";
            DataSet Siparis = new DataSet();
            Siparis = Dbase.DataSetCEK(query);
            rapSIPARIS rapor = new rapSIPARIS();
            rapor.DataSource = Siparis;
            rapor.ShowPreview();
        }
        public void SatisFaturasiYazdir_1(string SiparisNO)
        {
            string query = "SELECT * FROM vw_rap_siparisler WHERE SIPARIS_NO='" + SiparisNO + "'";
            DataSet Siparis = new DataSet();
            Siparis = Dbase.DataSetCEK(query);
            rapSIPARIS rapor = new rapSIPARIS();
            rapor.DataSource = Siparis;
            rapor.Print();
        }
        public void Stok_Hareket_Yazdir(string SiparisNO)
        {
            string query = "SELECT * FROM vw_stok_hareket WHERE SIPARIS_NO='" + SiparisNO + "'";
            DataSet Siparis = new DataSet();
            Siparis = Dbase.DataSetCEK(query);
            rapSIPARIS rapor = new rapSIPARIS();
            rapor.DataSource = Siparis;
            rapor.ShowPreview();
        }
        public void SatisFaturasiYazdir_muh(string SiparisNO)
        {
            string query = "SELECT * FROM vw_rap_siparisler WHERE SIPARIS_NO='" + SiparisNO + "'";
            DataSet Siparis = new DataSet();
            Siparis = Dbase.DataSetCEK(query);
            rapSIPARIS_muh rapor = new rapSIPARIS_muh();
            rapor.DataSource = Siparis;
            rapor.ShowPreview();
        }
        public void SatisFaturasiYazdir_muh_1(string SiparisNO)
        {
            string query = "SELECT * FROM vw_rap_siparisler WHERE SIPARIS_NO='" + SiparisNO + "'";
            DataSet Siparis = new DataSet();
            Siparis = Dbase.DataSetCEK(query);
            rapSIPARIS_muh rapor = new rapSIPARIS_muh();
            rapor.DataSource = Siparis;
            rapor.Print();
        }
        public void Stok_Hareket_Yazdir_muh(string SiparisNO)
        {
            string query = "SELECT * FROM vw_stok_hareket WHERE SIPARIS_NO='" + SiparisNO + "'";
            DataSet Siparis = new DataSet();
            Siparis = Dbase.DataSetCEK(query);
            rapSIPARIS_muh rapor = new rapSIPARIS_muh();
            rapor.DataSource = Siparis;
            rapor.ShowPreview();
        }
    }
}
