using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;

namespace SANSAR2013.StokModulu
{
    public partial class frmParaBirimleri : DevExpress.XtraEditors.XtraForm
    {
        public Boolean SecimIcinAcildimi = false;
        private Boolean Edit = false;
        private string SecilenId;
        private Boolean sorgu = false;

        public static string Parametre1, Parametre2;

        Classlar.clsParaBirimi ParaBirimi = new Classlar.clsParaBirimi();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();

        public frmParaBirimleri()
        {
            InitializeComponent();
        }

        void Listele()
        {
            Liste.DataSource = ParaBirimi.Listele();
        }
        private void Temizle()
        {
            btnParaBirimi.Text = "";
            txtKod.Text = "";
            txtAciklama.Text = "";
            Edit = false;
            TL_Kontrol();
        }
        void TL_Kontrol()
        {
            string para_birimi = "TÜRK LİRASI";
            string TurkLirasi = "TL";
            if (!ParaBirimi.TL_Sorgula(TurkLirasi))
            {
                ParaBirimi.Ekle(para_birimi, TurkLirasi, "Default Para Birimi");
            }
        }
        private void frmParaBirimleri_Load(object sender, EventArgs e)
        {
            Temizle();
            Listele();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnParaBirimi.Text != "")
            {
                if (Edit)
                {

                    ParaBirimi.Guncelle(SecilenId, btnParaBirimi.Text, txtKod.Text, txtAciklama.Text);
                    Mesajlar.Bilgi("Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir...");
                    Temizle();
                    Listele();
                }
                else
                {
                    sorgu = ParaBirimi.sorgu_sonucu(btnParaBirimi.Text);
                    if (sorgu)
                    {
                        Mesajlar.Uyari("Bu birim zaten listede ekli, güncellemek isterseniz ürünü seçiniz...");
                    }
                    else
                    {
                        ParaBirimi.Ekle(btnParaBirimi.Text, txtKod.Text, txtAciklama.Text);
                        Mesajlar.Bilgi("Para Birimi Kayıdı Yapılmıştır...");
                        Temizle();
                        Listele();
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Bir Para Birimi grubu Girişi Yapınız...");
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
                DataRow Satir = ParaBirimi.Ac(SecilenId);
                btnParaBirimi.Text = Satir["PARA_BIRIMI"].ToString();
                txtKod.Text = Satir["KOD"].ToString();
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
            if (btnParaBirimi.Text != "TL")
            {
                if (btnParaBirimi.Text != "")
                {
                    if (Mesajlar.Sor("Para Birimini Silmek istediğinizden Eminmisiniz..?"))
                    {
                        ParaBirimi.Sil(SecilenId);
                        Listele();
                        Temizle();
                    }
                }
                else
                {
                    Mesajlar.Uyari("Silmek istediğiniz Grubu Listeden seçiniz...");
                }
            }
            else
            {
                Mesajlar.Uyari("Bu para birimi default birim olduğundan silemezsiniz...");
            }

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnParaBirimi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataTable dt= Ekranlar.DovizKurlarıParaTablosu(true);
            if (dt!=null)
            {
                DataRow drow = dt.Rows[0];
                btnParaBirimi.Text = drow["ADI"].ToString();
                txtKod.Text = drow["KOD"].ToString();
            }

        }
    }
}