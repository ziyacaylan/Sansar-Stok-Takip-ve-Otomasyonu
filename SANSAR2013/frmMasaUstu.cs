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
    public partial class frmMasaUstu : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Ekranlar Ekranlar = new Classlar.Ekranlar();

        public frmMasaUstu()
        {
            InitializeComponent();
        }

        private void frmMasaUstu_Load(object sender, EventArgs e)
        {
            if (AnaForm.Username!="admin")
            {
                navKonsinyeSiparisler.Caption = "DENEME_BUTONU";
            }
        }

        private void navbarStokKarti_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ekranlar.StokKartiAc(false, "-1");
        }

        private void navbarGenelStok_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ekranlar.StokListesiAc();
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void navBarYeniSiparis_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ekranlar.YeniSiparisAc(false, false, "-1",false);
        }

        private void navBarSiparisListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ekranlar.SiparisListesiAc();
        }

        private void navSatisListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ekranlar.SatisListesiAc();
        }

        private void navSatisIadeleriListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ekranlar.SatisIadeListesiAc();
        }

        private void navSatisIadeGirisi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ekranlar.SatisIadeGiris(false, "-1", false);
        }

        private void navKonsinyeSiparisler_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (AnaForm.Username == "admin")
            {
                Ekranlar.KonsinyeSiparisListesiAc();
            }
        }

        private void navbarMusteriKarti_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ekranlar.MusteriKartiAc(false, "-1");
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ekranlar.MusteriListesiAc();
        }
    }
}