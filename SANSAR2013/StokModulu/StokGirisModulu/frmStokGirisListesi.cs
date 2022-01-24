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
    public partial class frmStokGirisListesi : DevExpress.XtraEditors.XtraForm
    {
        Classlar.clsStokGirisListesi TedarikListesi = new Classlar.clsStokGirisListesi();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.MusterıModulu.Classlar.clsMusteriKarti MusteriKarti = new MusterıModulu.Classlar.clsMusteriKarti();

        public frmStokGirisListesi()
        {
            InitializeComponent();
        }
        void Listele()
        {
            string Tipi = "AF";
            DataTable Tablo = TedarikListesi.TedarikListesiniGetir(Tipi);
            Liste.DataSource = Tablo;
        }
        void Temizle()
        {
            txtMusteriKodu.Text = "";
            txtFirmaAdi.Text = "";
            txtAdres.Text = "";
            txtSehir.Text = "";
            txtIlce.Text = "";
            txtBayiilikTuru.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiNo.Text = "";
            txtTelefon.Text = "";
            txtSorFaturaNo.Text = "";
            txtSorFiarmaAdi.Text = "";
            txtSorKayitNo.Text = "";
        }
        private void frmStokGirisListesi_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
            dt_ilkTarih.Text = DateTime.Now.ToShortDateString();
            dt_SonTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void frmStokGirisListesi_Activated(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void mn_Yenile_Click(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void tbnTumunuGoster_Click(object sender, EventArgs e)
        {
            Listele();
            Temizle();
            chkİlkTarih.Checked = false;
            chkSonTarih.Checked = false;
            rbFaturaNo.Checked = false;
            rbFirmaAdi.Checked = false;
            rbKayitNo.Checked=false;
        }

        private void mn_Guncelle_Click(object sender, EventArgs e)
        {
            Ekranlar.StokGirisiAc(true, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SIPARIS_NO").ToString());
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (!rbFirmaAdi.Checked)
            {
                if (!rbKayitNo.Checked)
                {
                    if (!rbFaturaNo.Checked)
                    {
                        if (chkİlkTarih.Checked)
                        {
                            if (chkSonTarih.Checked)
                            {
                                Liste.DataSource = TedarikListesi.IkiTarihArasiSorgula(Formatlar.IngilizceTarihKısaFormat(dt_ilkTarih.Text), Formatlar.IngilizceTarihKısaFormat(dt_SonTarih.Text), "AF");
                            }
                            else
                            {
                                Liste.DataSource = TedarikListesi.IlkTarihSorgula(Formatlar.IngilizceTarihKısaFormat(dt_ilkTarih.Text), "AF");
                            }
                        }
                    }
                    else
                    { 
                         Liste.DataSource = TedarikListesi.FaturaNOSorgula(txtSorFaturaNo.Text.ToUpper(), "AF");                   
                    }
                }
                else
                { 
                    Liste.DataSource = TedarikListesi.KayitNoSorgula(txtSorKayitNo.Text.ToUpper(), "AF");                
                }
            }
            else
            {
                Liste.DataSource = TedarikListesi.FirmaSorgula(txtSorFiarmaAdi.Text.ToUpper(), "AF");
            }
        }
        void MusteriBilgileriniCek(string Musteri_kodu)
        {
            DataRow drow = MusteriKarti.Musteri_Karti_bilgileriniCek(Musteri_kodu);
            if (drow !=null)
            {
                txtMusteriKodu.Text = drow["MUSTERI_KODU"].ToString();
                txtFirmaAdi.Text = drow["FIRMA_ADI"].ToString();
                txtAdres.Text = drow["ADRES_1"].ToString();
                txtSehir.Text = drow["IL_1"].ToString();
                txtIlce.Text = drow["ILCE_1"].ToString();
                txtTelefon.Text= drow["TEL_1"].ToString();
                txtVergiDairesi.Text = drow["VERGI_DAIRESI"].ToString();
                txtVergiNo.Text = drow["VERGI_NO"].ToString();
                txtBayiilikTuru.Text = drow["BAYIILIK_TURU"].ToString();
            }
        }
        private void Liste_Click(object sender, EventArgs e)
        {
            MusteriBilgileriniCek(TedarikListesi.TedarikciMusteriKoduCek(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SIPARIS_NO").ToString()));              

        }
    }
}