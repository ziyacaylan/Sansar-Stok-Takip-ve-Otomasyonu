using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.TeknikServisModulu
{
    public partial class frmServisBeklemeListesi : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        Classlar.clsServisGirisListesi ServisGirisListesi = new Classlar.clsServisGirisListesi();
        SANSAR2013.MusterıModulu.Classlar.clsMusteriKarti MusteriKarti = new MusterıModulu.Classlar.clsMusteriKarti();
        TeknikServisModulu.ServisGirisi.Classlar.clsServisGirisi ServisGiris = new ServisGirisi.Classlar.clsServisGirisi();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();

        public frmServisBeklemeListesi()
        {
            InitializeComponent();
        }

        private void btnServisIslemleri_Click(object sender, EventArgs e)
        {
            Ekranlar.ServisOlayFormuAc(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SERVIS_NO").ToString(), false);
        }
        void Listele()
        {
            Liste.DataSource = ServisGirisListesi.Listele();
        }
        private void frmServisBeklemeListesi_Load(object sender, EventArgs e)
        {
            Listele();
            dt_ilkTarih.Text = DateTime.Now.ToShortDateString();
            dt_SonTarih.Text = DateTime.Now.ToShortDateString();
        }
        void MusteriBilgileriniCek(string Musteri_kodu)
        {
            DataRow drow = MusteriKarti.Musteri_Karti_bilgileriniCek(Musteri_kodu);
            if (drow != null)
            {
                txtMusteriKodu.Text = drow["MUSTERI_KODU"].ToString();
                txtFirmaAdi.Text = drow["FIRMA_ADI"].ToString();
                txtAdres.Text = drow["ADRES_1"].ToString();
                txtSehir.Text = drow["IL_1"].ToString();
                txtIlce.Text = drow["ILCE_1"].ToString();
                txtTel.Text = drow["TEL_1"].ToString();
                txtVergiDairesi.Text = drow["VERGI_DAIRESI"].ToString();
                txtVergiNo.Text = drow["VERGI_NO"].ToString();
                txtBayiilikTuru.Text = drow["BAYIILIK_TURU"].ToString();
            }
        }
        private void Liste_Click_1(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                MusteriBilgileriniCek(ServisGirisListesi.ArizaliMusteriKoduCek(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SERVIS_NO").ToString()));
            }
        }
        void Temizle()
        {
            txtMusteriKodu.Text = "";
            txtFirmaAdi.Text = "";
            txtAdres.Text = "";
            txtSehir.Text = "";
            txtIlce.Text = "";
            txtTel.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiNo.Text = "";
            txtBayiilikTuru.Text = "";
            txtSorIrsaliyeNo.Text = "";
            txtSorFirmaAdi.Text = "";
            txtSorServisNo.Text = "";
            rbIrsaliyeNo.Checked = false;
            rbFirmaAdi.Checked = false;
            rbServisNo.Checked = false;
            chkİlkTarih.Checked = false;
            chkSonTarih.Checked = false;
        }
        private void mn_Yenile_Click(object sender, EventArgs e)
        {
            Temizle();
            Listele();
        }

        private void tbnTumunuGoster_Click(object sender, EventArgs e)
        {
            Temizle();
            Listele();
        }

        private void mn_Goruntule_Click(object sender, EventArgs e)
        {
            Ekranlar.ServisGirisiAc(true, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SERVIS_NO").ToString(), ServisGirisListesi.ArizaliMusteriKoduCek(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SERVIS_NO").ToString()));
        }

        private void frmServisBeklemeListesi_Activated(object sender, EventArgs e)
        {
            Temizle();
            Listele();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (!rbFirmaAdi.Checked)
            {
                if (!rbServisNo.Checked)
                {
                    if (!rbIrsaliyeNo.Checked)
                    {
                        if (chkİlkTarih.Checked)
                        {
                            if (chkSonTarih.Checked)
                            {
                                Liste.DataSource = ServisGirisListesi.IkiTarihArasiSorgula(Formatlar.IngilizceTarihKısaFormat(dt_ilkTarih.Text), Formatlar.IngilizceTarihKısaFormat(dt_SonTarih.Text));
                            }
                            else
                            {
                                Liste.DataSource = ServisGirisListesi.IlkTarihSorgula(Formatlar.IngilizceTarihKısaFormat(dt_ilkTarih.Text));
                            }
                        }
                    }
                    else
                    {
                        Liste.DataSource = ServisGirisListesi.IrsaliyeNOSorgula(txtSorIrsaliyeNo.Text.ToUpper());
                    }
                }
                else
                {
                    Liste.DataSource = ServisGirisListesi.ServisNoSorgula(txtSorServisNo.Text);
                }
            }
            else
            {
                Liste.DataSource = ServisGirisListesi.FirmaAdiSorgula(txtSorFirmaAdi.Text);
            }
        }
    }
}