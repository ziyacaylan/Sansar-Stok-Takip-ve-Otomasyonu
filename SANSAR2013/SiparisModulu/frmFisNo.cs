using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.SiparisModulu
{
    public partial class frmFisNo : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        public string FisNo="";

        public frmFisNo()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FisNo = txtFisNo.Text;
            this.Dispose();
        }

        private void txtFisNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                Mesajlar.Uyari("Sadece RAKAM Girebilirsiniz...!");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void frmFisNo_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
        }
    }
}