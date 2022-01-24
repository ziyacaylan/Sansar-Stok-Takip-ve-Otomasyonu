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
    public partial class frmUrunGrubu : DevExpress.XtraEditors.XtraForm
    {
        public Boolean SecimIcinAcildimi = false;
        private Boolean Edit = false;
        private string SecilenId ;
        private Boolean sorgu = false;

        Classlar.clsUrunGrubu UrunGrubu = new Classlar.clsUrunGrubu();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();

        public frmUrunGrubu()
        {
            InitializeComponent();
        }
        void Listele()
        {
            Liste.DataSource = UrunGrubu.Listele();
        }
        private void Temizle()
        {
            txtUrunGrubu.Text = "";
            txtAciklama.Text = "";
            Edit = false;
        }
        private void frmUrunGrubu_Load(object sender, EventArgs e)
        {
            Temizle();
            Listele();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtUrunGrubu.Text != "")
            {
                if (Edit)
                {

                    UrunGrubu.Guncelle(SecilenId, txtUrunGrubu.Text, txtAciklama.Text);
                    Mesajlar.Bilgi("Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir...");
                    Temizle();
                    Listele();
                }
                else
                {
                    sorgu = UrunGrubu.sorgu_sonucu(txtUrunGrubu.Text);
                    if (sorgu)
                    {
                        Mesajlar.Uyari("Bu grup zaten listede ekli, güncellemek isterseniz ürünü seçiniz...");
                    }
                    else
                    {
                        UrunGrubu.Ekle(txtUrunGrubu.Text, txtAciklama.Text);
                        Mesajlar.Bilgi("Ürün Grubu Kayıdı Yapılmıştır...");
                        Temizle();
                        Listele();
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Bir ürün grubu Girişi Yapınız...");
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
                DataRow Satir = UrunGrubu.Ac(SecilenId);
                txtUrunGrubu.Text = Satir["URUN_GRUBU"].ToString();
                txtAciklama.Text = Satir["ACIKLAMA"].ToString();
                Edit = true;
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

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {            
            if (txtUrunGrubu.Text!="")
            {
                if (Mesajlar.Sor("Ürün Grubunu Silmek istediğinizden Eminmisiniz..?"))
                {
                    UrunGrubu.Sil(SecilenId);
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

    }
}