using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.MusterıModulu
{
    public partial class frmMusteriKarti : DevExpress.XtraEditors.XtraForm
    {
        public Boolean SecimIcinAcildimi = false;
        public string Musteri_ID = "0";
        public Boolean Edit = false;
        private string  musteri_sira_no="0";

        Classlar.clsBayiilikTuru BayiilikTuru = new Classlar.clsBayiilikTuru();
        Classlar.clsMusteriKarti MusteriKarti = new Classlar.clsMusteriKarti();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();

        public frmMusteriKarti()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void BayiilikTuruYukle()
        {
            for (int i = 1; i <= MusteriKarti.Bayiilik_Turleri_SatirGetir(); i++)
            {
                cmbBayiilik_Turu.Properties.Items.Add("" + MusteriKarti.bayiilikTuru(i).ToString() + "");
            }
        }

        private void frmMusteriKarti_Load(object sender, EventArgs e)
        {
            BayiilikTuruYukle();
            if (Edit)
            {
                Musteri_Bilgi_Cek();
                btnSec.Enabled = false;
                if (MusteriKarti.MusteriKartiStokHareketiVarmi(txtMusteri_Kodu.Text))
                {
                    txtMusteri_Kodu.Enabled = false;
                    txtFirma_Adi.Enabled = false;
                }
            }
        }
        void Musteri_Bilgi_Cek()
        {
            DataRow Satir = MusteriKarti.Musteri_Karti_bilgilerini_cek(Musteri_ID);
            musteri_sira_no = Satir["ID"].ToString();
            txtMusteri_Kodu.Text = Satir["MUSTERI_KODU"].ToString();
            txtFirma_Adi.Text = Satir["FIRMA_ADI"].ToString();
            txtAdres_1.Text = Satir["ADRES_1"].ToString();
            txtIlce_1.Text = Satir["ILCE_1"].ToString();
            txtIl_1.Text = Satir["IL_1"].ToString();
            txtAdres_2.Text = Satir["ADRES_2"].ToString();
            txtIlce_2.Text = Satir["ILCE_2"].ToString();
            txtIl_2.Text = Satir["IL_2"].ToString();
            txt_Ulke.Text = Satir["ULKE"].ToString();
            txt_Tel_1.Text = Satir["TEL_1"].ToString();
            txt_Tel_2.Text = Satir["TEL_2"].ToString();
            txt_Fax.Text = Satir["FAX"].ToString();
            txt_CepTel.Text = Satir["CEP_TEL"].ToString();
            txt_Mail.Text = Satir["MAIL"].ToString();
            txtYetkili_Kisi.Text = Satir["YETKILI_KISI"].ToString();
            cmbBayiilik_Turu.Text = Satir["BAYIILIK_TURU"].ToString();
            txtVergiDairesi.Text = Satir["VERGI_DAIRESI"].ToString();
            txtVergiNo.Text = Satir["VERGI_NO"].ToString();
            txtIskonto_1.Text = Satir["ISK_1"].ToString();
            txtIskonto_2.Text = Satir["ISK_2"].ToString();
            txtIskonto_3.Text = Satir["ISK_3"].ToString();
            txtIskonto_4.Text = Satir["ISK_4"].ToString();
            txtIskonto_5.Text = Satir["ISK_5"].ToString();
            txtIskonto_6.Text = Satir["ISK_6"].ToString();
            txtAciklama_1.Text = Satir["ACIKLAMA_1"].ToString();
            txtAciklama_2.Text = Satir["ACIKLAMA_2"].ToString();
        }
        void Temizle()
        {
            txtMusteri_Kodu.Text = "";
            txtFirma_Adi.Text = "";
            txtAdres_1.Text = "";
            txtIl_1.Text = "";
            txtIlce_1.Text = "";
            txtAdres_2.Text = "";
            txtIl_2.Text = "";
            txtIlce_2.Text = "";
            txt_Ulke.Text = "";
            txt_Fax.Text = "";
            txt_Tel_1.Text = "";
            txt_Tel_2.Text = "";
            txt_CepTel.Text = "";
            txt_Mail.Text = "";
            txtYetkili_Kisi.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiNo.Text = "";
            cmbBayiilik_Turu.Text = "";
            txtIskonto_1.Text = "";
            txtIskonto_2.Text = "";
            txtIskonto_3.Text = "";
            txtIskonto_4.Text = "";
            txtIskonto_5.Text = "";
            txtIskonto_6.Text = "";
            txtAciklama_1.Text = "";
            txtAciklama_2.Text = "";
        }
        void Doldur()
        {
            if (txtIskonto_1.Text == "")
            {
                txtIskonto_1.Text = "0";
            }
            if (txtIskonto_2.Text == "")
            {
                txtIskonto_2.Text = "0";
            }
            if (txtIskonto_3.Text == "")
            {
                txtIskonto_3.Text = "0";
            }
            if (txtIskonto_4.Text == "")
            {
                txtIskonto_4.Text = "0";
            }
            if (txtIskonto_5.Text == "")
            {
                txtIskonto_5.Text = "0";
            }
            if (txtIskonto_6.Text == "")
            {
                txtIskonto_6.Text = "0";
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit == true)
            {
                if (txtMusteri_Kodu.Text != "")
                {
                    if (txtFirma_Adi.Text != "")
                    {
                        if (txtAdres_1.Text != "")
                        {
                            if (txtIlce_1.Text != "")
                            {
                                if (txtIl_1.Text != "")
                                {
                                    Doldur();
                                    MusteriKarti.Gulcelle(Musteri_ID, txtMusteri_Kodu.Text.ToUpper(), txtFirma_Adi.Text.ToUpper(), txtAdres_1.Text.ToUpper(), txtIl_1.Text.ToUpper(), txtIlce_1.Text.ToUpper(), txtAdres_2.Text.ToUpper(), txtIl_2.Text.ToUpper(), txtIlce_2.Text.ToUpper(), txt_Ulke.Text.ToUpper(), txt_Tel_1.Text.ToUpper(), txt_Tel_2.Text.ToUpper(), txt_Fax.Text.ToUpper(), txt_Mail.Text.ToUpper(), txt_CepTel.Text.ToUpper(), txtYetkili_Kisi.Text.ToUpper(), cmbBayiilik_Turu.Text, txtVergiDairesi.Text.ToUpper(), txtVergiNo.Text, txtIskonto_1.Text, txtIskonto_2.Text, txtIskonto_3.Text, txtIskonto_4.Text, txtIskonto_5.Text, txtIskonto_6.Text, txtAciklama_1.Text.ToUpper(), txtAciklama_2.Text.ToUpper());
                                    Mesajlar.Bilgi("Müşteri Kartı Güncellemesi Yapıldı...");
                                    Temizle();
                                }
                                else
                                {
                                    Mesajlar.Uyari("İl Yazmadınız...");
                                }
                            }
                            else
                            {
                                Mesajlar.Uyari("İlçe Belirtmediniz...");
                            }
                        }
                        else
                        {
                            Mesajlar.Uyari("Adres Yazmadınız...");
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Firma Adını Yazmadınız...!");
                    }
                }
                else
                {
                    Mesajlar.Uyari("Musteri Kodu Alanını Boş Bırakamazsınız...!");
                }
            }
            else
            {
                if (txtMusteri_Kodu.Text != "")
                {
                    if (txtFirma_Adi.Text != "")
                    {
                        if (txtAdres_1.Text != "")
                        {
                            if (txtIlce_1.Text != "")
                            {
                                if (txtIl_1.Text != "")
                                {
                                    Doldur();
                                    if (!MusteriKarti.MusteriKayitSorgu(txtMusteri_Kodu.Text.ToUpper(), txtFirma_Adi.Text.ToUpper()))
                                    {
                                        MusteriKarti.Ekle(txtMusteri_Kodu.Text.ToUpper(), txtFirma_Adi.Text.ToUpper(), txtAdres_1.Text.ToUpper(), txtIl_1.Text.ToUpper(), txtIlce_1.Text.ToUpper(), txtAdres_2.Text.ToUpper(), txtIl_2.Text.ToUpper(), txtIlce_2.Text.ToUpper(), txt_Ulke.Text.ToUpper(), txt_Tel_1.Text.ToUpper(), txt_Tel_2.Text.ToUpper(), txt_Fax.Text.ToUpper(), txt_Mail.Text, txt_CepTel.Text.ToUpper(), txtYetkili_Kisi.Text.ToUpper(), cmbBayiilik_Turu.Text, txtVergiDairesi.Text.ToUpper(), txtVergiNo.Text.ToUpper(), txtIskonto_1.Text, txtIskonto_2.Text, txtIskonto_3.Text, txtIskonto_4.Text, txtIskonto_5.Text, txtIskonto_6.Text, txtAciklama_1.Text.ToUpper(), txtAciklama_2.Text.ToUpper());
                                        Mesajlar.Bilgi("Müşteri Kaydı Yapıldı...");
                                        Temizle();
                                    }
                                    else
                                    {
                                        Mesajlar.Uyari("Bu Müşteri zaten Kayıtlı, Kontrol ediniz...!");
                                    }
                                }
                                else
                                {
                                    Mesajlar.Uyari("İl Yazmadınız...");
                                }
                            }
                            else
                            {
                                Mesajlar.Uyari("İlçe Belirtmediniz...");
                            }
                        }
                        else
                        {
                            Mesajlar.Uyari("Adres Yazmadınız...");
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Firma Adını Yazmadınız...!");
                    }
                }
                else
                {
                    Mesajlar.Uyari("Musteri Kodu Alanını Boş Bırakamazsınız...!");
                }
            }

        }
        private void txtIskonto_1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIskonto_2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIskonto_3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIskonto_4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIskonto_5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIskonto_6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Temizle();
            SecimIcinAcildimi = false;
            Edit = false;
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            Musteri_ID = Ekranlar.MusteriKodListesiSorgulama(true,false);
            if (Musteri_ID != "")
            {
                Musteri_Bilgi_Cek();
                btnSec.Enabled = false;
                Edit = true;
                if (MusteriKarti.MusteriKartiStokHareketiVarmi(txtMusteri_Kodu.Text))
                {
                    txtMusteri_Kodu.Enabled = false;
                    txtFirma_Adi.Enabled = false;
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MusteriKarti.MusteriKayitlimi(txtMusteri_Kodu.Text, txtFirma_Adi.Text))
            {
                if (MusteriKarti.MusteriKartiStokHareketiVarmi(txtMusteri_Kodu.Text))
                {
                    Mesajlar.Uyari("Stok Hareketi Yapıldığından Bu Müşteriyi Silemezsiniz...!!");
                }
                else
                {
                    if (Mesajlar.Sor("Müşteri Kartını Silmek İstediğinize Eminmisiniz ?"))
                    {
                        MusteriKarti.MusteriKartiSil(txtMusteri_Kodu.Text);
                        Temizle();
                    }
                }
            }
            else
            {
                Mesajlar.Uyari("Bu Müşteri zaten kayıtlı değil...!!");
            }
        }

    }
}