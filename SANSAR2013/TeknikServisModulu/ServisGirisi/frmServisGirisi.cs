using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.TeknikServisModulu.ServisGirisi
{
    public partial class frmServisGirisi : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        Classlar.clsServisGirisi ServisGiris = new Classlar.clsServisGirisi();
        SANSAR2013.EktralarModulu.Classlar.clsKargolar Kargolar = new EktralarModulu.Classlar.clsKargolar();
        SANSAR2013.Classlar.clsNumara Numaralar = new SANSAR2013.Classlar.clsNumara();
        SANSAR2013.StokModulu.Classlar.StokKarti StokKarti = new StokModulu.Classlar.StokKarti();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        Dizayn.Classlar.clsSrvGirisYazdir Yazdir = new Dizayn.Classlar.clsSrvGirisYazdir();
        public Boolean Edit = false;
        private Boolean degisiklik_yapıldımı = false;
        public string servis_NO = "";
        public string MusteriKodu;
        public string Stok_odu;
        private string UrunId;
        private string tarih_kontrol = "";
        private DataTable Tablo_Arizalilar;

        public frmServisGirisi()
        {
            InitializeComponent();
        }
        void Musteri_BilgileriniCEK(string musteri_ID)
        {
            DataRow drow = ServisGiris.MusteriBilgileri(musteri_ID);
            try
            {
                txtMusteriKodu.Text = drow["MUSTERI_KODU"].ToString();
                txtFirmaAdi.Text = drow["FIRMA_ADI"].ToString();
                txtAdres.Text = drow["ADRES_1"].ToString();
                txtIlce.Text = drow["ILCE_1"].ToString();
                txtSehir.Text = drow["IL_1"].ToString();
                txtTel.Text = drow["TEL_1"].ToString();
                txtBayiilikTuru.Text = drow["BAYIILIK_TURU"].ToString();
                txtVergiDairesi.Text = drow["VERGI_DAIRESI"].ToString();
                txtVergiNo.Text = drow["VERGI_NO"].ToString();
            }
            catch (Exception)
            {
                txtMusteriKodu.Text = "";
                txtFirmaAdi.Text = "";
                txtAdres.Text = "";
                txtIlce.Text = "";
                txtSehir.Text = "";
                txtTel.Text = "";
                txtBayiilikTuru.Text = "";
                txtVergiDairesi.Text = "";
                txtVergiNo.Text = "";
            }
        }
        private void btnSec_Click(object sender, EventArgs e)
        {
            string KOD = Ekranlar.MusteriKodListesiSorgulama(true, false);
            Musteri_BilgileriniCEK(KOD);
        }
        void KargolarYukle()
        {
            for (int i = 1; i <= Kargolar.KargoListeToplamı(); i++)
            {
                cmbTeslimat.Properties.Items.Add("" + Kargolar.KargoIsminiAl(i.ToString()).ToString() + "");
            }
        }
        void ServisGirisiniCEK()
        {
            DataRow drow = ServisGiris.MusteriBilgileriCEK(MusteriKodu);
            try
            {
                txtMusteriKodu.Text = drow["MUSTERI_KODU"].ToString();
                txtFirmaAdi.Text = drow["FIRMA_ADI"].ToString();
                txtAdres.Text = drow["ADRES_1"].ToString();
                txtIlce.Text = drow["ILCE_1"].ToString();
                txtSehir.Text = drow["IL_1"].ToString();
                txtTel.Text = drow["TEL_1"].ToString();
                txtBayiilikTuru.Text = drow["BAYIILIK_TURU"].ToString();
                txtVergiDairesi.Text = drow["VERGI_DAIRESI"].ToString();
                txtVergiNo.Text = drow["VERGI_NO"].ToString();
            }
            catch (Exception)
            {
                txtMusteriKodu.Text = "";
                txtFirmaAdi.Text = "";
                txtAdres.Text = "";
                txtIlce.Text = "";
                txtSehir.Text = "";
                txtTel.Text = "";
                txtBayiilikTuru.Text = "";
                txtVergiDairesi.Text = "";
                txtVergiNo.Text = "";
            }
            txtServisNo.Text = servis_NO;            
            DataRow droww=ServisGiris.ServisGirisCEK(servis_NO);
            try
            {
                txt_tarih.Text=Formatlar.EskiyeCevirKısa(droww["SERVIS_GIR_TARIH"].ToString());
                tarih_kontrol = Formatlar.EskiyeCevirKısa(droww["SERVIS_GIR_TARIH"].ToString());
                txtIrsaliyeNO.Text=droww["GIRIS_IRSALIYE_NO"].ToString();
                txtAciklama.Text = droww["ACIKLAMA"].ToString();
                cmbTeslimat.Text = droww["TESLIM_SEKLI"].ToString();
            }
            catch (Exception)
            {

                txt_tarih.Text = DateTime.Now.ToShortDateString();
            }
            Liste.DataSource=ServisGiris.ArizaliIcerikCEK(servis_NO);
        }
        private void frmServisGirisi_Load(object sender, EventArgs e)
        {
            if (Edit)
            {
                KargolarYukle();
                TabloKur_Arizalilar();
                ServisGirisiniCEK();
                TabloKalemler();
                btnSec.Enabled = false;
            }
            else
            {
                KargolarYukle();
                TabloKur_Arizalilar();
                txt_tarih.Text = DateTime.Now.ToShortDateString();
                txtServisNo.Text = Numaralar.GetServisNumarasi();
            }
        }

        private void btnIrsaliyeNoGir_Click(object sender, EventArgs e)
        {
            txtIrsaliyeNO.Text = Ekranlar.Irsaliye_No_Ac();
            degisiklik_yapıldımı = true;
        }
        void UrunSEC(string UrunId)
        {
            if (UrunId != "")
            {
                DataRow Satir = StokKarti.Stok_Karti_bilgilerini_cek(UrunId);
                txtStokKodu.Text = Satir["STOK_KODU"].ToString();
                txtModelNo.Text = Satir["MODEL_NO"].ToString();
                txtStokBirim.Text = Satir["STOK_BIRIMI"].ToString();
            }
        }
        private void btnStokSEC_Click(object sender, EventArgs e)
        {
            UrunSEC(Ekranlar.StokKodListesiSorgulama(true));
        }

        private void btnStokSEC_1_Click(object sender, EventArgs e)
        {
            UrunSEC(Ekranlar.StokKodListesiSorgulama(true));
        }

        private void btnAksesuarYOK_Click(object sender, EventArgs e)
        {
            txtAksesuarlar.Text = "YOK";
        }

        private void btnAksesuarlar_Click(object sender, EventArgs e)
        {
            Ekranlar.AksesuarlarAC(true);
            string satir = "";

            if (AnaForm.Tablo_Aksesuarlar.Rows.Count > 0)
            {
                for (int i = 0; i < AnaForm.Tablo_Aksesuarlar.Rows.Count; i++)
                {
                    if (satir == "")
                    {
                        satir = AnaForm.Tablo_Aksesuarlar.Rows[i]["AKSESUAR"].ToString();
                    }
                    else
                    {
                        satir = satir + ", " + AnaForm.Tablo_Aksesuarlar.Rows[i]["AKSESUAR"].ToString();
                    }
                }
            }
            txtAksesuarlar.Text = satir;
        }
        void TabloKur_Arizalilar()
        {
            Tablo_Arizalilar = new DataTable();

            Tablo_Arizalilar.Columns.Add(new DataColumn("ID", typeof(Int32)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("STOK_KODU", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("MODEL_NO", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("MIKTAR", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("STOK_BIRIMI", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("URUN_SERI_NO", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("GARANTI_DURUMU", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("AKSESUARLAR", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("SIKAYET", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("ACIKLAMA", typeof(string)));
        }
        void Temizle()
        {
            txtStokKodu.Text = "";
            txtModelNo.Text = "";
            txtMiktar.Text = "";
            txtStokBirim.Text = "";
            txtAksesuarlar.Text = "";
            txtArizaAciklama.Text = "";
            txtSerniNo.Text = "";

            chkGarantiVAR.Checked = false;
            chkGarantiYOK.Checked = false;
        }
        Boolean UrunEklimi(string stok_kodu)
        {
            Boolean ekli = false;

            for (int i = 0; i < Tablo_Arizalilar.Rows.Count; i++)
            {
                string arizali_urun_kodu = Tablo_Arizalilar.Rows[i]["STOK_KODU"].ToString();

                if (txtStokKodu.Text==arizali_urun_kodu)
                {
                    ekli = true;
                }
            }
            return ekli;
        }

        void ArizaliEkle()
        {
            int index_no = Tablo_Arizalilar.Rows.Count + 1;
            string garanti = "YOK";
           
            if (chkGarantiVAR.Checked)
            {
                garanti = "VAR";
            }
            else if (chkGarantiYOK.Checked)
            {
                garanti = "YOK";
            }
            Tablo_Arizalilar.Rows.Add((index_no), txtStokKodu.Text, txtModelNo.Text.ToUpper(), txtMiktar.Text, txtStokBirim.Text, txtSerniNo.Text, garanti, txtAksesuarlar.Text.ToUpper(), txtSikayet.Text.ToUpper(), txtArizaAciklama.Text.ToUpper());
            Temizle();

            Liste.DataSource = Tablo_Arizalilar;
            Mesajlar.Bilgi("Ürün Eklendi...");
        }
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (txtModelNo.Text != "")
            {
                if (txtMiktar.Text != "")
                {
                    if (chkGarantiVAR.Checked || chkGarantiYOK.Checked)
                    {
                        if (!UrunEklimi(txtStokKodu.Text))
                        {
                            
                            ArizaliEkle();
                        }
                        else
                        {
                            Mesajlar.Uyari("Bu ürünü zaten listeye eklediniz...");
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Garanti Durumunu Belirtmediniz...");
                    }
                }
                else
                {
                    Mesajlar.Uyari("Arılzalı miktarını belirtmediniz...");
                }
            }
            else
            {
                Mesajlar.Uyari("Model Numarasını Belirtmediniz...");
            }
        }

        private void chkGarantiVAR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGarantiVAR.Checked)
            {
                chkGarantiYOK.Checked = false;
            }
        }

        private void chkGarantiYOK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGarantiYOK.Checked)
            {
                chkGarantiVAR.Checked = false;
            }
        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtModelNo_EditValueChanged(object sender, EventArgs e)
        {
            if (txtStokKodu.Text=="")
            {
                txtStokBirim.Text = "ADET";
            }
        }

        private void Liste_MouseClick(object sender, MouseEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                txtStokKodu.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STOK_KODU".ToString())).ToString();
                txtModelNo.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MODEL_NO".ToString())).ToString();
                txtMiktar.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MIKTAR".ToString())).ToString();
                txtSerniNo.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "URUN_SERI_NO".ToString())).ToString();
                txtStokBirim.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STOK_BIRIMI".ToString())).ToString();
                txtSikayet.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SIKAYET".ToString())).ToString();
                txtArizaAciklama.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ACIKLAMA".ToString())).ToString();
                txtAksesuarlar.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "AKSESUARLAR".ToString())).ToString();

                string garanti = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GARANTI_DURUMU".ToString())).ToString();

                if (garanti == "VAR")
                {
                    chkGarantiVAR.Checked = true;
                }
                else if (garanti == "YOK")
                {
                    chkGarantiYOK.Checked = true;
                }
            }

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "STOK_KODU", txtStokKodu.Text);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MODEL_NO", txtModelNo.Text.ToUpper());
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MIKTAR",txtMiktar.Text);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "STOK_BIRIMI", txtStokBirim.Text);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "URUN_SERI_NO", txtSerniNo.Text);
            string garanti = "";
            if (chkGarantiVAR.Checked)
            {
                garanti = "VAR";
            }
            else if (chkGarantiYOK.Checked)
            {
                garanti = "YOK";
            }
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "GARANTI_DURUMU", garanti);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "AKSESUARLAR", txtAksesuarlar.Text.ToUpper());
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SIKAYET", txtSikayet.Text.ToUpper());
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ACIKLAMA", txtArizaAciklama.Text.ToUpper());
            Temizle();
            Mesajlar.Bilgi("Güncelleme yapıldı...");
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (!degisiklik_yapıldımı)
            {
                this.Close();
            }
            else
            {
                if (Mesajlar.Sor("Değişiklikler kaydedilmedi, çıkarsanız kaydedikmeyecek; çıkmaz istiyormusunuz_?"))
                {
                    this.Close();
                }
            }
        }

        private void btnYeniSiparis_Click(object sender, EventArgs e)
        {
            Ekranlar.ServisGirisiAc(false, "-1","-1");
        }
        DataTable Tablo_Guncelle()
        {
            DataTable Tablo = new DataTable();

            Tablo.Columns.Add(new DataColumn("ID", typeof(Int32)));
            Tablo.Columns.Add(new DataColumn("STOK_KODU", typeof(string)));
            Tablo.Columns.Add(new DataColumn("MODEL_NO", typeof(string)));
            Tablo.Columns.Add(new DataColumn("MIKTAR", typeof(string)));
            Tablo.Columns.Add(new DataColumn("STOK_BIRIMI", typeof(string)));
            Tablo.Columns.Add(new DataColumn("URUN_SERI_NO", typeof(string)));
            Tablo.Columns.Add(new DataColumn("GARANTI_DURUMU", typeof(string)));
            Tablo.Columns.Add(new DataColumn("AKSESUARLAR", typeof(string)));
            Tablo.Columns.Add(new DataColumn("SIKAYET", typeof(string)));
            Tablo.Columns.Add(new DataColumn("ACIKLAMA", typeof(string)));

            string stok_kodu, Model_no, Miktar, Stok_birim, urun_seri_no, garanti_durumu, aksesuarlar, sikayet, aciklama;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                stok_kodu = gridView1.GetRowCellValue(i, "STOK_KODU").ToString();
                Model_no = gridView1.GetRowCellValue(i, "MODEL_NO").ToString();
                Miktar = gridView1.GetRowCellValue(i, "MIKTAR").ToString();
                Stok_birim = gridView1.GetRowCellValue(i, "STOK_BIRIMI").ToString();
                urun_seri_no = gridView1.GetRowCellValue(i, "URUN_SERI_NO").ToString();
                garanti_durumu = gridView1.GetRowCellValue(i, "GARANTI_DURUMU").ToString();
                aksesuarlar = gridView1.GetRowCellValue(i, "AKSESUARLAR").ToString();
                sikayet = gridView1.GetRowCellValue(i, "SIKAYET").ToString();
                aciklama = gridView1.GetRowCellValue(i, "ACIKLAMA").ToString();

                Tablo.Rows.Add(i, stok_kodu, Model_no, Miktar, Stok_birim, urun_seri_no, garanti_durumu, aksesuarlar, sikayet, aciklama);
            }
            return Tablo;
        }
        DataTable TabloKalemler()
        {
          //  DataTable Tablo_Arizalilar = new DataTable();

            //Tablo_Arizalilar.Columns.Add(new DataColumn("ID", typeof(Int32)));
            //Tablo_Arizalilar.Columns.Add(new DataColumn("STOK_KODU", typeof(string)));
            //Tablo_Arizalilar.Columns.Add(new DataColumn("MODEL_NO", typeof(string)));
            //Tablo_Arizalilar.Columns.Add(new DataColumn("MIKTAR", typeof(string)));
            //Tablo_Arizalilar.Columns.Add(new DataColumn("STOK_BIRIMI", typeof(string)));
            //Tablo_Arizalilar.Columns.Add(new DataColumn("URUN_SERI_NO", typeof(string)));
            //Tablo_Arizalilar.Columns.Add(new DataColumn("GARANTI_DURUMU", typeof(string)));
            //Tablo_Arizalilar.Columns.Add(new DataColumn("AKSESUARLAR", typeof(string)));
            //Tablo_Arizalilar.Columns.Add(new DataColumn("SIKAYET", typeof(string)));
            //Tablo_Arizalilar.Columns.Add(new DataColumn("ACIKLAMA", typeof(string)));

            string stok_kodu, Model_no, Miktar, Stok_birim, urun_seri_no, garanti_durumu, aksesuarlar, sikayet, aciklama;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                stok_kodu = gridView1.GetRowCellValue(i, "STOK_KODU").ToString();
                Model_no = gridView1.GetRowCellValue(i, "MODEL_NO").ToString();
                Miktar = gridView1.GetRowCellValue(i, "MIKTAR").ToString();
                Stok_birim = gridView1.GetRowCellValue(i, "STOK_BIRIMI").ToString();
                urun_seri_no = gridView1.GetRowCellValue(i, "URUN_SERI_NO").ToString();
                garanti_durumu = gridView1.GetRowCellValue(i, "GARANTI_DURUMU").ToString();
                aksesuarlar = gridView1.GetRowCellValue(i, "AKSESUARLAR").ToString();
                sikayet = gridView1.GetRowCellValue(i, "SIKAYET").ToString();
                aciklama = gridView1.GetRowCellValue(i, "ACIKLAMA").ToString();

                Tablo_Arizalilar.Rows.Add(i,stok_kodu,Model_no,Miktar,Stok_birim,urun_seri_no,garanti_durumu,aksesuarlar,sikayet ,aciklama);
            }
            return Tablo_Arizalilar;
        }
        void Kaydet()
        { 
            string Tipi="SRV";

            ServisGiris.ServisGirisEKLE(Tipi, txtServisNo.Text, txt_tarih.Text, txtIrsaliyeNO.Text, txtMusteriKodu.Text, txtFirmaAdi.Text, AnaForm.Username, cmbTeslimat.Text, txtAciklama.Text.ToUpper(), Tablo_Guncelle());
            Mesajlar.Bilgi("Kayıt Eklendi...");
            Edit = true;
        }
        void Guncelle()
        {
            string Tipi = "SRV";
            ServisGiris.ServisGirisGUNCELLE(Tipi, txtServisNo.Text, txt_tarih.Text, txtIrsaliyeNO.Text, txtMusteriKodu.Text, txtFirmaAdi.Text, AnaForm.Username, cmbTeslimat.Text, txtAciklama.Text.ToUpper(), Tablo_Guncelle());
            Mesajlar.Bilgi("Kayıt Güncellendi...");
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit)
            {
                if (txtMusteriKodu.Text != "")
                {
                    if (gridView1.RowCount >= 1)
                    {
                        if (txtIrsaliyeNO.Text != "")
                        {
                            Guncelle();
                            degisiklik_yapıldımı = false;
                        }
                        else
                        {
                            if (Mesajlar.Sor("İrsaliye Numarasını belirtmediniz,Kayıda devam etmek istiyor musunuz_?"))
                            {
                                Guncelle();
                                degisiklik_yapıldımı = false;
                            }
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Arızalı ürünler girişi yapılmadı, kayıt yapamazsınız...");
                    }
                }
                else
                {
                    Mesajlar.Uyari("Müşteri Bilgileri girilmemiş kayıt yapılamaz...");
                }
            }
            else
            {
                if (txtMusteriKodu.Text != "")
                {
                    if (gridView1.RowCount >= 1)
                    {
                        if (txtIrsaliyeNO.Text != "")
                        {
                            txtServisNo.Text = Numaralar.GetServisNumarasi();
                            Kaydet();
                            degisiklik_yapıldımı = false;
                        }
                        else
                        {
                            if (Mesajlar.Sor("İrsaliye Numarasını belirtmediniz,Kayıda devam etmek istiyor musunuz_?"))
                            {
                                txtServisNo.Text = Numaralar.GetServisNumarasi();
                                Kaydet();
                                degisiklik_yapıldımı = false;
                            }
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Arızalı ürünler girişi yapılmadı, kayıt yapamazsınız...");
                    }
                }
                else
                {
                    Mesajlar.Uyari("Müşteri Bilgileri girilmemiş kayıt yapılamaz...");
                }
            }
        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            degisiklik_yapıldımı = true;
        }

        private void txtAciklama_Click(object sender, EventArgs e)
        {
            degisiklik_yapıldımı = true;
        }

        private void cmbTeslimat_Click(object sender, EventArgs e)
        {
            degisiklik_yapıldımı = true;
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            Yazdir.ServisGirisYazdir(txtServisNo.Text);
        }
        void ServisGirisIPTAL()
        {
            if (Mesajlar.Sor("Servis Girişini İptal Etmek İstiyor musunuz.._?"))
            {
                ServisGiris.ArizaliSIL(txtServisNo.Text);
                ServisGiris.IcerikSIL(txtServisNo.Text);
                Mesajlar.Bilgi("Servis Girişi İptal Edildi...");
                this.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ServisGirisIPTAL();
        }
    }
}