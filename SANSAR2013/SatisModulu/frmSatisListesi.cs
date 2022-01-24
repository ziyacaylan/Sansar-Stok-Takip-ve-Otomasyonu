using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.SatisModulu
{
    public partial class frmSatisListesi : DevExpress.XtraEditors.XtraForm
    {
        Classlar.SatisListesi SatilListesi = new Classlar.SatisListesi();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        SANSAR2013.MusterıModulu.Classlar.clsMusteriKarti MusteriKarti = new MusterıModulu.Classlar.clsMusteriKarti();

        public frmSatisListesi()
        {
            InitializeComponent();
        }
        void Listele()
        { 
            string Tipi="SP";
            string Tipi2 = "KNS.SP";
            DataTable Tablo = SatilListesi.SatisListesiniGetir(Tipi,Tipi2);
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
            txtSiparisVeren.Text = "";
            txtTelefon.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiNo.Text = "";
            txtSorFaturaNo.Text = "";
            txtSorFirmaAdi.Text = "";
            txtSorFisNo.Text = "";
            txtSorKayitNo.Text = "";
        }
        private void frmSatisListesi_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
            dt_ilkTarih.Text = DateTime.Now.ToShortDateString();
            dt_SonTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void frmSatisListesi_Activated(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void mn_Yenile_Click(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void mn_Guncelle_Click(object sender, EventArgs e)
        {
            Ekranlar.YeniSiparisAc(false, true, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(),false);
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (!rbFirmaAdi.Checked)
            {
                if (!rbFisNo.Checked)
                {
                    if (!rbFaturaNo.Checked)
                    {
                        if (!rbKayitNo.Checked)
                        {
                            if (chkİlkTarih.Checked)
                            {
                                if (chkSonTarih.Checked)
                                {
                                Liste.DataSource=SatilListesi.IkiTarihArasiSorgula(Formatlar.IngilizceTarihKısaFormat(dt_ilkTarih.Text), Formatlar.IngilizceTarihKısaFormat(dt_SonTarih.Text));
                                }
                                else
                                {
                                    Liste.DataSource = SatilListesi.IlkTarihSorgula(Formatlar.IngilizceTarihKısaFormat(dt_ilkTarih.Text));
                                }
                            }
                        }
                        else
                        {
                            Liste.DataSource = SatilListesi.KayitNOSorgula(txtSorKayitNo.Text);
                        }
                    }
                    else
                    {
                        Liste.DataSource = SatilListesi.FaturaNoSorgula(txtSorFaturaNo.Text);
                    }
                }
                else
                {
                    Liste.DataSource = SatilListesi.FisNoSorgula(txtSorFisNo.Text);
                }
            }
            else
            {
                Liste.DataSource = SatilListesi.FirmaAdiSorgula(txtSorFirmaAdi.Text.ToUpper());
            }
        }

        private void tbnTumunuGoster_Click(object sender, EventArgs e)
        {
            Listele();
            Temizle();
            rbFaturaNo.Checked = false;
            rbFirmaAdi.Checked = false;
            rbFisNo.Checked = false;
            rbKayitNo.Checked = false;
            chkİlkTarih.Checked = false;
            chkSonTarih.Checked = false;
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
                txtTelefon.Text = drow["TEL_1"].ToString();
                txtVergiDairesi.Text = drow["VERGI_DAIRESI"].ToString();
                txtVergiNo.Text = drow["VERGI_NO"].ToString();
                txtBayiilikTuru.Text = drow["BAYIILIK_TURU"].ToString();
            }
        }

        private void Liste_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount != 0 && gridView1.RowCount != -1)
            {
                MusteriBilgileriniCek(SatilListesi.SatisMusteriKoduCek(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SIPARIS_NO").ToString()));
                txtSiparisVeren.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SIPARIS_VEREN").ToString();
            }
        }
    }
}