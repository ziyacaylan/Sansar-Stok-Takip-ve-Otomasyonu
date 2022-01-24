using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SANSAR2013.Classlar
{
    class Formatlar
    {
        public string IngiliceTarihFormati(string GelenTarih)
        {
            DateTime Tarih = Convert.ToDateTime(GelenTarih);
            string Gun, Ay, Yil, Saat, Dakika, Saniye;
            Gun = Tarih.Day.ToString();
            Ay = Tarih.Month.ToString();
            Yil = Tarih.Year.ToString();
            Saat = Tarih.Hour.ToString();
            Dakika = Tarih.Minute.ToString();
            Saniye = Tarih.Second.ToString();
            string YeniTarih = Yil + "-" + Ay + "-" + Gun + "  " + Saat + ":" + Dakika + ":" + Saniye;
            //string YeniTarih = Yil + "-" + Ay + "-" + Gun;
           // 2013-01-17 11:42:31
            return YeniTarih;
        }
        public string IngilizceTarihKısaFormat(string GelenTarih)
        {
            DateTime Tarih = Convert.ToDateTime(GelenTarih);
            string Gun, Ay, Yil, Saat, Dakika, Saniye;
            Gun = Tarih.Day.ToString();
            Ay = Tarih.Month.ToString();
            Yil = Tarih.Year.ToString();
            Saat = Tarih.Hour.ToString();
            Dakika = Tarih.Minute.ToString();
            Saniye = Tarih.Second.ToString();
            string YeniTarih = Yil + "-" + Ay + "-" + Gun;
            //string YeniTarih = Yil + "-" + Ay + "-" + Gun;
            // 2013-01-17 11:42:31
            return YeniTarih;
        }
        public string EskiyeCevirKısa(string GelenTarih)
        {
            DateTime Tarih = Convert.ToDateTime(GelenTarih);
            string Gun, Ay, Yil, Saat, Dakika, Saniye;
            Gun = Tarih.Day.ToString();
            Ay = Tarih.Month.ToString();
            Yil = Tarih.Year.ToString();
            Saat = Tarih.Hour.ToString();
            Dakika = Tarih.Minute.ToString();
            Saniye = Tarih.Second.ToString();
            string YeniTarih = Gun + "." + Ay + "." + Yil;
            //string YeniTarih = Yil + "-" + Ay + "-" + Gun;
            // 2013-01-17 11:42:31
            return YeniTarih;
        }
    }
}
