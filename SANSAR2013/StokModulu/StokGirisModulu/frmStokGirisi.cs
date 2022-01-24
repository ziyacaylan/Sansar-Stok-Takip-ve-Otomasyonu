using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.StokModulu.StokGirisModulu
{
    public partial class frmStokGirisi : DevExpress.XtraEditors.XtraForm
    {
        Classlar.clsStokGirisi StokGirisi = new Classlar.clsStokGirisi();
        Classlar.clsStokGirisListesi TedarikListesi = new Classlar.clsStokGirisListesi();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.MusterıModulu.Classlar.clsMusteriKarti MusteriKarti = new MusterıModulu.Classlar.clsMusteriKarti();
        SANSAR2013.StokModulu.Classlar.StokKarti StokKarti = new StokModulu.Classlar.StokKarti();
        SANSAR2013.StokModulu.Classlar.clsStokTuru StokTuru = new StokModulu.Classlar.clsStokTuru();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        SANSAR2013.Classlar.clsNumara Numaralar = new SANSAR2013.Classlar.clsNumara();
        SANSAR2013.EktralarModulu.Classlar.clsKargolar Kargolar = new EktralarModulu.Classlar.clsKargolar();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        StokGirisModulu.Classlar.clsStokGirisYAZDIR yazdir = new Classlar.clsStokGirisYAZDIR();

        private DataTable Tablo_Kalemler;
        public Boolean Goruntuleme = false;
        public string Musteri_ID;
        public Boolean urun_eklimi = false;
        public string UrunId = "";
        public string KayitNO = "";

        private string Stok_Kodu="";
        private string stok_birimi, stok_turu;

        public frmStokGirisi()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (Goruntuleme)
            {
                this.Close();
            }
            else
            {
                if (txtMusteriKodu.Text != "")
                {
                    if (gridView1.RowCount != 1)
                    {
                        if (Mesajlar.Sor("Stok Girişini Kaydetmediniz, çıkarsanız kaydedilmeyecek, devam etmek istiyormusunuz..?"))
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }
        void Stok_Turlerini_Getir()
        {
            for (int i = 1; i <= StokKarti.Stok_Turu_Getır(); i++)
            {
                cmd_stok_turu.Items.Add("" + StokTuru.StokBirimiAl(i.ToString()).ToString() + "");
            }
        }

        void   MusteriBilgileriniCek(string MusteriKodu)
        {
            DataRow satir = MusteriKarti.Musteri_Karti_bilgileriniCek(MusteriKodu);
            txtMusteriKodu.Text = satir["MUSTERI_KODU"].ToString();
            txtFirmaAdi.Text = satir["FIRMA_ADI"].ToString();
            txtAdres.Text = satir["ADRES_1"].ToString();
            txtSehir.Text = satir["IL_1"].ToString();
            txtIlce.Text = satir["ILCE_1"].ToString();
            txtTel.Text = satir["TEL_1"].ToString();
            txtBayiilikTuru.Text = satir["BAYIILIK_TURU"].ToString();
            txtVergiDairesi.Text = satir["VERGI_DAIRESI"].ToString();
            txtVergiNo.Text = satir["VERGI_NO"].ToString();
        }
        void MusteriBilgi(DataRow Satir)
        {
            txtMusteriKodu.Text = Satir["MUSTERI_KODU"].ToString();
            txtFirmaAdi.Text = Satir["FIRMA_ADI"].ToString();
            txtAdres.Text = Satir["ADRES_1"].ToString();
            txtSehir.Text = Satir["IL_1"].ToString();
            txtIlce.Text = Satir["ILCE_1"].ToString();
            txtTel.Text = Satir["TEL_1"].ToString();
            txtBayiilikTuru.Text = Satir["BAYIILIK_TURU"].ToString();
            txtVergiDairesi.Text = Satir["VERGI_DAIRESI"].ToString();
            txtVergiNo.Text = Satir["VERGI_NO"].ToString();
        }
        void UrunEklimi()
        {
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                if (Stok_Kodu == gridView1.GetRowCellValue(i, "STOK_KODU").ToString())
                {
                    urun_eklimi = true;
                }
            }
        }
        void StokSec()
        {
            urun_eklimi = false;
            UrunId = Ekranlar.StokKodListesiSorgulama(true);
            if (UrunId != "")
            {
                DataRow Satir = StokKarti.Stok_Karti_bilgilerini_cek(UrunId);
                Stok_Kodu = Satir["STOK_KODU"].ToString();
                stok_birimi = Satir["STOK_BIRIMI"].ToString();
                stok_turu = Satir["STOK_TURU"].ToString();

                UrunEklimi();

                if (urun_eklimi != true)
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TURU", Satir["STOK_TURU"].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "STOK_KODU", Satir["STOK_KODU"].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MODEL_NO", Satir["MODEL_NO"].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "STOK_BIRIMI", Satir["STOK_BIRIMI"].ToString());

                    for (int i = 1; i <= StokKarti.Stok_Turu_Getır(); i++)
                    {
                        cmd_stok_turu.Items.Add("" + StokTuru.StokBirimiAl(i.ToString()).ToString() + "");
                    }
                }
                else
                {
                    Mesajlar.Uyari("Bu ürünü zaten eklediniz...!!!");
                }

            }
        }
        private void btnSec_Click(object sender, EventArgs e)
        {
            Musteri_ID = Ekranlar.MusteriKodListesiSorgulama(true, false);
            if (Musteri_ID != "")
            {
                DataRow drow = MusteriKarti.Musteri_Karti_bilgilerini_cek(Musteri_ID);
                MusteriBilgi(drow);
                btnSec.Enabled = false;
            }
        }

        string  TedarikBilgileri(DataRow TedarikBilgileri)
        {
            Musteri_ID = TedarikBilgileri["MUSTERI_KODU"].ToString();
            return Musteri_ID;
        }
        private void frmStokGirisi_Load(object sender, EventArgs e)
        {
            if (Goruntuleme)
            {
             Musteri_ID= TedarikBilgileri( TedarikListesi.TedarikBilgileri(KayitNO));
               MusteriBilgileriniCek(Musteri_ID);
               TedarikBilgileriniCek();
               btnSec.Enabled = false;
               txt_tarih.Enabled = false;
               btnFaturaNoGir.Enabled = false;
               btnKaydet.Enabled = false;
               btnYeniSiparis.Enabled = false;
               btn_sec.Dispose();
               cmd_stok_turu.Dispose();
               KargolarYukle();

               gridView1.Columns["TURU"].OptionsColumn.AllowEdit = false;
               gridView1.Columns["STOK_KODU"].OptionsColumn.AllowEdit = false;
               gridView1.Columns["MODEL_NO"].OptionsColumn.AllowEdit = false;
               gridView1.Columns["MIKTAR"].OptionsColumn.AllowEdit = false;
               gridView1.Columns["ACIKLAMA"].OptionsColumn.AllowEdit = false;

               gridView1.Columns["TURU"].OptionsColumn.AllowFocus = false;
               gridView1.Columns["STOK_KODU"].OptionsColumn.AllowFocus = false;
               gridView1.Columns["MODEL_NO"].OptionsColumn.AllowFocus = false;
               gridView1.Columns["MIKTAR"].OptionsColumn.AllowFocus = false;
               gridView1.Columns["ACIKLAMA"].OptionsColumn.AllowFocus = false;
            }
            else
            {
                txt_tarih.Text = DateTime.Now.ToShortDateString();
                Stok_Turlerini_Getir();
                txtKayitNo.Text = Numaralar.GetTedarikFaturaNumarasi();
                KargolarYukle();
            }
        }
        void TedarikBilgileriniCek()
        {
            Liste.DataSource = StokGirisi.TedarikHareketIcerikYukle(KayitNO);
            DataRow drow = TedarikListesi.TedarikBilgileri(KayitNO);

            txtKayitNo.Text = KayitNO;
            txt_tarih.Text=Formatlar.EskiyeCevirKısa(drow["TARIH"].ToString());
            cmbTeslimat.Text = drow["TESLIM_SEKLI"].ToString();
            txtFaturaNo.Text = drow["FATURA_NO"].ToString();
            txtAciklama.Text = drow["ACIKLAMA"].ToString();
        }
        private void btnFaturaNoGir_Click(object sender, EventArgs e)
        {
            string fatura = Ekranlar.Fatura_No_Ac(false, true);
            if (fatura != "")
            {
                txtFaturaNo.Text = fatura;
            }
        }

        private void btn_sec_Click(object sender, EventArgs e)
        {
            StokSec();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MIKTAR", 1);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "STOK_BIRIMI", "ADET");
        }

        private void btnYeniSiparis_Click(object sender, EventArgs e)
        {
            Ekranlar.StokGirisiAc(false,"0");
        }
        void Tablo_Kur()
        {
            string id, Tipi,turu, stok_kodu, model_no, miktar, stok_birimi,aciklama;
            Tablo_Kalemler = new DataTable();

            Tablo_Kalemler.Columns.Add(new DataColumn("ID", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("TIPI", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("TURU", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("STOK_KODU", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("MODEL_NO", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("MIKTAR", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("STOK_BIRIMI", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("ACIKLAMA", typeof(string)));

            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                id = gridView1.GetRowCellValue(i, "ID").ToString();
                Tipi = "AF";
                turu = gridView1.GetRowCellValue(i, "TURU").ToString();
                stok_kodu = gridView1.GetRowCellValue(i, "STOK_KODU").ToString();
                model_no = gridView1.GetRowCellValue(i, "MODEL_NO").ToString();
                miktar = gridView1.GetRowCellValue(i, "MIKTAR").ToString();
                stok_birimi = gridView1.GetRowCellValue(i, "STOK_BIRIMI").ToString();
                aciklama = gridView1.GetRowCellValue(i, "ACIKLAMA").ToString();

                Tablo_Kalemler.Rows.Add(id, Tipi,turu, stok_kodu, model_no, miktar, stok_birimi, aciklama);
            }
        }
        void Kaydet()
        {
            string siparisTipi = "AF";
            Tablo_Kur();
            StokGirisi.TedarikStokHareketEkle(txt_tarih.Text,siparisTipi,txtKayitNo.Text,txtFaturaNo.Text,txtMusteriKodu.Text,txtFirmaAdi.Text,txtAdres.Text,txtSehir.Text,txtIlce.Text,txtTel.Text,txtBayiilikTuru.Text,txtVergiDairesi.Text,txtVergiNo.Text,cmbTeslimat.Text,txtAciklama.Text,Tablo_Kalemler.Rows.Count.ToString(),Tablo_Kalemler);
       
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtMusteriKodu.Text != "")
            {
                if (txtFaturaNo.Text != "")
                {
                    if (StokGirisi.TedarikKayitSorgula(txtMusteriKodu.Text,txtFirmaAdi.Text,txtFaturaNo.Text))
                    {
                        Mesajlar.Uyari("Stok Giriş Kayıdı Daha önceden yapılmış...");
                    }
                    else
                    {
                        if (Mesajlar.Sor("Stok Giriş Kayıdı yapılsın mı ?"))
                        {
                         txtKayitNo.Text = Numaralar.GetTedarikFaturaNumarasi();
                         Kaydet();
                         Mesajlar.Bilgi("Stok Giriş Kaydı Yapııldı.");
                         this.Close();
                        }                        
                    }
                }
                else
                {
                    if (Mesajlar.Sor("Fatura Numarası Girmediniz, devam etmek istiyor musunuz..?"))
                    {
                        if (StokGirisi.TedarikKayitSorgula(txtMusteriKodu.Text, txtFirmaAdi.Text, txtFaturaNo.Text))
                        {
                            Mesajlar.Uyari("Stok Giriş Kayıdı Daha önceden yapılmış...");
                        }
                        else
                        {
                            if (Mesajlar.Sor("Stok Giriş Kayıdı yapılsın mı ?"))
                            {
                                txtKayitNo.Text = Numaralar.GetTedarikFaturaNumarasi();
                                Kaydet();
                                Mesajlar.Bilgi("Stok Giriş Kaydı Yapııldı.");
                                this.Close();
                            }
                        }
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Tedarikçi Firma yı seçmediniz...");
            }
        }
        void KargolarYukle()
        {
            for (int i = 1; i <= Kargolar.KargoListeToplamı(); i++)
            {
                cmbTeslimat.Properties.Items.Add("" + Kargolar.KargoIsminiAl(i.ToString()).ToString() + "");
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            yazdir.StokGirisYazdir(txtKayitNo.Text);
        }
    }
}