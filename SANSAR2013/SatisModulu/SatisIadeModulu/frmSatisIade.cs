using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.SatisModulu.SatisIadeModulu
{
    public partial class frmSatisIade : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Mesajlar Mesajlar=new SANSAR2013.Classlar.Mesajlar();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.MusterıModulu.Classlar.clsMusteriKarti MusteriKarti = new MusterıModulu.Classlar.clsMusteriKarti();
        SANSAR2013.StokModulu.Classlar.StokKarti StokKarti = new StokModulu.Classlar.StokKarti();
        SANSAR2013.StokModulu.Classlar.clsStokTuru StokTuru = new StokModulu.Classlar.clsStokTuru();
        SANSAR2013.EktralarModulu.Classlar.clsKargolar Kargolar = new EktralarModulu.Classlar.clsKargolar();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.Classlar.clsNumara Numaralar = new SANSAR2013.Classlar.clsNumara();
        Classlar.clsSatisIade SatisIade = new Classlar.clsSatisIade();
        Dizaynlar.clsYazdir rapor = new Dizaynlar.clsYazdir();

        public Boolean Edit = false;
        public Boolean KayıtStoklaraEklendimi = false;
        private Boolean degisiklikYapildimi = false;
        public string Musteri_ID;
        public Boolean urun_eklimi = false;
        public Boolean stokEklendimi = false;

        public DataTable Tablo_Kalemler;

        public string UrunId = "";
        public string KayitNO = "";
        private string Stok_Kodu = "";
        private string stok_birimi, stok_turu;

        public frmSatisIade()
        {
            InitializeComponent();
        }
        void Stok_Turlerini_Getir()
        {
            for (int i = 1; i <= StokKarti.Stok_Turu_Getır(); i++)
            {
                cmd_stok_turu.Items.Add("" + StokTuru.StokBirimiAl(i.ToString()).ToString() + "");
            }
        }
        void KargolarYukle()
        {
            for (int i = 1; i <= Kargolar.KargoListeToplamı(); i++)
            {
                cmbTeslimat.Properties.Items.Add("" + Kargolar.KargoIsminiAl(i.ToString()).ToString() + "");
            }
        }

        void IadeBilgileriniCek()
        {
            DataRow drow = SatisIade.IadeBilgileriniCEK(KayitNO, KayıtStoklaraEklendimi);

                cmbTeslimat.Text = drow["TESLIM_SEKLI"].ToString();
                dt_tarih.Text = Formatlar.EskiyeCevirKısa(drow["TARIH"].ToString());
                txtFaturaNo.Text = drow["FATURA_NO"].ToString();
                txtAciklama.Text = drow["ACIKLAMA"].ToString();
                txtKayitNo.Text = drow["SIPARIS_NO"].ToString();

                string MusteriKodu = drow["MUSTERI_KODU"].ToString();

                MusteriBilgi(SatisIade.MusteriBilgileri(MusteriKodu));

                Liste.DataSource = SatisIade.SatisIade_Kalemleri_CEK(KayitNO);
        }

        private void frmSatisIade_Load(object sender, EventArgs e)
        {
            if (KayıtStoklaraEklendimi)
            {
                    IadeBilgileriniCek();
                    KargolarYukle();
                    txtStokgaEklendimi.Text = "STOĞA EKLENDİ";
                    txtStokgaEklendimi.BackColor = Color.Green;
                    btn_stok_KAYIT.Enabled = false;
                    btnKaydet.Enabled = false;
                    btnYeniSiparis.Enabled = false;
                    degisiklikYapildimi = false;
            }
            else
            {
                if (Edit)
                {
                    IadeBilgileriniCek();
                    KargolarYukle();
                    txtStokgaEklendimi.Text = "STOĞA EKLENMEDİ";
                    txtStokgaEklendimi.BackColor = Color.Violet;
                }
                else
                {
                    dt_tarih.Text = DateTime.Now.ToShortDateString();
                    Stok_Turlerini_Getir();
                    KargolarYukle();
                    txtStokgaEklendimi.Text = "STOĞA EKLENMEDİ";
                    txtStokgaEklendimi.BackColor = Color.Violet;
                    txtKayitNo.Text = Numaralar.GetSatisIadeFaturaNumarasi();
                }
            }            

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
            Ekranlar.SatisIadeGiris(false, "0",false);
        }
        void Tablo_Kur()
        {
            string id, turu, stok_kodu, model_no, miktar, stok_birimi, aciklama;
            Tablo_Kalemler = new DataTable();

            Tablo_Kalemler.Columns.Add(new DataColumn("ID", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("TURU", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("STOK_KODU", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("MODEL_NO", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("MIKTAR", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("STOK_BIRIMI", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("ACIKLAMA", typeof(string)));

            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                id = gridView1.GetRowCellValue(i, "ID").ToString();
                turu = gridView1.GetRowCellValue(i, "TURU").ToString();
                stok_kodu = gridView1.GetRowCellValue(i, "STOK_KODU").ToString();
                model_no = gridView1.GetRowCellValue(i, "MODEL_NO").ToString();
                miktar = gridView1.GetRowCellValue(i, "MIKTAR").ToString();
                stok_birimi = gridView1.GetRowCellValue(i, "STOK_BIRIMI").ToString();
                aciklama = gridView1.GetRowCellValue(i, "ACIKLAMA").ToString();

                Tablo_Kalemler.Rows.Add(id, turu, stok_kodu, model_no, miktar, stok_birimi, aciklama);
            }
        }

        private void btnFaturaNoGir_Click(object sender, EventArgs e)
        {
            string fatura = Ekranlar.Fatura_No_Ac(false, true);
            if (fatura != "")
            {
                txtFaturaNo.Text = fatura;
            }
        }
        void Kaydet()
        {
            string siparisTipi = "SI";
            Tablo_Kur();
            SatisIade.SatisIadeKaydet(dt_tarih.Text, siparisTipi, txtKayitNo.Text, txtFaturaNo.Text, txtMusteriKodu.Text, txtFirmaAdi.Text, cmbTeslimat.Text, txtAciklama.Text,"H", (Convert.ToInt32(gridView1.RowCount.ToString())-1), Tablo_Kalemler);
        }
        void Guncelle()
        {
            string siparisTipi = "SI";
            Tablo_Kur();
            SatisIade.SatiIadeGuncelle(dt_tarih.Text, siparisTipi, txtKayitNo.Text, txtFaturaNo.Text, txtMusteriKodu.Text, txtFirmaAdi.Text, cmbTeslimat.Text, txtAciklama.Text,"H",( Convert.ToInt32(gridView1.RowCount.ToString())-1), Tablo_Kalemler);
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit)
            {
                if (degisiklikYapildimi)
                {
                    Guncelle();
                    Mesajlar.Bilgi("Güncelleme gerçekleştirildi...");
                    degisiklikYapildimi = false;
                }
            }
            else
            {
                txtKayitNo.Text = Numaralar.GetSatisIadeFaturaNumarasi();

                if (txtMusteriKodu.Text != "")
                {
                    if (gridView1.RowCount > 1)
                    {
                        if (txtFaturaNo.Text != "")
                        {
                            if (SatisIade.IadeKaydiYapıldımı(txtMusteriKodu.Text, txtFirmaAdi.Text, txtFaturaNo.Text, txtKayitNo.Text))
                            {
                                Mesajlar.Uyari("Iade Kaydı daha önceden yapılmış.");
                            }
                            else
                            {
                                txtKayitNo.Text = Numaralar.GetSatisIadeFaturaNumarasi();
                                Kaydet();
                                Mesajlar.Bilgi("Kayıt gerçekleştirildi...");
                                this.Close();
                            }
                        }
                        else
                        {
                            if (SatisIade.IadeKaydiYapıldımı(txtMusteriKodu.Text, txtFirmaAdi.Text, txtFaturaNo.Text, txtKayitNo.Text))
                            {
                                Mesajlar.Uyari("Iade Kaydı daha önceden yapılmış.");
                            }
                            else
                            {
                                if (Mesajlar.Sor("Fatura Numarası Girmediniz,Kaydetmek istiyormusunuz ?"))
                                {
                                    txtKayitNo.Text = Numaralar.GetSatisIadeFaturaNumarasi();
                                    Kaydet();
                                    Mesajlar.Bilgi("Kayıt gerçekleştirildi...");
                                    this.Close();
                                }
                            }
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Iade edilen urunlerı girmediniz...");
                    }
                }
                else
                {
                    Mesajlar.Uyari("Firma Bilgilerini Secmediniz...Kayıt yapamazsınız.!");
                }
            }
        }
        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (KayıtStoklaraEklendimi)
            {
                this.Close();
            }
            else
            {
                if (Edit)
                {
                    if (degisiklikYapildimi)
                    {
                        if (Mesajlar.Sor("Değişiklikler kaydedilmedi,çıkarsanız kaydedilmicek; Çıkmak istiyormusunuz...?"))
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
                    if (degisiklikYapildimi)
                    {
                        if (Mesajlar.Sor("Değişiklikler kaydedilmedi,çıkarsanız kaydedilmicek; Çıkmak istiyormusunuz...?"))
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
        }
        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            degisiklikYapildimi = true;
        }

        private void cmbTeslimat_SelectedValueChanged(object sender, EventArgs e)
        {
            degisiklikYapildimi = true;
        }

        private void dt_tarih_EditValueChanged(object sender, EventArgs e)
        {
            degisiklikYapildimi = true;
        }

        private void txtAciklama_EditValueChanged(object sender, EventArgs e)
        {
            degisiklikYapildimi = true;
        }

        private void txtFaturaNo_EditValueChanged(object sender, EventArgs e)
        {
            degisiklikYapildimi = true;
        }
        void siparis_hareket_sil()
        {
            SatisIade.SatisIadeSil(txtKayitNo.Text, txtMusteriKodu.Text);
            SatisIade.SatisIadeKalemleriniSil(txtKayitNo.Text, txtMusteriKodu.Text);
        }
        void StokKayitYAP(string KayitNO)
        {
            string siparisTipi = "SI";
            Tablo_Kur();
            SatisIade.SatisIade_STOK_Kaydet(dt_tarih.Text, siparisTipi, txtKayitNo.Text, txtFaturaNo.Text, txtMusteriKodu.Text, txtFirmaAdi.Text, cmbTeslimat.Text, txtAciklama.Text, "E", (Convert.ToInt32(gridView1.RowCount.ToString()) - 1), Tablo_Kalemler);
            siparis_hareket_sil();
        }
        private void btn_stok_KAYIT_Click(object sender, EventArgs e)
        {
            if (!SatisIade.Stok_Eklimi(txtKayitNo.Text))
            {
                if (txtFaturaNo.Text != "")
                {
                    if (Mesajlar.Sor("Iade kabulü halinde stoğa eklenicektir. Kabul edilsin mi...?"))
                    {
                        StokKayitYAP(txtKayitNo.Text);
                        txtStokgaEklendimi.Text = "STOĞA EKLENDİ";
                        txtStokgaEklendimi.BackColor = Color.Green;
                        Mesajlar.Bilgi("Iade stok kayıdı yapıldı...!");
                        btnKaydet.Enabled = false;
                        btnYeniSiparis.Enabled = false;
                        btn_stok_KAYIT.Enabled = false;
                        Edit = false;
                        degisiklikYapildimi = false;
                        KayıtStoklaraEklendimi = false;
                        this.Close();
                    }
                }
                else if (Mesajlar.Sor("Fatura numarasını gırmedınız, devam etmek istiyormusunuz...?"))
                {
                    if (Mesajlar.Sor("Iade kabulü halinde stoğa eklenicektir. Kabul edilsin mi...?"))
                    {
                        StokKayitYAP(txtKayitNo.Text);
                        txtStokgaEklendimi.Text = "STOĞA EKLENDİ";
                        txtStokgaEklendimi.BackColor = Color.Green;
                        Mesajlar.Bilgi("Iade stok kayıdı yapıldı...!");
                        btnKaydet.Enabled = false;
                        btnYeniSiparis.Enabled = false;
                        btn_stok_KAYIT.Enabled = false;
                        Edit = false;
                        degisiklikYapildimi = false;
                        KayıtStoklaraEklendimi = false;
                        this.Close();
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Stok kayıt işlemi daha önceden yapıldığından bu işlem tekrarlanamaz...!");
                btnKaydet.Enabled = false;
                btnYeniSiparis.Enabled = false;
                btn_stok_KAYIT.Enabled = false;
                Edit = false;
                degisiklikYapildimi = false;
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (KayıtStoklaraEklendimi)
            {
                rapor.SatisIADEFaturasiYazdir(txtKayitNo.Text);
            }
            else
            {
                rapor.SatisIADEFaturasiYazdir__Kayitsiz(txtKayitNo.Text);
            }
        }
    }
}