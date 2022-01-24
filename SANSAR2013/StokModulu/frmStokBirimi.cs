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
    public partial class frmStokBirimi : DevExpress.XtraEditors.XtraForm
    {
        public Boolean SecimIcinAcildimi = false;
        private Boolean Edit = false;
        private string SecilenId;
        private Boolean sorgu = false;

        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        Classlar.clsStokBirimi StokBirimi = new Classlar.clsStokBirimi();

        public frmStokBirimi()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtStokBirimi.Text != "")
            {
                if (Mesajlar.Sor("Stok Birimini Silmek istediğinizden Eminmisiniz..?"))
                {
                    StokBirimi.Sil(SecilenId);
                    Listele();
                    Temizle();
                }
            }
            else
            {
                Mesajlar.Uyari("Silmek istediğiniz ürünü Listeden seçiniz...");
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Edit = false;
            Temizle();
            Listele();
        }
        void Listele()
        {
            Liste.DataSource = StokBirimi.Listele();
        }
        private void Temizle()
        {
            txtStokBirimi.Text = "";
            txtAciklama.Text = "";
            Edit = false;
        }

        private void frmStokBirimi_Load(object sender, EventArgs e)
        {
            Temizle();
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtStokBirimi.Text != "")
            {
                if (Edit)
                {

                    StokBirimi.Guncelle(SecilenId, txtStokBirimi.Text, txtAciklama.Text);
                    Mesajlar.Bilgi("Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir...");
                    Temizle();
                    Listele();
                }
                else
                {
                    sorgu = StokBirimi.sorgu_sonucu(txtStokBirimi.Text);
                    if (sorgu)
                    {
                        Mesajlar.Uyari("Bu Birim zaten listede ekli, güncellemek isterseniz ürünü seçiniz...");
                    }
                    else
                    {
                        StokBirimi.Ekle(txtStokBirimi.Text, txtAciklama.Text);
                        Mesajlar.Bilgi("Stok Birimi Kayıdı Yapılmıştır...");
                        Temizle();
                        Listele();
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Bir Stok Birimi Girişi Yapınız...");
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
                DataRow Satir = StokBirimi.Ac(SecilenId);
                txtStokBirimi.Text = Satir["STOK_BIRIMI"].ToString();
                txtAciklama.Text = Satir["ACIKLAMA"].ToString();
                Edit = true;
            }
        }
    }
}