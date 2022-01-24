using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.SiparisModulu
{
    public partial class frmSiparisListesi : DevExpress.XtraEditors.XtraForm
    {
        Classlar.clsSiparisListesi SiparisListe = new Classlar.clsSiparisListesi();
        SANSAR2013.MusterıModulu.Classlar.clsMusteriKarti MusteriKarti = new MusterıModulu.Classlar.clsMusteriKarti();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        public frmSiparisListesi()
        {
            InitializeComponent();
        }
        void Listele()
        {
            Liste.DataSource = SiparisListe.Listele();
        }
        private void frmSiparisListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void tmr_liste_yenile_Tick(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }
        void Temizle()
        {
            txt_musteri_Kodu.Text = "";
            txt_FirmaAdi.Text = "";
            txtAdres.Text = "";
            txtSehir.Text = "";
            txtIlce.Text = "";
            txtTel.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiNo.Text = "";
            txtBayiilikTuru.Text = "";
            txtSiparisVeren.Text = "";

            txtSorFirmaAdi.Text = "";
            txtSorFaturaNo.Text = "";
            txtSorFisNo.Text = "";
            txtSorSiparisNo.Text = "";
        }
        void MusteriBilgileriniCek(string musteri_kodu)
        {
            DataRow drow = MusteriKarti.Musteri_Karti_bilgileriniCek(musteri_kodu);
            if (drow != null)
            {
                txt_musteri_Kodu.Text = drow["MUSTERI_KODU"].ToString();
                txt_FirmaAdi.Text = drow["FIRMA_ADI"].ToString();
                txtAdres.Text = drow["ADRES_1"].ToString();
                txtSehir.Text = drow["IL_1"].ToString();
                txtIlce.Text = drow["ILCE_1"].ToString();
                txtTel.Text = drow["TEL_1"].ToString();
                txtVergiDairesi.Text = drow["VERGI_DAIRESI"].ToString();
                txtVergiNo.Text = drow["VERGI_NO"].ToString();
                txtBayiilikTuru.Text = drow["BAYIILIK_TURU"].ToString();
                txtSiparisVeren.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SIPARIS_VEREN").ToString();
            }
        }
        private void Liste_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount!=0  && gridView1.RowCount!=-1)
            {
               MusteriBilgileriniCek (SiparisListe.MusteriKoduCek(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString())); 
            }           
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (rdFirmaAdi.Checked)
            {
                Liste.DataSource = SiparisListe.FirmaSorgula(txtSorFirmaAdi.Text.ToUpper());
                txtSorFisNo.Text = "";
                txtSorSiparisNo.Text = "";
                txtSorFaturaNo.Text = "";
            }
            else if (rdFisNo.Checked)
            {
                Liste.DataSource = SiparisListe.FisNoSorgula(txtSorFisNo.Text.ToUpper());
                txtSorFirmaAdi.Text = "";
                txtSorFaturaNo.Text = "";
                txtSorSiparisNo.Text = "";
            }
            else if (rdFaturaNo.Checked)
            {
                Liste.DataSource = SiparisListe.FaturaNoSorgula(txtSorFaturaNo.Text.ToUpper());
                txtSorFirmaAdi.Text = "";
                txtSorFisNo.Text = "";
                txtSorSiparisNo.Text="";
            }
            else if (rdSiparisNo.Checked)
            {
                Liste.DataSource = SiparisListe.SiparisNoSorgula(txtSorSiparisNo.Text.ToUpper());
                txtSorFirmaAdi.Text = "";
                txtSorFisNo.Text = "";
                txtSorFaturaNo.Text = "";
            }
        }

        private void mn_Yenile_Click(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void mn_Guncelle_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount>0)
            {
               Ekranlar.YeniSiparisAc(true,false, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(),false); 
            }            
        }

        private void frmSiparisListesi_Activated(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }
    }
}