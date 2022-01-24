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
    public partial class frmBayiilik_Turu : DevExpress.XtraEditors.XtraForm
    {
        public Boolean SecimIcinAcildimi = false;
        private Boolean Edit = false;
        private string SecilenId;
        private Boolean sorgu = false;

        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        Classlar.clsBayiilikTuru BayiiTurleri = new Classlar.clsBayiilikTuru();
        public frmBayiilik_Turu()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void Listele()
        {
            Liste.DataSource = BayiiTurleri.Listele();
        }
        private void Temizle()
        {
            txtBayiilikTuru.Text = "";
            txtAciklama.Text = "";
            Edit = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtBayiilikTuru.Text != "")
            {
                if (Edit)
                {
                    BayiiTurleri.Guncelle(SecilenId, txtBayiilikTuru.Text, txtAciklama.Text);
                    Mesajlar.Bilgi("Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir...");
                    Temizle();
                    Listele();
                }
                else
                {
                    sorgu = BayiiTurleri.sorgu_sonucu(txtBayiilikTuru.Text);
                    if (sorgu)
                    {
                        Mesajlar.Uyari("Bu Tür zaten ekli, güncellemek isterseniz ürünü seçiniz...");
                    }
                    else
                    {
                        BayiiTurleri.Ekle(txtBayiilikTuru.Text, txtAciklama.Text);
                        Mesajlar.Bilgi("Bayiilik Türü Kaydı Yapılmıştır...");
                        Temizle();
                        Listele();
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Bayiilik Türü Girişi Yapınız...");
            }
        }

        private void frmBayiilik_Turu_Load(object sender, EventArgs e)
        {
            Temizle();
            Listele();
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
        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (SecimIcinAcildimi == true)
            {
                Sec();
                AnaForm.AraDegiskenString = SecilenId;
                this.Dispose();
            }
            else
            {
                Sec();
                DataRow Satir = BayiiTurleri.Ac(SecilenId);
                txtBayiilikTuru.Text = Satir["BAYIILIK_TURU"].ToString();
                txtAciklama.Text = Satir["ACIKLAMA"].ToString();
                Edit = true;
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Edit = false;
            Temizle();
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtBayiilikTuru.Text != "")
            {
                if (Mesajlar.Sor("Bayiilik Türünü Silmek istediğinizden Eminmisiniz..?"))
                {
                    BayiiTurleri.Sil(SecilenId);
                    Listele();
                    Temizle();
                }
            }
            else
            {
                Mesajlar.Uyari("Silmek istediğiniz Bayiilik Türünü Listeden seçiniz...");
            }
        }
    }
}