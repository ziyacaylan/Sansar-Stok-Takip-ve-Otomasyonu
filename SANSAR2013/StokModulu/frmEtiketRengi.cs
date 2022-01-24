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
    public partial class frmEtiketRengi : DevExpress.XtraEditors.XtraForm
    {
        public Boolean SecimIcinAcildimi = false;
        private Boolean Edit = false;
        private string SecilenId;
        private Boolean sorgu = false;

        Classlar.clsEtiketRengi EtiketRengi = new Classlar.clsEtiketRengi();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();

        public frmEtiketRengi()
        {
            InitializeComponent();
        }
        void Listele()
        {
            Liste.DataSource = EtiketRengi.Listele();
        }
        private void Temizle()
        {
            txtEtiketRengi.Text = "";
            txtAciklama.Text = "";
            Edit = false;
        }
        private void frmEtiketRengi_Load(object sender, EventArgs e)
        {
            Temizle();
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtEtiketRengi.Text != "")
            {
                if (Edit)
                {

                    EtiketRengi.Guncelle(SecilenId, txtEtiketRengi.Text, txtAciklama.Text);
                    Mesajlar.Bilgi("Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir...");
                    Temizle();
                    Listele();
                }
                else
                {
                    sorgu = EtiketRengi.sorgu_sonucu(txtEtiketRengi.Text);
                    if (sorgu)
                    {
                        Mesajlar.Uyari("Bu renk zaten listede ekli, güncellemek isterseniz ürünü seçiniz...");
                    }
                    else
                    {
                        EtiketRengi.Ekle(txtEtiketRengi.Text, txtAciklama.Text);
                        Mesajlar.Bilgi("Etiket Rengi Kayıdı Yapılmıştır...");
                        Temizle();
                        Listele();
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Bir etiket rengi Girişi Yapınız...");
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
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
                DataRow Satir = EtiketRengi.Ac(SecilenId);
                txtEtiketRengi.Text = Satir["ETIKET_RENGI"].ToString();
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
            if (txtEtiketRengi.Text != "")
            {
                if (Mesajlar.Sor("Etiket Rengini Silmek istediğinizden Eminmisiniz..?"))
                {
                    EtiketRengi.Sil(SecilenId);
                    Listele();
                    Temizle();
                }
            }
            else
            {
                Mesajlar.Uyari("Silmek istediğiniz Rengi Listeden seçiniz...");
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}