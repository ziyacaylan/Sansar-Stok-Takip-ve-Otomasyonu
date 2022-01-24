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
    public partial class frmServerAyarlari : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Mesajlar Mesajlar = new Classlar.Mesajlar();
        public frmServerAyarlari()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SANSAR2013.Properties.Settings.Default.ServerIdAdresi = txtServer.Text;
            SANSAR2013.Properties.Settings.Default.VeritabaniAdi = txtDatabase.Text;
            SANSAR2013.Properties.Settings.Default.VeritabaniKullaniciAdi= txtUsername.Text;
            SANSAR2013.Properties.Settings.Default.VeritabaniSifresi= txtPassword.Text;
            SANSAR2013.Properties.Settings.Default.Save();
            Mesajlar.Bilgi("Ayarlar Kaydedildi...");
        }

        private void frmServerAyarlari_Load(object sender, EventArgs e)
        {
           txtServer.Text= SANSAR2013.Properties.Settings.Default.ServerIdAdresi  ;
            txtDatabase.Text=SANSAR2013.Properties.Settings.Default.VeritabaniAdi ;
            txtUsername.Text=SANSAR2013.Properties.Settings.Default.VeritabaniKullaniciAdi ;
           txtPassword.Text= SANSAR2013.Properties.Settings.Default.VeritabaniSifresi ;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}