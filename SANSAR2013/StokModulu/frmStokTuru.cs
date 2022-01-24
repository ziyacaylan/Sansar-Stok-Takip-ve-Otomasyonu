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
    public partial class frmStokTuru : DevExpress.XtraEditors.XtraForm
    {
        public Boolean SecimIcinAcildimi = false;
        private Boolean Edit = false;
        private string SecilenId;
        private Boolean sorgu = false;

        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        Classlar.clsStokTuru StokTuru = new Classlar.clsStokTuru();

        public frmStokTuru()
        {
            InitializeComponent();
        }

        void Listele()
        {
            Liste.DataSource = StokTuru.Listele();
        }
        private void Temizle()
        {
            txtStokTuru.Text = "";
            txtAciklama.Text = "";
            Edit = false;
        }

        private void frmStokTuru_Load(object sender, EventArgs e)
        {
            Temizle();
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtStokTuru.Text != "")
            {
                if (Edit)
                {

                    StokTuru.Guncelle(SecilenId, txtStokTuru.Text, txtAciklama.Text);
                    Mesajlar.Bilgi("Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir...");
                    Temizle();
                    Listele();
                }
                else
                {
                    sorgu = StokTuru.sorgu_sonucu(txtStokTuru.Text);
                    if (sorgu)
                    {
                        Mesajlar.Uyari("Bu tür zaten listede ekli, güncellemek isterseniz ürünü seçiniz...");
                    }
                    else
                    {
                        StokTuru.Ekle(txtStokTuru.Text, txtAciklama.Text);
                        Mesajlar.Bilgi("Stok Türü Kayıdı Yapılmıştır...");
                        Temizle();
                        Listele();
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Bir tür grubu Girişi Yapınız...");
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtStokTuru.Text != "")
            {
                if (Mesajlar.Sor("Stok Türünü Silmek istediğinizden Eminmisiniz..?"))
                {
                    StokTuru.Sil(SecilenId);
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
                DataRow Satir = StokTuru.Ac(SecilenId);
                txtStokTuru.Text = Satir["STOK_TURU"].ToString();
                txtAciklama.Text = Satir["ACIKLAMA"].ToString();
                Edit = true;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}