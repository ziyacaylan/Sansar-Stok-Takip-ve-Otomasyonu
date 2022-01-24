using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.SatisModulu.SatisIadeModulu.Classlar
{
    class clsSatisIadeListesi
    {
        SANSAR2013.Classlar.Veritabani Dbase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();

        public DataTable SatisIadeListesiniGetir_Bekleyenler(string Tipi)
        {
            string query = "SELECT * FROM tbl_siparis_hareket WHERE TIPI='" + Tipi + "' AND KDV_EKLIMI='"+"H"+"'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataTable SatisIadeListesiniGetir_Eklenenler(string Tipi)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE TIPI='" + Tipi + "' AND KDV_EKLIMI='" + "E" + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            return Tablo;
        }
        public DataTable SatisIadeListesiniGetir(string Tipi)
        {
            string id, tarih, siparis_no, fatura_no, musteri_kodu, firma_adi, aciklama;
            int kalem_adet;
            DataTable Tablo_Kalemler = new DataTable();

            Tablo_Kalemler.Columns.Add(new DataColumn("ID", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("TARIH", typeof(DateTime)));
            Tablo_Kalemler.Columns.Add(new DataColumn("SIPARIS_NO", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("FATURA_NO", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("MUSTERI_KODU", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("FIRMA_ADI", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("SIP_KALEM_ADET", typeof(Int32)));
            Tablo_Kalemler.Columns.Add(new DataColumn("ACIKLAMA", typeof(string)));

            DataTable Bekleyenler = SatisIadeListesiniGetir_Bekleyenler(Tipi);

            for (int i = 0; i < Bekleyenler.Rows.Count; i++)
            {
                id = Bekleyenler.Rows[i]["ID"].ToString();
                tarih = Bekleyenler.Rows[i]["TARIH"].ToString();
                siparis_no = Bekleyenler.Rows[i]["SIPARIS_NO"].ToString();
                fatura_no = Bekleyenler.Rows[i]["FATURA_NO"].ToString();
                musteri_kodu = Bekleyenler.Rows[i]["MUSTERI_KODU"].ToString();
                firma_adi = Bekleyenler.Rows[i]["FIRMA_ADI"].ToString();
                kalem_adet =Convert.ToInt32 (Bekleyenler.Rows[i]["SIP_KALEM_ADET"].ToString());
                aciklama = Bekleyenler.Rows[i]["ACIKLAMA"].ToString();

                Tablo_Kalemler.Rows.Add(id, Formatlar.EskiyeCevirKısa(tarih), siparis_no, fatura_no, musteri_kodu, firma_adi, kalem_adet, aciklama);
            }

            DataTable Eklenenler = SatisIadeListesiniGetir_Eklenenler(Tipi);

            for (int x = 0; x < Eklenenler.Rows.Count; x++)
            {
                id = Eklenenler.Rows[x]["ID"].ToString();
                tarih = Eklenenler.Rows[x]["TARIH"].ToString();
                siparis_no = Eklenenler.Rows[x]["SIPARIS_NO"].ToString();
                fatura_no = Eklenenler.Rows[x]["FATURA_NO"].ToString();
                musteri_kodu = Eklenenler.Rows[x]["MUSTERI_KODU"].ToString();
                firma_adi = Eklenenler.Rows[x]["FIRMA_ADI"].ToString();
                kalem_adet = Convert.ToInt32(Eklenenler.Rows[x]["SIP_KALEM_ADET"].ToString());
                aciklama = Eklenenler.Rows[x]["ACIKLAMA"].ToString();

                Tablo_Kalemler.Rows.Add(id, Formatlar.EskiyeCevirKısa(tarih), siparis_no, fatura_no, musteri_kodu, firma_adi, kalem_adet, aciklama);
            }
            return Tablo_Kalemler;
        }
        public Boolean IadeStokgaEklimi(string KayitNO)
        {
            string query = "SELECT * FROM tbl_stok_hareket WHERE SIPARIS_NO='" + KayitNO + "'";
            DataTable Tablo = Dbase.TabloCek(query);
            if (Tablo.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
