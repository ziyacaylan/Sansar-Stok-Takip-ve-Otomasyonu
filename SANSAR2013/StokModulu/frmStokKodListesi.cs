using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.StokModulu
{
    public partial class frmStokKodListesi : DevExpress.XtraEditors.XtraForm
    {
        Classlar.clsStokKodLisitesi StokKodListesi = new Classlar.clsStokKodLisitesi();
        Classlar.clsUrunGrubu UrunGrubu = new Classlar.clsUrunGrubu();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        string SecilenId="";
        public Boolean SecimIcinAcildimi = false;
        public frmStokKodListesi()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            AnaForm.AraDegiskenString = "-1";
            this.Close();
        }

        private void frmStokKodListesi_Load(object sender, EventArgs e)
        {
            Liste.DataSource = StokKodListesi.Listele();
        }

        private void btnUrunGrubu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            btnUrunGrubu.Text = UrunGrubu.UrunGrubuAl(Ekranlar.UrunGrubuAc(true));
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            Liste.DataSource = StokKodListesi.Sorgula(txtStokKodu.Text.ToUpper(), txtModelNo.Text.ToUpper(), btnUrunGrubu.Text);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Liste.DataSource = StokKodListesi.Listele();
            txtStokKodu.Text = "";
            txtModelNo.Text = "";
            btnUrunGrubu.Text = "";
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            if (SecimIcinAcildimi == true)
            {
                Sec();
                AnaForm.AraDegiskenString = SecilenId;
                this.Dispose();
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

        private void frmStokKodListesi_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaForm.AraDegiskenString = SecilenId;
        }
    }
}