using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace SANSAR2013.Classlar
{
    class ExportIslemleri
    {
        SaveFileDialog Save = new SaveFileDialog();
        Mesajlar Mesajlar = new Mesajlar();

        public void Excel2003(string RaporAdi, DevExpress.XtraGrid.GridControl Liste)
        {
            Save.Filter = "Excel 2003|*.xls";
            Save.FileName = RaporAdi + "_" + DateTime.Now.ToShortDateString();
            if (Save.ShowDialog()==DialogResult.OK)
            {
                Liste.ExportToXls(Save.FileName);
                if (Mesajlar.Sor("Dosyayı Açmak İster misiniz_?"))
                {
                    Process.Start(Save.FileName);
                }
            }
        }
        public void Excel2007(string RaporAdi, DevExpress.XtraGrid.GridControl Liste)
        {
            Save.Filter = "Excel 2007|*.xlsx";
            Save.FileName = RaporAdi + "_" + DateTime.Now.ToShortDateString();
            if (Save.ShowDialog() == DialogResult.OK)
            {
                Liste.ExportToXlsx(Save.FileName);
                if (Mesajlar.Sor("Dosyayı Açmak İster misiniz_?"))
                {
                    Process.Start(Save.FileName);
                }
            }
        }
        public void PDF(string RaporAdi, DevExpress.XtraGrid.GridControl Liste)
        {
            Save.Filter = "Acrobat Reader|*.pdf";
            Save.FileName = RaporAdi + "_" + DateTime.Now.ToShortDateString();
            if (Save.ShowDialog() == DialogResult.OK)
            {
                Liste.ExportToPdf(Save.FileName);
                if (Mesajlar.Sor("Dosyayı Açmak İster misiniz_?"))
                {
                    Process.Start(Save.FileName);
                }
            }
        }
        public void HTML(string RaporAdi, DevExpress.XtraGrid.GridControl Liste)
        {
            Save.Filter = "Html|*.html";
            Save.FileName = RaporAdi + "_" + DateTime.Now.ToShortDateString();
            if (Save.ShowDialog() == DialogResult.OK)
            {
                Liste.ExportToPdf(Save.FileName);
                if (Mesajlar.Sor("Dosyayı Açmak İster misiniz_?"))
                {
                    Process.Start(Save.FileName);
                }
            }
        }
    }
}
