using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.Kullanicilar
{
    public partial class frmKullaniciEkle : DevExpress.XtraEditors.XtraForm
    {
        public frmKullaniciEkle()
        {
            InitializeComponent();
        }
        public Boolean Edit = false;
        public string SecilenID = "";

        private void frmKullaniciEkle_Load(object sender, EventArgs e)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}