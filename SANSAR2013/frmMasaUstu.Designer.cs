namespace SANSAR2013
{
    partial class frmMasaUstu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarYeniSiparis = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSiparisListesi = new DevExpress.XtraNavBar.NavBarItem();
            this.navKonsinyeSiparisler = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navbarStokKarti = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarGenelStok = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarDefolular = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarStokHareketleri = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navbarMusteriKarti = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navSatisListesi = new DevExpress.XtraNavBar.NavBarItem();
            this.navSatisIadeleriListesi = new DevExpress.XtraNavBar.NavBarItem();
            this.navSatisIadeGirisi = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3,
            this.navBarGroup4});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navbarStokKarti,
            this.navbarGenelStok,
            this.navBarItem3,
            this.navbarMusteriKarti,
            this.navBarItem5,
            this.navBarDefolular,
            this.navBarStokHareketleri,
            this.navBarYeniSiparis,
            this.navBarSiparisListesi,
            this.navSatisListesi,
            this.navSatisIadeleriListesi,
            this.navSatisIadeGirisi,
            this.navKonsinyeSiparisler});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl1.Size = new System.Drawing.Size(139, 504);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("Caramel");
            this.navBarControl1.Click += new System.EventHandler(this.navBarControl1_Click);
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "Sipariş Yönetimi";
            this.navBarGroup3.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarYeniSiparis),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSiparisListesi),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navKonsinyeSiparisler)});
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // navBarYeniSiparis
            // 
            this.navBarYeniSiparis.Caption = "Yeni Sipariş";
            this.navBarYeniSiparis.LargeImage = global::SANSAR2013.Properties.Resources.siparis;
            this.navBarYeniSiparis.Name = "navBarYeniSiparis";
            this.navBarYeniSiparis.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarYeniSiparis_LinkClicked);
            // 
            // navBarSiparisListesi
            // 
            this.navBarSiparisListesi.Caption = "Sipariş Listesi";
            this.navBarSiparisListesi.LargeImage = global::SANSAR2013.Properties.Resources.siparis_listesi;
            this.navBarSiparisListesi.Name = "navBarSiparisListesi";
            this.navBarSiparisListesi.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarSiparisListesi_LinkClicked);
            // 
            // navKonsinyeSiparisler
            // 
            this.navKonsinyeSiparisler.Caption = "Konsinye Sipariş Listesi";
            this.navKonsinyeSiparisler.LargeImage = global::SANSAR2013.Properties.Resources.siparis_hareket;
            this.navKonsinyeSiparisler.Name = "navKonsinyeSiparisler";
            this.navKonsinyeSiparisler.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navKonsinyeSiparisler_LinkClicked);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Stok Yönetimi";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarStokKarti),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarGenelStok),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarDefolular),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarStokHareketleri)});
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.TopVisibleLinkIndex = 1;
            // 
            // navbarStokKarti
            // 
            this.navbarStokKarti.Caption = "Stok Kartı Aç";
            this.navbarStokKarti.LargeImage = global::SANSAR2013.Properties.Resources.stok_karti;
            this.navbarStokKarti.Name = "navbarStokKarti";
            this.navbarStokKarti.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navbarStokKarti_LinkClicked);
            // 
            // navbarGenelStok
            // 
            this.navbarGenelStok.Caption = "Genel Stok Listesi";
            this.navbarGenelStok.LargeImage = global::SANSAR2013.Properties.Resources.stok_listesi;
            this.navbarGenelStok.Name = "navbarGenelStok";
            this.navbarGenelStok.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navbarGenelStok_LinkClicked);
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "Servis Stok Listesi";
            this.navBarItem3.LargeImage = global::SANSAR2013.Properties.Resources.servis_stok;
            this.navBarItem3.Name = "navBarItem3";
            // 
            // navBarDefolular
            // 
            this.navBarDefolular.Caption = "Defolular";
            this.navBarDefolular.LargeImage = global::SANSAR2013.Properties.Resources.defolu_stok;
            this.navBarDefolular.Name = "navBarDefolular";
            // 
            // navBarStokHareketleri
            // 
            this.navBarStokHareketleri.Caption = "Stok Hareketleri";
            this.navBarStokHareketleri.Name = "navBarStokHareketleri";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Müşteri Yönetimi";
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarMusteriKarti),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem5)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navbarMusteriKarti
            // 
            this.navbarMusteriKarti.Caption = "Müşteri Kartı Aç";
            this.navbarMusteriKarti.LargeImage = global::SANSAR2013.Properties.Resources.musteri_karti;
            this.navbarMusteriKarti.Name = "navbarMusteriKarti";
            this.navbarMusteriKarti.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navbarMusteriKarti_LinkClicked);
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "Müşteri Listesi";
            this.navBarItem5.LargeImage = global::SANSAR2013.Properties.Resources.musteri_listesi;
            this.navBarItem5.Name = "navBarItem5";
            this.navBarItem5.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem5_LinkClicked);
            // 
            // navBarGroup4
            // 
            this.navBarGroup4.Caption = "Satış Yönetimi";
            this.navBarGroup4.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup4.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navSatisListesi),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navSatisIadeleriListesi),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navSatisIadeGirisi)});
            this.navBarGroup4.Name = "navBarGroup4";
            // 
            // navSatisListesi
            // 
            this.navSatisListesi.Caption = "Satış Listesi";
            this.navSatisListesi.LargeImage = global::SANSAR2013.Properties.Resources.satis_listesi;
            this.navSatisListesi.Name = "navSatisListesi";
            this.navSatisListesi.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navSatisListesi_LinkClicked);
            // 
            // navSatisIadeleriListesi
            // 
            this.navSatisIadeleriListesi.Caption = "Satış İadeleri Listesi";
            this.navSatisIadeleriListesi.LargeImage = global::SANSAR2013.Properties.Resources.satis_iade_listesi;
            this.navSatisIadeleriListesi.Name = "navSatisIadeleriListesi";
            this.navSatisIadeleriListesi.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navSatisIadeleriListesi_LinkClicked);
            // 
            // navSatisIadeGirisi
            // 
            this.navSatisIadeGirisi.Caption = "Satış İade Girişi";
            this.navSatisIadeGirisi.LargeImage = global::SANSAR2013.Properties.Resources.satis_iade1;
            this.navSatisIadeGirisi.Name = "navSatisIadeGirisi";
            this.navSatisIadeGirisi.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navSatisIadeGirisi_LinkClicked);
            // 
            // frmMasaUstu
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Center;
            this.BackgroundImageStore = global::SANSAR2013.Properties.Resources.masa_ustu;
            this.ClientSize = new System.Drawing.Size(833, 504);
            this.Controls.Add(this.navBarControl1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMasaUstu";
            this.Text = "Hoşgeldiniz...";
            this.Load += new System.EventHandler(this.frmMasaUstu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup4;
        private DevExpress.XtraNavBar.NavBarItem navbarStokKarti;
        private DevExpress.XtraNavBar.NavBarItem navbarGenelStok;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem navbarMusteriKarti;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarDefolular;
        private DevExpress.XtraNavBar.NavBarItem navBarStokHareketleri;
        public DevExpress.XtraNavBar.NavBarItem navBarYeniSiparis;
        private DevExpress.XtraNavBar.NavBarItem navBarSiparisListesi;
        private DevExpress.XtraNavBar.NavBarItem navSatisListesi;
        private DevExpress.XtraNavBar.NavBarItem navSatisIadeleriListesi;
        private DevExpress.XtraNavBar.NavBarItem navSatisIadeGirisi;
        private DevExpress.XtraNavBar.NavBarItem navKonsinyeSiparisler;
    }
}