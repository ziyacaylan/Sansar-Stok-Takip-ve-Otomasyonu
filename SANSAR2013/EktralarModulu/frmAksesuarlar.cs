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
    public partial class frmAksesuarlar : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        Classlar.clsAksesuarlar Aksesuar = new Classlar.clsAksesuarlar();

        public Boolean SecimIcinAcildimi = false;
        public Boolean Edit = false;

        public string SecidenID="";
        public DataTable Tablo_Aksesuar;

        public frmAksesuarlar()
        {
            InitializeComponent();
        }

        private void frmAksesuarlar_Load(object sender, EventArgs e)
        {
            Listele();
            TabloKur();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Kaydet()
        {
            Aksesuar.Ekle(txtAksesuar.Text.ToUpper(), txtAciklama.Text.ToUpper());
            Mesajlar.Bilgi("Aksesuar Kaydedildi...");
        }
        void Guncelle()
        {
            if (txtAksesuar.Text != "")
            {
                Aksesuar.Guncelle(SecidenID, txtAksesuar.Text.ToUpper(), txtAciklama.Text.ToUpper());
                Mesajlar.Bilgi("Aksesuar Kaydı güncellendi...");
            }
            else
            {
                Mesajlar.Uyari("Güncellenecek Aksesuar bulunamadı, Lütfen önce Listeden seçiniz...");
            }
        }
        void Listele()
        { 
            Liste.DataSource = Aksesuar.Listele();
            Liste3.DataSource = Aksesuar.Listele();        
        }
        void Temizle()
        {
            txtAksesuar.Text = "";
            txtAciklama.Text = "";
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAksesuar.Text != "")
            {
                if (Edit)
                {
                    Guncelle();
                    Listele();
                    Temizle();
                    Edit = false;
                }
                else
                {
                    if (!Aksesuar.AksesuarEklimi(txtAksesuar.Text))
                    {
                        if (Edit)
                        {
                            Guncelle();
                            Listele();
                            Temizle();
                            Edit = false;
                        }
                        else
                        {
                            Kaydet();
                            Listele();
                            Temizle();
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Bu Aksesuarı zaten eklediniz...");
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Aksesuar ismini boş bırakamazsınız...!");
            }
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
            SecidenID = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "ID").ToString();
            txtAksesuar.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "AKSESUAR_ADI").ToString();
            txtAciklama.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "ACIKLAMA").ToString();
            Edit = true;
            }
            catch (Exception)
            {

                SecidenID = "0";
                txtAciklama.Text = "";
                txtAksesuar.Text = "";
            }

        }

        private void btnTumunuGoster_Click(object sender, EventArgs e)
        {
            Listele();
            txtSorgula.Text = "";
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
         Liste.DataSource= Aksesuar.Sorgula(txtSorgula.Text.ToUpper());
        }
        void TabloKur()
        {
            Tablo_Aksesuar = new DataTable();

            Tablo_Aksesuar.Columns.Add(new DataColumn("ID", typeof(Int32)));
            Tablo_Aksesuar.Columns.Add(new DataColumn("AKSESUAR", typeof(string)));
            Tablo_Aksesuar.Columns.Add(new DataColumn("ACIKLAMA", typeof(string)));
        }
        void Aksesuar_SEC()
        {
            string id, aksesuar, aciklama;
            Boolean varyok = false;
            id = "0";
            aksesuar = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "AKSESUAR_ADI".ToString())).ToString();
            aciklama = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ACIKLAMA".ToString())).ToString();

            if (Tablo_Aksesuar.Rows.Count==0)
            {
                Tablo_Aksesuar.Rows.Add(Convert.ToInt32(id), aksesuar, aciklama);
                Liste2.DataSource = Tablo_Aksesuar;
            }
            else
            {
                varyok = false;

                for (int i = 0; i < Tablo_Aksesuar.Rows.Count; i++)
                {
                    string aksesuar_adi = Tablo_Aksesuar.Rows[i]["AKSESUAR"].ToString();
                    
                    if (aksesuar_adi == aksesuar)
                    {
                        varyok = true;
                    }
                }
                if (!varyok)
                {
                    Tablo_Aksesuar.Rows.Add(Convert.ToInt32(id), aksesuar, aciklama);
                }
                Liste2.DataSource = Tablo_Aksesuar;
            }
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Aksesuar_SEC();
        }

        private void btnSecim_Tamam_Click(object sender, EventArgs e)
        {
            if (SecimIcinAcildimi)
            {
                AnaForm.Tablo_Aksesuarlar = Tablo_Aksesuar;
                this.Close();
            }
        }
    }
}