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
    public partial class frmMusteriListesi : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        Classlar.clsMusteriListesi MusteriListesi = new Classlar.clsMusteriListesi();
        Classlar.clsMusteriKarti MusteriKartı = new Classlar.clsMusteriKarti();
        public frmMusteriListesi()
        {
            InitializeComponent();
        }

        private void frmMusteriListesi_Load(object sender, EventArgs e)
        {
            Liste.DataSource = MusteriListesi.Listele();
            BayiilikTuruYukle();
        }

        private void mn_Yenile_Click(object sender, EventArgs e)
        {
            Liste.DataSource = MusteriListesi.Listele();
        }

        private void Liste_Click(object sender, EventArgs e)
        {
            txtMusteriKodu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MUSTERI_KODU").ToString();
            txtFirmaAdi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FIRMA_ADI").ToString();
            txtAdres.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ADRES_1").ToString();
            txtIl.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IL_1").ToString();
            txtIlce.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ILCE_1").ToString();
            txtUlke.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ULKE").ToString();
            txtTel_1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEL_1").ToString();
            txtTel_2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEL_2").ToString();
            txtCepTel.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CEP_TEL").ToString();
        }

        private void btnTumunuGoster_Click(object sender, EventArgs e)
        {
            Liste.DataSource = MusteriListesi.Listele();
            txt_SorFirmaAdi.Text = "";
            txt_SorIl.Text = "";
        }
        void BayiilikTuruYukle()
        {
            for (int i = 1; i <= MusteriKartı.Bayiilik_Turleri_SatirGetir(); i++)
            {
                cmb_SorBayiilikTuru.Properties.Items.Add("" + MusteriKartı.bayiilikTuru(i).ToString() + "");
            }
        }
        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (rdFirmaAdi.Checked)
            {
              Liste.DataSource= MusteriListesi.FirmaSorgula(txt_SorFirmaAdi.Text.ToUpper());
            }
            else if (rdSehir.Checked)
            {
                Liste.DataSource = MusteriListesi.SehirSorgula(txt_SorIl.Text.ToUpper());
            }
            else if (rdBayiilikTuru.Checked)
            { 
            Liste.DataSource=MusteriListesi.BayiilikTuruSorgula(cmb_SorBayiilikTuru.Text);
            }
        }

        private void mn_Guncelle_Click(object sender, EventArgs e)
        {
            Ekranlar.MusteriKartiAc(true, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
        }
    }
}