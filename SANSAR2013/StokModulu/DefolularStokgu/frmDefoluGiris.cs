using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SANSAR2013.StokModulu.DefolularStokgu
{
    public partial class frmDefoluGiris : DevExpress.XtraEditors.XtraForm
    {
        SANSAR2013.Classlar.Mesajlar Mesajlar = new SANSAR2013.Classlar.Mesajlar();
        SANSAR2013.StokModulu.Classlar.StokKarti StokKarti = new StokModulu.Classlar.StokKarti();
        SANSAR2013.Classlar.Ekranlar Ekranlar = new SANSAR2013.Classlar.Ekranlar();
        Classlar.clsDefoluGiris DefoluGiris = new Classlar.clsDefoluGiris();
        SANSAR2013.Classlar.Formatlar Formatlar = new SANSAR2013.Classlar.Formatlar();

        public string UrunID;
        public Boolean Edit;

        public frmDefoluGiris()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void StokTurleriniYukle()
        {
            for (int i = 1; i <= StokKarti.Stok_Turu_Getır(); i++)
            {
                cmbStokTuru.Properties.Items.Add("" + StokKarti.stok_turu(i).ToString() + "");
            }
        }
        void EtiketRenkleriniYukle()
        {
            for (int i = 1; i <= StokKarti.Etiket_Rengi_Getir(); i++)
            {
                cmbEtiketRengi.Properties.Items.Add("" + StokKarti.Etiket_Rengi(i).ToString() + "");
            }
        }
        void StokBirimleriniYukle()
        {
            for (int i = 1; i <= StokKarti.Stok_Birimleri_SatirGetir(); i++)
            {
                cmbStokBirimi.Properties.Items.Add("" + StokKarti.stokbirimi(i).ToString() + "");
            }
        }
        void Kaydet()
        {
            DefoluGiris.Defolu_EKLE(txt_tarih.Text, txtStokKodu.Text, txtModelNo.Text.ToUpper(), txtUrunGrubu.Text.ToUpper(), txtMiktar.Text, cmbStokBirimi.Text, cmbStokTuru.Text, cmbEtiketRengi.Text, txtDepoNo.Text.ToUpper(), txtRafNo.Text.ToUpper(), txtGozNo.Text.ToUpper(), txtAciklama.Text.ToUpper(), txtKoliNo.Text.ToUpper());
            Mesajlar.Bilgi("Defolu giriş kaydı yapıldı...");
        }
        private void Temizle()
        {
            txtStokKodu.Text = "";
            cmbStokTuru.Text = "";
            cmbStokBirimi.Text = "";
            cmbEtiketRengi.Text = "";
            txtModelNo.Text = "";
            txtUrunGrubu.Text="";
            txtMiktar.Text = "";
            txtDepoNo.Text = "";
            txtRafNo.Text = "";
            txtGozNo.Text = "";
            txtKoliNo.Text = "";
            txtAciklama.Text = "";
        }
        void Guncelle()
        {
            DefoluGiris.Defolu_GUNCELLE(UrunID, txt_tarih.Text, txtStokKodu.Text, txtModelNo.Text.ToUpper(), txtUrunGrubu.Text.ToUpper(), txtMiktar.Text, cmbStokBirimi.Text, cmbStokTuru.Text, cmbEtiketRengi.Text, txtDepoNo.Text.ToUpper(), txtRafNo.Text.ToUpper(), txtGozNo.Text.ToUpper(), txtAciklama.Text.ToUpper(), txtKoliNo.Text.ToUpper());
            Mesajlar.Bilgi("Defolu güncellemesi yapıldı...");
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit)
            {
                if (cmbStokTuru.Text != "GENEL STOK")
                {
                    if (txtModelNo.Text != "")
                    {
                        if (txtUrunGrubu.Text != "")
                        {
                            if (txtMiktar.Text != "")
                            {
                                if (cmbStokBirimi.Text != "")
                                {
                                    Guncelle();
                                    Temizle();
                                    Edit = false;
                                }
                                else
                                {
                                    Mesajlar.Uyari("Stok Birimini belirtmediniz...");
                                }
                            }
                            else
                            {
                                Mesajlar.Uyari("Arızalı miktarını girmediniz....");
                            }
                        }
                        else
                        {
                            Mesajlar.Uyari("Ürün grubunu belirmeniz gerekmektedir.");
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Model Numarasını belirtmediniz...");

                    }
                }
                else
                {
                    if (txtStokKodu.Text != "")
                    {
                        if (txtMiktar.Text != "")
                        {
                            if (cmbStokBirimi.Text != "")
                            {
                                Guncelle();
                                Temizle();
                                Edit = false;
                            }
                            else
                            {
                                Mesajlar.Uyari("Stok Birimini belirtmediniz...");
                            }
                        }
                        else
                        {
                            Mesajlar.Uyari("Arızalı miktarını girmediniz....");
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Stok Kodu nu boş bırakamazsınız,Lütfen ürün seçiniz...");
                    }
                }
            }
            else
            {
                if (cmbStokTuru.Text != "GENEL STOK")
                {
                    if (txtModelNo.Text != "")
                    {
                        if (txtUrunGrubu.Text != "")
                        {
                            if (txtMiktar.Text != "")
                            {
                                if (cmbStokBirimi.Text != "")
                                {
                                    Kaydet();
                                    Temizle();
                                }
                                else
                                {
                                    Mesajlar.Uyari("Stok Birimini belirtmediniz...");
                                }
                            }
                            else
                            {
                                Mesajlar.Uyari("Arızalı miktarını girmediniz....");
                            }
                        }
                        else
                        {
                            Mesajlar.Uyari("Ürün grubunu belirmeniz gerekmektedir.");
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Model Numarasını belirtmediniz...");

                    }
                }
                else
                {
                    if (txtStokKodu.Text != "")
                    {
                        if (txtMiktar.Text != "")
                        {
                            if (cmbStokBirimi.Text != "")
                            {
                                Kaydet();
                                Temizle();
                            }
                            else
                            {
                                Mesajlar.Uyari("Stok Birimini belirtmediniz...");
                            }
                        }
                        else
                        {
                            Mesajlar.Uyari("Arızalı miktarını girmediniz....");
                        }
                    }
                    else
                    {
                        Mesajlar.Uyari("Stok Kodu nu boş bırakamazsınız,Lütfen ürün seçiniz...");
                    }
                }
            }
        }
        void DefoluBilgileriniCEK()
        {
          DataRow drow= DefoluGiris.DefoluBilgileri(UrunID);
          try
          {
              txt_tarih.Text=Formatlar.EskiyeCevirKısa(drow["TARIH"].ToString());
              txtStokKodu.Text = drow["STOK_KODU"].ToString();
              txtModelNo.Text = drow["MODEL_NO"].ToString();
              txtUrunGrubu.Text = drow["URUN_GRUBU"].ToString();
              cmbStokTuru.Text = drow["STOK_TURU"].ToString();
              txtMiktar.Text = drow["MIKTAR"].ToString();
              cmbStokBirimi.Text=drow["STOK_BIRIMI"].ToString();
              cmbEtiketRengi.Text=drow["ETIKET_RENGI"].ToString();
              txtDepoNo.Text=drow["DEPO_NO"].ToString();
              txtGozNo.Text=drow["GOZ_NO"].ToString();
              txtKoliNo.Text=drow["KOLI_NO"].ToString();
              txtRafNo.Text=drow["RAF_NO"].ToString();
              txtAciklama.Text = drow["ACIKLAMA"].ToString();
          }
          catch (Exception)
          {

              txt_tarih.Text = "";
              txtStokKodu.Text = "";
              txtModelNo.Text = "";
              txtUrunGrubu.Text = "";
              cmbStokTuru.Text = "";
              cmbStokBirimi.Text = "";
              cmbEtiketRengi.Text = "";
              txtDepoNo.Text = "";
              txtGozNo.Text = "";
              txtKoliNo.Text = "";
              txtRafNo.Text = "";
              txtAciklama.Text = "";
          }
        }
        private void frmDefoluGiris_Load(object sender, EventArgs e)
        {
            if (Edit)
            {
                StokBirimleriniYukle();
                EtiketRenkleriniYukle();
                StokTurleriniYukle();
                DefoluBilgileriniCEK();
            }
            else
            {
                StokBirimleriniYukle();
                EtiketRenkleriniYukle();
                StokTurleriniYukle();
                txt_tarih.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void btnStokKodBak_Click(object sender, EventArgs e)
        {
            UrunID = Ekranlar.StokKodListesiSorgulama(true);
            if (UrunID!="")
            {
                
                try
                {
                    DataRow drow = DefoluGiris.StokBilgileri(UrunID);
                    cmbStokTuru.Text = drow["STOK_TURU"].ToString();
                    txtStokKodu.Text = drow["STOK_KODU"].ToString();
                    txtModelNo.Text = drow["MODEL_NO"].ToString();
                    txtUrunGrubu.Text = drow["URUN_GRUBU"].ToString();
                    cmbStokBirimi.Text = drow["STOK_BIRIMI"].ToString();
                }
                catch (Exception)
                {

                    cmbStokTuru.Text = "";
                    txtStokKodu.Text = "";
                    txtModelNo.Text = "";
                    txtUrunGrubu.Text = "";
                    cmbStokBirimi.Text = "";
                }
            }
        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Temizle();
            Edit = false;
        }
    }
}