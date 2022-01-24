using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.TeknikServisModulu.TS_OlayModulu
{
    public partial class frmOlayFormu : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();
        Classlar.clsTS_Olaylar Olaylar = new Classlar.clsTS_Olaylar();
        SANSAR2013.EktralarModulu.Classlar.clsKargolar Kargolar = new EktralarModulu.Classlar.clsKargolar();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.StokModulu.Classlar.clsParaBirimi ParaBirimi = new StokModulu.Classlar.clsParaBirimi();
        SANSAR2013.EktralarModulu.Classlar.clsArizaKodlari ArizaKodlari = new EktralarModulu.Classlar.clsArizaKodlari();
        Dizaynlar.Classlar.clsCikisYazdir Yazdir= new Dizaynlar.Classlar.clsCikisYazdir();

        public string servis_no = "";
        public Boolean Edit = false;
        public Boolean DegisiklikYapildimi = false;
        public Boolean ServisCikisYapildimi = false;
        private Boolean duzenleme = false;
        private string servis_aciklama, cikis_ir_no, teslim_sekli, ser_cik_tarih,aciklama,ser_gir_teslim_sekli;

        private DataTable Tablo_Arizalilar;

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
            Tablo_Arizalilar.Columns.Add(new DataColumn("YAPILAN_ISLEM", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("SERVIS_ACIKLAMA", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("ARIZA_KODU", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("TAMIR_KAPSAMI", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("FIYAT", typeof(string)));
            Tablo_Arizalilar.Columns.Add(new DataColumn("PARA_BIRIM", typeof(string)));
        }
        public frmOlayFormu()
        {
            InitializeComponent();
        }

        void KargolarYukle()
        {
            for (int i = 1; i <= Kargolar.KargoListeToplamı(); i++)
            {
                cmbTeslimat.Properties.Items.Add("" + Kargolar.KargoIsminiAl(i.ToString()).ToString() + "");
            }
        }
        void ArizaKodlariniYukle()
        {
            for (int i = 1; i <= ArizaKodlari.ArizaKodlariListeToplamı(); i++)
            {
                cmbArizaKodu.Properties.Items.Add("" + ArizaKodlari.ArizaKodu_IsminiAl(i.ToString()).ToString() + "");
            }
        }
        void MusterBilgileri(string Musteri_KODU)
        {
            DataRow drow = Olaylar.MusteriBilgileri(Musteri_KODU);
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

                throw;
            }
        }
        void ServisCikisBilgileriniYukle()
        {
            DataRow drow = Olaylar.ServisCikisBilgileriCEK(servis_no);
            try
            {
                MusterBilgileri(drow["MUSTERI_KODU"].ToString());
                txt_Servis_giris_tarih.Text = Formatlar.EskiyeCevirKısa(drow["SERVIS_GIR_TARIH"].ToString());
                txt_servis_giris_irsaliye.Text = drow["GIRIS_IRSALIYE_NO"].ToString();
                string cikis_tarih = drow["SERVIS_CIK_TARIH"].ToString();
                if (cikis_tarih == "")
                {
                    txt_Seriv_Cikas_Tarih.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    txt_Seriv_Cikas_Tarih.Text = Formatlar.EskiyeCevirKısa(cikis_tarih);
                }
                txt_Servis_Cikis_Irsaliye_No.Text = drow["CIKIS_IRSALIYE_NO"].ToString();
                txtServisNo.Text = drow["SERVIS_NO"].ToString();
                txtTeslimAlan.Text = drow["TESLIM_ALAN"].ToString();
                txtIslemYapan.Text = drow["ISLEM_YAPAN"].ToString();
                txt_Servis_Aciklama.Text = drow["SERVIS_ACIKLAMA"].ToString();
                cmbTeslimat.Text = drow["GONDERILME_SEKLI"].ToString();

                teslim_sekli = drow["GONDERILME_SEKLI"].ToString();
                servis_aciklama = drow["SERVIS_ACIKLAMA"].ToString();
                ser_cik_tarih = txt_Seriv_Cikas_Tarih.Text;
                cikis_ir_no = drow["CIKIS_IRSALIYE_NO"].ToString();
                aciklama = drow["ACIKLAMA"].ToString();
                ser_gir_teslim_sekli = drow["TESLIM_SEKLI"].ToString();
            }
            catch (Exception)
            {
                MusterBilgileri(drow["MUSTERI_KODU"].ToString());
                txt_Servis_giris_tarih.Text = "";
                txt_servis_giris_irsaliye.Text = "";
                txt_Seriv_Cikas_Tarih.Text = "";
                txt_Servis_Cikis_Irsaliye_No.Text = "";
                txtServisNo.Text = "";
                txtTeslimAlan.Text = "";
                txtIslemYapan.Text = "";
                txt_Servis_Aciklama.Text = "";
                cmbTeslimat.Text = "";
            }
        }
        void ServisBilgilerini_Yukle()
        {
            DataRow drow = Olaylar.ServisBilgileriniCEK(servis_no);
            try
            {
                MusterBilgileri(drow["MUSTERI_KODU"].ToString());
                txt_Servis_giris_tarih.Text = Formatlar.EskiyeCevirKısa(drow["SERVIS_GIR_TARIH"].ToString());
                txt_servis_giris_irsaliye.Text = drow["GIRIS_IRSALIYE_NO"].ToString();
                string cikis_tarih = drow["SERVIS_CIK_TARIH"].ToString();
                if (cikis_tarih == "")
                {
                    txt_Seriv_Cikas_Tarih.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    txt_Seriv_Cikas_Tarih.Text = Formatlar.EskiyeCevirKısa(cikis_tarih);
                }
                txt_Servis_Cikis_Irsaliye_No.Text = drow["CIKIS_IRSALIYE_NO"].ToString();
                txtServisNo.Text = drow["SERVIS_NO"].ToString();
                txtTeslimAlan.Text = drow["TESLIM_ALAN"].ToString();
                txtIslemYapan.Text = drow["ISLEM_YAPAN"].ToString();
                txt_Servis_Aciklama.Text = drow["SERVIS_ACIKLAMA"].ToString();
                cmbTeslimat.Text = drow["GONDERILME_SEKLI"].ToString();

                teslim_sekli = drow["GONDERILME_SEKLI"].ToString();
                servis_aciklama = drow["SERVIS_ACIKLAMA"].ToString();
                ser_cik_tarih = txt_Seriv_Cikas_Tarih.Text;
                cikis_ir_no = drow["CIKIS_IRSALIYE_NO"].ToString();
                aciklama = drow["ACIKLAMA"].ToString();
                ser_gir_teslim_sekli = drow["TESLIM_SEKLI"].ToString();
            }
            catch (Exception)
            {
                MusterBilgileri(drow["MUSTERI_KODU"].ToString());
                txt_Servis_giris_tarih.Text = "";
                txt_servis_giris_irsaliye.Text = "";
                txt_Seriv_Cikas_Tarih.Text = "";
                txt_Servis_Cikis_Irsaliye_No.Text = "";
                txtServisNo.Text = "";
                txtTeslimAlan.Text = "";
                txtIslemYapan.Text = "";
                txt_Servis_Aciklama.Text = "";
                cmbTeslimat.Text = "";
            }
        }
        void Degisiklik_Kontrol()
        {
            if (teslim_sekli == cmbTeslimat.Text)
            {
                if (txt_Seriv_Cikas_Tarih.Text == ser_cik_tarih)
                {
                    if (cikis_ir_no == txt_Servis_Cikis_Irsaliye_No.Text)
                    {
                        if (txt_Servis_Aciklama.Text == servis_aciklama)
                        {
                            DegisiklikYapildimi = duzenleme;
                        }
                        else
                        {
                            DegisiklikYapildimi = true;
                        }
                    }
                    else
                    {
                        DegisiklikYapildimi = true;
                    }
                }
                else
                {
                    DegisiklikYapildimi = true;
                }
            }
            else
            {
                DegisiklikYapildimi = true;
            }
        }
        private void frmOlayFormu_Load(object sender, EventArgs e)
        {
            if (ServisCikisYapildimi)
            {
                KargolarYukle();
                ServisCikisBilgileriniYukle();
                TabloKur_Arizalilar();
                ArizaKodlariniYukle();
                Liste.DataSource = Olaylar.Arizali_Cikis_Icerik_CEK(servis_no);

                btnCikis_Irsaliyeno.Visible = false;
                btnDuzenle.Visible = false;
                btnResimYok.Visible = false;
                btnResimEkle.Enabled = false;
                btnServisCikis.Enabled = false;
                btnKaydet.Enabled = false;
                txt_Servis_Aciklama.Properties.ReadOnly = true;
                txt_Seriv_Cikas_Tarih.Properties.ReadOnly = true;
                cmbTeslimat.Properties.ReadOnly = true;
                txtIslemYapan.Properties.ReadOnly = true;
                txtIslemAciklama.Properties.ReadOnly = true;
                cmbArizaKodu.Properties.ReadOnly = true;
                txtTamirKapsami.Properties.ReadOnly = true;
                txtFiyat.Properties.ReadOnly = true;
                txtYapilanIslem.Properties.ReadOnly = true;
                cmbParaBirimi.Properties.ReadOnly = true;
                chkSerG_VAR.Visible = false;
                chkSerG_YOK.Visible = false;
                chkVAR.Enabled = false;
                chkYOK.Enabled = false;
            }
            else
            {
                txt_Seriv_Cikas_Tarih.Text = DateTime.Now.ToShortDateString();
                KargolarYukle();
                ServisBilgilerini_Yukle();
                TabloKur_Arizalilar();
                ArizaKodlariniYukle();
                Liste.DataSource = Olaylar.Arizali_Icerik_CEK(servis_no);
            }
        }

        private void btnCikis_Irsaliyeno_Click(object sender, EventArgs e)
        {
            txt_Servis_Cikis_Irsaliye_No.Text = Ekranlar.Irsaliye_No_Ac();
            DegisiklikYapildimi = true;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Degisiklik_Kontrol();

            if (DegisiklikYapildimi)
            {
                if (Mesajlar.Sor("Yapılan değişiklikler Kaydedilmedi Çıkarsanız KAYDEDİLMEYECEK, Çıkmak istediğinize Emin misiniz_?"))
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
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
                    chkVAR.Checked = true;
                }
                else if (garanti == "YOK")
                {
                    chkYOK.Checked = true;
                }

                txtYapilanIslem.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YAPILAN_ISLEM".ToString())).ToString();
                txtIslemAciklama.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SERVIS_ACIKLAMA".ToString())).ToString();
                cmbArizaKodu.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ARIZA_KODU".ToString())).ToString();
                txtTamirKapsami.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TAMIR_KAPSAMI".ToString())).ToString();
                if (txtTamirKapsami.Text == "GARANTİ DAHİLİNDE")
                {
                    chkSerG_YOK.Checked = false;
                    chkSerG_VAR.Checked = true;
                }
                if (txtTamirKapsami.Text == "GARANTİ DIŞI")
                {
                    chkSerG_YOK.Checked = true;
                    chkSerG_VAR.Checked = false;
                }
                if (txtTamirKapsami.Text == "")
                {
                    chkSerG_YOK.Checked = false;
                    chkSerG_VAR.Checked = false;
                }
                txtFiyat.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FIYAT".ToString())).ToString();
                cmbParaBirimi.Text = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PARA_BIRIM".ToString())).ToString();
            }
        }

        private void cmbParaBirimi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            cmbParaBirimi.Text = ParaBirimi.ParaBirimiAl(Ekranlar.ParaBirimleriAc(true));
        }
        void Temizle()
        {
            txtStokKodu.Text = "";
            txtModelNo.Text = "";
            txtMiktar.Text = "";
            txtStokBirim.Text = "";
            txtSerniNo.Text = "";
            txtAksesuarlar.Text = "";
            txtSikayet.Text = "";
            txtArizaAciklama.Text = "";
            txtYapilanIslem.Text = "";
            cmbArizaKodu.Text = "";
            cmbParaBirimi.Text = "";
            txtTamirKapsami.Text = "";
            txtFiyat.Text = "";
            txtIslemAciklama.Text = "";
            chkSerG_VAR.Checked = false;
            chkSerG_YOK.Checked = false;
            chkVAR.Checked = false;
            chkYOK.Checked = false;
        }

        void ServisIslemleriniYap()
        {
            if (txtFiyat.Text == "")
            {
                txtFiyat.Text = "0";
                cmbParaBirimi.Text = "TL";
            }
            if (txtTamirKapsami.Text == "")
            {
                txtTamirKapsami.Text = "GARANTİ DAHİLİNDE";
            }
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "YAPILAN_ISLEM", txtYapilanIslem.Text.ToString().ToUpper());
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SERVIS_ACIKLAMA", txtIslemAciklama.Text.ToString().ToUpper());
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ARIZA_KODU", cmbArizaKodu.Text.ToString());
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TAMIR_KAPSAMI", txtTamirKapsami.Text);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "FIYAT", Convert.ToInt32(txtFiyat.Text));
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PARA_BIRIM", cmbParaBirimi.Text);
            Temizle();
            Mesajlar.Bilgi("Yapılan İşlem Güncellendi...");
        }
        private void btnSatisONAY_Click(object sender, EventArgs e)
        {
            if (txtModelNo.Text != "")
            {
                string garanti = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GARANTI_DURUMU".ToString())).ToString();

                if (garanti == "YOK")
                {
                    if (txtTamirKapsami.Text != "")
                    {
                        if (txtTamirKapsami.Text == "GARANTİ DIŞI")
                        {
                            if (txtFiyat.Text == "")
                            {
                                Mesajlar.Uyari("Cihaz Garanti Dışı olduğundan Tamir Fiyatını Belirtmelisiniz...");
                            }
                            else
                            {
                                if (cmbParaBirimi.Text != "")
                                {
                                    ServisIslemleriniYap();
                                    duzenleme = true;
                                }
                                else
                                {
                                    Mesajlar.Uyari("Tamir Bedeli para Birimini Belirtmediniz...");
                                }
                            }
                        }
                        else
                        {
                            ServisIslemleriniYap();
                            duzenleme = true;
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Cihaz Tamir Kapsamını Belirtmediniz...");
                    }
                }
                else
                {
                    ServisIslemleriniYap();
                    duzenleme = true;
                }
            }
            else
            {
                Mesajlar.Uyari("Ürün seçimi yapılmadı...!");
            }
        }
        private void chkSerG_VAR_CheckedChanged(object sender, EventArgs e)
        {
            //chkSerG_VAR.Checked = true;
            if (chkSerG_VAR.Checked)
            {
                chkSerG_YOK.Checked = false;
                txtTamirKapsami.Text = "GARANTİ DAHİLİNDE";
            }
        }
        private void chkSerG_YOK_CheckedChanged(object sender, EventArgs e)
        {
            // chkSerG_YOK.Checked = true;
            if (chkSerG_YOK.Checked)
            {
                chkSerG_VAR.Checked = false;
                txtTamirKapsami.Text = "GARANTİ DIŞI";
            }
        }
        DataTable TabloKalemler()
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
            Tablo.Columns.Add(new DataColumn("YAPILAN_ISLEM", typeof(string)));
            Tablo.Columns.Add(new DataColumn("SERVIS_ACIKLAMA", typeof(string)));
            Tablo.Columns.Add(new DataColumn("ARIZA_KODU", typeof(string)));
            Tablo.Columns.Add(new DataColumn("TAMIR_KAPSAMI", typeof(string)));
            Tablo.Columns.Add(new DataColumn("FIYAT", typeof(decimal)));
            Tablo.Columns.Add(new DataColumn("PARA_BIRIM", typeof(string)));

            string stok_kodu, Model_no, Miktar, Stok_birim, urun_seri_no, garanti_durumu, aksesuarlar, sikayet, aciklama, yapilan_islem, servis_aciklama, ariza_kodu, tamir_kapsami, para_birim, ara_fiyat;
            decimal fiyat;

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
                yapilan_islem = gridView1.GetRowCellValue(i, "YAPILAN_ISLEM").ToString();
                servis_aciklama = gridView1.GetRowCellValue(i, "SERVIS_ACIKLAMA").ToString();
                ariza_kodu = gridView1.GetRowCellValue(i, "ARIZA_KODU").ToString();
                tamir_kapsami = gridView1.GetRowCellValue(i, "TAMIR_KAPSAMI").ToString();
                ara_fiyat = gridView1.GetRowCellValue(i, "FIYAT").ToString();
                if (ara_fiyat == "")
                {
                    ara_fiyat = "0";
                    fiyat = Convert.ToDecimal(ara_fiyat);
                }
                else
                {
                    fiyat = Convert.ToDecimal(ara_fiyat);
                }
                para_birim = gridView1.GetRowCellValue(i, "PARA_BIRIM").ToString();
                Tablo.Rows.Add(i, stok_kodu, Model_no, Miktar, Stok_birim, urun_seri_no, garanti_durumu, aksesuarlar, sikayet, aciklama, yapilan_islem, servis_aciklama, ariza_kodu, tamir_kapsami, fiyat, para_birim);
            }
            return Tablo;
        }
        void Kaydet()
        {
            string Tipi = "SRV";

            Olaylar.ServisOlayGUNCELLE(Tipi, txtServisNo.Text, txtMusteriKodu.Text, AnaForm.Username.ToString(), txt_Seriv_Cikas_Tarih.Text, txt_Servis_Cikis_Irsaliye_No.Text, cmbTeslimat.Text, txt_Servis_Aciklama.Text.ToUpper(), TabloKalemler());
            Mesajlar.Bilgi("Kayıt Eklendi...");
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Degisiklik_Kontrol();

            if (DegisiklikYapildimi)
            {
                txtIslemYapan.Text = AnaForm.Username.ToString();
                Kaydet();
                Temizle();

                teslim_sekli = cmbTeslimat.Text;
                servis_aciklama = txt_Servis_Aciklama.Text;
                ser_cik_tarih = txt_Seriv_Cikas_Tarih.Text;
                cikis_ir_no = txt_Servis_Cikis_Irsaliye_No.Text;
                DegisiklikYapildimi = false;
            }
            else
            {
                Mesajlar.Bilgi("Değişiklik Yapılmadı...");
            }
        }
        void ServisCikis()
        { 
            string Tipi="SRV";

            Olaylar.ServisCikisYAP(Tipi, txtServisNo.Text, txt_Servis_giris_tarih.Text, txt_servis_giris_irsaliye.Text, txt_Seriv_Cikas_Tarih.Text, txt_Servis_Cikis_Irsaliye_No.Text, txtMusteriKodu.Text, txtFirmaAdi.Text, txtTeslimAlan.Text, txtIslemYapan.Text, ser_gir_teslim_sekli, cmbTeslimat.Text, aciklama, txt_Servis_Aciklama.Text.ToUpper(), TabloKalemler());
            Mesajlar.Bilgi("Servis Çıkışı Yapıldı...");
        }
        private void btnServisCikis_Click(object sender, EventArgs e)
        {
            if (cmbTeslimat.Text != "")
            {
                if (txt_Servis_Cikis_Irsaliye_No.Text != "")
                {
                    if (Mesajlar.Sor("Arızalı ürünlerin servis çıkışı yapılsın mı_?"))
                    {
                        ServisCikis();
                        this.Close();
                    }
                }
                else
                {
                    if (Mesajlar.Sor("Servis Çıkış İrsaliye numarasını yazmadınız,devam edilsin mi _?"))
                    {
                        ServisCikis();
                        this.Close();
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Servis çıkışı teslim şeklini belirtmediniz...!!!");
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (ServisCikisYapildimi)
            {
                Yazdir.ServisCikisYazdir(txtServisNo.Text);
            }
            else
            {
                Yazdir.ServisIslemYazdir(txtServisNo.Text);
            }
        }
    }
}