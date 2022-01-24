using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SANSAR2013.Classlar
{
    class GirisIslemi
    {
        Veritabani Dbase = new Veritabani();
        public Boolean KullaniciGirisi(string KullaniciAdi, string Parola)
        {
            string sql = "SELECT * FROM tbl_kullanicilar WHERE KULLANICI_ADI='" + KullaniciAdi + "' AND PAROLA='" + Parola + "'";
           
            try
            {
                DataRow Satir = Dbase.SatirCek(sql);
                AnaForm.UserId=Satir["ID"].ToString();
                AnaForm.Adi = Satir["ADI"].ToString();
                AnaForm.Soyadi = Satir["SOYADI"].ToString();
                AnaForm.Username = KullaniciAdi;
                AnaForm.GirisDurumu = true;
                return true;
            }
            catch (Exception)
            {
                AnaForm.UserId = "-1";
                AnaForm.Username = "";
                AnaForm.GirisDurumu = false;
                return false;
            }
            
           // return false ;
        }
    }
}
