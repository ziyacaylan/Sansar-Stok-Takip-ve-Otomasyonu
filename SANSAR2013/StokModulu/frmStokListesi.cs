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
    public partial class frmStokListesi : DevExpress.XtraEditors.XtraForm
    {
        //private string SecilenId;

        Classlar.StokListesi StokListesi = new Classlar.StokListesi();
        Classlar.StokKarti StokKarti = new Classlar.StokKarti();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();

        public frmStokListesi()
        {
            InitializeComponent();
        }

        private void frmStokListesi_Load(object sender, EventArgs e)
        {
            Liste.DataSource = StokListesi.Listele();
            UrunGrubu();
        }
        void UrunGrubu()
        {
            for (int i = 1; i <= StokKarti.UrunGrubuAdetCek(); i++)
            {
                cmbSorUrunGrubu.Properties.Items.Add("" + StokKarti.UrunGrubu(i).ToUpper() + "");
            }
        }
        private void mn_Guncelle_Click(object sender, EventArgs e)
        {
            Ekranlar.StokKartiAc(true, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
        }

        private void Liste_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount != 0 && gridView1.RowCount != -1)
            {
                txtStokKodu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STOK_KODU").ToString();
                txtModelNo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MODEL_NO").ToString();
                txtUrubGrubu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "URUN_GRUBU").ToString();
                txtStokMiktar.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STOK_MIKTAR").ToString();
                txtStokBirimi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STOK_BIRIMI").ToString();
                txtBirimFiyat.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SATIS_FIYAT").ToString();
                txtParaBirimi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SATIS_FIYAT_PARA_BIRIMI").ToString();
                txtIskontoGrubu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ISKONTO_GRUBU").ToString();
                txtEtiketRengi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ETIKET_RENGI").ToString();
                txtDepoNo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DEPO_NO").ToString();
                txtRafNo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RAF_NO").ToString();
                txtGozNo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GOZ_NO").ToString();
                txtKritikStokSeviyesi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KRITIK_STOK_SEVIYESI").ToString();
                txtAciklama.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ACIKLAMA").ToString();
            }
        }

        private void frmStokListesi_Activated(object sender, EventArgs e)
        {
            Liste.DataSource = StokListesi.Listele();
        }

        private void mn_Yenile_Click(object sender, EventArgs e)
        {
            Liste.DataSource = StokListesi.Listele();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (rbStokKodu.Checked)
            {
                Liste.DataSource = StokListesi.StokKoduSorgula(txtSorStokKodu.Text.ToUpper());
            }
            else if (rbModelNo.Checked)
            {
                Liste.DataSource = StokListesi.ModelNoSorgula(txtSorModelNo.Text.ToUpper());
            }
            else if (rbUrunGrubu.Checked)
            {
                Liste.DataSource = StokListesi.UrunGrubuSorgula(cmbSorUrunGrubu.Text);
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Liste.DataSource = StokListesi.Listele();
            txtSorStokKodu.Text = "";
            txtSorModelNo.Text = "";
            cmb_SorUrunGrubu.Text = "";
        }
    }
}