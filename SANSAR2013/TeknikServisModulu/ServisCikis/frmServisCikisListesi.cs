using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.TeknikServisModulu.ServisCikis
{
    public partial class frmServisCikisListesi : DevExpress.XtraEditors.XtraForm
    {
        Classlar.clsServisCikis ServisCikisListesi = new Classlar.clsServisCikis();
        SANSAR2013.MusterıModulu.Classlar.clsMusteriKarti MusteriKarti = new MusterıModulu.Classlar.clsMusteriKarti();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();

        public frmServisCikisListesi()
        {
            InitializeComponent();
        }
        void Listele()
        {
            Liste.DataSource = ServisCikisListesi.Listele();
        }
        void Temizle()
        {
            txtMusteriKodu.Text = "";
            txtFirmaAdi.Text = "";
            txtAdres.Text = "";
            txtIlce.Text = "";
            txtSehir.Text="";
            txtBayiilikTuru.Text = "";
            txtTel.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiNo.Text = "";
            txtSorFirmaAdi.Text = "";
            txtSorIrsaliyeNO.Text = "";
            txtSorServisNO.Text = "";
            dt_ilkTarih.Text = DateTime.Now.ToShortDateString();
            dt_SonTarih.Text = DateTime.Now.ToShortDateString();
            chkİlkTarih.Checked = false;
            chkSonTarih.Checked = false;
            rbIrsaliyeNo.Checked = false;
            rbFirmaAdi.Checked = false;
            rbServisNo.Checked = false;
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

        private void frmServisCikisListesi_Load(object sender, EventArgs e)
        {
            Listele();
            dt_ilkTarih.Text = DateTime.Now.ToShortDateString();
            dt_SonTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void tbnTumunuGoster_Click(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void Liste_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount>0)
            {
              MusteriBilgileriniCek(ServisCikisListesi.ArizaliMusteriKoduCek(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SERVIS_NO").ToString()));  
            }            
        }

        private void mn_Yenile_Click(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void mn_Goruntule_Click(object sender, EventArgs e)
        {
            Ekranlar.ServisOlayFormuAc(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SERVIS_NO").ToString(),true);
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
                                Liste.DataSource = ServisCikisListesi.IkiTarihArasiSorgula(Formatlar.IngilizceTarihKısaFormat(dt_ilkTarih.Text), Formatlar.IngilizceTarihKısaFormat(dt_SonTarih.Text));
                            }
                            else
                            {
                                Liste.DataSource = ServisCikisListesi.IlkTarihSorgula(Formatlar.IngilizceTarihKısaFormat(dt_ilkTarih.Text));
                            }
                        }
                    }
                    else
                    {
                        Liste.DataSource = ServisCikisListesi.IrsaliyeNOSorgula(txtSorIrsaliyeNO.Text.ToUpper());
                    }
                }
                else
                {
                    Liste.DataSource = ServisCikisListesi.ServisNoSorgula(txtSorServisNO.Text);
                }
            }
            else
            {
                Liste.DataSource = ServisCikisListesi.FirmaAdiSorgula(txtSorFirmaAdi.Text);
            }
        }
    }
}