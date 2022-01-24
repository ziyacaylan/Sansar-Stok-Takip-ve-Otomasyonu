using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.MusterıModulu
{
    public partial class frmMusteriKodListesi : DevExpress.XtraEditors.XtraForm
    {
        Classlar.clsBayiilikTuru BayiilikTuru = new Classlar.clsBayiilikTuru();
        Classlar.clsMusteriKodListesi MusteriListesi = new Classlar.clsMusteriKodListesi();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        string SecilenId = "";
        public Boolean SecimIcinAcildimi = false;
        public Boolean TedarikIcinmi = false;

        public frmMusteriKodListesi()
        {
            InitializeComponent();
        }

        private void frmMusteriKodListesi_Load(object sender, EventArgs e)
        {
            Liste.DataSource = MusteriListesi.Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            txtFirmaAdi.Text = "";
            txtMusteriKodu.Text = "";
            txtSehir.Text = "";
            btnBayiilikTuru.Text = "";
            Liste.DataSource = MusteriListesi.Listele();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            AnaForm.AraDegiskenString = "-1";
            this.Close();
        }

        private void btnBayiilikTuru_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            btnBayiilikTuru.Text = BayiilikTuru.BayiilikTuruAl(Ekranlar.BayiilikTuruAc(true));
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            Liste.DataSource = MusteriListesi.Sorgula(txtMusteriKodu.Text.ToUpper(), txtFirmaAdi.Text.ToUpper(), txtSehir.Text.ToUpper(), btnBayiilikTuru.Text);
        }

        private void frmMusteriKodListesi_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaForm.AraDegiskenString = SecilenId;
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

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            if (TedarikIcinmi)
            {
                Sec();
                AnaForm.AraDegiskenString = SecilenId;
                this.Dispose();
            }
            else
            {
                if (SecimIcinAcildimi == true)
                {
                    Sec();
                    AnaForm.AraDegiskenString = SecilenId;
                    this.Dispose();
                }
            }
        }
    }
}