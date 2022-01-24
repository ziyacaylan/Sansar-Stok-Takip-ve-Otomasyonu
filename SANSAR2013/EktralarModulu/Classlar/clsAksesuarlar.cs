using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.EktralarModulu.Classlar
{
    class clsAksesuarlar
    {
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.Classlar.Veritabani DBase = new SANSAR2013.Classlar.Veritabani();

        public void Ekle(string Aksesuar, string Aciklama)
        {
            string query = "INSERT INTO tbl_aksesuarlar (AKSESUAR_ADI,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + Aksesuar + "','" + Aciklama + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            DBase.Insert(query);
        }

        public void Guncelle(string ID, string Aksesuar, string Aciklama)
        {
            string query = "UPDATE tbl_aksesuarlar SET AKSESUAR_ADI='" + Aksesuar + "',ACIKLAMA='" + Aciklama + "',EDIT_USER='" + AnaForm.UserId + "',EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE ID='" + ID + "'";
            DBase.Insert(query);
        }
        public void Sil(string SecilenID)
        {
            string query = "DELETE FROM tbl_aksesuarlar WHERE ID='" + SecilenID + "'";
            DBase.Delete(query);
        }
        public DataTable Listele()
        {
            string query = "SELECT * FROM tbl_aksesuarlar";
            DataTable tablo = DBase.TabloCek(query);
            return tablo;
        }
        public Boolean AksesuarEklimi(string aksesuar_adi)
        {
            Boolean ekli = false;
            string query = "SELECT * FROM tbl_aksesuarlar WHERE AKSESUAR_ADI='"+aksesuar_adi+"'";
            DataRow drow = DBase.SatirCek(query);
            try
            {
                string aksesuar = "";
                aksesuar = drow["AKSESUAR_ADI"].ToString();
                if (aksesuar != "")
                {
                    ekli = true;
                    return ekli;
                }
            }
            catch (Exception)
            {
                ekli = false;
                return ekli;
            }
            return ekli;
        }
        public DataTable Sorgula(string Aksesuar)
        {
            string query = "SELECT * FROM tbl_aksesuarlar WHERE AKSESUAR_ADI LIKE '%"+Aksesuar+"%'";
            DataTable Tablo = DBase.TabloCek(query);
            return Tablo;
        }
    }

}
