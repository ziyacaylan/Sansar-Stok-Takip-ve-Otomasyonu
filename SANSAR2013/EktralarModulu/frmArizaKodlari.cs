using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.EktralarModulu
{
    public partial class frmArizaKodlari : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        Classlar.clsArizaKodlari ArizaKodlari = new Classlar.clsArizaKodlari();

        public Boolean SecimIcinAcildimi=false;
        private Boolean Edit = false;

        private string SecilenId;

        public frmArizaKodlari()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmArizaKodlari_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Temizle()
        {
            txtAriza_Kodu.Text = "";
            txtAciklama.Text = "";
        }
        void Listele()
        {
            Liste.DataSource = ArizaKodlari.Listele();
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit)
            {
                Sec();
                ArizaKodlari.Guncelle(SecilenId, txtAriza_Kodu.Text.ToUpper(), txtAciklama.Text.ToUpper());
                Mesajlar.Bilgi("Güncelleme Yapıldı...");
                Temizle();
                Listele();
                Edit = false;
            }
            else
            {
                ArizaKodlari.Ekle(txtAriza_Kodu.Text.ToUpper(), txtAciklama.Text.ToUpper());
                Mesajlar.Bilgi("Kayıt Eklendi...");
                Temizle();
                Listele();
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Edit = false;
            Temizle();
            Listele();
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
                DataRow Satir = ArizaKodlari.Ac(SecilenId);

                txtAriza_Kodu.Text = Satir["ARIZA_KODU"].ToString();
                txtAciklama.Text = Satir["ACIKLAMA"].ToString();
                Edit = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtAriza_Kodu.Text != "")
            {
                if (Mesajlar.Sor("Etiket Rengini Silmek istediğinizden Eminmisiniz..?"))
                {
                    ArizaKodlari.Sil(SecilenId);
                    Listele();
                    Temizle();
                }
            }
            else
            {
                Mesajlar.Uyari("Silmek istediğiniz Rengi Listeden seçiniz...");
            }
        }


    }
}