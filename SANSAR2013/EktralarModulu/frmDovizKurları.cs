using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;

namespace SANSAR2013.EktralarModulu
{
    public partial class frmDovizKurları : DevExpress.XtraEditors.XtraForm
    {
        Classlar.clsDovizKurlari Kurlar = new Classlar.clsDovizKurlari();
        SANSAR2013.StokModulu.Classlar.clsParaBirimi Para_Birimi = new StokModulu.Classlar.clsParaBirimi();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();

        public Boolean SecimIcinAcildimi = false;
        public string SecilenId;
        private string Parametre1, Parametre2;
        private Boolean guncellendimi = false;

        public frmDovizKurları()
        {
            InitializeComponent();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            DataSet al = new DataSet();
            al.ReadXml("http://www.tcmb.gov.tr/kurlar/today.xml");
            DataRow USD = al.Tables[1].Rows[0];
            DataRow USDSA = al.Tables[1].Rows[0];
            txtDolarAlis.Text = USD[4].ToString();
            txtDolarSatis.Text = USDSA[5].ToString();

            DataRow EUR = al.Tables[1].Rows[11];
            DataRow EURSA = al.Tables[1].Rows[11];

            txtEuroAlis.Text = EUR[4].ToString();
            txtEuroSatis.Text = EURSA[5].ToString();
            //Al();
            DataTable dt = new DataTable();
            // DataTable nesnemizi yaratıyoruz
            DataRow dr;
            // DataTable ın satırlarını tanımlıyoruz.
            dt.Columns.Add(new DataColumn("ADI", typeof(string)));
            dt.Columns.Add(new DataColumn("KOD", typeof(string)));
            dt.Columns.Add(new DataColumn("DOVIZ_ALIS", typeof(string)));
            dt.Columns.Add(new DataColumn("DOVIZ_SATIS", typeof(string)));
            dt.Columns.Add(new DataColumn("EFEKTIF_ALIS", typeof(string)));
            dt.Columns.Add(new DataColumn("EFEKTIF_SATIS", typeof(string)));
            // DataTableımıza 6 sütün ekliyoruz ve değişken tiplerini tanımlıyoruz.

            XmlTextReader rdr = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");
            // XmlTextReader nesnesini yaratıyoruz ve parametre olarak xml dokümanın urlsini veriyoruz
            // XmlTextReader urlsi belirtilen xml dokümanlarına hızlı ve forward-only giriş imkanı sağlar.
            XmlDocument myxml = new XmlDocument();
            // XmlDocument nesnesini yaratıyoruz.
            myxml.Load(rdr);
            // Load metodu ile xml yüklüyoruz

            XmlNode tarih = myxml.SelectSingleNode("/Tarih_Date/@Tarih");
            XmlNodeList mylist = myxml.SelectNodes("/Tarih_Date/Currency");
            XmlNodeList adi = myxml.SelectNodes("/Tarih_Date/Currency/Isim");
            XmlNodeList kod = myxml.SelectNodes("/Tarih_Date/Currency/@Kod");
            XmlNodeList doviz_alis = myxml.SelectNodes("/Tarih_Date/Currency/ForexBuying");
            XmlNodeList doviz_satis = myxml.SelectNodes("/Tarih_Date/Currency/ForexSelling");
            XmlNodeList efektif_alis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteBuying");
            XmlNodeList efektif_satis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteSelling");
            // XmlNodeList cinsinden her bir nodu, SelectSingleNode metoduna nodların xpathini parametre olarak
            // göndererek tanımlıyoruz.

           txtTarih.Text = tarih.InnerText.ToString();
            // datagridimin captionu ayarlıyoruz.
            int x = 19;
            /*  Burada xmlde bahsettiğim - bence-  mantık hatasından dolayı x gibi bir değişken tanımladım.
            bu x =19  DataTable a sadece 19 satır eklenmesini sağlıyor. çünkü xml dökümanında 19. node dan sonra
            güncel kur bilgileri değil Euro dönüşüm kurları var ve bu node dan sonra yapı ilk 18 node ile tutmuyor
            Bence ayrı bir xml dökümanda tutulması gerekirdi. 
            */

            for (int i = 0; i < x; i++)
            {

                dr = dt.NewRow();
                dr[0] = adi.Item(i).InnerText.ToString(); // i. adi nodunun içeriği
                // Adı isimli DataColumn un satırlarını  /Tarih_Date/Currency/Isim node ları ile dolduruyoruz.
                dr[1] = kod.Item(i).InnerText.ToString();
                // Kod satırları
                dr[2] = doviz_alis.Item(i).InnerText.ToString();
                // Döviz Alış
                dr[3] = doviz_satis.Item(i).InnerText.ToString();
                // Döviz  Satış
                dr[4] = efektif_alis.Item(i).InnerText.ToString();
                // Efektif Alış
                dr[5] = efektif_satis.Item(i).InnerText.ToString();
                // Efektif Satış.
                dt.Rows.Add(dr);

            }
            // DataTable ımızın satırlarını 18 satır olacak şekilde dolduruyoruz
            // gerçi yine web mastırın insafı devreye giriyor:).
            // yukarıda bahsettiğim sorun.
            //return dt;
            // DataTable ı döndürüyoruz.

            Liste1.DataSource = dt;
            guncellendimi = true;
            //KurListesiYukle();
        }

        void Al()
        {
            XmlTextReader tr = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(tr);
            DataTable dt = ds.Tables[1];
            Liste1.DataSource = dt;
            //Liste1.DataBind();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDolarAlis_TextChanged(object sender, EventArgs e)
        {
            txtDolarAlis.Text = txtDolarAlis.Text.Replace('.', ',');
        }

        private void txtDolarSatis_TextChanged(object sender, EventArgs e)
        {
            txtDolarSatis.Text = txtDolarSatis.Text.Replace('.', ',');
        }

        private void txtEuroAlis_TextChanged(object sender, EventArgs e)
        {
            txtEuroAlis.Text = txtEuroAlis.Text.Replace('.', ',');
        }

        private void txtEuroSatis_TextChanged(object sender, EventArgs e)
        {
            txtEuroSatis.Text = txtEuroSatis.Text.Replace('.', ',');
        }
        void BirimleriYukle()
        {
            for (int i =1 ; i <= Kurlar.ParaBirimi_SatirSayisi(); i++)
            {
                string birim = Para_Birimi.ParaBirimiYukle(i.ToString());
                if (birim != "")
                {
                    cmbKurAdi.Properties.Items.Add("" + birim + "");
                }
            }
        }
        private void frmDovizKurları_Load(object sender, EventArgs e)
        {
            Liste.DataSource = Kurlar.Listele();
            BirimleriYukle();
            dtTarih.Text = DateTime.Now.ToShortDateString();

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Kurlar.Ekle(txtTarih.Text, txtDolarAlis.Text, txtDolarSatis.Text, txtEuroAlis.Text, txtEuroSatis.Text);
            //Mesajlar.Bilgi("Kur Güncelleme İşlemi Kaydedildi...!");
            //Liste.DataSource = Kurlar.Listele();
            if (guncellendimi)
            {
                int Satir_Sayisi = Kurlar.ParaBirimi_SatirSayisi();

                for (int i = 1; i <= Satir_Sayisi; i++)
                {
                    string birim = Para_Birimi.ParaBirimiAl(i.ToString());
                    //while (birim == "")
                    //{
                    //    birim = Para_Birimi.ParaBirimiAl(i.ToString());
                    //}
                    for (int x = 0; x < GRD_ParaBirimListesi.RowCount; x++)
                    {
                        string deger = GRD_ParaBirimListesi.GetRowCellValue(x, "KOD").ToString();
                        if (birim == deger)
                        {
                            string para_b = GRD_ParaBirimListesi.GetRowCellValue(x, "ADI").ToString();
                            string kod = GRD_ParaBirimListesi.GetRowCellValue(x, "KOD").ToString();
                            string dvz_alis = GRD_ParaBirimListesi.GetRowCellValue(x, "DOVIZ_ALIS").ToString();
                            string dvz_satis = GRD_ParaBirimListesi.GetRowCellValue(x, "DOVIZ_SATIS").ToString();
                            string efektif_alis = GRD_ParaBirimListesi.GetRowCellValue(x, "EFEKTIF_ALIS").ToString();
                            string efektif_satis = GRD_ParaBirimListesi.GetRowCellValue(x, "EFEKTIF_SATIS").ToString();

                            if (Kurlar.KurSorgula_Guncelmi(Formatlar.IngilizceTarihKısaFormat(txtTarih.Text), kod))
                            {
                                Kurlar.Gulcelle(Formatlar.IngilizceTarihKısaFormat(txtTarih.Text), para_b, kod, dvz_alis.Replace(".", ","), dvz_satis.Replace(".", ","), efektif_alis.Replace(".", ","), efektif_satis.Replace(".", ","));
                            }
                            else
                            {
                                Kurlar.Ekle(Formatlar.IngilizceTarihKısaFormat(txtTarih.Text), para_b, kod, dvz_alis.Replace(".", ","), dvz_satis.Replace(".", ","), efektif_alis.Replace(".", ","), efektif_satis.Replace(".", ","));
                            }
                        }
                    }

                }

                Liste.DataSource = Kurlar.Listele();
                Mesajlar.Bilgi("Kur Bilgileri Kaydedildi...");
            }
            else
            {
                Mesajlar.Uyari("Güncel kur bilgilerini almak için listeyi Güncelleyin...!!!");
            }
        }
        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Gridwiev2();

            if (SecimIcinAcildimi)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("ADI", typeof(string)));
                dt.Columns.Add(new DataColumn("KOD", typeof(string)));

                DataRow drow = dt.NewRow();
                drow["ADI"] = Parametre1;
                drow["KOD"] = Parametre2;
                dt.Rows.Add(drow);
                AnaForm.Tablo = dt;
                this.Dispose();
            }
        }
        void Gridwiev2()
        {
            try
            {
                Parametre1 = GRD_ParaBirimListesi.GetRowCellValue(GRD_ParaBirimListesi.FocusedRowHandle, "ADI").ToString();
                Parametre2 = GRD_ParaBirimListesi.GetRowCellValue(GRD_ParaBirimListesi.FocusedRowHandle, "KOD").ToString();
            }
            catch (Exception)
            {

                SecilenId = "-1";
                Parametre1 = "";
                Parametre2 = "";
            }
        }
        void Sec()
        {
            try
            {
                SecilenId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
            }
            catch (Exception)
            {

                SecilenId = "-1";
            }

        }
        void KurListesiYukle()
        {
            if (txtTarih.Text != "")
            {
                for (int i = 0; i < GRD_ParaBirimListesi.RowCount; i++)
                {
                    cmbParaBirimleriListesi.Properties.Items.Add("" + GRD_ParaBirimListesi.GetRowCellValue(i, "ADI").ToString() + "");
                }
            }
            else
            {
                Mesajlar.Uyari("Önce Kuları Güncellemelisiniz...!!!");
            }

        }
        void ParaBirimKaydet()
        {
            string aciklama = "";
            for (int i = 0; i < GRD_ParaBirimListesi.RowCount; i++)
            {
                if (cmbParaBirimleriListesi.Text == GRD_ParaBirimListesi.GetRowCellValue(i, "ADI").ToString())
                {
                    Parametre1 = GRD_ParaBirimListesi.GetRowCellValue(i, "ADI").ToString();
                    Parametre2 = GRD_ParaBirimListesi.GetRowCellValue(i, "KOD").ToString();
                    Para_Birimi.Ekle(Parametre1, Parametre2, aciklama);
                }
            }
        }
        private void btnKayit_Click(object sender, EventArgs e)
        {
            if (cmbParaBirimleriListesi.Text != "")
            {
                Boolean sorgu = Para_Birimi.ParaBirimleri_Kayit_Sorgula(cmbParaBirimleriListesi.Text);
                if (!sorgu)
                {
                    ParaBirimKaydet();
                    Mesajlar.Bilgi("Kayıt İşlemi Yapıldı...!!!");
                }
                else
                {
                    Mesajlar.Uyari("Bu Para Birimi zaten listede ekli; eklemek için başka seçiniz...");
                }
            }
            else
            {
                Mesajlar.Uyari("Kaydedilecek Para Birimini Seçmediniz...");
            }
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            KurListesiYukle();
        }

        private void Liste_DoubleClick_1(object sender, EventArgs e)
        {
            Sec();
            if (SecimIcinAcildimi)
            {
                Kurlar.KurCek(SecilenId);
                AnaForm.AraDegiskenString = SecilenId;
                this.Dispose();
            }
        }

        private void btnSorgula_Click_1(object sender, EventArgs e)
        {
            if (chkKur.Checked)
            {
                if (chkTarih.Checked)
                {
                    Liste.DataSource = Kurlar.Listele_Tarih_ParaBirimineGore(Formatlar.IngilizceTarihKısaFormat(dtTarih.Text), cmbKurAdi.Text);
                }
                else
                {
                    Liste.DataSource = Kurlar.Listele_ParaBirimineGore(cmbKurAdi.Text);
                }
            }
            else if (chkTarih.Checked)
            {
                Liste.DataSource = Kurlar.Listele_TariheGore(Formatlar.IngilizceTarihKısaFormat(dtTarih.Text));
            }
            else
            {
                Liste.DataSource = Kurlar.Listele();
            }
        }

    }
}