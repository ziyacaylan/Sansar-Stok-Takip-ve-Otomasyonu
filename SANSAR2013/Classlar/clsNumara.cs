using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.Classlar
{
    class clsNumara
    {
        SANSAR2013.Classlar.Veritabani Dbase = new Veritabani();
        SANSAR2013.Classlar.clsFatParametre Parametreler = new clsFatParametre();

        public string GetYeniSiparisNumarasi()
        {
            string Numara = SiparisNumarasi();
            string Numara1 = SiparisNumarasi1();

            int Yeni = Convert.ToInt32(Numara);
            int Yeni1 = Convert.ToInt32(Numara1);

            if (Yeni < Yeni1)
            {
                Yeni = Yeni1;
            }
            string Sifirlar = "";

            int uz = Parametreler.GetSiparisUzun();
            int bas_uzunluk = Parametreler.GetSiparisBasKar().Length;
            int yeni_uzunluk = Yeni.ToString().Length;

            int sayac = uz - bas_uzunluk - yeni_uzunluk;
            for (int i = 0; i < sayac; i++)
            {
                Sifirlar += "0";
            }
            Numara = Parametreler.SiparisBasKar + Sifirlar + (Yeni + 1);
            return Numara;



            //string Numara = SiparisNumarasi();
            //string Numara1 = SiparisNumarasi1();
            //int Yeni;
            //int Yeni1;

            //Numara = Numara.Substring(Parametreler.GetSiparisBasKar().Length, Numara.Length - Parametreler.GetSiparisBasKar().Length);
            //Yeni = Convert.ToInt32(Numara);

            //Numara1 = Numara1.Substring(Parametreler.GetSiparisBasKar().Length, Numara1.Length - Parametreler.GetSiparisBasKar().Length);
            //Yeni1 = Convert.ToInt32(Numara1);

            //if (Yeni < Yeni1)
            //{
            //    Yeni = Yeni1;
            //}
            //string Sifirlar = "";

            //int uz = Parametreler.GetSiparisUzun();
            //int bas_uzunluk = Parametreler.GetSatisIadeBasKar().Length;
            //int yeni_uzunluk = Yeni.ToString().Length;

            //int sayac = uz - bas_uzunluk - yeni_uzunluk;
            //for (int i = 0; i < sayac; i++)
            //{
            //    Sifirlar += "0";
            //}
            //Numara = Parametreler.SiparisBasKar + Sifirlar + (Yeni + 1);
            //return Numara;
        }

        string SiparisNumarasi1()
        {
            string query = "SELECT * FROM tbl_siparis_hareket WHERE TIPI='SP' || TIPI='KNS.SP'";
            DataTable Tablo = new DataTable();
            Tablo = Dbase.TabloCek(query);
            int sonuc = 0;

            for (int i = 0; i < Tablo.Rows.Count; i++)
            {
                string siparis_no_OKU = Tablo.Rows[i]["SIPARIS_NO"].ToString();

                string Numara;
                int Yeni;

                Numara = siparis_no_OKU.Substring(Parametreler.GetSiparisBasKar().Length, siparis_no_OKU.Length - Parametreler.GetSiparisBasKar().Length);
                Yeni = Convert.ToInt32(Numara);

                if (sonuc < Yeni)
                {
                    sonuc = Yeni;
                }
            }
            return sonuc.ToString();   


            //string query = "SELECT * FROM tbl_siparis_hareket WHERE TIPI='SP' || TIPI='KNS.SP' ORDER BY ID DESC";
            //DataRow drow1 = Dbase.SatirCek(query);
            //if (drow1 != null)
            //{
            //    string Numara1 = drow1["SIPARIS_NO"].ToString();
            //    return Numara1;
            //}
            //else
            //{
            //    string Numara1 = "SP0001";
            //    return Numara1;
            //}
        }
        string SiparisNumarasi()
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE TIPI='SP' || TIPI='KNS.SP'";
            DataTable Tablo = new DataTable();
            Tablo = Dbase.TabloCek(query);
            int sonuc = 0;

            for (int i = 1; i < Tablo.Rows.Count; i++)
            {
                string siparis_no_OKU = Tablo.Rows[i]["SIPARIS_NO"].ToString();

                string Numara;
                int Yeni;

                Numara = siparis_no_OKU.Substring(Parametreler.GetSiparisBasKar().Length, siparis_no_OKU.Length - Parametreler.GetSiparisBasKar().Length);
                Yeni = Convert.ToInt32(Numara);

                if (sonuc < Yeni)
                {
                    sonuc = Yeni;
                }
            }
            return sonuc.ToString();         
        }

        string TedarikNumarasi()
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE TIPI='AF'";
            DataTable Tablo = new DataTable();
            Tablo = Dbase.TabloCek(query);
            int sonuc = 0;

            for (int i = 0; i < Tablo.Rows.Count; i++)
            {
                string siparis_no_OKU = Tablo.Rows[i]["SIPARIS_NO"].ToString();

                string Numara;
                int Yeni;

                Numara = siparis_no_OKU.Substring(Parametreler.GetSatisIadeBasKar().Length, siparis_no_OKU.Length - Parametreler.GetSatisIadeBasKar().Length);
                Yeni = Convert.ToInt32(Numara);

                if (sonuc < Yeni)
                {
                    sonuc = Yeni;
                }
            }
            return sonuc.ToString();
        }
        public string GetTedarikFaturaNumarasi()
        {
            string Numara = TedarikNumarasi();
            int Yeni = Convert.ToInt32(Numara);

            string Sifirlar = "";

            int uz = Parametreler.GetAlisUzun();
            int bas_uzunluk = Parametreler.GetAlisBasKar().Length;
            int yeni_uzunluk = Yeni.ToString().Length;

            int sayac = uz - bas_uzunluk - yeni_uzunluk;
            for (int i = 0; i < sayac; i++)
            {
                Sifirlar += "0";
            }
            Numara = Parametreler.AlisBasKar + Sifirlar + (Yeni + 1);
            return Numara;
        }

        string ServisNumarasi()
        {
            string query = "SELECT * FROM tbl_arizalilar WHERE TIPI='SRV'";
            DataTable Tablo = new DataTable();
            Tablo = Dbase.TabloCek(query);
            int sonuc = 0;
            if (Tablo.Rows.Count > 0)
            {
                for (int i = 0; i < Tablo.Rows.Count; i++)
                {
                    string siparis_no_OKU = Tablo.Rows[i]["SERVIS_NO"].ToString();

                    string Numara;
                    int Yeni;

                    Numara = siparis_no_OKU.Substring(Parametreler.GetServisBasKar().Length, siparis_no_OKU.Length - Parametreler.GetServisBasKar().Length);
                    Yeni = Convert.ToInt32(Numara);

                    if (sonuc < Yeni)
                    {
                        sonuc = Yeni;
                    }
                }
            }
            else
            {
                sonuc = 0;
            }
            return sonuc.ToString();
        }
        public string ServisNumarasi1()
        {
            string query = "SELECT * FROM tbl_arizalilar_gonderilen WHERE TIPI='SRV'";
            DataTable Tablo = new DataTable();
            Tablo = Dbase.TabloCek(query);
            int sonuc = 0;
            if (Tablo.Rows.Count > 0)
            {
                for (int i = 0; i < Tablo.Rows.Count; i++)
                {
                    string siparis_no_OKU = Tablo.Rows[i]["SERVIS_NO"].ToString();

                    string Numara;
                    int Yeni;

                    Numara = siparis_no_OKU.Substring(Parametreler.GetServisBasKar().Length, siparis_no_OKU.Length - Parametreler.GetServisBasKar().Length);
                    Yeni = Convert.ToInt32(Numara);

                    if (sonuc < Yeni)
                    {
                        sonuc = Yeni;
                    }
                }
            }
            else
            {
                sonuc = 0;
            }
            return sonuc.ToString();
        }
        public string GetServisNumarasi()
        {
            string Numara = ServisNumarasi();
            string Numara1 = ServisNumarasi1();

            int Yeni = Convert.ToInt32(Numara);
            int Yeni1 = Convert.ToInt32(Numara1);

            if (Yeni < Yeni1)
            {
                Yeni = Yeni1;
            }
            string Sifirlar = "";

            int uz = Parametreler.GetServisUzun();
            int bas_uzunluk = Parametreler.GetServisBasKar().Length;
            int yeni_uzunluk = Yeni.ToString().Length;

            int sayac = uz - bas_uzunluk - yeni_uzunluk;
            for (int i = 0; i < sayac; i++)
            {
                Sifirlar += "0";
            }
            Numara = Parametreler.ServisBasKar + Sifirlar + (Yeni + 1);
            return Numara;
            //string Numara = ServisNumarasi();
            //int Yeni = Convert.ToInt32(Numara);

            //string Sifirlar = "";

            //int uz = Parametreler.GetServisUzun();
            //int bas_uzunluk = Parametreler.GetServisBasKar().Length;
            //int yeni_uzunluk = Yeni.ToString().Length;

            //int sayac = uz - bas_uzunluk - yeni_uzunluk;
            //for (int i = 0; i < sayac; i++)
            //{
            //    Sifirlar += "0";
            //}
            //Numara = Parametreler.ServisBasKar + Sifirlar + (Yeni + 1);
            //return Numara;
        }

        string SatisIadeNumarasi()
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE TIPI='SI'";
            DataTable Tablo = new DataTable();
            Tablo = Dbase.TabloCek(query);
            int sonuc = 0;

            for (int i = 1; i < Tablo.Rows.Count; i++)
            {
                string siparis_no_OKU = Tablo.Rows[i]["SIPARIS_NO"].ToString();

                string Numara;
                int Yeni;

                Numara = siparis_no_OKU.Substring(Parametreler.GetSatisIadeBasKar().Length, siparis_no_OKU.Length - Parametreler.GetSatisIadeBasKar().Length);
                Yeni = Convert.ToInt32(Numara);

                if (sonuc < Yeni)
                {
                    sonuc = Yeni;
                }
            }
            return sonuc.ToString();
        }
        string SatisIadeNumarasi1()
        {
            string query = "SELECT * FROM tbl_siparis_hareket WHERE TIPI='SI'";
            DataTable Tablo = new DataTable();
            Tablo = Dbase.TabloCek(query);
            int sonuc = 0;

            for (int i = 1; i < Tablo.Rows.Count; i++)
            {
                string siparis_no_OKU = Tablo.Rows[i]["SIPARIS_NO"].ToString();

                string Numara;
                int Yeni;

                Numara = siparis_no_OKU.Substring(Parametreler.GetSatisIadeBasKar().Length, siparis_no_OKU.Length - Parametreler.GetSatisIadeBasKar().Length);
                Yeni = Convert.ToInt32(Numara);

                if (sonuc < Yeni)
                {
                    sonuc = Yeni;
                }
            }
            return sonuc.ToString();
        }
        public string GetSatisIadeFaturaNumarasi()
        {
            string Numara = SatisIadeNumarasi();
            string Numara1 = SatisIadeNumarasi1();
            int Yeni=Convert.ToInt32(Numara);
            int Yeni1=Convert.ToInt32(Numara1);

            if (Yeni <= Yeni1)
            {
                Yeni = Yeni1;
            }
            string Sifirlar = "";

            int uz = Parametreler.GetSatisIadeUzun();
            int bas_uzunluk = Parametreler.GetSatisIadeBasKar().Length;
            int yeni_uzunluk = Yeni.ToString().Length;

            int sayac = uz - bas_uzunluk - yeni_uzunluk;
            for (int i = 0; i < sayac; i++)
            {
                Sifirlar += "0";
            }
            Numara = Parametreler.SatisIadeBasKar + Sifirlar + (Yeni + 1);
            return Numara;
        }
        //string SatisIadeFaturaNumarasi()
        //{
        //    string Sql = "SELECT dbo.FN_FATURANUMARA('SI') AS NUMARA";
        //    string Numara = Dbase.SatirCek(Sql)["NUMARA"].ToString();
        //    return Numara;
        //}
        //string AlisFaturaNumarasi()
        //{
        //    string Sql = "SELECT dbo.FN_FATURANUMARA('A') AS NUMARA";
        //    string Numara = Dbase.SatirCek(Sql)["NUMARA"].ToString();
        //    return Numara;
        //}
        //string AlisIadeFaturaNumarasi()
        //{
        //    string Sql = "SELECT dbo.FN_FATURANUMARA('AI') AS NUMARA";
        //    string Numara = Dbase.SatirCek(Sql)["NUMARA"].ToString();
        //    return Numara;
        //}
        //Numara = Numara.Substring(Parametreler.GetSatisIadeBasKar().Length, Numara.Length - Parametreler.GetSatisIadeBasKar().Length);
        //Yeni = Convert.ToInt32(Numara);

        //Numara1 = Numara1.Substring(Parametreler.GetSatisIadeBasKar().Length, Numara1.Length - Parametreler.GetSatisIadeBasKar().Length);
        //Yeni1 = Convert.ToInt32(Numara1);
    }
}
