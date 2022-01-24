using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.IO;
using SANSAR2013.StokModulu.Classlar;

namespace SANSAR2013.StokModulu
{
    public partial class frmStokKarti : DevExpress.XtraEditors.XtraForm
    {
        public Boolean SecimIcinAcildimi = false;
        public string UrunId = "0";
        public Boolean Edit = false;

        private string ResimYolu;
        private string DosyaAdi;

        private int fileLength_1;
        private byte[] rawdata;
        IDataReader data;

       // SANSAR2013.Classlar.Veritabani DBase = new SANSAR2013.Classlar.Veritabani();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        SANSAR2013.Classlar.ResimFormat Resim_YenidenBoyutlandir = new SANSAR2013.Classlar.ResimFormat();

        Classlar.StokKarti StokKarti = new Classlar.StokKarti();
        Classlar.clsUrunGrubu UrunGrubu = new Classlar.clsUrunGrubu();
        Classlar.clsParaBirimi ParaBirimi = new Classlar.clsParaBirimi();
        Classlar.clsStokBirimi StokBirim = new Classlar.clsStokBirimi();
        Classlar.clsIskontoGrubu IskontoGrubu = new Classlar.clsIskontoGrubu();
        Classlar.clsEtiketRengi EtiketRengi = new Classlar.clsEtiketRengi();
        Classlar.clsStokTuru StokTuru = new Classlar.clsStokTuru();

        //Classlar.clsIskontoGrubu IskontoGrubu = new Classlar.clsIskontoGrubu();
        public frmStokKarti()
        {
            InitializeComponent();
        }

        private void frmStokKarti_Load(object sender, EventArgs e)
        {
            Stok_Birimini_Yukle();
            IskontoGroplariniYukle();
            StokTuruYukle();
            EtiketRengiYukle();
            if (Edit)
            {
                urun_bilgi_cek();
                btnStokKodBak.Enabled = false;
                if (StokKarti.UrunStokHareketVarmi(txtStokKodu.Text,txtModelNo.Text))
                {
                    txtStokKodu.Enabled = false;
                }
            }

        }
        void urun_bilgi_cek()
        {
            DataRow Satir = StokKarti.Stok_Karti_bilgilerini_cek(UrunId);
            txtStokKodu.Text = Satir["STOK_KODU"].ToString();
            txtModelNo.Text = Satir["MODEL_NO"].ToString();
            btn_txtUrunGrubu.Text = Satir["URUN_GRUBU"].ToString();

            cmbStokBirimi.Text = Satir["STOK_BIRIMI"].ToString();
            cmbIskontoGrubu.Text = Satir["ISKONTO_GRUBU"].ToString();
            cmbStokTuru.Text = Satir["STOK_TURU"].ToString();
            txtAlisFiyati.Text = Satir["ALIS_FIYAT"].ToString();
            cmbAlisParaBirimi.Text = Satir["ALIS_FIYAT_PARA_BIRIMI"].ToString();
            txtSatisFiyati.Text = Satir["SATIS_FIYAT"].ToString();
            txtSatisParaBirimi.Text = Satir["SATIS_FIYAT_PARA_BIRIMI"].ToString();
            txtSatisFiyati_1.Text = Satir["SATIS_FIYAT_1"].ToString();
            txtSatisParaBirimi_1.Text = Satir["SATIS_FIYAT_PARA_BIRIMI_1"].ToString();
            cmbEtıketRengi.Text = Satir["ETIKET_RENGI"].ToString();
            txtDepoNo.Text = Satir["DEPO_NO"].ToString();
            txtRafNo.Text = Satir["RAF_NO"].ToString();
            txtGozNo.Text = Satir["GOZ_NO"].ToString();
            txtKritikStokSeviyesi.Text = Satir["KRITIK_STOK_SEVIYESI"].ToString();
            txtAciklama.Text = Satir["ACIKLAMA"].ToString();
            txtResimYolu.Text = Satir["RESIM_ADI"].ToString();
            if (txtResimYolu.Text != "")
            {
                data = StokKarti.ResimCek(UrunId);
                if (data.Read())
                {
                    fileLength_1 = data.GetInt32(data.GetOrdinal("BOYUT"));
                    DosyaAdi = data.GetString(data.GetOrdinal("RESIM_ADI"));
                    ResimYolu = DosyaAdi;
                    byte[] rawdata = new byte[fileLength_1];
                    data.GetBytes(data.GetOrdinal("RESIM"), 0, rawdata, 0, fileLength_1);
                    FileStream fs = new FileStream(DosyaAdi, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                    fs.Write(rawdata, 0, fileLength_1);
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                    resim.Image = new Bitmap(DosyaAdi);
                }
            }

        }
        void EtiketRengiYukle()
        {
            for (int i = 1; i <= StokKarti.Etiket_Rengi_Getir(); i++)
            {
                cmbEtıketRengi.Properties.Items.Add("" + StokKarti.Etiket_Rengi(i).ToString() + "");
            }
        }
        void StokTuruYukle()
        {
            for (int i = 1; i <= StokKarti.Stok_Turu_Getır(); i++)
            {
                cmbStokTuru.Properties.Items.Add("" + StokKarti.stok_turu(i).ToString() + "");
            }
        }
        void IskontoGroplariniYukle()
        {
            for (int i = 1; i <= StokKarti.Iskonto_GrubuGetir(); i++)
            {
                cmbIskontoGrubu.Properties.Items.Add("" + StokKarti.iskonto_grubu(i).ToString() + "");
            }
        }
        void Stok_Birimini_Yukle()
        {
            for (int i = 1; i <= StokKarti.Stok_Birimleri_SatirGetir(); i++)
            {
                cmbStokBirimi.Properties.Items.Add("" + StokKarti.stokbirimi(i).ToString() + "");
            }
        }
        void Temizle()
        {
            txtStokKodu.Text = "";
            txtModelNo.Text = "";
            btn_txtUrunGrubu.Text = "";
            cmbStokBirimi.Text = "";
            cmbIskontoGrubu.Text = "";
            cmbStokTuru.Text = "";
            cmbEtıketRengi.Text = "";
            cmbAlisParaBirimi.Text = "";
            txtSatisParaBirimi.Text = "";
            txtSatisFiyati.Text = "";
            txtResimYolu.Text = "";
            txtRafNo.Text = "";
            txtKritikStokSeviyesi.Text = "";
            txtGozNo.Text = "";
            txtDepoNo.Text = "";
            txtAlisFiyati.Text = "";
            txtAciklama.Text = "";
            txtSatisFiyati_1.Text = "";
            txtSatisParaBirimi_1.Text = "";
            // resim.Image = null;
            rawdata = null;
            ResimYolu = "";
            resim.Image=null;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (StokKarti.UrunStokHareketVarmi(txtStokKodu.Text,txtModelNo.Text))
            {
                Mesajlar.Uyari("Stok Hareketi Yapıldığından Bu ürünü SİLEMEZSİZİN...!!!");
            }
            else
            {
                if (Mesajlar.Sor("Bu Ürünü Silmek İstediğinize Eminmisiniz ?"))
                {
                    StokKarti.UrunSil(txtStokKodu.Text,txtModelNo.Text);
                    Temizle();
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit == true)
            {
                if (txtStokKodu.Text != "")
                {
                    if (txtModelNo.Text != "")
                    {
                        if (btn_txtUrunGrubu.Text != "")
                        {
                            if (cmbStokBirimi.Text != "")
                            {
                                if (cmbAlisParaBirimi.Text != "")
                                {
                                    if (txtSatisParaBirimi_1.Text != "")
                                    {
                                            //GÜNCELLEME***********************************
                                            Txt_Doldur();
                                            ResimAyarla();
                                            StokKarti.Guncelle(UrunId,txtStokKodu.Text.ToUpper(), txtModelNo.Text.ToUpper(), btn_txtUrunGrubu.Text.ToUpper(), cmbStokBirimi.Text.ToUpper(), cmbIskontoGrubu.Text.ToUpper(), cmbStokTuru.Text.ToUpper(), Convert.ToDecimal(txtAlisFiyati.Text), cmbAlisParaBirimi.Text.ToUpper(), Convert.ToDecimal(txtSatisFiyati.Text), (txtSatisParaBirimi.Text).ToUpper(), Convert.ToDecimal(txtSatisFiyati_1.Text), txtSatisParaBirimi_1.Text.ToUpper(), Convert.ToInt32(txtKritikStokSeviyesi.Text), (cmbEtıketRengi.Text).ToUpper(), txtDepoNo.Text.ToUpper(), txtRafNo.Text.ToUpper(), txtGozNo.Text.ToUpper(), txtAciklama.Text.ToUpper(), fileLength_1, DosyaAdi, rawdata);
                                            Mesajlar.Bilgi("Stok Kartı Güncellemesi Yapıldı...");
                                            Temizle();
                                            //GÜNCELLEME***********************************
                                    }
                                    else
                                    {
                                        Mesajlar.Uyari("Satış Fiyatı Para Birimini Belirtmediniz...!");
                                    }
                                }
                                else
                                {
                                    Mesajlar.Uyari("Alış Fiyatı Para Birimini Belirtmediniz...!");
                                }
                            }
                            else
                            {
                                Mesajlar.Uyari("Stok Birimi Alanını Boş Bırakamazsınız...!");
                            }
                        }
                        else
                        {
                            Mesajlar.Uyari("Ürün Grubu Alanını Boş Bırakamazsınız...!");
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Model No Alanını Boş Bırakamazsınız...!");
                    }
                }
                else
                {
                    Mesajlar.Uyari("Stok Kodu Alanını Boş Bırakamazsınız...!");
                }
            }
            else
            {
                if (txtStokKodu.Text != "")
                {
                    if (txtModelNo.Text != "")
                    {
                        if (btn_txtUrunGrubu.Text != "")
                        {
                            if (cmbStokBirimi.Text != "")
                            {
                                if (cmbAlisParaBirimi.Text != "")
                                {
                                    if (txtSatisParaBirimi_1.Text != "")
                                    {
                                        if (!Urun_Kayit_Sorgula())
                                        {
                                            //KAYDETME*******************************************
                                        Txt_Doldur();                                            
                                        StokKarti.Ekle(txtStokKodu.Text.ToUpper(), txtModelNo.Text.ToUpper(), btn_txtUrunGrubu.Text.ToUpper(), cmbStokBirimi.Text.ToUpper(), cmbIskontoGrubu.Text.ToUpper(), cmbStokTuru.Text.ToUpper(), Convert.ToDecimal(txtAlisFiyati.Text), cmbAlisParaBirimi.Text.ToUpper(), Convert.ToDecimal(txtSatisFiyati.Text), (txtSatisParaBirimi.Text).ToUpper(), Convert.ToDecimal(txtSatisFiyati_1.Text), txtSatisParaBirimi_1.Text.ToUpper(), Convert.ToInt32(txtKritikStokSeviyesi.Text), (cmbEtıketRengi.Text).ToUpper(), txtDepoNo.Text.ToUpper(), txtRafNo.Text.ToUpper(), txtGozNo.Text.ToUpper(), txtAciklama.Text.ToUpper(), fileLength_1, DosyaAdi, rawdata);
                                        Mesajlar.Bilgi("Stok Kartı Kayıdı Yapıldı...");
                                        Temizle();
                                            //KAYDETME*******************************************
                                        }
                                        else
                                        {
                                            Mesajlar.Uyari("Bu Koda kayıtlı ürün zaten var, kontrol ediniz...!");
                                        }
                                    }
                                    else
                                    {
                                        Mesajlar.Uyari("Satış Fiyatı Para Birimini Belirtmediniz...!");
                                    }
                                }
                                else
                                {
                                    Mesajlar.Uyari("Alış Fiyatı Para Birimini Belirtmediniz...!");
                                }
                            }
                            else
                            {
                                Mesajlar.Uyari("Stok Birimi Alanını Boş Bırakamazsınız...!");
                            }
                        }
                        else
                        {
                            Mesajlar.Uyari("Ürün Grubu Alanını Boş Bırakamazsınız...!");
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Model No Alanını Boş Bırakamazsınız...!");
                    }
                }
                else
                {
                    Mesajlar.Uyari("Stok Kodu Alanını Boş Bırakamazsınız...!");
                }
            }
        }
        void Txt_Doldur()
        {
            if (txtAlisFiyati.Text == "")
            {
                txtAlisFiyati.Text = "0";
            }
            if (txtSatisFiyati.Text == "")
            {
                txtSatisFiyati.Text = "0";
            }
            if (txtSatisFiyati_1.Text == "")
            {
                txtSatisFiyati_1.Text = "0";
            }
            if (txtKritikStokSeviyesi.Text == "")
            {
                txtKritikStokSeviyesi.Text = "0";
            }
        }
       private Boolean Urun_Kayit_Sorgula()
        {
           Boolean sorgu=false;
            return sorgu = StokKarti.Urun_kayit_sorgula(txtStokKodu.Text.ToUpper(), txtModelNo.Text.ToUpper());
        }
        private void btnSec_Click(object sender, EventArgs e)
        {
            ResimAc.Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png";
            ResimAc.ShowDialog();
            if (ResimAc.FileName != "" && ResimAc.FileName != "ResimAc")
            {
                resim.Image = new Bitmap(ResimAc.FileName);
                Bitmap Resim_boyut = new Bitmap(ResimAc.FileName);
                // resim.Image = Resim_YenidenBoyutlandir.ResimBoyutlandir(Resim_boyut, 100, 200);

                ResimYolu = ResimAc.FileName;
                DosyaAdi = ResimAc.SafeFileName;
                txtResimYolu.Text = ResimYolu;
                ResimAyarla();
            }
            else
            {
                ResimAc.FileName = "";
            }
        }
        void ResimAyarla()
        {
            //Bitmap Resim_boyut = new Bitmap(ResimAc.FileName);
            //Bitmap YeniBoyut = Resim_YenidenBoyutlandir.ResimBoyutlandir(Resim_boyut, 800, 600);            
            //FileStream fs = new FileStream(ResimYolu, FileMode.OpenOrCreate, FileAccess.Read);
            if (txtResimYolu.Text!="")
            {
             FileStream fs = new FileStream(ResimYolu, FileMode.Open, FileAccess.Read);

            fileLength_1 = (int)fs.Length;
            rawdata = new byte[fileLength_1];
            fs.Read(rawdata, 0, (int)fileLength_1);               
            }
        }
        private void btn_txtUrunGrubu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            btn_txtUrunGrubu.Text = UrunGrubu.UrunGrubuAl(Ekranlar.UrunGrubuAc(true));
        }

        private void cmbAlisParaBirimi_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            cmbAlisParaBirimi.Text = ParaBirimi.ParaBirimiAl(Ekranlar.ParaBirimleriAc(true));
        }

        private void txtSatisParaBirimi_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            txtSatisParaBirimi.Text = ParaBirimi.ParaBirimiAl(Ekranlar.ParaBirimleriAc(true));
        }

        private void txtAlisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
           // if (char.IsDigit(e.KeyChar) == false && !char.IsControl(e.KeyChar))
            if (e.Handled = char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                Mesajlar.Uyari("Sadece RAKAM Girebilirsiniz...!");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtSatisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                Mesajlar.Uyari("Sadece RAKAM Girebilirsiniz...!");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtKritikStokSeviyesi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                Mesajlar.Uyari("Sadece RAKAM Girebilirsiniz...!");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtSatisParaBirimi_1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            txtSatisParaBirimi_1.Text = ParaBirimi.ParaBirimiAl(Ekranlar.ParaBirimleriAc(true));
        }

        private void frmStokKarti_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (resim.Image != null)
            {
                resim.Image.Dispose();
            }

        }

        private void btnStokKodBak_Click(object sender, EventArgs e)
        {
            UrunId = Ekranlar.StokKodListesiSorgulama(true);
            if (UrunId != "")
            {
                urun_bilgi_cek();
                btnStokKodBak.Enabled = false;
                Edit = true;
                if (StokKarti.UrunStokHareketVarmi(txtStokKodu.Text,txtModelNo.Text))
                {
                    txtStokKodu.Enabled = false;
                }
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Temizle();
            SecimIcinAcildimi = false;
            Edit = false;
        }
    }
}