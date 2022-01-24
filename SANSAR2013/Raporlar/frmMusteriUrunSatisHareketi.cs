using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.Raporlar
{
    public partial class frmMusteriUrunSatisHareketi : DevExpress.XtraEditors.XtraForm
    {
        public string Musteri_ID = "";
        public string Stok_ID = "";

        SANSAR2013.MusterıModulu.Classlar.clsMusteriKarti MusteriKarti = new MusterıModulu.Classlar.clsMusteriKarti();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        Classlar.clsMusteriUrunSatisHareket SatisHareket = new Classlar.clsMusteriUrunSatisHareket();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        SANSAR2013.Classlar.ExportIslemleri ExportIslemleri = new SANSAR2013.Classlar.ExportIslemleri();
 
        public frmMusteriUrunSatisHareketi()
        {
            InitializeComponent();
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
        }
        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            Musteri_ID = Ekranlar.MusteriKodListesiSorgulama(true, false);
            if (Musteri_ID != "")
            {
                MusteriBilgileriniCek();
            }
        }
        private void StokBilgileriCEK(string stok_ID)
        {
            DataRow drow = SatisHareket.StokBilgileriniCEK(stok_ID);
            try
            {
                txtStokKodu.Text = drow["STOK_KODU"].ToString();
                txtModelNO.Text = drow["MODEL_NO"].ToString();
                txtBirimFiyat.Text = drow["SATIS_FIYAT"].ToString();
                txtParaBirimi.Text = drow["SATIS_FIYAT_PARA_BIRIMI"].ToString();
            }
            catch (Exception)
            {
                txtStokKodu.Text = "";
                txtModelNO.Text = "";
                txtBirimFiyat.Text = "";
                txtParaBirimi.Text = "";
            }
        }
        private void btnUrunSEC_Click(object sender, EventArgs e)
        {
           Stok_ID= Ekranlar.StokKodListesiSorgulama(true);
           if (Stok_ID!="")
           {
               StokBilgileriCEK(Stok_ID);
           }
        }
        private void SorguListele()
        {
            if (chkTarihAraligi.Checked)
            {
                Liste.DataSource = SatisHareket.IkiTarihArasiSorgula(txtMusteriKodu.Text, txtStokKodu.Text, txtModelNO.Text, dt_ilkTarih.Text, dt_SonTarih.Text);
            }
            else
            {
                Liste.DataSource = SatisHareket.SatisUrunHAREKET(txtMusteriKodu.Text, txtStokKodu.Text, txtModelNO.Text);
            }
        }
        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (txtFirmaAdi.Text != "")
            {
                if (txtStokKodu.Text != "")
                {
                    SorguListele();
                }
                else
                {
                    if (txtModelNO.Text != "")
                    {
                        SorguListele();
                    }
                    else
                    {
                        Mesajlar.Uyari("Sorgulanacak Ürünü Belirtmediniz...");
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Firma Adını Belirtmediniz...");
            }
        }

        private void btnSatisGör_Click(object sender, EventArgs e)
        {
            Ekranlar.YeniSiparisAc(false, false, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SIPARIS_NO").ToString(),true);
        }

        private void mn_Yenile_Click(object sender, EventArgs e)
        {
            if (txtFirmaAdi.Text != "")
            {
                if (txtStokKodu.Text != "")
                {
                    SorguListele();
                }
                else
                {
                    if (txtModelNO.Text != "")
                    {
                        SorguListele();
                    }
                    else
                    {
                        Mesajlar.Uyari("Sorgulanacak Ürünü Belirtmediniz...");
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Firma Adını Belirtmediniz...");
            }
        }
        void Temizle()
        {
            txtStokKodu.Text = "";
            txtModelNO.Text = "";
            txtBirimFiyat.Text = "";
            txtParaBirimi.Text = "";
            chkTarihAraligi.Checked = false;
        }
        private void temizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Temizle();
            SorguListele();
        }

        private void btnExcell2003_Click(object sender, EventArgs e)
        {
            ExportIslemleri.Excel2003("" + txtFirmaAdi.Text + "", Liste);
        }

        private void btnExcell2007_Click(object sender, EventArgs e)
        {
            ExportIslemleri.Excel2007("" + txtFirmaAdi.Text + "", Liste);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            ExportIslemleri.PDF("" + txtFirmaAdi.Text + "", Liste);
        }

        private void btnHTML_Click(object sender, EventArgs e)
        {
            ExportIslemleri.HTML("" + txtFirmaAdi.Text + "", Liste);
        }

        private void frmMusteriUrunSatisHareketi_Load(object sender, EventArgs e)
        {
            dt_ilkTarih.Text = DateTime.Now.ToShortDateString();
            dt_SonTarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}