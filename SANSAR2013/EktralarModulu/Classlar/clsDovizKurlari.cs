using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.EktralarModulu.Classlar
{
    class clsDovizKurlari
    {
        SANSAR2013.Classlar.Veritabani DBase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.StokModulu.Classlar.clsParaBirimi ParaBirimi=new StokModulu.Classlar.clsParaBirimi();

        public DataTable Listele()
        {
            string query="SELECT * FROM tbl_doviz_kurlari";
            DataTable Tablo = DBase.TabloCek(query);
            return Tablo ;
        }
        public DataTable Listele_TariheGore(string tarih)
        {
            string query = "SELECT * FROM tbl_doviz_kurlari WHERE TARIH='"+tarih+"'";
            DataTable Tablo = DBase.TabloCek(query);
            return Tablo;
        }
        public DataTable Listele_ParaBirimineGore(string ParaBirimi)
        {
            string query = "SELECT * FROM tbl_doviz_kurlari WHERE ADI='" + ParaBirimi + "'";
            DataTable Tablo = DBase.TabloCek(query);
            return Tablo;
        }
        public DataTable Listele_Tarih_ParaBirimineGore(string tarih, string ParaBirimi)
        {
            string query = "SELECT * FROM tbl_doviz_kurlari WHERE TARIH='"+tarih+"' AND ADI='" + ParaBirimi + "'";
            DataTable Tablo = DBase.TabloCek(query);
            return Tablo;
        }
        public DataTable   Kurlari_Cek(string tarih)
        {
            string query = "SELECT * FROM tbl_doviz_kurlari WHERE TARIH='"+tarih+"' ";
            DataTable tablo = DBase.TabloCek(query);
            return tablo;

        }
        public void Ekle(string Tarih,string adi,string Kod,string dvz_alis,string dvz_satis,string efektif_alis,string efektif_satis)
        {
            string query = "INSERT INTO tbl_doviz_kurlari (TARIH,ADI,KOD,DOVIZ_ALIS,DOVIZ_SATIS,EFEKTIF_ALIS,EFEKTIF_SATIS,SAVE_USER,SAVE_DATE) VALUES ('" + Tarih + "','" + adi + "','"+Kod+"','" + dvz_alis + "','" + dvz_satis + "','" + efektif_alis + "','"+efektif_satis+"','" + AnaForm.UserId + "','" + Formatlar.IngiliceTarihFormati(DateTime.Now.ToString()) + "') ";
            DBase.Insert(query);
        }
        public void Gulcelle(string Tarih,string adi,string Kod,string dvz_alis,string dvz_satis,string efektif_alis,string efektif_satis)
        {
            string query = "UPDATE tbl_doviz_kurlari SET TARIH='"+Tarih+"',ADI='"+adi+"',KOD='"+Kod+"',DOVIZ_ALIS='"+dvz_alis+"',DOVIZ_SATIS='"+dvz_satis+"',EFEKTIF_ALIS='"+efektif_alis+"',EFEKTIF_SATIS='"+efektif_satis+"',SAVE_USER='"+AnaForm.UserId+"',SAVE_DATE='"+Formatlar.IngiliceTarihFormati(DateTime.Now.ToString())+"' WHERE TARIH='"+Tarih+"' AND KOD='"+Kod+"'";
            DBase.Isle(query);
        }
        public DataRow KurCek(string ID)
        {
            string query = "SELECT * FROM tbl_doviz_kurlari WHERE ID='" + ID + "'";
            DataRow drow = DBase.SatirCek(query);            
        return drow;
        }
        public string KurIsminiAl(string Id)
        {
            DataRow Satir;
            string query = "SELECT * FROM tbl_doviz_kurlari WHERE ID='" + Id + "'";
            Satir = DBase.SatirCek(query);
            string ali = Satir["ADI"].ToString();
            return ali;
        }
        public int ParaBirimi_SatirSayisi()
        {
            DataRow drow = ParaBirimi.Para_Birim_SatirSayisi();
            int sayi = Convert.ToInt32(drow["ID"].ToString());
            return sayi;
        }
        public Boolean KurSorgula_Guncelmi(string tarih,string kod)
        {
            IDataReader reader;
            string son_tarih = "";
            string query = "SELECT * FROM tbl_doviz_kurlari WHERE TARIH='"+tarih+"' AND KOD='"+kod+"'";
            reader = DBase.DataOku(query);
            while (reader.Read())
            {
                son_tarih = reader["TARIH"].ToString();
            }
            reader.Close();
            if (son_tarih=="")
            {
                son_tarih ="01.01.0001";
            }

            if (tarih==Formatlar.IngilizceTarihKısaFormat(son_tarih))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean XTarihliKurVarmı(string tarih)
        {
            //string ax = "";
            //IDataReader reader;
            string query = "SELECT * FROM tbl_doviz_kurlari WHERE TARIH='" + Formatlar.IngilizceTarihKısaFormat(tarih) + "'";
            DataTable tablo = DBase.TabloCek(query);
            if (tablo.Rows.Count != 0)
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
