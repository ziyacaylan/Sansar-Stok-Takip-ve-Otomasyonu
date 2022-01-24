using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013
{
    public partial class frmGiris : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.GirisIslemi Giris = new Classlar.GirisIslemi();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new Classlar.Mesajlar();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new Classlar.Ekranlar();
        public frmGiris()
        {
            InitializeComponent();
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Gray;
            TransparencyKey = BackColor;

            if (SANSAR2013.Properties.Settings.Default.Animsa == true)
            {
                txtKullaniciAdi.Text = SANSAR2013.Properties.Settings.Default.KullaniciAdi;
                txtParola.Text = SANSAR2013.Properties.Settings.Default.Parola;
                chkBeniAnimsa.Checked = true;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (Giris.KullaniciGirisi(txtKullaniciAdi.Text, txtParola.Text))
            {
                SANSAR2013.Properties.Settings.Default.Animsa = (bool)chkBeniAnimsa.Checked;
                SANSAR2013.Properties.Settings.Default.KullaniciAdi=txtKullaniciAdi.Text;
                SANSAR2013.Properties.Settings.Default.Parola = txtParola.Text;
                SANSAR2013.Properties.Settings.Default.Save();
                this.Close();
            }
            else
            {
                if (AnaForm.ErisimBilgisiHatasi==false)
                {
                  Mesajlar.Uyari("Yanlış Giriş yaptınız, Lütfen Tekrar deneyiniz...");   
                }
                
            
            }
        }

        private void btnServerAyarlari_Click(object sender, EventArgs e)
        {
            Ekranlar.ServerAyarlari();
        }

    }
}