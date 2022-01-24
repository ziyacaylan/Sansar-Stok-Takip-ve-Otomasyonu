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
    public partial class frmKargolar : DevExpress.XtraEditors.XtraForm
    {
        public Boolean SecimIcinAcildimi = false;
        private Boolean Edit = false;
        private string SecilenId;
        private Boolean sorgu = false;

        Classlar.clsKargolar Kargolar = new Classlar.clsKargolar();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();

        public frmKargolar()
        {
            InitializeComponent();
        }

        private void frmKargolar_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Temizle()
        {
            txtTeslim.Text = "";
            txtTelefon.Text = "";
            txtAciklama.Text = "";
        }
        void Listele()
        {
            Liste.DataSource = Kargolar.Listele();
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
                Kargolar.Guncelle(SecilenId,txtTeslim.Text.ToUpper(), txtTelefon.Text.ToUpper(), txtAciklama.Text.ToUpper());
                Mesajlar.Bilgi("Güncelleme Yapıldı...");
                Temizle();
                Listele();
                Edit = false;
            }
            else
            {
                Kargolar.Ekle(txtTeslim.Text.ToUpper(), txtTelefon.Text.ToUpper(), txtAciklama.Text.ToUpper());
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

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                DataRow Satir = Kargolar.Ac(SecilenId);

                txtTeslim.Text= Satir["TESLIM"].ToString();
                txtTelefon.Text = Satir["TEL"].ToString();
                txtAciklama.Text = Satir["ACIKLAMA"].ToString();
                Edit = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtTeslim.Text != "")
            {
                if (Mesajlar.Sor("Etiket Rengini Silmek istediğinizden Eminmisiniz..?"))
                {
                    Kargolar.Sil(SecilenId);
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