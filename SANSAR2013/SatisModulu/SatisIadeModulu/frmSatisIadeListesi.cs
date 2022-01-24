using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.SatisModulu.SatisIadeModulu
{
    public partial class frmSatisIadeListesi : DevExpress.XtraEditors.XtraForm
    {
        Classlar.clsSatisIadeListesi IadeListesi = new Classlar.clsSatisIadeListesi();
        SANSAR2013.MusterıModulu.Classlar.clsMusteriKarti MusteriKarti = new MusterıModulu.Classlar.clsMusteriKarti();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();

        public frmSatisIadeListesi()
        {
            InitializeComponent();
        }

        void Listele()
        {
            if (chkEklenmeyenler.Checked)
            {
                if (chkStokgaEkleneler.Checked)
                {
                    Liste.DataSource = IadeListesi.SatisIadeListesiniGetir("SI");
                }
                else
                {
                    Liste.DataSource = IadeListesi.SatisIadeListesiniGetir_Bekleyenler("SI");
                }
            }
            else if (chkStokgaEkleneler.Checked)
            {
                Liste.DataSource = IadeListesi.SatisIadeListesiniGetir_Eklenenler("SI");
            }
         
        }
        private void frmSatisIadeListesi_Load(object sender, EventArgs e)
        {
            chkEklenmeyenler.Checked = true;
            chkStokgaEkleneler.Checked = true;
            Listele();
        }

        private void chkEklenmeyenler_CheckedChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void chkStokgaEkleneler_CheckedChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void frmSatisIadeListesi_Activated(object sender, EventArgs e)
        {
            Listele();
        }

        private void mn_Yenile_Click(object sender, EventArgs e)
        {
            Listele();
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
            if (gridView1.RowCount!=0 && gridView1.RowCount!=-1)
            {
               MusteriBilgileriniCek(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MUSTERI_KODU").ToString()); 
            }            
        }

        private void mn_Guncelle_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount>0)
            {
                Boolean stokeklemedurumu = IadeListesi.IadeStokgaEklimi(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SIPARIS_NO").ToString());
                if (stokeklemedurumu)
                {
                    Ekranlar.SatisIadeGiris(false, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SIPARIS_NO").ToString(), true);
                }
                else
                {
                    Ekranlar.SatisIadeGiris(true, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SIPARIS_NO").ToString(), false);
                }
            }
        }
    }
}