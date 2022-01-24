using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.StokModulu.DefolularStokgu
{
    public partial class frmDefolularListesi : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        Classlar.clsDefolularListesi DefoluListesi = new Classlar.clsDefolularListesi();
        SANSAR2013.StokModulu.Classlar.StokKarti StokKarti = new StokModulu.Classlar.StokKarti();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        Dizaynlar.clsYAZDIR yazdir = new Dizaynlar.clsYAZDIR();

        public frmDefolularListesi()
        {
            InitializeComponent();
        }

        private void btnYeniGiris_Click(object sender, EventArgs e)
        {
            Ekranlar.DefoluGiris("-1", false);
        }
        void Listele()
        {
            Liste.DataSource = DefoluListesi.Defolu_Listele();
        }
        private void frmDefolularListesi_Load(object sender, EventArgs e)
        {
            Listele();
            UrunGrubu();
        }

        private void mn_Yenile_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void Liste_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount != 0 && gridView1.RowCount != -1)
            {
                txtStokKodu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STOK_KODU").ToString();
                txtModelNo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MODEL_NO").ToString();
                txtUrubGrubu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "URUN_GRUBU").ToString();
                txtArizaliMiktar.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MIKTAR").ToString();
                txtStokBirimi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STOK_BIRIMI").ToString();
                txtEtiketRengi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ETIKET_RENGI").ToString();
                txtDepoNo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DEPO_NO").ToString();
                txtRafNo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RAF_NO").ToString();
                txtGozNo.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GOZ_NO").ToString();
                txtKritikStokSeviyesi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KOLI_NO").ToString();
                txtAciklama.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ACIKLAMA").ToString();
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            txtSorModelNo.Text = "";
            txtSorStokKodu.Text = "";
            cmb_SorUrunGrubu.Text = "";
            Listele();
        }
        void UrunGrubu()
        {
            for (int i = 1; i <= StokKarti.UrunGrubuAdetCek(); i++)
            {
                cmbSorUrunGrubu.Properties.Items.Add("" + StokKarti.UrunGrubu(i).ToUpper() + "");
            }
        }
        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (rbStokKodu.Checked)
            {
                Liste.DataSource = DefoluListesi.StokKoduSOR(txtSorStokKodu.Text.ToUpper());
            }
            else if (rbModelNo.Checked)
            {
                Liste.DataSource = DefoluListesi.Model_NO_SOR(txtSorModelNo.Text.ToUpper());
            }
            else
            {
                Liste.DataSource = DefoluListesi.Urun_Grubu_SOR(cmbSorUrunGrubu.Text.ToUpper());
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount != 0 && gridView1.RowCount != -1)
            {
                if (Mesajlar.Sor("Seçili ürünü Silmek istediğinize emin misiniz_?"))
                {
                    DefoluListesi.DefoluSIL(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
                    Mesajlar.Bilgi("Kayıt silindi...!!");
                    Listele();
                }
            }
            else
            {
                Mesajlar.Uyari("Listede Ekli ürün bulunmamaktadır, ürün seçimi yapılamıyor");
            }
        }

        private void mn_Guncelle_Click(object sender, EventArgs e)
        {
            Ekranlar.DefoluGiris(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), true);
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (rbStokKodu.Checked)
            {
                yazdir.DefoluYazdir_STOK_KODU(txtSorStokKodu.Text);
            }
            else if (rbModelNo.Checked)
            {
                yazdir.DefoluYazdir_MODEL_NO(txtSorModelNo.Text);
            }
            else if (rbUrunGrubu.Checked)
            {
                yazdir.DefoluYazdir_URUN_GRUBU(cmb_SorUrunGrubu.Text);
            }
            else
            {
                yazdir.DefoluYazdir();
            }
        }
    }
}