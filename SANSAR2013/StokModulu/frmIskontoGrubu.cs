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
    public partial class frmIskontoGrubu : DevExpress.XtraEditors.XtraForm
    {
        public Boolean SecimIcinAcildimi = false;
        private Boolean Edit = false;
        private string SecilenId;
        private Boolean sorgu = false;

        Classlar.clsIskontoGrubu IskontoGrubu = new Classlar.clsIskontoGrubu();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();

        public frmIskontoGrubu()
        {
            InitializeComponent();
        }

        void Listele()
        {
            Liste.DataSource = IskontoGrubu.Listele();
        }
        private void Temizle()
        {
            txtIskontoGrubu.Text = "";
            txtAciklama.Text = "";
            Edit = false;
        }

        private void frmIskontoGrubu_Load(object sender, EventArgs e)
        {
            Temizle();
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtIskontoGrubu.Text != "")
            {
                if (Edit)
                {

                    IskontoGrubu.Guncelle(SecilenId, txtIskontoGrubu.Text, txtAciklama.Text);
                    Mesajlar.Bilgi("Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir...");
                    Temizle();
                    Listele();
                }
                else
                {
                    sorgu = IskontoGrubu.sorgu_sonucu(txtIskontoGrubu.Text);
                    if (sorgu)
                    {
                        Mesajlar.Uyari("Bu grup zaten listede ekli, güncellemek isterseniz ürünü seçiniz...");
                    }
                    else
                    {
                        IskontoGrubu.Ekle(txtIskontoGrubu.Text, txtAciklama.Text);
                        Mesajlar.Bilgi("İskonto Grubu Kayıdı Yapılmıştır...");
                        Temizle();
                        Listele();
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Bir iskonto grubu Girişi Yapınız...");
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

        private void Liste_DoubleClick(object sender, EventArgs e)
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
                DataRow Satir = IskontoGrubu.Ac(SecilenId);
                txtIskontoGrubu.Text = Satir["ISKONTO_GRUBU"].ToString();
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
            if (txtIskontoGrubu.Text != "")
            {
                if (Mesajlar.Sor("İskonto Grubunu Silmek istediğinizden Eminmisiniz..?"))
                {
                    IskontoGrubu.Sil(SecilenId);
                    Listele();
                    Temizle();
                }
            }
            else
            {
                Mesajlar.Uyari("Silmek istediğiniz Grubu Listeden seçiniz...");
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}