using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.SiparisModulu
{
    public partial class frmYeniSiparis : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        SANSAR2013.EktralarModulu.Classlar.clsDovizKurlari Kurlar = new EktralarModulu.Classlar.clsDovizKurlari();
        SANSAR2013.MusterıModulu.Classlar.clsMusteriKarti MusteriKarti = new MusterıModulu.Classlar.clsMusteriKarti();
        SANSAR2013.EktralarModulu.Classlar.clsKargolar Kargolar = new EktralarModulu.Classlar.clsKargolar();
        Classlar.clsYeniSiparis Siparis = new Classlar.clsYeniSiparis();
        SANSAR2013.StokModulu.Classlar.StokKarti StokKarti = new StokModulu.Classlar.StokKarti();
        SANSAR2013.StokModulu.Classlar.clsStokTuru StokTuru = new StokModulu.Classlar.clsStokTuru();
        SANSAR2013.Classlar.clsNumara Numaralar = new SANSAR2013.Classlar.clsNumara();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.Kullanicilar.Classlar.clsKullanicilar Kullanicilar = new Kullanicilar.Classlar.clsKullanicilar();
        SANSAR2013.StokModulu.Classlar.clsParaBirimi Paralar = new StokModulu.Classlar.clsParaBirimi();
        Classlar.Dizaynlar.dzYAZDIR dzYazdir = new Classlar.Dizaynlar.dzYAZDIR();

        private string Musteri_ID = "";
        private string isk_1 = "";
        private string isk_2 = "";
        private string isk_3 = "";
        private string isk_4 = "";
        private string isk_5 = "";
        private string isk_6 = "";

        private string UrunId = "";
        private string stok_birimi = "";
        private string birim_fiyat = "";
        private string birim_fiyat_1 = "";
        private string para_birimi = "";
        private string para_birimi_1 = "";
        private string stok_turu = "";
        private string iskonto_grubu = "";

        public Boolean Edit = false;
        public Boolean satisGoruntule = false;
        public Boolean stokhareketgoruntule = false;

        public string SiparisID = "";
        public int Kur_ID = 0;
        public string Dolar_satis = "";
        public string Euro_satis = "";
        private Boolean urun_eklimi = false;
        private string Stok_Kodu = "";

        private string siparis = "";
        // private string satis_onay = "";

        private DataTable Tablo_Kurlar;
        private DataTable Tablo_Kalemler;
        //   private DataTable AraTablo;
        private Boolean ilk_acilis = false;

        public frmYeniSiparis()
        {
            InitializeComponent();
        }
        void SiparisBilgileriniCek()
        {
            btnSec.Hide();
            DataRow drow = Siparis.SiparisBilgileriYukle(SiparisID);
            txtMusteriKodu.Text = drow["MUSTERI_KODU"].ToString();
            txtFirmaAdi.Text = drow["FIRMA_ADI"].ToString();

            DataRow musteri = MusteriKarti.Musteri_Karti_bilgileriniCek(drow["MUSTERI_KODU"].ToString());
            txtAdres.Text = musteri["ADRES_1"].ToString();
            txtSehir.Text = musteri["IL_1"].ToString();
            txtIlce.Text = musteri["ILCE_1"].ToString();
            txtVergiDairesi.Text = musteri["VERGI_DAIRESI"].ToString();
            txtVergiNo.Text = musteri["VERGI_NO"].ToString();
            txtBayiilikTuru.Text = musteri["BAYIILIK_TURU"].ToString();
            txtTel.Text = musteri["TEL_1"].ToString();

            isk_1 = musteri["ISK_1"].ToString();
            isk_2 = musteri["ISK_2"].ToString();
            isk_3 = musteri["ISK_3"].ToString();
            isk_4 = musteri["ISK_4"].ToString();
            isk_5 = musteri["ISK_5"].ToString();
            isk_6 = musteri["ISK_6"].ToString();

            string tip = drow["TIPI"].ToString();
            if (tip == "SP")
            {
                cmbSiparisTuru.Text = "SİPARİS";
            }
            else
            {
                if (tip == "KNS.SP")
                {
                    cmbSiparisTuru.Text = "KONSİNYE SİPARİS";
                }
            }
            txtSiparisVeren.Text = drow["SIPARIS_VEREN"].ToString();
            txtFisNo.Text = drow["FIS_NO"].ToString();
            txtFaturaNo.Text = drow["FATURA_NO"].ToString();
            txtAciklama.Text = drow["ACIKLAMA"].ToString();
            txtSiparisGiren.Text = drow["SIPARIS_GIREN"].ToString();
            txtSiparisNo.Text = drow["SIPARIS_NO"].ToString();
            txtStokOnay.Text = drow["STOK_ONAY"].ToString();
            cmbTeslimat.Text = drow["TESLIM_SEKLI"].ToString();
            cmbTeslimAdresi.Text = drow["SEVK_ADRES"].ToString();
            dt_KurTarih.Text = Formatlar.EskiyeCevirKısa(drow["KUR_TARIH"].ToString());
            txtKdv.Text = drow["KDV_ORAN"].ToString();
            txt_tarih.Text = Formatlar.EskiyeCevirKısa(drow["TARIH"].ToString());

            Liste.DataSource = Siparis.SiparisIcerikleriniYukle(txtSiparisNo.Text);
            Hesapla();

            if (drow["KDV_EKLIMI"].ToString() == "E")
            {
                chkKdv.Checked = true;
            }
            else
            {
                chkKdv.Checked = false;
            }
        }
        void StokSareketCEK_SIPARİSNO(string siparisNO)
        {
            btnSec.Visible = false;
            btnFisNoGir.Visible = false;
            btnFisNoGit.Visible = false;
            btnFaturaNoGir.Visible = false;
            btnStokONAY.Enabled = false;
            btnSatisONAY.Enabled = false;
            btnYeniSiparis.Enabled = false;
            btnSil.Enabled = false;
            btnKaydet.Enabled = false;
            btn_sec.Dispose();
            cmd_stok_turu.Dispose();
            chkKdv.Enabled = false;
            chkIskontoYok.Enabled = false;

            txtSiparisVeren.Properties.ReadOnly = true;
            txt_tarih.Properties.ReadOnly = true;
            cmbSiparisTuru.Properties.ReadOnly = true;
            txtKdv.Properties.ReadOnly = true;
            dt_KurTarih.Properties.ReadOnly = true;

            gridView1.Columns["STOK_KODU"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["MODEL_NO"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["MIKTAR"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["BIRIM_FIYAT"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["ISK_1"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["ISK_2"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["ISK_3"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["KDV"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["TURU"].OptionsColumn.AllowEdit = false;

            gridView1.Columns["STOK_KODU"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["MODEL_NO"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["MIKTAR"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["BIRIM_FIYAT"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["ISK_1"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["ISK_2"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["ISK_3"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["KDV"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["TURU"].OptionsColumn.AllowFocus = false;

            Liste.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            Liste.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            Liste.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            Liste.EmbeddedNavigator.Buttons.Next.Enabled = false;
            Liste.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            Liste.EmbeddedNavigator.Buttons.Append.Enabled = false;

            DataRow drow = Siparis.StokHareketCET_siparisNO_ile(siparisNO);
            txtMusteriKodu.Text = drow["MUSTERI_KODU"].ToString();
            txtFirmaAdi.Text = drow["FIRMA_ADI"].ToString();

            DataRow musteri = MusteriKarti.Musteri_Karti_bilgileriniCek(drow["MUSTERI_KODU"].ToString());
            txtAdres.Text = musteri["ADRES_1"].ToString();
            txtSehir.Text = musteri["IL_1"].ToString();
            txtIlce.Text = musteri["ILCE_1"].ToString();
            txtVergiDairesi.Text = musteri["VERGI_DAIRESI"].ToString();
            txtVergiNo.Text = musteri["VERGI_NO"].ToString();
            txtBayiilikTuru.Text = musteri["BAYIILIK_TURU"].ToString();
            txtTel.Text = musteri["TEL_1"].ToString();

            txtSiparisVeren.Text = drow["SIPARIS_VEREN"].ToString();
            txtFisNo.Text = drow["FIS_NO"].ToString();
            txtFaturaNo.Text = drow["FATURA_NO"].ToString();
            txtAciklama.Text = drow["ACIKLAMA"].ToString();
            txtSiparisGiren.Text = drow["SIPARIS_GIREN"].ToString();
            txtSiparisNo.Text = drow["SIPARIS_NO"].ToString();
            txtStokOnay.Text = drow["STOK_ONAY"].ToString();
            cmbTeslimat.Text = drow["TESLIM_SEKLI"].ToString();
            cmbTeslimAdresi.Text = drow["SEVK_ADRES"].ToString();
            dt_KurTarih.Text = Formatlar.EskiyeCevirKısa(drow["KUR_TARIH"].ToString());
            txtKdv.Text = drow["KDV_ORAN"].ToString();
            txt_tarih.Text = Formatlar.EskiyeCevirKısa(drow["TARIH"].ToString());

            string Tipi = drow["TIPI"].ToString();
            if (Tipi == "SP")
            {
                cmbSiparisTuru.Text = "SİPARİS";
            }
            else if (Tipi == "KNS.SP")
            {
                cmbSiparisTuru.Text = "KONSİNYE SİPARİS";
            }
            Liste.DataSource = Siparis.Stok_Hareket_Icerik_SiparisNO(siparisNO);
            Hesapla();

            if (drow["KDV_EKLIMI"].ToString() == "E")
            {
                chkKdv.Checked = true;
            }
            else
            {
                chkKdv.Checked = false;
            }
        }
        void StokHareketBilgileriniCek()
        {
            btnSec.Visible = false;
            btnFisNoGir.Visible = false;
            btnFisNoGit.Visible = false;
            btnFaturaNoGir.Visible = false;
            btnStokONAY.Enabled = false;
            btnSatisONAY.Enabled = false;
            btnYeniSiparis.Enabled = false;
            btnSil.Enabled = false;
            btnKaydet.Enabled = false;
            btn_sec.Dispose();
            cmd_stok_turu.Dispose();
            chkKdv.Enabled = false;
            chkIskontoYok.Enabled = false;

            txtSiparisVeren.Properties.ReadOnly = true;
            txt_tarih.Properties.ReadOnly = true;
            cmbSiparisTuru.Properties.ReadOnly = true;
            txtKdv.Properties.ReadOnly = true;
            dt_KurTarih.Properties.ReadOnly = true;

            gridView1.Columns["STOK_KODU"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["MODEL_NO"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["MIKTAR"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["BIRIM_FIYAT"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["ISK_1"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["ISK_2"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["ISK_3"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["KDV"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["TURU"].OptionsColumn.AllowEdit = false;

            gridView1.Columns["STOK_KODU"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["MODEL_NO"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["MIKTAR"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["BIRIM_FIYAT"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["ISK_1"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["ISK_2"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["ISK_3"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["KDV"].OptionsColumn.AllowFocus = false;
            gridView1.Columns["TURU"].OptionsColumn.AllowFocus = false;

            Liste.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            Liste.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            Liste.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            Liste.EmbeddedNavigator.Buttons.Next.Enabled = false;
            Liste.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            Liste.EmbeddedNavigator.Buttons.Append.Enabled = false;

            DataRow drow = Siparis.StokHareketBilgileriniYukle(SiparisID);
            txtMusteriKodu.Text = drow["MUSTERI_KODU"].ToString();
            txtFirmaAdi.Text = drow["FIRMA_ADI"].ToString();

            DataRow musteri = MusteriKarti.Musteri_Karti_bilgileriniCek(drow["MUSTERI_KODU"].ToString());
            txtAdres.Text = musteri["ADRES_1"].ToString();
            txtSehir.Text = musteri["IL_1"].ToString();
            txtIlce.Text = musteri["ILCE_1"].ToString();
            txtVergiDairesi.Text = musteri["VERGI_DAIRESI"].ToString();
            txtVergiNo.Text = musteri["VERGI_NO"].ToString();
            txtBayiilikTuru.Text = musteri["BAYIILIK_TURU"].ToString();
            txtTel.Text = musteri["TEL_1"].ToString();

            txtSiparisVeren.Text = drow["SIPARIS_VEREN"].ToString();
            txtFisNo.Text = drow["FIS_NO"].ToString();
            txtFaturaNo.Text = drow["FATURA_NO"].ToString();
            txtAciklama.Text = drow["ACIKLAMA"].ToString();
            txtSiparisGiren.Text = drow["SIPARIS_GIREN"].ToString();
            txtSiparisNo.Text = drow["SIPARIS_NO"].ToString();
            txtStokOnay.Text = drow["STOK_ONAY"].ToString();
            cmbTeslimat.Text = drow["TESLIM_SEKLI"].ToString();
            cmbTeslimAdresi.Text = drow["SEVK_ADRES"].ToString();
            dt_KurTarih.Text = Formatlar.EskiyeCevirKısa(drow["KUR_TARIH"].ToString());
            txtKdv.Text = drow["KDV_ORAN"].ToString();
            txt_tarih.Text = Formatlar.EskiyeCevirKısa(drow["TARIH"].ToString());

            string Tipi = drow["TIPI"].ToString();
            if (Tipi == "SP")
            {
                cmbSiparisTuru.Text = "SİPARİS";
            }
            else if (Tipi == "KNS.SP")
            {
                cmbSiparisTuru.Text = "KONSİNYE SİPARİS";
            }

            Liste.DataSource = Siparis.StokHareketIverikYukle(txtSiparisNo.Text);
            Hesapla();

            if (drow["KDV_EKLIMI"].ToString() == "E")
            {
                chkKdv.Checked = true;
            }
            else
            {
                chkKdv.Checked = false;
            }
        }
        private void frmYeniSiparis_Load(object sender, EventArgs e)
        {
            if (stokhareketgoruntule)
            {
                StokSareketCEK_SIPARİSNO(SiparisID);
                chkTL.Checked = true;
                this.Text = "Satış Fişi";
                Para_birimlerini_Getir();
                kolonHesapla();
                Hesapla();
            }
            else
            {
                if (satisGoruntule)
                {
                    StokHareketBilgileriniCek();
                    chkTL.Checked = true;
                    this.Text = "Satış Fişi";
                    Para_birimlerini_Getir();
                    kolonHesapla();
                    Hesapla();
                }
                else
                {
                    if (Edit)
                    {
                        txtKdv.Text = "18";
                        chkTL.Checked = true;
                        KargolarYukle();
                        Para_birimlerini_Getir();
                        SiparisBilgileriniCek();
                        Stok_Turlerini_Getir();
                        ilk_acilis = true;
                    }
                    else
                    {
                        txt_tarih.Text = DateTime.Now.ToShortDateString();
                        dt_KurTarih.Text = DateTime.Now.ToShortDateString();
                        txtSiparisNo.Text = Numaralar.GetYeniSiparisNumarasi();
                        txtKdv.Text = "18";
                        txtSiparisGiren.Text = "" + AnaForm.Username + "";
                        Para_birimlerini_Getir();
                        KargolarYukle();
                        Doviz_KurCek();
                        Stok_Turlerini_Getir();
                        chkTL.Checked = true;
                    }
                }
            }
        }
        void KargolarYukle()
        {
            for (int i = 1; i <= Kargolar.KargoListeToplamı(); i++)
            {
                cmbTeslimat.Properties.Items.Add("" + Kargolar.KargoIsminiAl(i.ToString()).ToString() + "");
            }
        }
        private void MusteriBilgileriniCek()
        {
            DataRow satir = MusteriKarti.Musteri_Karti_bilgilerini_cek(Musteri_ID);
            txtMusteriKodu.Text = satir["MUSTERI_KODU"].ToString();
            txtFirmaAdi.Text = satir["FIRMA_ADI"].ToString();
            txtAdres.Text = satir["ADRES_1"].ToString();
            txtSehir.Text = satir["IL_1"].ToString();
            txtIlce.Text = satir["ILCE_1"].ToString();
            txtTel.Text = satir["TEL_1"].ToString();
            txtBayiilikTuru.Text = satir["BAYIILIK_TURU"].ToString();
            txtVergiDairesi.Text = satir["VERGI_DAIRESI"].ToString();
            txtVergiNo.Text = satir["VERGI_NO"].ToString();

            isk_1 = satir["ISK_1"].ToString();
            isk_2 = satir["ISK_2"].ToString();
            isk_3 = satir["ISK_3"].ToString();
            isk_4 = satir["ISK_4"].ToString();
            isk_5 = satir["ISK_5"].ToString();
            isk_6 = satir["ISK_6"].ToString();
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            Musteri_ID = Ekranlar.MusteriKodListesiSorgulama(true, false);
            if (Musteri_ID != "")
            {
                MusteriBilgileriniCek();
                btnSec.Enabled = false;
            }
        }

        private void btnFisNoGit_Click(object sender, EventArgs e)
        {
            string fis = Ekranlar.Fis_No_Ac();
            if (fis != "")
            {
                txtFisNo.Text = fis;
            }

        }

        private void btnFaturaNoGir_Click(object sender, EventArgs e)
        {
            string fatura = Ekranlar.Fatura_No_Ac(true, false);
            if (fatura != "")
            {
                txtFaturaNo.Text = fatura;
            }

        }
        void Doviz_KurCek()
        {
            DateTime guncel_tarih = Convert.ToDateTime(Formatlar.EskiyeCevirKısa(Siparis.GüncelKurTarihi()));

            if (Siparis.KurTablosuBosmu())
            {
                if (Kurlar.XTarihliKurVarmı(dt_KurTarih.Text))
                {
                    Tablo_Kurlar = Kurlar.Kurlari_Cek(Formatlar.IngilizceTarihKısaFormat(dt_KurTarih.Text));
                }
                else
                {
                    dt_KurTarih.Text = guncel_tarih.ToShortDateString();
                    Tablo_Kurlar = Kurlar.Kurlari_Cek(Formatlar.IngilizceTarihKısaFormat(guncel_tarih.ToShortDateString()));
                }
            }
            else
            {
                Mesajlar.Uyari("Kur Tablosu BOŞ tur, lütfen kurları güncelleyiniz...");
            }
        }
        private void btnStokONAY_Click(object sender, EventArgs e)
        {
            if (txtMusteriKodu.Text != "")
            {
                if (gridView1.RowCount > 0)
                {
                    if (Siparis.SiparisNoKontrol(txtSiparisNo.Text))
                    {
                        if (txtFisNo.Text != "")
                        {
                            txtStokOnay.Text = "" + AnaForm.Username + "";
                            ilk_acilis = false;
                            Mesajlar.Bilgi("Stok ONAY verildi...");
                        }
                        else
                        {
                            Mesajlar.Uyari("Fis No girilmemiş...STOK ONAY veremezsiniz.!");
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Sipariş Kaydedilmemiş, Stok ONAY veremesizin...");
                    }
                }
                else
                {
                    Mesajlar.Uyari("Sipariş Girilmediği için STOK ONAY veremezsiniz...");
                }
            }
            else
            {
                Mesajlar.Uyari("Sipariş Girilmediği için STOK ONAY veremezsiniz...");
            }
        }

        private void cmbTeslimAdresi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtMusteriKodu.Text != "")
            {
                if (cmbTeslimAdresi.Text == "ADRES 2")
                {
                    txtAciklama.Text = Siparis.TeslimAdresi_M_Kodu(txtMusteriKodu.Text);
                }
            }

        }

        private void btn_sec_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            StokSec();

        }
        void Stok_Turlerini_Getir()
        {
            for (int i = 1; i <= StokKarti.Stok_Turu_Getır(); i++)
            {
                cmd_stok_turu.Items.Add("" + StokTuru.StokBirimiAl(i.ToString()).ToString() + "");
            }
        }
        void Para_birimlerini_Getir()
        {
            string para = Paralar.Para_Birim_SatirSayisi()["ID"].ToString();
            for (int i = 1; i <= Convert.ToInt32(para); i++)
            {
                cmb_para_birimleri.Items.Add("" + Paralar.ParaBirimiYukle_KOD(i.ToString()).ToString() + "");
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
                //txtModelNo.Text = Satir["MODEL_NO"].ToString();

                stok_birimi = Satir["STOK_BIRIMI"].ToString();
                iskonto_grubu = Satir["ISKONTO_GRUBU"].ToString();
                stok_turu = Satir["STOK_TURU"].ToString();
                birim_fiyat = Satir["SATIS_FIYAT"].ToString();
                para_birimi = Satir["SATIS_FIYAT_PARA_BIRIMI"].ToString();
                birim_fiyat_1 = Satir["SATIS_FIYAT_1"].ToString();
                para_birimi_1 = Satir["SATIS_FIYAT_PARA_BIRIMI_1"].ToString();

                string grw_isk_1 = "0";
                string grw_isk_2 = "0";
                string grw_isk_3 = "0";

                if (chkIskontoYok.Checked)
                {
                    grw_isk_1 = "0";
                    grw_isk_2 = "0";
                    grw_isk_3 = "0";
                }
                else
                {
                    if (iskonto_grubu == "1. GRUP")
                    {
                        grw_isk_1 = isk_1;
                        grw_isk_2 = isk_2;
                        grw_isk_3 = isk_3;
                    }
                    else if (iskonto_grubu == "2.GRUP")
                    {
                        grw_isk_1 = isk_4;
                        grw_isk_2 = isk_5;
                        grw_isk_3 = isk_6;
                    }
                    if (grw_isk_1 == "")
                    {
                        grw_isk_1 = "0";
                    }
                    if (grw_isk_2 == "")
                    {
                        grw_isk_2 = "0";
                    }
                    if (grw_isk_3 == "")
                    {
                        grw_isk_3 = "0";
                    }
                }
                UrunEklimi();

                if (urun_eklimi != true)
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TURU", Satir["STOK_TURU"].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "STOK_KODU", Satir["STOK_KODU"].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MODEL_NO", Satir["MODEL_NO"].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "STOK_BIRIMI", Satir["STOK_BIRIMI"].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "BIRIM_FIYAT", Convert.ToDecimal(Satir["SATIS_FIYAT"].ToString()));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PARA_BIRIMI", Satir["SATIS_FIYAT_PARA_BIRIMI"].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ISK_1", Convert.ToDecimal(grw_isk_1));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ISK_2", Convert.ToDecimal(grw_isk_2));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ISK_3", Convert.ToDecimal(grw_isk_3));

                    if (chkKdv.Checked)
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "KDV", 0);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "KDV", txtKdv.Text);
                    }

                    for (int i = 1; i <= StokKarti.Stok_Turu_Getır(); i++)
                    {
                        cmd_stok_turu.Items.Add("" + StokTuru.StokBirimiAl(i.ToString()).ToString() + "");
                    }
                }
                else
                {
                    if (Mesajlar.Sor("Bu ürünü zaten eklediniz, Onaylarsanız tekrar eklenecek...!"))
                    {
                        gridView1.AddNewRow();
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TURU", Satir["STOK_TURU"].ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "STOK_KODU", Satir["STOK_KODU"].ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MODEL_NO", Satir["MODEL_NO"].ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "STOK_BIRIMI", Satir["STOK_BIRIMI"].ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "BIRIM_FIYAT", Convert.ToDecimal(Satir["SATIS_FIYAT"].ToString()));
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PARA_BIRIMI", Satir["SATIS_FIYAT_PARA_BIRIMI"].ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ISK_1", Convert.ToDecimal(grw_isk_1));
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ISK_2", Convert.ToDecimal(grw_isk_2));
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ISK_3", Convert.ToDecimal(grw_isk_3));

                        if (chkKdv.Checked)
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "KDV", 0);
                        }
                        else
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "KDV", txtKdv.Text);
                        }

                        for (int i = 1; i <= StokKarti.Stok_Turu_Getır(); i++)
                        {
                            cmd_stok_turu.Items.Add("" + StokTuru.StokBirimiAl(i.ToString()).ToString() + "");
                        }
                    }
                }

            }
        }
        void kolonHesapla()
        {

            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                decimal BirimFiyat, Miktar, Isk1, Isk2, Isk3;
                BirimFiyat = Convert.ToDecimal("0");

                Miktar = Convert.ToDecimal("0");

                BirimFiyat = Convert.ToDecimal(gridView1.GetRowCellValue(i, ("BIRIM_FIYAT").ToString()));
                para_birimi = gridView1.GetRowCellValue(i, "PARA_BIRIMI").ToString();

                Miktar = Convert.ToDecimal(gridView1.GetRowCellValue(i, "MIKTAR").ToString());
                Isk1 = Convert.ToDecimal(gridView1.GetRowCellValue(i, "ISK_1").ToString());
                Isk2 = Convert.ToDecimal(gridView1.GetRowCellValue(i, "ISK_2").ToString());
                Isk3 = Convert.ToDecimal(gridView1.GetRowCellValue(i, "ISK_3").ToString());

                decimal AraToplam;//, KatmaDegerV;
                //KatmaDegerV = 0;
                AraToplam = BirimFiyat * Miktar;
                AraToplam = AraToplam - (AraToplam / 100 * Isk1);
                AraToplam = AraToplam - (AraToplam / 100 * Isk2);
                AraToplam = AraToplam - (AraToplam / 100 * Isk3);

                //***********************************************************************
                BirimFiyat = BirimFiyat - (BirimFiyat / 100 * Isk1);
                BirimFiyat = BirimFiyat - (BirimFiyat / 100 * Isk2);
                BirimFiyat = BirimFiyat - (BirimFiyat / 100 * Isk3);
                //***********************************************************************

                string kayitli_birim = "";
                string p_b_kuru = "";

                if (para_birimi != "")
                {
                    if (para_birimi != "-")
                    {
                        if (para_birimi != "TL")
                        {
                            for (int r = 0; r < Tablo_Kurlar.Rows.Count; r++)
                            {
                                kayitli_birim = Tablo_Kurlar.Rows[r]["KOD"].ToString();
                                if (kayitli_birim == para_birimi)
                                {
                                    p_b_kuru = Tablo_Kurlar.Rows[r]["DOVIZ_SATIS"].ToString();
                                }
                            }
                        }
                        else
                        {
                            p_b_kuru = "1";
                        }
                    }
                    else
                    {
                        p_b_kuru = "1";
                    }
                }
                else
                {
                    p_b_kuru = "1";
                }
                decimal ELEMAN = 0;
                ELEMAN = AraToplam;
                AraToplam = AraToplam * Convert.ToDecimal(p_b_kuru);
                gridView1.SetRowCellValue(i, "TOPLAM", AraToplam.ToString("#0.00"));
                gridView1.SetRowCellValue(i, "TOPLAM_USD", ELEMAN.ToString("#0.00"));
                gridView1.SetRowCellValue(i, "ISK_BIR_FIYAT_USD", BirimFiyat.ToString("#0.00"));
                gridView1.SetRowCellValue(i, "ISK_BIR_FIYAT_TL", ((BirimFiyat) * Convert.ToDecimal(p_b_kuru)).ToString("#0.00"));
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "TOPLAM")
            {
                string para_birimi = "";
                decimal BirimFiyat=0, Miktar=0, Isk1=0, Isk2=0, Isk3=0;
                decimal AraToplam=0;//, KatmaDegerV;

                string kayitli_birim = "0";
                string p_b_kuru = "0";

                try
                {
                    BirimFiyat = Convert.ToDecimal("0");

                    Miktar = Convert.ToDecimal("0");
                    Isk1 = Convert.ToDecimal("0");
                    Isk2 = Convert.ToDecimal("0");
                    Isk3 = Convert.ToDecimal("0");
                    BirimFiyat = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, ("BIRIM_FIYAT").ToString()));
                    para_birimi = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PARA_BIRIMI").ToString();

                    Miktar = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MIKTAR").ToString());
                    Isk1 = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ISK_1").ToString());
                    Isk2 = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ISK_2").ToString());
                    Isk3 = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ISK_3").ToString());

                    // decimal AraToplam;//, KatmaDegerV;
                    //KatmaDegerV = 0;
                    AraToplam = BirimFiyat * Miktar;
                    AraToplam = AraToplam - (AraToplam / 100 * Isk1);
                    AraToplam = AraToplam - (AraToplam / 100 * Isk2);
                    AraToplam = AraToplam - (AraToplam / 100 * Isk3);

                    //string kayitli_birim = "";
                    //string p_b_kuru = "";

                    if (para_birimi != "TL")
                    {
                        for (int i = 0; i < Tablo_Kurlar.Rows.Count; i++)
                        {
                            kayitli_birim = Tablo_Kurlar.Rows[i]["KOD"].ToString();
                            if (kayitli_birim == para_birimi)
                            {
                                p_b_kuru = Tablo_Kurlar.Rows[i]["DOVIZ_SATIS"].ToString();
                            }
                        }
                    }
                    else
                    {
                        p_b_kuru = "1";
                    }
                    //***********************************************
                }
                catch (Exception)
                {

                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TOPLAM", 0);
                }
                AraToplam = AraToplam * Convert.ToDecimal(p_b_kuru);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TOPLAM", AraToplam.ToString("#0.00"));
             //   gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TOPLAM_DVZ", (AraToplam / Convert.ToDecimal(p_b_kuru)).ToString("#0.00"));         
            }
            Hesapla();
        }
        void Hesapla()
        {
            decimal BirimFiyat, Miktar, Toplam, KdvOrani, IskontoOncesiToplam, IskontoToplam, KdvToplam, SatirToplam;
            string para_birimi = "";
            string kayitli_birim = "";
            string p_b_kuru = "";
            IskontoOncesiToplam = 0;
            Toplam = 0;
            KdvToplam = 0;
            Miktar = 0;
            KdvOrani = 0;
            SatirToplam = 0;

            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                BirimFiyat = Convert.ToDecimal(gridView1.GetRowCellValue(i, "BIRIM_FIYAT").ToString());
                para_birimi = gridView1.GetRowCellValue(i, "PARA_BIRIMI").ToString();

                Miktar = Convert.ToDecimal(gridView1.GetRowCellValue(i, "MIKTAR").ToString());
                KdvOrani = Convert.ToDecimal(gridView1.GetRowCellValue(i, "KDV").ToString());

                if (para_birimi != "TL")
                {
                    for (int x = 0; x < Tablo_Kurlar.Rows.Count; x++)
                    {
                        kayitli_birim = Tablo_Kurlar.Rows[x]["KOD"].ToString();
                        if (kayitli_birim == para_birimi)
                        {
                            p_b_kuru = Tablo_Kurlar.Rows[x]["DOVIZ_SATIS"].ToString();
                        }
                    }
                    if (p_b_kuru == "")
                    {
                        p_b_kuru = "1";
                    }
                }
                else
                {
                    p_b_kuru = "1";
                }
                IskontoOncesiToplam = IskontoOncesiToplam + ((BirimFiyat * Convert.ToDecimal(p_b_kuru)) * Miktar);
                SatirToplam = (Convert.ToDecimal(gridView1.GetRowCellValue(i, "TOPLAM").ToString()));
                Toplam += SatirToplam;
                KdvToplam = KdvToplam + (SatirToplam * (KdvOrani / 100));
            }

            if (chkDolar.Checked)
            {
                if (chkKdv.Checked)
                {
                    for (int i = 0; i < Tablo_Kurlar.Rows.Count; i++)
                    {
                        kayitli_birim = Tablo_Kurlar.Rows[i]["KOD"].ToString();
                        if (kayitli_birim == "USD")
                        {
                            p_b_kuru = Tablo_Kurlar.Rows[i]["DOVIZ_SATIS"].ToString();
                        }
                    }
                    IskontoOncesiToplam = IskontoOncesiToplam / Convert.ToDecimal(p_b_kuru);
                    txtToplam.Text = IskontoOncesiToplam.ToString("#0.00 USD");
                    IskontoToplam = IskontoOncesiToplam - (Toplam / Convert.ToDecimal(p_b_kuru));
                    txtIskontoToplam.Text = IskontoToplam.ToString("#0.00 USD");
                    KdvToplam = ((Convert.ToDecimal(txtKdv.Text)) * ((IskontoOncesiToplam - IskontoToplam))) / (Convert.ToDecimal(txtKdv.Text) + 100);
                    Toplam = (IskontoOncesiToplam - IskontoToplam) - ((Toplam) * (Convert.ToDecimal(p_b_kuru)));
                    txtNetFiyat.Text = ((IskontoOncesiToplam - IskontoToplam) - KdvToplam).ToString("#0.00 USD");
                    //txtNetFiyat.Text = (IskontoOncesiToplam - IskontoToplam).ToString("#0.00 USD");
                    txtKdvToplam.Text = (KdvToplam).ToString("#0.00 USD");
                    txtGenelToplam.Text = (((IskontoOncesiToplam - IskontoToplam) - KdvToplam) + KdvToplam).ToString("#0.00 USD");
                }
                else
                {
                    for (int i = 0; i < Tablo_Kurlar.Rows.Count; i++)
                    {
                        kayitli_birim = Tablo_Kurlar.Rows[i]["KOD"].ToString();
                        if (kayitli_birim == "USD")
                        {
                            p_b_kuru = Tablo_Kurlar.Rows[i]["DOVIZ_SATIS"].ToString();
                        }
                    }
                    IskontoOncesiToplam = IskontoOncesiToplam / Convert.ToDecimal(p_b_kuru);
                    txtToplam.Text = IskontoOncesiToplam.ToString("#0.00 USD");
                    IskontoToplam = IskontoOncesiToplam - (Toplam / Convert.ToDecimal(p_b_kuru));
                    txtIskontoToplam.Text = IskontoToplam.ToString("#0.00 USD");
                    txtNetFiyat.Text = (IskontoOncesiToplam - IskontoToplam).ToString("#0.00 USD");
                    if (chkKdv.Checked)
                    {
                        KdvToplam = Toplam * (Convert.ToDecimal(txtKdv.Text) / 100);
                    }
                    txtKdvToplam.Text = (KdvToplam / Convert.ToDecimal(p_b_kuru)).ToString("#0.00 USD");
                    txtGenelToplam.Text = ((KdvToplam + Toplam) / Convert.ToDecimal(p_b_kuru)).ToString("#0.00 USD");
                }
            }
            else if (chkEuro.Checked)
            {
                if (chkKdv.Checked)
                {
                    for (int i = 0; i < Tablo_Kurlar.Rows.Count; i++)
                    {
                        kayitli_birim = Tablo_Kurlar.Rows[i]["KOD"].ToString();
                        if (kayitli_birim == "EUR")
                        {
                            p_b_kuru = Tablo_Kurlar.Rows[i]["DOVIZ_SATIS"].ToString();
                        }
                    }
                    IskontoOncesiToplam = IskontoOncesiToplam / Convert.ToDecimal(p_b_kuru);
                    txtToplam.Text = IskontoOncesiToplam.ToString("#0.00 EUR");
                    IskontoToplam = IskontoOncesiToplam - (Toplam / Convert.ToDecimal(p_b_kuru));
                    txtIskontoToplam.Text = IskontoToplam.ToString("#0.00 EUR");
                    KdvToplam = ((Convert.ToDecimal(txtKdv.Text)) * ((IskontoOncesiToplam - IskontoToplam))) / (Convert.ToDecimal(txtKdv.Text) + 100);
                    Toplam = (IskontoOncesiToplam - IskontoToplam) - ((Toplam) * (Convert.ToDecimal(p_b_kuru)));
                    txtNetFiyat.Text = ((IskontoOncesiToplam - IskontoToplam) - KdvToplam).ToString("#0.00 EUR");
                    //txtNetFiyat.Text = (IskontoOncesiToplam - IskontoToplam).ToString("#0.00 USD");
                    txtKdvToplam.Text = (KdvToplam).ToString("#0.00 EUR");
                    txtGenelToplam.Text = (((IskontoOncesiToplam - IskontoToplam) - KdvToplam) + KdvToplam).ToString("#0.00 EUR");
                }
                else
                {
                    for (int i = 0; i < Tablo_Kurlar.Rows.Count; i++)
                    {
                        kayitli_birim = Tablo_Kurlar.Rows[i]["KOD"].ToString();
                        if (kayitli_birim == "EUR")
                        {
                            p_b_kuru = Tablo_Kurlar.Rows[i]["DOVIZ_SATIS"].ToString();
                        }
                    }
                    IskontoOncesiToplam = IskontoOncesiToplam / Convert.ToDecimal(p_b_kuru);
                    txtToplam.Text = IskontoOncesiToplam.ToString("#0.00 EUR");
                    IskontoToplam = IskontoOncesiToplam - (Toplam / Convert.ToDecimal(p_b_kuru));
                    txtIskontoToplam.Text = IskontoToplam.ToString("#0.00 EUR");
                    txtNetFiyat.Text = (IskontoOncesiToplam - IskontoToplam).ToString("#0.00 EUR");
                    if (chkKdv.Checked)
                    {
                        KdvToplam = Toplam * (Convert.ToDecimal(txtKdv.Text) / 100);
                    }
                    txtKdvToplam.Text = (KdvToplam / Convert.ToDecimal(p_b_kuru)).ToString("#0.00 EUR");
                    txtGenelToplam.Text = ((KdvToplam + Toplam) / Convert.ToDecimal(p_b_kuru)).ToString("#0.00 EUR");
                }
            }
            else if (chkTL.Checked)
            {
                if (chkKdv.Checked)
                {
                    txtToplam.Text = IskontoOncesiToplam.ToString("#0.00 TL");
                    IskontoToplam = IskontoOncesiToplam - (Toplam);
                    txtIskontoToplam.Text = IskontoToplam.ToString("#0.00 TL");
                    KdvToplam = ((Convert.ToDecimal(txtKdv.Text)) * ((IskontoOncesiToplam - IskontoToplam))) / (Convert.ToDecimal(txtKdv.Text) + 100);
                    Toplam = (IskontoOncesiToplam - IskontoToplam);// - (Toplam);
                    txtNetFiyat.Text = ((IskontoOncesiToplam - IskontoToplam) - KdvToplam).ToString("#0.00 TL");
                    //txtNetFiyat.Text = (IskontoOncesiToplam - IskontoToplam).ToString("#0.00 USD");
                    txtKdvToplam.Text = (KdvToplam).ToString("#0.00 TL");
                    txtGenelToplam.Text = (((IskontoOncesiToplam - IskontoToplam) - KdvToplam) + KdvToplam).ToString("#0.00 TL");
                }
                else
                {

                    txtToplam.Text = IskontoOncesiToplam.ToString("#0.00 TL");
                    IskontoToplam = IskontoOncesiToplam - Toplam;
                    txtIskontoToplam.Text = IskontoToplam.ToString("#0.00 TL");
                    txtNetFiyat.Text = (IskontoOncesiToplam - IskontoToplam).ToString("#0.00 TL");
                    if (chkKdv.Checked)
                    {
                        KdvToplam = Toplam * (Convert.ToDecimal(txtKdv.Text) / 100);
                    }
                    txtKdvToplam.Text = KdvToplam.ToString("#0.00 TL");
                    txtGenelToplam.Text = (KdvToplam + Toplam).ToString("#0.00 TL");
                }
            }
            ilk_acilis = false;
        }
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            string stokkodu = "";
            stokkodu = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STOK_KODU").ToString();
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MIKTAR", 1);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "BIRIM_FIYAT", 0);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ISK_1", 0);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ISK_2", 0);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ISK_3", 0);
            if (stokkodu != "")
            {
                if (chkKdv.Checked)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "KDV", 0);
                }
                else
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "KDV", txtKdv.Text);
                }
                StokBilgileriniGoruntule(stokkodu);
            }
            else
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "STOK_BIRIMI", "ADET");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PARA_BIRIMI", "-");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "KDV", 0);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ISKONTOLU_BIRIM_FIYAT_USD", 0);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ISKONTOLU_BIRIM_FIYAT_TL", 0);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TOPLAM_DVZ", 0);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TOPLAM", 0);
                kolonHesapla();
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void chkDolar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDolar.Checked)
            {
                chkEuro.Checked = false;
                chkTL.Checked = false;
            }
            kolonHesapla();
            Hesapla();
        }

        private void chkEuro_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEuro.Checked)
            {
                chkDolar.Checked = false;
                chkTL.Checked = false;
            }
            kolonHesapla();
            Hesapla();
        }

        private void chkTL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTL.Checked)
            {
                chkDolar.Checked = false;
                chkEuro.Checked = false;
            }
            kolonHesapla();
            Hesapla();
        }
        void Kaydet()
        {
            string kdv_ekleme = "";
            string stk_onay = "";
            string sts_onay = "";
            if (cmbSiparisTuru.Text == "SİPARİS")
            {
                siparis = "SP";
            }
            else if (cmbSiparisTuru.Text == "KONSİNYE SİPARİS")
            {
                siparis = "KNS.SP";
            }

            Tablo_Kur();

            if (chkKdv.Checked)
            {
                kdv_ekleme = "E";
            }
            else
            {
                kdv_ekleme = "H";
            }

            Siparis.Ekle_Siparis_Hareket(txt_tarih.Text, siparis, txtSiparisNo.Text, txtFisNo.Text, txtFaturaNo.Text, txtMusteriKodu.Text, txtFirmaAdi.Text, txtSiparisVeren.Text.ToUpper(), Kullanicilar.KullaniciAdiCek(AnaForm.UserId), stk_onay, sts_onay, cmbTeslimAdresi.Text, cmbTeslimat.Text, txtAciklama.Text.ToUpper(), txtKdv.Text, dt_KurTarih.Text, kdv_ekleme, Convert.ToString(Tablo_Kalemler.Rows.Count), Tablo_Kalemler);
        }
        void Tablo_Kur()
        {
            string id ,turu, stok_kodu, model_no, miktar, stok_birimi, birim_fiyat, para_birimi, isk_1, isk_2, isk_3, kdv,ISKONTOLU_BIRIM_FIYAT_USD,ISKONTOLU_BIRIM_FIYAT_TL,TOPLAM_DVZ, toplam;
            string tipi = "";
            Tablo_Kalemler = new DataTable();

            Tablo_Kalemler.Columns.Add(new DataColumn("ID", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("TIPI", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("TURU", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("STOK_KODU", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("MODEL_NO", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("MIKTAR", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("STOK_BIRIMI", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("BIRIM_FIYAT", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("PARA_BIRIMI", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("ISK_1", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("ISK_2", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("ISK_3", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("KDV", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("ISK_BIR_FIYAT_USD", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("ISK_BIR_FIYAT_TL", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("TOPLAM_USD", typeof(string)));
            Tablo_Kalemler.Columns.Add(new DataColumn("TOPLAM", typeof(string)));

            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                id = gridView1.GetRowCellValue(i, "ID").ToString();
                if (cmbSiparisTuru.Text == "SİPARİS")
                {
                    tipi = "SP";
                }
                else if (cmbSiparisTuru.Text == "KONSİNYE SİPARİS")
                {
                    tipi = "KNS.SP";
                }
                turu = gridView1.GetRowCellValue(i, "TURU").ToString();
                stok_kodu = gridView1.GetRowCellValue(i, "STOK_KODU").ToString();
                model_no = gridView1.GetRowCellValue(i, "MODEL_NO").ToString();
                miktar = gridView1.GetRowCellValue(i, "MIKTAR").ToString();
                stok_birimi = gridView1.GetRowCellValue(i, "STOK_BIRIMI").ToString();
                birim_fiyat = gridView1.GetRowCellValue(i, "BIRIM_FIYAT").ToString();
                para_birimi = gridView1.GetRowCellValue(i, "PARA_BIRIMI").ToString();
                isk_1 = gridView1.GetRowCellValue(i, "ISK_1").ToString();
                isk_2 = gridView1.GetRowCellValue(i, "ISK_2").ToString();
                isk_3 = gridView1.GetRowCellValue(i, "ISK_3").ToString();
                kdv = gridView1.GetRowCellValue(i, "KDV").ToString();
                ISKONTOLU_BIRIM_FIYAT_USD = gridView1.GetRowCellValue(i, "ISK_BIR_FIYAT_USD").ToString();
                ISKONTOLU_BIRIM_FIYAT_TL = gridView1.GetRowCellValue(i, "ISK_BIR_FIYAT_TL").ToString();
                TOPLAM_DVZ = gridView1.GetRowCellValue(i, "TOPLAM_USD").ToString();
                toplam = gridView1.GetRowCellValue(i, "TOPLAM").ToString();

                Tablo_Kalemler.Rows.Add(id, tipi, turu, stok_kodu, model_no, miktar, stok_birimi, birim_fiyat, para_birimi, isk_1, isk_2, isk_3, kdv, ISKONTOLU_BIRIM_FIYAT_USD, ISKONTOLU_BIRIM_FIYAT_TL,TOPLAM_DVZ, toplam);
            }
        }
        void Guncelle()
        {
            string kdv_ekleme = "";
            string sts_onay = "";
            if (cmbSiparisTuru.Text == "SİPARİS")
            {
                siparis = "SP";
            }
            else if (cmbSiparisTuru.Text == "KONSİNYE SİPARİS")
            {
                siparis = "KNS.SP";
            }
            Tablo_Kur();

            if (chkKdv.Checked)
            {
                kdv_ekleme = "E";
            }
            else
            {
                kdv_ekleme = "H";
            }

            Siparis.Guncelle_Siparis_Hareket(txt_tarih.Text, siparis, txtSiparisNo.Text, txtFisNo.Text, txtFaturaNo.Text, txtMusteriKodu.Text, txtFirmaAdi.Text, txtSiparisVeren.Text.ToUpper(), txtSiparisGiren.Text, txtStokOnay.Text, sts_onay, cmbTeslimAdresi.Text, cmbTeslimat.Text, txtAciklama.Text.ToUpper(), txtKdv.Text, dt_KurTarih.Text, kdv_ekleme, Convert.ToString(Tablo_Kalemler.Rows.Count), Tablo_Kalemler);
        }
        void FisNO_Bossa_Guncelle()
        {
            if (txtFisNo.Text=="")
            {
                txtFisNo.Text = txtSiparisNo.Text;
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            FisNO_Bossa_Guncelle();
            if (txtMusteriKodu.Text != "")
            {
                if (txtSiparisVeren.Text != "")
                {
                    if (gridView1.RowCount != 1)
                    {
                        if (Edit)
                        {
                            kolonHesapla();
                            Hesapla();
                            Guncelle();
                            Mesajlar.Bilgi("Sipariş Güncellendi...!!!");
                            ilk_acilis = true;
                        }
                        else
                        {
                            if (!Siparis.FisNoKayitKontrol(txtFisNo.Text))
                            {
                                if (Siparis.SiparisNoKontrol(txtSiparisNo.Text))
                                {
                                    kolonHesapla();
                                    Hesapla();
                                    txtSiparisNo.Text = Numaralar.GetYeniSiparisNumarasi();
                                    Kaydet();
                                    Edit = true;
                                    Mesajlar.Bilgi("Sipariş Kaydı Yapıldı...!!!");
                                    ilk_acilis = true;
                                }
                                else
                                {
                                    txtSiparisNo.Text = Numaralar.GetYeniSiparisNumarasi();
                                    kolonHesapla();
                                    Hesapla();
                                    Kaydet();
                                    Edit = true;
                                    Mesajlar.Bilgi("Sipariş Kaydı Yapıldı...!!!");
                                    ilk_acilis = true;
                                    //this.Close();
                                }
                            }
                            else
                            {
                                Mesajlar.Uyari("Girilen Fiş Numarası Daha Önceden Kullanıldığından Başka Fiş Numarası Giriniz...");
                            }
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Sipariş İçin Ürün Girişi Yapmadınız...!!!");
                    }
                }
                else
                {
                    Mesajlar.Uyari("Sipariş Vereni Belirtmediniz...!!!");
                }
            }
            else
            {

                Mesajlar.Uyari("Siparişi Alınan Müşteriyi Seçmediniz...!!!");
            }
        }

        private void dt_KurTarih_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dt_KurTarih.Text) > Convert.ToDateTime(DateTime.Now.ToLongDateString()))
            {
                dt_KurTarih.Text = DateTime.Now.ToShortDateString();
                //   Mesajlar.Uyari("Girilen Tarih bu günün tarihinden büyük olamaz...!!!");
            }
            Doviz_KurCek();
            kolonHesapla();
            Hesapla();
        }

        private void chkKdv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKdv.Checked)
            {
                kolonHesapla();
                Hesapla();
            }
            else
            {
                kolonHesapla();
                Hesapla();
            }

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (satisGoruntule)
            {
                this.Close();
            }
            else
            {
                if (txtMusteriKodu.Text != "")
                {
                    if (ilk_acilis)
                    {
                        this.Close();
                    }
                    else
                    {
                        if (Mesajlar.Sor("Siparişi Kaydetmediniz, çıkarsanız sipariş silinecek çıkmak istiyormusunuz...?"))
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void txtFisNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                Mesajlar.Uyari("Sadece RAKAM Girebilirsiniz...!");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtFaturaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                Mesajlar.Uyari("Sadece RAKAM Girebilirsiniz...!");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtKdv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                Mesajlar.Uyari("Sadece RAKAM Girebilirsiniz...!");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void cmbSiparisTuru_EditValueChanged(object sender, EventArgs e)
        {
            ilk_acilis = false;
        }

        private void txtKdv_TextChanged(object sender, EventArgs e)
        {
            ilk_acilis = false;
            Hesapla();
        }

        private void txtFisNo_TextChanged(object sender, EventArgs e)
        {
            ilk_acilis = false;
        }

        private void txtFaturaNo_TextChanged(object sender, EventArgs e)
        {
            ilk_acilis = false;
        }
        private void SatisOnayVer()
        {
            string kdv_ekleme = "";
            if (cmbSiparisTuru.Text == "SİPARİS")
            {
                siparis = "SP";
            }
            else if (cmbSiparisTuru.Text == "KONSİNYE SİPARİS")
            {
                siparis = "KNS.SP";
            }
            Tablo_Kur();

            if (chkKdv.Checked)
            {
                kdv_ekleme = "E";
            }
            else
            {
                kdv_ekleme = "H";
            }
            Tablo_Kur();
            Siparis.Stok_Hareket_Ekle(txt_tarih.Text, siparis, txtSiparisNo.Text, txtFisNo.Text, txtFaturaNo.Text, txtMusteriKodu.Text, txtFirmaAdi.Text, txtSiparisVeren.Text, txtSiparisGiren.Text, txtStokOnay.Text, AnaForm.Username, cmbTeslimAdresi.Text, cmbTeslimat.Text, txtAciklama.Text, txtKdv.Text, Formatlar.IngilizceTarihKısaFormat(dt_KurTarih.Text), kdv_ekleme, Convert.ToString(Tablo_Kalemler.Rows.Count), Tablo_Kalemler);
            Mesajlar.Bilgi("Satış ONAY Kaydı Yapıldı...");
        }
        private void btnSatisONAY_Click(object sender, EventArgs e)
        {
            if (txtFisNo.Text != "")
            {
                if (txtStokOnay.Text != "")
                {
                    if (Siparis.SatisOnayYetkisiVarmı(AnaForm.UserId))
                    {
                        SatisOnayVer();
                        this.Close();
                    }
                    else
                    {
                        Mesajlar.Uyari("Satış ONAY Verme Yetkiniz YOK...");
                    }
                }
                else
                {
                    Mesajlar.Uyari("Stok ONAY verilmediği için Satış ONAY veremezsiniz...");
                }
            }
            else
            {
                Mesajlar.Uyari("Fiş No Girilmemiş, Satış Onay veremezsiniz...");
            }
        }

        private void btnYeniSiparis_Click(object sender, EventArgs e)
        {
            Ekranlar.YeniSiparisAc(false, false, "-1",false);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Mesajlar.Sor("Siparişi İptan Etmek İstediğinize Emin misiniz...?"))
            {
                Siparis.SiparisIptal(txtSiparisNo.Text);
                this.Close();
            }
        }
        //  DataTable YazSiparis()
        //{
        //    string id, tarih, siparisno, fisno, faturano, musterikodu, firmaadi, adres, ilce, sehir, tel, vergidairesi, vergino, siparisveren, siparisgiren, stokonay, satisonay, sevkadresi, teslimsekli, aciklama;
        //    Tablo_Kalemler = new DataTable();

        //    Tablo_Kalemler.Columns.Add(new DataColumn("ID", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("TARIH", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("SIPARIS_NO", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("FIS_NO", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("FATURA_NO", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("MUSTERI_KODU", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("FIRMA_ADI", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("ADRES_1", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("ILCE_1", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("IL_1", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("TEL_1", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("VERGI_DAIRESI", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("VERGI_NO", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("SIPARIS_VEREN", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("SIPARIS_GIREN", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("STOK_ONAY", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("SATIS_ONAY", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("SEVK_ADRES", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("TESLIM_SEKLI", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("ACIKLAMA", typeof(string)));

        //    id = "1";
        //    tarih = txt_tarih.Text;
        //    siparisno = txtSiparisNo.Text;
        //    fisno = txtFisNo.Text;
        //    faturano = txtFaturaNo.Text;
        //    musterikodu = txtMusteriKodu.Text;
        //    firmaadi = txtFirmaAdi.Text;
        //    adres = txtAdres.Text;
        //    ilce = txtIlce.Text;
        //    sehir = txtSehir.Text;
        //    tel = txtTel.Text;
        //    vergidairesi = txtVergiDairesi.Text;
        //    vergino = txtVergiNo.Text;
        //    siparisveren = txtSiparisVeren.Text;
        //    siparisgiren = txtSiparisGiren.Text;
        //    stokonay = txtStokOnay.Text;
        //    satisonay = " ";
        //    sevkadresi = "";
        //    teslimsekli = cmbTeslimat.Text;
        //    aciklama = txtAciklama.Text;

        //    Tablo_Kalemler.Rows.Add(id, tarih, siparisno, fisno, faturano, musterikodu, firmaadi, adres, ilce, sehir, tel, vergidairesi, vergino, siparisveren, siparisgiren, stokonay, satisonay, sevkadresi, teslimsekli, aciklama);
        //      return Tablo_Kalemler;
        //}
        //   DataTable YazSiparis_Icerik()
        //{
        //    string id, stok_kodu, model_no, miktar, stok_birimi, birim_fiyat, para_birimi, isk_1, isk_2, isk_3, kdv, toplam,aciklama;
        //    Tablo_Kalemler = new DataTable();

        //    Tablo_Kalemler.Columns.Add(new DataColumn("ID", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("STOK_KODU", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("MODEL_NO", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("MIKTAR", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("STOK_BIRIMI", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("BIRIM_FIYAT", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("PARA_BIRIMI", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("ISK_1", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("ISK_2", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("ISK_3", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("KDV", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("TOPLAM", typeof(string)));
        //    Tablo_Kalemler.Columns.Add(new DataColumn("ACIKLAMA", typeof(string)));

        //    for (int i = 0; i < gridView1.RowCount - 1; i++)
        //    {
        //        id = gridView1.GetRowCellValue(i, "ID").ToString();
        //        stok_kodu = gridView1.GetRowCellValue(i, "STOK_KODU").ToString();
        //        model_no = gridView1.GetRowCellValue(i, "MODEL_NO").ToString();
        //        miktar = gridView1.GetRowCellValue(i, "MIKTAR").ToString();
        //        stok_birimi = gridView1.GetRowCellValue(i, "STOK_BIRIMI").ToString();
        //        birim_fiyat = gridView1.GetRowCellValue(i, "BIRIM_FIYAT").ToString();
        //        para_birimi = gridView1.GetRowCellValue(i, "PARA_BIRIMI").ToString();
        //        isk_1 = gridView1.GetRowCellValue(i, "ISK_1").ToString();
        //        isk_2 = gridView1.GetRowCellValue(i, "ISK_2").ToString();
        //        isk_3 = gridView1.GetRowCellValue(i, "ISK_3").ToString();
        //        kdv = gridView1.GetRowCellValue(i, "KDV").ToString();
        //        toplam = gridView1.GetRowCellValue(i, "TOPLAM").ToString();
        //        aciklama = gridView1.GetRowCellValue(i, "ACIKLAMA").ToString();

        //        Tablo_Kalemler.Rows.Add(id, stok_kodu, model_no, miktar, stok_birimi, birim_fiyat, para_birimi, isk_1, isk_2, isk_3, kdv, toplam, aciklama);
        //    }
        //    return Tablo_Kalemler;
        //}

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (satisGoruntule)
            {
                if (chk_muh.Checked)
                {
                    dzYazdir.Stok_Hareket_Yazdir_muh(txtSiparisNo.Text);
                }
                else
                {
                    dzYazdir.Stok_Hareket_Yazdir(txtSiparisNo.Text);
                }
            }
            else
            {
                if (chk_muh.Checked)
                {
                    dzYazdir.SatisFaturasiYazdir_muh(txtSiparisNo.Text);
                }
                else
                {
                    dzYazdir.SatisFaturasiYazdir(txtSiparisNo.Text);
                }
            }
        }
        void StokBilgileriniGoruntule(string stok_kodu)
        {
            int stok_miktar = Convert.ToInt32(Siparis.GenelStok_Miktar(stok_kodu));
            int defolular = Convert.ToInt32(Siparis.DefoluStok_Miktar(stok_kodu));
            int muhtelif = Convert.ToInt32(Siparis.MuhtelifStok_Miktar(stok_kodu));
            string  gunluk_satis = Siparis.GunlukSatislar_Miktari(stok_kodu);

            int satilabilir = stok_miktar - (defolular + muhtelif + Convert.ToInt32(gunluk_satis));
            try
            {
            txtStokKodu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STOK_KODU").ToString();
            txtModelNo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MODEL_NO").ToString();
            txtBirimFiyat.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BIRIM_FIYAT").ToString();
            txtParaBirimi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PARA_BIRIMI").ToString();
            }
            catch (Exception)
            {

                txtStokKodu.Text = "";
                txtModelNo.Text ="";
                txtBirimFiyat.Text = "";
                txtParaBirimi.Text = "";
            }


            txtStokMiktar.Text = stok_miktar.ToString();
            txtDefoluMiktar.Text = defolular.ToString();
            txtMuhtelifMikktar.Text = muhtelif.ToString();
            txtGunlukSatis.Text = gunluk_satis.ToString();
            txtSatılabilirMiktar.Text = satilabilir.ToString();

            
        }
        void KritikStokSeviyesiSorgulama(string stok_kodu)
        {
            if (stok_kodu != "")
            {
                if (Convert.ToInt32(txtSatılabilirMiktar.Text) < Siparis.GenelStok_KritikStokMiktar(stok_kodu))
                {
                    Mesajlar.Uyari("Kritik stok seviyesinin altında sipariş...|... MODEL NO : '"+txtModelNo.Text +"'...|... KRITIK STOK SEVİYESİ= " + (Siparis.GenelStok_KritikStokMiktar(stok_kodu).ToString()));
                }
            }            
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string stok_kodu = "0";
            try
            {
                stok_kodu = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STOK_KODU").ToString();
            }
            catch (Exception)
            {

                stok_kodu = "0";
            }
            StokBilgileriniGoruntule(stok_kodu);
            kolonHesapla();
        }

        private void txtSatılabilirMiktar_EditValueChanged(object sender, EventArgs e)
        {
            if (!satisGoruntule)
            {
               KritikStokSeviyesiSorgulama(txtStokKodu.Text); 
            }            
        }

    }
}