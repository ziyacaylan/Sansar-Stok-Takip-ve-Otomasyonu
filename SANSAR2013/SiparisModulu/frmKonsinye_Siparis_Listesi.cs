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
    public partial class frmKonsinye_Siparis_Listesi : DevExpress.XtraEditors.XtraForm
    {
        Classlar.clsKonsinyeSiparisListesi KonsinyeSiparisListesi = new Classlar.clsKonsinyeSiparisListesi();
        SANSAR2013.MusterıModulu.Classlar.clsMusteriKarti MusteriKarti = new MusterıModulu.Classlar.clsMusteriKarti();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.Classlar.Mesajlar Mesajlar=new SANSAR2013.Classlar.Mesajlar();

        public frmKonsinye_Siparis_Listesi()
        {
            InitializeComponent();
        }

        void Listele()
        {
            Liste.DataSource = KonsinyeSiparisListesi.KonsinyeSiparisListesiniGetir("KNS.SP");
        }
        void Temizle()
        {
            txt_musteri_Kodu.Text = "";
            txt_FirmaAdi.Text = "";
            txtAdres.Text = "";
            txtBayiilikTuru.Text = "";
            txtIlce.Text = "";
            txtSehir.Text = "";
            txtSiparisVeren.Text = "";
            txtSorFaturaNo.Text = "";
            txtSorFirmaAdi.Text = "";
            txtSorFisNo.Text = "";
            txtSorSiparisNo.Text = "";
            txtTel.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiNo.Text = "";
        }
        private void frmKonsinye_Siparis_Listesi_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void btnTumunuGoster_Click(object sender, EventArgs e)
        {
            Temizle();
            Listele();
            rdFaturaNo.Checked = false;
            rdFirmaAdi.Checked = false;
            rdFisNo.Checked = false;
            rdSiparisNo.Checked=false;
        }

        private void mn_Yenile_Click(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void frmKonsinye_Siparis_Listesi_Activated(object sender, EventArgs e)
        {
            Listele();
            Temizle();
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
            if (gridView1.RowCount>=1)
            {
                MusteriBilgileriniCek(KonsinyeSiparisListesi.SiparisMusteriKoduCek(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SIPARIS_NO").ToString()));
            }
            
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (rdFirmaAdi.Checked)
            {
              Liste.DataSource=  KonsinyeSiparisListesi.FirmaSorgula(txtSorFirmaAdi.Text.ToUpper(), "KNS.SP");
            }
            else if (rdFisNo.Checked)
            {
                Liste.DataSource = KonsinyeSiparisListesi.FisNOSorgula(txtSorFisNo.Text, "KNS.SP");
            }
            else if (rdFaturaNo.Checked)
            {
                Liste.DataSource = KonsinyeSiparisListesi.FaturaNOSorgula(txtSorFaturaNo.Text, "KNS.SP");
            }
            else
            {
                Liste.DataSource = KonsinyeSiparisListesi.SiparisNoSorgula(txtSorSiparisNo.Text, "KNS.SP");
            }
        }

        private void mn_Guncelle_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount >= 1)
            {
                Ekranlar.YeniSiparisAc(true, false, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(),false);
            }
            else
            {
                Mesajlar.Uyari("Tablo Boştur...");
            }
        }
    }
}