using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace SANSAR2013.Classlar
{
    class Mesajlar
    {
        public Boolean Sor(string Mesaj)
        {
            DialogResult Sor = new DialogResult();
            Sor = MessageBox.Show(Mesaj, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Sor == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        public void Uyari(string Mesaj)
        {
            MessageBox.Show(Mesaj,"UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Bilgi(string Mesaj)
        {
            MessageBox.Show(Mesaj, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
