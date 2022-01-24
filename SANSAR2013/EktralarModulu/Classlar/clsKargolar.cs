using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.EktralarModulu.Classlar
{
    class clsKargolar
    {
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.Classlar.Veritabani DBase = new SANSAR2013.Classlar.Veritabani();

        public void Ekle(string Teslim,string Telefon,string Aciklama)
        {
            string query = "INSERT INTO tbl_kargolar (TESLIM,TEL,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + Teslim + "','"+Telefon+"','"+Aciklama+"','"+AnaForm.UserId+"','"+Formatlar.IngiliceTarihFormati(DateTime.Now.ToString())+"')";
            DBase.Insert(query);
        }

        public void  Guncelle(string SecilenID, string Teslim,string Telefon,string Aciklama)
        {
            string query = "UPDATE tbl_kargolar SET TESLIM='" + Teslim + "',TEL='" + Telefon + "',ACIKLAMA='" + Aciklama + "',EDIT_USER='" + AnaForm.UserId + "',EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE ID='" + SecilenID + "'";
            DBase.Update(query);
        }
        public void Sil(string SecilenID)
        {
            string query = "DELETE FROM tbl_kargolar WHERE ID='" + SecilenID + "'";
            DBase.Delete(query);
        }
        public DataTable Listele()
        {
            string query = "SELECT * FROM tbl_kargolar";
            DataTable tablo = DBase.TabloCek(query);
            return tablo;
        }

        public DataRow Ac(string Id)
        {
            return DBase.SatirCek("SELECT * FROM tbl_kargolar WHERE ID=" + Id);
        }
        public string KargoIsminiAl(string Id)
        {
            DataRow Satir;
            string query = "SELECT TESLIM FROM tbl_kargolar WHERE ID='" + Id + "'";
            Satir = DBase.SatirCek(query);
            string ali = Satir["TESLIM"].ToString();
            return ali;
        }
        public string Kargo_ID_AL(string Teslim)
        {
            string Urun_ID;
            string query = "SELECT * FROM tbl_kargolar WHERE TESLIM='" + Teslim + "'";
            DataRow Satir = DBase.SatirCek(query);

            return Urun_ID = Satir["ID"].ToString();
        }
        public int KargoListeToplamı()
        {
            string query = "SELECT Count(TESLIM) FROM tbl_kargolar";

            return DBase.Count(query);
        }
    }
}
