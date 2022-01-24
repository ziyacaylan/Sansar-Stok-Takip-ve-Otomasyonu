using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.StokModulu.Classlar
{
    class clsUrunGrubu
    {      
        //Boolean  gonder = false;

        SANSAR2013.Classlar.Veritabani DBase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        
        public  DataTable Listele()
        {
            string query = "SELECT * FROM tbl_urun_grubu";
            DataTable tablo = DBase.TabloCek(query);
            return tablo;
        }

        public void Ekle(string Urun_Grubu,string Aciklama)
        {
            string query = "INSERT INTO tbl_urun_grubu (URUN_GRUBU,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('" + Urun_Grubu.ToUpper() + "','" + Aciklama.ToUpper() + "','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "')";
            DBase.Insert(query);
        }

        public void Guncelle(string Grup_ID ,string Urun_Grubu, string Aciklama)
        {
            string query = "UPDATE tbl_urun_grubu SET URUN_GRUBU='" + Urun_Grubu.ToUpper() + "', ACIKLAMA='" + Aciklama.ToUpper() + "', EDIT_USER='" + AnaForm.UserId + "', EDIT_DATE='" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "' WHERE ID='" + Grup_ID + "'";
            DBase.Isle(query);
        }

        public DataRow Ac(string Id)
        {
            return DBase.SatirCek("SELECT * FROM tbl_urun_grubu WHERE ID=" + Id);
        }

        //public DataRow Grup_Adi_Sorgula(string grup_adi )
        //{
        //    string query = "SELECT * FROM tbl_urun_grubu WHERE URUN_GRUBU='"+grup_adi+"'";
        //   return DBase.SatirCek(query);
        //}

        public Boolean sorgu_sonucu(string grup_adi)
        {
            IDataReader reader;
            string  sonuc="";
            
            string query = "SELECT * FROM tbl_urun_grubu WHERE URUN_GRUBU='" + grup_adi + "'";
            reader=DBase.DataOku(query);
            while (reader.Read())
            {
                sonuc = reader["URUN_GRUBU"].ToString();
            }
            reader.Close();

           if (sonuc == grup_adi)
           {
               return true;
           }
           else
           {
               return false;
           }

        }
        public void Sil(string SecilenID)
        {
            string query = "DELETE FROM tbl_urun_grubu WHERE ID='" + SecilenID + "'";
            DBase.Delete(query);
        }
        public string UrunGrubuAl(string Id)
        {
            return Ac(Id)["URUN_GRUBU"].ToString();
        }
        public string Urun_Grubu_ID_AL(string Urun_Grubu)
        {
            string  Urun_ID;
            string query = "SELECT * FROM tbl_urun_grubu WHERE URUN_GRUBU='" + Urun_Grubu+"'";
           DataRow Satir= DBase.SatirCek(query);

            return Urun_ID=Satir["ID"].ToString();
        }
    }
}
