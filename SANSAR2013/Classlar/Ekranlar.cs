using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.Classlar
{
    class Ekranlar
    {
        public void StokKartiAc(Boolean Edit, string SecilenID)
        {
            SANSAR2013.StokModulu.frmStokKarti frm = new StokModulu.frmStokKarti();
            if (Edit == true)
            {
                frm.Edit = true;
                frm.UrunId = SecilenID;
                frm.ShowDialog();
            }
            else
            {
                frm.Edit = false;
                frm.ShowDialog();
            }
        }
        public string StokKodListesiSorgulama(Boolean Sec)
        {
            SANSAR2013.StokModulu.frmStokKodListesi frm = new StokModulu.frmStokKodListesi();
            frm.SecimIcinAcildimi = true;
            frm.ShowDialog();
            return AnaForm.AraDegiskenString;
        }
        public string MusteriKodListesiSorgulama(Boolean Sec,Boolean TedarikIcınmi)
        {
            if (TedarikIcınmi)
            {
                SANSAR2013.MusterıModulu.frmMusteriKodListesi frm = new MusterıModulu.frmMusteriKodListesi();
                frm.TedarikIcinmi = TedarikIcınmi;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.MusterıModulu.frmMusteriKodListesi frm = new MusterıModulu.frmMusteriKodListesi();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public string MusteriKartiAc(Boolean Edit, string SecilenID)
        {
            if (Edit)
            {
                SANSAR2013.MusterıModulu.frmMusteriKarti frm = new MusterıModulu.frmMusteriKarti();
                frm.Edit = true;
                frm.Musteri_ID = SecilenID;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.MusterıModulu.frmMusteriKarti frm = new MusterıModulu.frmMusteriKarti();
                frm.Edit = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }

        }
        public string KullaniciEkle(Boolean Edit, string SecilenID)
        {
            if (Edit)
            {
                SANSAR2013.Kullanicilar.frmKullaniciEkle frm = new Kullanicilar.frmKullaniciEkle();
                frm.Edit = true;
                frm.SecilenID = SecilenID;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.Kullanicilar.frmKullaniciEkle frm = new Kullanicilar.frmKullaniciEkle();
                frm.Edit = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public void StokListesiAc()
        {
            SANSAR2013.StokModulu.frmStokListesi frm = new StokModulu.frmStokListesi();
            frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
            frm.Show();
        }
        public void SatisIadeGiris(Boolean Edit, string KayitNO, Boolean KayıtStoklaraEklendimi)
        {
            if (KayıtStoklaraEklendimi)
            {
                SANSAR2013.SatisModulu.SatisIadeModulu.frmSatisIade frm = new SatisModulu.SatisIadeModulu.frmSatisIade();
                frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
                frm.Edit = false;
                frm.KayitNO = KayitNO;
                frm.KayıtStoklaraEklendimi = true;
                frm.Show();
            }
            else
            {
                if (Edit)
                {
                    SANSAR2013.SatisModulu.SatisIadeModulu.frmSatisIade frm = new SatisModulu.SatisIadeModulu.frmSatisIade();
                    frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
                    frm.Edit = true;
                    frm.KayitNO = KayitNO;
                    frm.KayıtStoklaraEklendimi = false;
                    frm.Show();
                }
                else
                {
                    SANSAR2013.SatisModulu.SatisIadeModulu.frmSatisIade frm = new SatisModulu.SatisIadeModulu.frmSatisIade();
                    frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
                    frm.Edit = false;
                    frm.KayitNO = KayitNO;
                    frm.KayıtStoklaraEklendimi = false;
                    frm.Show();
                }
            }
        }
        public void YeniSiparisAc(Boolean Edit,Boolean satisGoruntule, string SecilenID,Boolean stokhareketgoruntule)
        {
            if (stokhareketgoruntule)
            {
                SANSAR2013.SiparisModulu.frmYeniSiparis frm = new SiparisModulu.frmYeniSiparis();
                frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
                frm.satisGoruntule = true;
                frm.SiparisID = SecilenID;
                frm.stokhareketgoruntule = true;
                frm.Show();
            }
            else
            {
                if (satisGoruntule)
                {
                    SANSAR2013.SiparisModulu.frmYeniSiparis frm = new SiparisModulu.frmYeniSiparis();
                    frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
                    frm.satisGoruntule = true;
                    frm.SiparisID = SecilenID;
                    frm.Show();
                }
                else
                {
                    if (Edit)
                    {
                        SANSAR2013.SiparisModulu.frmYeniSiparis frm = new SiparisModulu.frmYeniSiparis();
                        frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
                        frm.Edit = true;
                        frm.SiparisID = SecilenID;
                        frm.Show();
                    }
                    else
                    {
                        SANSAR2013.SiparisModulu.frmYeniSiparis frm = new SiparisModulu.frmYeniSiparis();
                        frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
                        frm.Edit = false;
                        frm.Show();
                    }
                }
            }
        }
        public void SiparisListesiAc()
        {
            SANSAR2013.SiparisModulu.frmSiparisListesi frm = new SiparisModulu.frmSiparisListesi();
            frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
            frm.Show();
        }
        public void MusteriListesiAc()
        {
            SANSAR2013.MusterıModulu.frmMusteriListesi frm = new MusterıModulu.frmMusteriListesi();
            frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
            frm.Show();
        }
        public void KonsinyeSiparisListesiAc()
        {
            SANSAR2013.SiparisModulu.frmKonsinye_Siparis_Listesi frm = new SiparisModulu.frmKonsinye_Siparis_Listesi();
            frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
            frm.Show();
        }
        public void ServerAyarlari()
        {
            frmServerAyarlari frm = new frmServerAyarlari();
            frm.ShowDialog();
        }
        public void SatisListesiAc()
        {
            SANSAR2013.SatisModulu.frmSatisListesi frm = new SatisModulu.frmSatisListesi();
            frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
            frm.Show();
        }
        public void TedarikListesiAc()
        {
            SANSAR2013.StokModulu.StokGirisModulu.frmStokGirisListesi frm=new StokModulu.StokGirisModulu.frmStokGirisListesi();
            frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
            frm.Show();
        }
        //public void UrunGrubuAc()
        //{
        //    SANSAR2013.StokModulu.frmUrunGrubu frm = new StokModulu.frmUrunGrubu();
        //    frm.ShowDialog();
        //}
        public string UrunGrubuAc(Boolean Sec)
        {
            if (Sec == true)
            {
                SANSAR2013.StokModulu.frmUrunGrubu frm = new StokModulu.frmUrunGrubu();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.StokModulu.frmUrunGrubu frm = new StokModulu.frmUrunGrubu();
                frm.SecimIcinAcildimi = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public string StokBirimiAc(Boolean Sec)
        {
            if (Sec == true)
            {
                SANSAR2013.StokModulu.frmStokBirimi frm = new StokModulu.frmStokBirimi();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.StokModulu.frmStokBirimi frm = new StokModulu.frmStokBirimi();
                frm.SecimIcinAcildimi = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public string IskontoGrubuAc(Boolean Sec)
        {
            if (Sec == true)
            {
                SANSAR2013.StokModulu.frmIskontoGrubu frm = new StokModulu.frmIskontoGrubu();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.StokModulu.frmIskontoGrubu frm = new StokModulu.frmIskontoGrubu();
                frm.SecimIcinAcildimi = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public string StokTuruAc(Boolean Sec)
        {
            if (Sec == true)
            {
                SANSAR2013.StokModulu.frmStokTuru frm = new StokModulu.frmStokTuru();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.StokModulu.frmStokTuru frm = new StokModulu.frmStokTuru();
                frm.SecimIcinAcildimi = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public string ParaBirimleriAc(Boolean Sec)
        {
            if (Sec == true)
            {
                SANSAR2013.StokModulu.frmParaBirimleri frm = new StokModulu.frmParaBirimleri();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.StokModulu.frmParaBirimleri frm = new StokModulu.frmParaBirimleri();
                frm.SecimIcinAcildimi = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public string EtiketRengiAc(Boolean Sec)
        {
            if (Sec == true)
            {
                SANSAR2013.StokModulu.frmEtiketRengi frm = new StokModulu.frmEtiketRengi();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.StokModulu.frmEtiketRengi frm = new StokModulu.frmEtiketRengi();
                frm.SecimIcinAcildimi = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public string BayiilikTuruAc(Boolean Sec)
        {
            if (Sec == true)
            {
                SANSAR2013.MusterıModulu.frmBayiilik_Turu frm = new MusterıModulu.frmBayiilik_Turu();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.MusterıModulu.frmBayiilik_Turu frm = new MusterıModulu.frmBayiilik_Turu();
                frm.SecimIcinAcildimi = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public string Fis_No_Ac()
        {
            SANSAR2013.SiparisModulu.frmFisNo frm = new SiparisModulu.frmFisNo();
            frm.ShowDialog();
            return frm.FisNo;
        }
        public string Fatura_No_Ac(Boolean siparis,Boolean tedarik)
        {
            if (tedarik)
            {
                SANSAR2013.SiparisModulu.frmFaturaNo frm = new SiparisModulu.frmFaturaNo();
                frm.tedarik = tedarik;
                frm.ShowDialog();
                return frm.FaturaNo;
            }
            else
            {
                SANSAR2013.SiparisModulu.frmFaturaNo frm = new SiparisModulu.frmFaturaNo();
                frm.siparis = siparis;
                frm.ShowDialog();
                return frm.FaturaNo;
            }
        }
        public DataTable DovizKurlarıParaTablosu(Boolean Sec)
        {
            if (Sec)
            {
                SANSAR2013.EktralarModulu.frmDovizKurları frm = new EktralarModulu.frmDovizKurları();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.Tablo;
            }
            else
            {
                SANSAR2013.EktralarModulu.frmDovizKurları frm = new EktralarModulu.frmDovizKurları();
                frm.SecimIcinAcildimi = false;
                frm.ShowDialog();
                return AnaForm.Tablo;
            }
        }
        public string DovizKurları(Boolean Sec)
        {
            if (Sec)
            {
                SANSAR2013.EktralarModulu.frmDovizKurları frm = new EktralarModulu.frmDovizKurları();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.EktralarModulu.frmDovizKurları frm = new EktralarModulu.frmDovizKurları();
                frm.SecimIcinAcildimi = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public string KargolarAc(Boolean Sec)
        {

            if (Sec)
            {
                SANSAR2013.EktralarModulu.frmKargolar frm = new EktralarModulu.frmKargolar();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.EktralarModulu.frmKargolar frm = new EktralarModulu.frmKargolar();
                frm.SecimIcinAcildimi = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public string StokGirisiAc(Boolean Edit,string SecilenID)
        {
            if (Edit)
            {
                SANSAR2013.StokModulu.StokGirisModulu.frmStokGirisi frm = new StokModulu.StokGirisModulu.frmStokGirisi();
                frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
                frm.Goruntuleme = true;
                frm.KayitNO = SecilenID;
                frm.Show();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.StokModulu.StokGirisModulu.frmStokGirisi frm = new StokModulu.StokGirisModulu.frmStokGirisi();
                frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
                frm.Goruntuleme = false;
                frm.Show();
                return AnaForm.AraDegiskenString;
            }

        }
        public void SatisIadeListesiAc()
        {
            SANSAR2013.SatisModulu.SatisIadeModulu.frmSatisIadeListesi frm = new SatisModulu.SatisIadeModulu.frmSatisIadeListesi();
            frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
            frm.Show();
        }
        public void ServisGirisListesiAc()
        {
            SANSAR2013.TeknikServisModulu.frmServisBeklemeListesi frm = new TeknikServisModulu.frmServisBeklemeListesi();
            frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
            frm.Show();
        }
        public void ServisGirisiAc(Boolean Edit, string SecilenID,string Musteri_kodu)
        {
            if (Edit)
            {
                SANSAR2013.TeknikServisModulu.ServisGirisi.frmServisGirisi frm = new TeknikServisModulu.ServisGirisi.frmServisGirisi();
                frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
                frm.Edit = true;
                frm.MusteriKodu = Musteri_kodu;
                frm.servis_NO = SecilenID;
                frm.Show();
            }
            else
            {
                SANSAR2013.TeknikServisModulu.ServisGirisi.frmServisGirisi frm = new TeknikServisModulu.ServisGirisi.frmServisGirisi();
                frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
                frm.Show();
            }
        }
        public void ServisOlayFormuAc(string SecilenID,Boolean ServisCikisYapildimi)
        {
                SANSAR2013.TeknikServisModulu.TS_OlayModulu.frmOlayFormu frm = new TeknikServisModulu.TS_OlayModulu.frmOlayFormu();
                frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
                frm.servis_no = SecilenID;
                frm.ServisCikisYapildimi = ServisCikisYapildimi;
                frm.Show();
        }
        public void  DefoluGiris(string ID,Boolean Edit)
        {
            SANSAR2013.StokModulu.DefolularStokgu.frmDefoluGiris frm = new StokModulu.DefolularStokgu.frmDefoluGiris();
            if (Edit == true)
            {
                frm.Edit = true;
                frm.UrunID = ID;
                frm.ShowDialog();
            }
            else
            {
                frm.Edit = false;
                frm.ShowDialog();
            }
        }
        public void  DefoluGirisListesiAc()
        {
            SANSAR2013.StokModulu.DefolularStokgu.frmDefolularListesi frm = new StokModulu.DefolularStokgu.frmDefolularListesi();
            frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
            frm.Show();
        }
        public string Irsaliye_No_Ac()
        {
            SANSAR2013.TeknikServisModulu.frmIrsaliyeNO frm = new TeknikServisModulu.frmIrsaliyeNO();
            frm.ShowDialog();
            return frm.IrsaliyeNo;
        }
        public string AksesuarlarAC(Boolean Sec)
        {
            if (Sec == true)
            {
                SANSAR2013.EktralarModulu.frmAksesuarlar frm = new EktralarModulu.frmAksesuarlar();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.EktralarModulu.frmAksesuarlar frm = new EktralarModulu.frmAksesuarlar();
                frm.SecimIcinAcildimi = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public string ArizaKodlariAc(Boolean Sec)
        {
            if (Sec == true)
            {
                SANSAR2013.EktralarModulu.frmArizaKodlari frm = new EktralarModulu.frmArizaKodlari();
                frm.SecimIcinAcildimi = true;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
            else
            {
                SANSAR2013.EktralarModulu.frmArizaKodlari frm = new EktralarModulu.frmArizaKodlari();
                frm.SecimIcinAcildimi = false;
                frm.ShowDialog();
                return AnaForm.AraDegiskenString;
            }
        }
        public void ServisCikisListesiAc()
        {
            SANSAR2013.TeknikServisModulu.ServisCikis.frmServisCikisListesi frm = new TeknikServisModulu.ServisCikis.frmServisCikisListesi();
            frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
            frm.Show();
        }
        public void Musteri_Urun_Satin_SORGULAMA()
        {
            SANSAR2013.Raporlar.frmMusteriUrunSatisHareketi frm = new Raporlar.frmMusteriUrunSatisHareketi();
            frm.MdiParent = SANSAR2013.AnaForm.ActiveForm;
            frm.Show();
        }
    }
}
