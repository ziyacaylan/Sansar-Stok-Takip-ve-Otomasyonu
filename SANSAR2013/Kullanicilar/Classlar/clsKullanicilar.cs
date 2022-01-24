using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.Kullanicilar.Classlar
{
    class clsKullanicilar
    {
        SANSAR2013.Classlar.Veritabani DBase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        public int Kullanici_ID_Cek(string Kullanini_Adi)
        {
            string query = "SELECT * FROM tbl_kullanicilar WHERE KULLANICI_ADI='" + Kullanini_Adi + "'";            
            DataRow drow=DBase.SatirCek(query);
            int Kullanici_ID= Convert.ToInt32(drow["ID"].ToString());
            return Kullanici_ID;
        }
        public string KullaniciAdiCek(string kullaniciID)
        {
            string query = "SELECT * FROM tbl_kullanicilar WHERE ID='" + kullaniciID + "'";
            DataRow drow = DBase.SatirCek(query);
            string  Kullanici_adi= drow["ADI"].ToString();
            return Kullanici_adi;
        }
        public void KullaniciEkle(string adi, string soyadi, string unvan, string tel, string email, string kullanici_adi, string parola, string kullanici_tipi, string aciklama)
        {
            string query = "INSERT INTO tbl_kullanicilar (ADI,SOYADI,TELEFON,MAIL,KULLANICI_ADI,PAROLA,KULLANICI_TIPI,ACIKLAMA,SAVE_USER,SAVE_DATE) VALUES ('"+adi+"','"+soyadi+"','"+unvan+"','"+tel+"','"+email+"','"+kullanici_adi+"','"+parola+"','"+aciklama+"','"+AnaForm.UserId.ToString()+"','"+Formatlar.IngiliceTarihFormati(DateTime.Now.ToString())+"')";
            DBase.Insert(query);

        }
        public void KullaniciGuncelle(string kullanici_ID,string adi, string soyadi, string unvan, string tel, string email, string kullanici_adi, string parola, string kullanici_tipi,string aciklama)
        {
            string query = "UPDATE tbl_kullanicilar SET ADI='"+adi+"',SOYADI='"+soyadi+"',TELEFON='"+tel+"',MAIL='"+email+"',KULLANICI_ADI='"+kullanici_adi+"',PAROLA='"+parola+"',KULLANICI_TIPI='"+kullanici_tipi+"',ACIKLAMA='"+aciklama+"',EDIT_USER='"+AnaForm.UserId.ToString()+"',EDIT_DATE='"+Formatlar.IngiliceTarihFormati(DateTime.Now.ToString())+"' WHERE ID='"+kullanici_ID+"'";
            DBase.Update(query);

        }
        public void KallaniciSil(string kullanici_adi)
        {
            string query = "DELETE FROM tbl_kullanicilar WHERE KULLANICI_ADI='" + kullanici_adi + "'";
            DBase.Delete(query);
        }
    }
}
