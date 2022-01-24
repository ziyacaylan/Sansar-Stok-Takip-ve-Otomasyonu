using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace SANSAR2013
{
    public partial class AnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        /*TEMEL ERİŞİM DEĞİŞKENLERİ*/
        public static string AraDegiskenString;
        public static string UserId = "-1";
        public static DataTable Tablo;
        public static DataTable Tablo_Aksesuarlar;
        /*TEMEL ERİŞİM DEĞİŞKENLERİ*/

        public static Boolean GirisDurumu = false;
        //public static string UserId = "-1";
        public static string Username = "";
        public static string Adi = "";
        public static string Soyadi="";
        public static Boolean ErisimBilgisiHatasi = false;

        private DataTable Tablo_kurlar;

        SANSAR2013.Classlar.Ekranlar Ekranlar = new Classlar.Ekranlar();
        SANSAR2013.SiparisModulu.Classlar.clsYeniSiparis Siparis = new SiparisModulu.Classlar.clsYeniSiparis();
        SANSAR2013.Classlar.Veritabani DBase = new Classlar.Veritabani();
        Classlar.Formatlar Formatlar = new Classlar.Formatlar();
        SANSAR2013.EktralarModulu.Classlar.clsDovizKurlari Kurlar = new EktralarModulu.Classlar.clsDovizKurlari();
        Classlar.Mesajlar Mesajlar = new Classlar.Mesajlar();
        public AnaForm()
        {
            InitializeComponent();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            GirisIslemi();
            frmMasaUstu frm = new frmMasaUstu();
            frm.MdiParent = this;
            frm.Show();
            KullaniciGetir();
            Kurcek();
            if (AnaForm.Username != "admin")
            {
                barKonsinye_Sip_Listesi.Caption = "DENEME BUTONU";
            }
        }
        void Kurcek()
        {
            DateTime guncel_tarih = Convert.ToDateTime(Formatlar.EskiyeCevirKısa(Siparis.GüncelKurTarihi()));
            Tablo_kurlar = Kurlar.Kurlari_Cek(Formatlar.IngilizceTarihKısaFormat(Formatlar.IngilizceTarihKısaFormat(guncel_tarih.ToShortDateString())));
            string kayitli_birim;

            if (Siparis.KurTablosuBosmu())
            {
            for (int i = 0; i < Tablo_kurlar.Rows.Count; i++)
            {
                kayitli_birim = Tablo_kurlar.Rows[i]["KOD"].ToString();
                if (kayitli_birim == "USD")
                {
                    barDolar.EditValue = Tablo_kurlar.Rows[i]["DOVIZ_SATIS"].ToString();
                }
                if (kayitli_birim == "EUR")
                {
                    barEuro.EditValue = Tablo_kurlar.Rows[i]["DOVIZ_SATIS"].ToString();
                }
            }
            }
            else
            {
                Mesajlar.Uyari("Kur Tablosu BOŞ tur, lütfen kurları güncelleyiniz...");
            }
        }
        private void barStokKartiAc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.StokKartiAc(false, "-1");
        }

        private void barStokListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.StokListesiAc();
        }

        private void barMusteriKarti_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.MusteriKartiAc(false, "-1");
        }

        private void barYeniSiparis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.YeniSiparisAc(false,false,"-1",false);
        }

        private void barSiparisListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.SiparisListesiAc();
        }

        private void barMusteriListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.MusteriListesiAc();
        }

        private void barKonsinye_Sip_Listesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (AnaForm.Username == "admin")
            {
                Ekranlar.KonsinyeSiparisListesiAc();
            }
            else
            {
                barKonsinye_Sip_Listesi.Caption = "DENEME BUTONU";
            }
        }
        void GirisIslemi()
        {
            frmGiris Giris = new frmGiris();
            Giris.ShowDialog();
            if (GirisDurumu == false)
            {
                Application.Exit();
            }
            else
            {
                this.Opacity = 100; 
                this.Show();
            }
        }

        private void barSatisListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.SatisListesiAc();
        }
        private void KullaniciGetir()
        {
            barUser.Caption = ""+Adi+" "+Soyadi+"";
            barNow.Caption = DateTime.Now.ToShortDateString();
        }

        private void barCikis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barUrun_Grubu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.UrunGrubuAc(false);
        }

        private void barStokBirim_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.StokBirimiAc(false);
        }

        private void barIskontoGrubu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.IskontoGrubuAc(false);
        }

        private void barStokTuru_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.StokTuruAc(false);
        }

        private void barParaBirimleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.ParaBirimleriAc(false);
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.EtiketRengiAc(false);
        }

        private void barBayiiTuru_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.BayiilikTuruAc(false);
        }

        private void barKurlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.DovizKurları(false);
        }

        private void barKargolar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.KargolarAc(false);
        }

        private void barStok_Girisi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.StokGirisiAc(false,"0");
        }

        private void barStok_Giris_Listesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.TedarikListesiAc();
        }

        private void btnSatisIdeGiris_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.SatisIadeGiris(false, "0",false);
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.SatisIadeListesiAc();
        }

        private void barServisGiris_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.ServisGirisiAc(false, "-1","-1");
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.ServisGirisListesiAc();
        }

        private void barGenelStok_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.StokListesiAc();
        }

        private void barDefoluStok_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.DefoluGirisListesiAc();
        }

        private void btnAksesuarlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.AksesuarlarAC(false);
        }

        private void btnArizaKodlari_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.ArizaKodlariAc(false);
        }

        private void btnServisCikisListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.ServisCikisListesiAc();
        }

        private void barSatisHareketleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.Musteri_Urun_Satin_SORGULAMA();
        }
        private void btnSatisHareketRaporları_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.Musteri_Urun_Satin_SORGULAMA();
        }

        private void barKullaniciEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ekranlar.KullaniciEkle(false, "-1");
        }
    }
}