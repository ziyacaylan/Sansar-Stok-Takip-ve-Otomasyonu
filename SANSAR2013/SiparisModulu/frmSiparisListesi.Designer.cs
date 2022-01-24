namespace SANSAR2013.SiparisModulu
{
    partial class frmSiparisListesi
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
            this.components = new System.ComponentModel.Container();
            this.Liste = new DevExpress.XtraGrid.GridControl();
            this.SagMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mn_Guncelle = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Yenile = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SIPARIS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FIS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FATURA_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FIRMA_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SIPARIS_VEREN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SIPARIS_GIREN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STOK_ONAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SIP_KALEM_ADET = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnSorgula = new DevExpress.XtraEditors.SimpleButton();
            this.btnTumunuGoster = new DevExpress.XtraEditors.SimpleButton();
            this.rdSiparisNo = new System.Windows.Forms.RadioButton();
            this.rdFaturaNo = new System.Windows.Forms.RadioButton();
            this.rdFisNo = new System.Windows.Forms.RadioButton();
            this.rdFirmaAdi = new System.Windows.Forms.RadioButton();
            this.txtSorSiparisNo = new DevExpress.XtraEditors.TextEdit();
            this.txtSorFaturaNo = new DevExpress.XtraEditors.TextEdit();
            this.txtSorFisNo = new DevExpress.XtraEditors.TextEdit();
            this.txtSorFirmaAdi = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtAdres = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtVergiNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.txtIlce = new DevExpress.XtraEditors.TextEdit();
            this.txtVergiDairesi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtSiparisVeren = new DevExpress.XtraEditors.TextEdit();
            this.txtBayiilikTuru = new DevExpress.XtraEditors.TextEdit();
            this.txtSehir = new DevExpress.XtraEditors.TextEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtTel = new DevExpress.XtraEditors.TextEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_FirmaAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.txt_musteri_Kodu = new DevExpress.XtraEditors.TextEdit();
            this.tmr_liste_yenile = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).BeginInit();
            this.SagMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSorSiparisNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSorFaturaNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSorFisNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSorFirmaAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiDairesi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiparisVeren.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBayiilikTuru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSehir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FirmaAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_musteri_Kodu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Liste
            // 
            this.Liste.ContextMenuStrip = this.SagMenu;
            this.Liste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Liste.Location = new System.Drawing.Point(0, 220);
            this.Liste.MainView = this.gridView1;
            this.Liste.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Liste.Name = "Liste";
            this.Liste.Size = new System.Drawing.Size(1050, 300);
            this.Liste.TabIndex = 0;
            this.Liste.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.Liste.Click += new System.EventHandler(this.Liste_Click);
            // 
            // SagMenu
            // 
            this.SagMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_Guncelle,
            this.mn_Yenile});
            this.SagMenu.Name = "SagMenu";
            this.SagMenu.Size = new System.Drawing.Size(144, 52);
            // 
            // mn_Guncelle
            // 
            this.mn_Guncelle.Image = global::SANSAR2013.Properties.Resources.guncelle;
            this.mn_Guncelle.Name = "mn_Guncelle";
            this.mn_Guncelle.Size = new System.Drawing.Size(143, 24);
            this.mn_Guncelle.Text = "Görüntüle";
            this.mn_Guncelle.Click += new System.EventHandler(this.mn_Guncelle_Click);
            // 
            // mn_Yenile
            // 
            this.mn_Yenile.Image = global::SANSAR2013.Properties.Resources.yenile_1;
            this.mn_Yenile.Name = "mn_Yenile";
            this.mn_Yenile.Size = new System.Drawing.Size(143, 24);
            this.mn_Yenile.Text = "Yenile";
            this.mn_Yenile.Click += new System.EventHandler(this.mn_Yenile_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.TARIH,
            this.SIPARIS_NO,
            this.FIS_NO,
            this.FATURA_NO,
            this.FIRMA_ADI,
            this.SIPARIS_VEREN,
            this.SIPARIS_GIREN,
            this.STOK_ONAY,
            this.SIP_KALEM_ADET,
            this.ACIKLAMA});
            this.gridView1.GridControl = this.Liste;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.OptionsColumn.AllowFocus = false;
            // 
            // TARIH
            // 
            this.TARIH.Caption = "TARİH";
            this.TARIH.FieldName = "TARIH";
            this.TARIH.Name = "TARIH";
            this.TARIH.OptionsColumn.AllowEdit = false;
            this.TARIH.OptionsColumn.AllowFocus = false;
            this.TARIH.OptionsColumn.AllowSize = false;
            this.TARIH.OptionsColumn.ReadOnly = true;
            this.TARIH.Visible = true;
            this.TARIH.VisibleIndex = 0;
            this.TARIH.Width = 84;
            // 
            // SIPARIS_NO
            // 
            this.SIPARIS_NO.Caption = "SİPARİŞ NO";
            this.SIPARIS_NO.FieldName = "SIPARIS_NO";
            this.SIPARIS_NO.Name = "SIPARIS_NO";
            this.SIPARIS_NO.OptionsColumn.AllowEdit = false;
            this.SIPARIS_NO.OptionsColumn.AllowFocus = false;
            this.SIPARIS_NO.OptionsColumn.AllowSize = false;
            this.SIPARIS_NO.OptionsColumn.ReadOnly = true;
            this.SIPARIS_NO.Visible = true;
            this.SIPARIS_NO.VisibleIndex = 1;
            this.SIPARIS_NO.Width = 84;
            // 
            // FIS_NO
            // 
            this.FIS_NO.Caption = "FİŞ NO";
            this.FIS_NO.FieldName = "FIS_NO";
            this.FIS_NO.Name = "FIS_NO";
            this.FIS_NO.OptionsColumn.AllowEdit = false;
            this.FIS_NO.OptionsColumn.AllowFocus = false;
            this.FIS_NO.OptionsColumn.ReadOnly = true;
            this.FIS_NO.Visible = true;
            this.FIS_NO.VisibleIndex = 2;
            this.FIS_NO.Width = 90;
            // 
            // FATURA_NO
            // 
            this.FATURA_NO.Caption = "FATURA NO";
            this.FATURA_NO.FieldName = "FATURA_NO";
            this.FATURA_NO.Name = "FATURA_NO";
            this.FATURA_NO.OptionsColumn.AllowEdit = false;
            this.FATURA_NO.OptionsColumn.AllowFocus = false;
            this.FATURA_NO.OptionsColumn.ReadOnly = true;
            this.FATURA_NO.Visible = true;
            this.FATURA_NO.VisibleIndex = 3;
            this.FATURA_NO.Width = 87;
            // 
            // FIRMA_ADI
            // 
            this.FIRMA_ADI.Caption = "FİRMA ADI";
            this.FIRMA_ADI.FieldName = "FIRMA_ADI";
            this.FIRMA_ADI.Name = "FIRMA_ADI";
            this.FIRMA_ADI.OptionsColumn.AllowEdit = false;
            this.FIRMA_ADI.OptionsColumn.AllowFocus = false;
            this.FIRMA_ADI.OptionsColumn.ReadOnly = true;
            this.FIRMA_ADI.Visible = true;
            this.FIRMA_ADI.VisibleIndex = 4;
            this.FIRMA_ADI.Width = 218;
            // 
            // SIPARIS_VEREN
            // 
            this.SIPARIS_VEREN.Caption = "SİPARİŞ VEREN";
            this.SIPARIS_VEREN.FieldName = "SIPARIS_VEREN";
            this.SIPARIS_VEREN.Name = "SIPARIS_VEREN";
            this.SIPARIS_VEREN.OptionsColumn.AllowEdit = false;
            this.SIPARIS_VEREN.OptionsColumn.AllowFocus = false;
            this.SIPARIS_VEREN.OptionsColumn.ReadOnly = true;
            this.SIPARIS_VEREN.Visible = true;
            this.SIPARIS_VEREN.VisibleIndex = 5;
            this.SIPARIS_VEREN.Width = 82;
            // 
            // SIPARIS_GIREN
            // 
            this.SIPARIS_GIREN.Caption = "SİPARİŞ ALAN";
            this.SIPARIS_GIREN.FieldName = "SIPARIS_GIREN";
            this.SIPARIS_GIREN.Name = "SIPARIS_GIREN";
            this.SIPARIS_GIREN.OptionsColumn.AllowEdit = false;
            this.SIPARIS_GIREN.OptionsColumn.AllowFocus = false;
            this.SIPARIS_GIREN.OptionsColumn.ReadOnly = true;
            this.SIPARIS_GIREN.Visible = true;
            this.SIPARIS_GIREN.VisibleIndex = 6;
            this.SIPARIS_GIREN.Width = 67;
            // 
            // STOK_ONAY
            // 
            this.STOK_ONAY.Caption = "STOK ONAY";
            this.STOK_ONAY.FieldName = "STOK_ONAY";
            this.STOK_ONAY.Name = "STOK_ONAY";
            this.STOK_ONAY.OptionsColumn.AllowEdit = false;
            this.STOK_ONAY.OptionsColumn.AllowFocus = false;
            this.STOK_ONAY.OptionsColumn.ReadOnly = true;
            this.STOK_ONAY.Visible = true;
            this.STOK_ONAY.VisibleIndex = 7;
            this.STOK_ONAY.Width = 67;
            // 
            // SIP_KALEM_ADET
            // 
            this.SIP_KALEM_ADET.Caption = "SİP.KALEM ADET";
            this.SIP_KALEM_ADET.FieldName = "SIP_KALEM_ADET";
            this.SIP_KALEM_ADET.Name = "SIP_KALEM_ADET";
            this.SIP_KALEM_ADET.OptionsColumn.AllowEdit = false;
            this.SIP_KALEM_ADET.OptionsColumn.AllowFocus = false;
            this.SIP_KALEM_ADET.OptionsColumn.ReadOnly = true;
            this.SIP_KALEM_ADET.Visible = true;
            this.SIP_KALEM_ADET.VisibleIndex = 8;
            this.SIP_KALEM_ADET.Width = 90;
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.Caption = "AÇIKLAMA";
            this.ACIKLAMA.FieldName = "ACIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.OptionsColumn.AllowEdit = false;
            this.ACIKLAMA.OptionsColumn.AllowFocus = false;
            this.ACIKLAMA.OptionsColumn.ReadOnly = true;
            this.ACIKLAMA.Visible = true;
            this.ACIKLAMA.VisibleIndex = 9;
            this.ACIKLAMA.Width = 163;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1050, 220);
            this.panelControl1.TabIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnSorgula);
            this.groupControl2.Controls.Add(this.btnTumunuGoster);
            this.groupControl2.Controls.Add(this.rdSiparisNo);
            this.groupControl2.Controls.Add(this.rdFaturaNo);
            this.groupControl2.Controls.Add(this.rdFisNo);
            this.groupControl2.Controls.Add(this.rdFirmaAdi);
            this.groupControl2.Controls.Add(this.txtSorSiparisNo);
            this.groupControl2.Controls.Add(this.txtSorFaturaNo);
            this.groupControl2.Controls.Add(this.txtSorFisNo);
            this.groupControl2.Controls.Add(this.txtSorFirmaAdi);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(583, 2);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(465, 216);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Sipariş Sorgulama";
            // 
            // btnSorgula
            // 
            this.btnSorgula.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSorgula.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSorgula.Appearance.Options.UseFont = true;
            this.btnSorgula.Image = global::SANSAR2013.Properties.Resources.arama;
            this.btnSorgula.Location = new System.Drawing.Point(180, 151);
            this.btnSorgula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSorgula.Size = new System.Drawing.Size(135, 34);
            this.btnSorgula.TabIndex = 59;
            this.btnSorgula.Text = "SORGULA";
            this.btnSorgula.Click += new System.EventHandler(this.simpleButton6_Click);
            // 
            // btnTumunuGoster
            // 
            this.btnTumunuGoster.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnTumunuGoster.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnTumunuGoster.Appearance.Options.UseFont = true;
            this.btnTumunuGoster.Image = global::SANSAR2013.Properties.Resources.tumunu_goster;
            this.btnTumunuGoster.Location = new System.Drawing.Point(320, 151);
            this.btnTumunuGoster.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTumunuGoster.Name = "btnTumunuGoster";
            this.btnTumunuGoster.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnTumunuGoster.Size = new System.Drawing.Size(135, 34);
            this.btnTumunuGoster.TabIndex = 58;
            this.btnTumunuGoster.Text = "Tümünü Göster";
            this.btnTumunuGoster.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // rdSiparisNo
            // 
            this.rdSiparisNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rdSiparisNo.AutoSize = true;
            this.rdSiparisNo.Location = new System.Drawing.Point(87, 123);
            this.rdSiparisNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdSiparisNo.Name = "rdSiparisNo";
            this.rdSiparisNo.Size = new System.Drawing.Size(141, 17);
            this.rdSiparisNo.TabIndex = 0;
            this.rdSiparisNo.TabStop = true;
            this.rdSiparisNo.Text = "Sipariş Nomarasına Göre";
            this.rdSiparisNo.UseVisualStyleBackColor = true;
            // 
            // rdFaturaNo
            // 
            this.rdFaturaNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rdFaturaNo.AutoSize = true;
            this.rdFaturaNo.Location = new System.Drawing.Point(87, 101);
            this.rdFaturaNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdFaturaNo.Name = "rdFaturaNo";
            this.rdFaturaNo.Size = new System.Drawing.Size(142, 17);
            this.rdFaturaNo.TabIndex = 0;
            this.rdFaturaNo.TabStop = true;
            this.rdFaturaNo.Text = "Fatura Numarasına Göre";
            this.rdFaturaNo.UseVisualStyleBackColor = true;
            // 
            // rdFisNo
            // 
            this.rdFisNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rdFisNo.AutoSize = true;
            this.rdFisNo.Location = new System.Drawing.Point(87, 77);
            this.rdFisNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdFisNo.Name = "rdFisNo";
            this.rdFisNo.Size = new System.Drawing.Size(123, 17);
            this.rdFisNo.TabIndex = 0;
            this.rdFisNo.TabStop = true;
            this.rdFisNo.Text = "Fiş Numarasına Göre";
            this.rdFisNo.UseVisualStyleBackColor = true;
            // 
            // rdFirmaAdi
            // 
            this.rdFirmaAdi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rdFirmaAdi.AutoSize = true;
            this.rdFirmaAdi.Location = new System.Drawing.Point(87, 55);
            this.rdFirmaAdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdFirmaAdi.Name = "rdFirmaAdi";
            this.rdFirmaAdi.Size = new System.Drawing.Size(107, 17);
            this.rdFirmaAdi.TabIndex = 0;
            this.rdFirmaAdi.TabStop = true;
            this.rdFirmaAdi.Text = "Firma Adına Göre";
            this.rdFirmaAdi.UseVisualStyleBackColor = true;
            // 
            // txtSorSiparisNo
            // 
            this.txtSorSiparisNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSorSiparisNo.Location = new System.Drawing.Point(237, 123);
            this.txtSorSiparisNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSorSiparisNo.Name = "txtSorSiparisNo";
            this.txtSorSiparisNo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtSorSiparisNo.Properties.Appearance.Options.UseFont = true;
            this.txtSorSiparisNo.Size = new System.Drawing.Size(216, 18);
            this.txtSorSiparisNo.TabIndex = 57;
            // 
            // txtSorFaturaNo
            // 
            this.txtSorFaturaNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSorFaturaNo.Location = new System.Drawing.Point(237, 101);
            this.txtSorFaturaNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSorFaturaNo.Name = "txtSorFaturaNo";
            this.txtSorFaturaNo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtSorFaturaNo.Properties.Appearance.Options.UseFont = true;
            this.txtSorFaturaNo.Size = new System.Drawing.Size(216, 18);
            this.txtSorFaturaNo.TabIndex = 57;
            // 
            // txtSorFisNo
            // 
            this.txtSorFisNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSorFisNo.Location = new System.Drawing.Point(237, 78);
            this.txtSorFisNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSorFisNo.Name = "txtSorFisNo";
            this.txtSorFisNo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtSorFisNo.Properties.Appearance.Options.UseFont = true;
            this.txtSorFisNo.Size = new System.Drawing.Size(216, 18);
            this.txtSorFisNo.TabIndex = 57;
            // 
            // txtSorFirmaAdi
            // 
            this.txtSorFirmaAdi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSorFirmaAdi.Location = new System.Drawing.Point(237, 55);
            this.txtSorFirmaAdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSorFirmaAdi.Name = "txtSorFirmaAdi";
            this.txtSorFirmaAdi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtSorFirmaAdi.Properties.Appearance.Options.UseFont = true;
            this.txtSorFirmaAdi.Size = new System.Drawing.Size(216, 18);
            this.txtSorFirmaAdi.TabIndex = 57;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtAdres);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtVergiNo);
            this.groupControl1.Controls.Add(this.labelControl15);
            this.groupControl1.Controls.Add(this.txtIlce);
            this.groupControl1.Controls.Add(this.txtVergiDairesi);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtSiparisVeren);
            this.groupControl1.Controls.Add(this.txtBayiilikTuru);
            this.groupControl1.Controls.Add(this.txtSehir);
            this.groupControl1.Controls.Add(this.labelControl19);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtTel);
            this.groupControl1.Controls.Add(this.labelControl20);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txt_FirmaAdi);
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Controls.Add(this.labelControl22);
            this.groupControl1.Controls.Add(this.txt_musteri_Kodu);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(581, 216);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Seçilen Sipariş Bilgileri";
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(128, 76);
            this.txtAdres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Properties.ReadOnly = true;
            this.txtAdres.Size = new System.Drawing.Size(445, 40);
            this.txtAdres.TabIndex = 46;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(18, 35);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 12);
            this.labelControl1.TabIndex = 64;
            this.labelControl1.Text = "Mişteri Kodu";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(16, 80);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(29, 12);
            this.labelControl3.TabIndex = 49;
            this.labelControl3.Text = "Adres";
            // 
            // txtVergiNo
            // 
            this.txtVergiNo.Location = new System.Drawing.Point(128, 183);
            this.txtVergiNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVergiNo.Name = "txtVergiNo";
            this.txtVergiNo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtVergiNo.Properties.Appearance.Options.UseFont = true;
            this.txtVergiNo.Properties.ReadOnly = true;
            this.txtVergiNo.Size = new System.Drawing.Size(175, 18);
            this.txtVergiNo.TabIndex = 56;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl15.Location = new System.Drawing.Point(315, 185);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(67, 12);
            this.labelControl15.TabIndex = 65;
            this.labelControl15.Text = "Sipariş Veren";
            // 
            // txtIlce
            // 
            this.txtIlce.Location = new System.Drawing.Point(393, 119);
            this.txtIlce.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIlce.Name = "txtIlce";
            this.txtIlce.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtIlce.Properties.Appearance.Options.UseFont = true;
            this.txtIlce.Properties.ReadOnly = true;
            this.txtIlce.Size = new System.Drawing.Size(180, 18);
            this.txtIlce.TabIndex = 48;
            // 
            // txtVergiDairesi
            // 
            this.txtVergiDairesi.Location = new System.Drawing.Point(128, 162);
            this.txtVergiDairesi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVergiDairesi.Name = "txtVergiDairesi";
            this.txtVergiDairesi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtVergiDairesi.Properties.Appearance.Options.UseFont = true;
            this.txtVergiDairesi.Properties.ReadOnly = true;
            this.txtVergiDairesi.Size = new System.Drawing.Size(175, 18);
            this.txtVergiDairesi.TabIndex = 55;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(16, 122);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(6, 12);
            this.labelControl4.TabIndex = 50;
            this.labelControl4.Text = "Il";
            // 
            // txtSiparisVeren
            // 
            this.txtSiparisVeren.Location = new System.Drawing.Point(393, 183);
            this.txtSiparisVeren.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSiparisVeren.Name = "txtSiparisVeren";
            this.txtSiparisVeren.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtSiparisVeren.Properties.Appearance.Options.UseFont = true;
            this.txtSiparisVeren.Properties.ReadOnly = true;
            this.txtSiparisVeren.Size = new System.Drawing.Size(180, 18);
            this.txtSiparisVeren.TabIndex = 57;
            // 
            // txtBayiilikTuru
            // 
            this.txtBayiilikTuru.Location = new System.Drawing.Point(393, 141);
            this.txtBayiilikTuru.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBayiilikTuru.Name = "txtBayiilikTuru";
            this.txtBayiilikTuru.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtBayiilikTuru.Properties.Appearance.Options.UseFont = true;
            this.txtBayiilikTuru.Properties.ReadOnly = true;
            this.txtBayiilikTuru.Size = new System.Drawing.Size(180, 18);
            this.txtBayiilikTuru.TabIndex = 52;
            // 
            // txtSehir
            // 
            this.txtSehir.Location = new System.Drawing.Point(128, 119);
            this.txtSehir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSehir.Name = "txtSehir";
            this.txtSehir.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtSehir.Properties.Appearance.Options.UseFont = true;
            this.txtSehir.Properties.ReadOnly = true;
            this.txtSehir.Size = new System.Drawing.Size(175, 18);
            this.txtSehir.TabIndex = 47;
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl19.Location = new System.Drawing.Point(16, 143);
            this.labelControl19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(35, 12);
            this.labelControl19.TabIndex = 61;
            this.labelControl19.Text = "Telefon";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(369, 122);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(18, 12);
            this.labelControl5.TabIndex = 51;
            this.labelControl5.Text = "Ilçe";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(128, 141);
            this.txtTel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTel.Name = "txtTel";
            this.txtTel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtTel.Properties.Appearance.Options.UseFont = true;
            this.txtTel.Properties.ReadOnly = true;
            this.txtTel.Size = new System.Drawing.Size(175, 18);
            this.txtTel.TabIndex = 53;
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl20.Location = new System.Drawing.Point(320, 143);
            this.labelControl20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(60, 12);
            this.labelControl20.TabIndex = 66;
            this.labelControl20.Text = "Bayiilik Türü";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(18, 56);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 12);
            this.labelControl2.TabIndex = 60;
            this.labelControl2.Text = "Firma Adı";
            // 
            // txt_FirmaAdi
            // 
            this.txt_FirmaAdi.Location = new System.Drawing.Point(128, 54);
            this.txt_FirmaAdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_FirmaAdi.Name = "txt_FirmaAdi";
            this.txt_FirmaAdi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txt_FirmaAdi.Properties.Appearance.Options.UseFont = true;
            this.txt_FirmaAdi.Properties.ReadOnly = true;
            this.txt_FirmaAdi.Size = new System.Drawing.Size(445, 18);
            this.txt_FirmaAdi.TabIndex = 58;
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl21.Location = new System.Drawing.Point(18, 164);
            this.labelControl21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(64, 12);
            this.labelControl21.TabIndex = 63;
            this.labelControl21.Text = "Vergi Dairesi";
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl22.Location = new System.Drawing.Point(18, 185);
            this.labelControl22.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(42, 12);
            this.labelControl22.TabIndex = 62;
            this.labelControl22.Text = "Vergi No";
            // 
            // txt_musteri_Kodu
            // 
            this.txt_musteri_Kodu.Location = new System.Drawing.Point(128, 32);
            this.txt_musteri_Kodu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_musteri_Kodu.Name = "txt_musteri_Kodu";
            this.txt_musteri_Kodu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.txt_musteri_Kodu.Properties.Appearance.Options.UseFont = true;
            this.txt_musteri_Kodu.Properties.ReadOnly = true;
            this.txt_musteri_Kodu.Size = new System.Drawing.Size(445, 18);
            this.txt_musteri_Kodu.TabIndex = 54;
            // 
            // tmr_liste_yenile
            // 
            this.tmr_liste_yenile.Enabled = true;
            this.tmr_liste_yenile.Interval = 50000;
            this.tmr_liste_yenile.Tick += new System.EventHandler(this.tmr_liste_yenile_Tick);
            // 
            // frmSiparisListesi
            // 
            this.AcceptButton = this.btnSorgula;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 520);
            this.Controls.Add(this.Liste);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSiparisListesi";
            this.ShowIcon = false;
            this.Text = "Sipariş Listesi";
            this.Activated += new System.EventHandler(this.frmSiparisListesi_Activated);
            this.Load += new System.EventHandler(this.frmSiparisListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).EndInit();
            this.SagMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSorSiparisNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSorFaturaNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSorFisNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSorFirmaAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiDairesi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiparisVeren.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBayiilikTuru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSehir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FirmaAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_musteri_Kodu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl Liste;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.RadioButton rdFirmaAdi;
        private System.Windows.Forms.RadioButton rdFaturaNo;
        private System.Windows.Forms.RadioButton rdFisNo;
        private DevExpress.XtraEditors.TextEdit txtSorFaturaNo;
        private DevExpress.XtraEditors.TextEdit txtSorFisNo;
        private DevExpress.XtraEditors.TextEdit txtSorFirmaAdi;
        private DevExpress.XtraEditors.MemoEdit txtAdres;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtVergiNo;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit txtIlce;
        private DevExpress.XtraEditors.TextEdit txtVergiDairesi;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSiparisVeren;
        private DevExpress.XtraEditors.TextEdit txtBayiilikTuru;
        private DevExpress.XtraEditors.TextEdit txtSehir;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtTel;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_FirmaAdi;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.TextEdit txt_musteri_Kodu;
        private DevExpress.XtraEditors.SimpleButton btnSorgula;
        private DevExpress.XtraEditors.SimpleButton btnTumunuGoster;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn SIPARIS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn FIS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn FATURA_NO;
        private DevExpress.XtraGrid.Columns.GridColumn FIRMA_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn SIPARIS_VEREN;
        private DevExpress.XtraGrid.Columns.GridColumn SIPARIS_GIREN;
        private DevExpress.XtraGrid.Columns.GridColumn STOK_ONAY;
        private DevExpress.XtraGrid.Columns.GridColumn SIP_KALEM_ADET;
        private DevExpress.XtraGrid.Columns.GridColumn ACIKLAMA;
        public System.Windows.Forms.Timer tmr_liste_yenile;
        private System.Windows.Forms.ContextMenuStrip SagMenu;
        private System.Windows.Forms.ToolStripMenuItem mn_Guncelle;
        private System.Windows.Forms.ToolStripMenuItem mn_Yenile;
        private System.Windows.Forms.RadioButton rdSiparisNo;
        private DevExpress.XtraEditors.TextEdit txtSorSiparisNo;
    }
}