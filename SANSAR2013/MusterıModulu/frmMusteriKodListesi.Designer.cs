namespace SANSAR2013.MusterıModulu
{
    partial class frmMusteriKodListesi
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
            this.btnBayiilikTuru = new DevExpress.XtraEditors.ButtonEdit();
            this.btnListele = new DevExpress.XtraEditors.SimpleButton();
            this.Liste = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MUSTERI_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FIRMA_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ADRES_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ILCE_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IL_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSorgula = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtSehir = new DevExpress.XtraEditors.TextEdit();
            this.txtFirmaAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtMusteriKodu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.btnBayiilikTuru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSehir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirmaAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBayiilikTuru
            // 
            this.btnBayiilikTuru.Location = new System.Drawing.Point(11, 165);
            this.btnBayiilikTuru.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBayiilikTuru.Name = "btnBayiilikTuru";
            this.btnBayiilikTuru.Properties.AllowFocused = false;
            this.btnBayiilikTuru.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnBayiilikTuru.Properties.Appearance.Options.UseFont = true;
            this.btnBayiilikTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnBayiilikTuru.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnBayiilikTuru.Size = new System.Drawing.Size(168, 19);
            this.btnBayiilikTuru.TabIndex = 3;
            this.btnBayiilikTuru.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnBayiilikTuru_ButtonClick);
            // 
            // btnListele
            // 
            this.btnListele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnListele.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnListele.Appearance.Options.UseFont = true;
            this.btnListele.Image = global::SANSAR2013.Properties.Resources.tumunu_goster;
            this.btnListele.Location = new System.Drawing.Point(11, 46);
            this.btnListele.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListele.Name = "btnListele";
            this.btnListele.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnListele.Size = new System.Drawing.Size(135, 34);
            this.btnListele.TabIndex = 1;
            this.btnListele.Text = "Tümünü Göster";
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // Liste
            // 
            this.Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Liste.Location = new System.Drawing.Point(0, 0);
            this.Liste.MainView = this.gridView1;
            this.Liste.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Liste.Name = "Liste";
            this.Liste.Size = new System.Drawing.Size(879, 379);
            this.Liste.TabIndex = 0;
            this.Liste.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.Liste.DoubleClick += new System.EventHandler(this.Liste_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.MUSTERI_KODU,
            this.FIRMA_ADI,
            this.ADRES_1,
            this.ILCE_1,
            this.IL_1});
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
            this.ID.OptionsColumn.FixedWidth = true;
            this.ID.OptionsColumn.ReadOnly = true;
            this.ID.Width = 150;
            // 
            // MUSTERI_KODU
            // 
            this.MUSTERI_KODU.Caption = "MÜŞTERİ KODU";
            this.MUSTERI_KODU.FieldName = "MUSTERI_KODU";
            this.MUSTERI_KODU.Name = "MUSTERI_KODU";
            this.MUSTERI_KODU.OptionsColumn.AllowEdit = false;
            this.MUSTERI_KODU.OptionsColumn.AllowFocus = false;
            this.MUSTERI_KODU.OptionsColumn.FixedWidth = true;
            this.MUSTERI_KODU.OptionsColumn.ReadOnly = true;
            this.MUSTERI_KODU.Visible = true;
            this.MUSTERI_KODU.VisibleIndex = 0;
            this.MUSTERI_KODU.Width = 150;
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
            this.FIRMA_ADI.VisibleIndex = 1;
            this.FIRMA_ADI.Width = 258;
            // 
            // ADRES_1
            // 
            this.ADRES_1.Caption = "ADRES";
            this.ADRES_1.FieldName = "ADRES_1";
            this.ADRES_1.Name = "ADRES_1";
            this.ADRES_1.OptionsColumn.AllowEdit = false;
            this.ADRES_1.OptionsColumn.AllowFocus = false;
            this.ADRES_1.OptionsColumn.FixedWidth = true;
            this.ADRES_1.OptionsColumn.ReadOnly = true;
            this.ADRES_1.Visible = true;
            this.ADRES_1.VisibleIndex = 2;
            this.ADRES_1.Width = 265;
            // 
            // ILCE_1
            // 
            this.ILCE_1.Caption = "İLÇE";
            this.ILCE_1.FieldName = "ILCE_1";
            this.ILCE_1.Name = "ILCE_1";
            this.ILCE_1.OptionsColumn.AllowEdit = false;
            this.ILCE_1.OptionsColumn.AllowFocus = false;
            this.ILCE_1.OptionsColumn.FixedWidth = true;
            this.ILCE_1.OptionsColumn.ReadOnly = true;
            this.ILCE_1.Visible = true;
            this.ILCE_1.VisibleIndex = 3;
            this.ILCE_1.Width = 195;
            // 
            // IL_1
            // 
            this.IL_1.Caption = "ŞEHİR";
            this.IL_1.FieldName = "IL_1";
            this.IL_1.Name = "IL_1";
            this.IL_1.OptionsColumn.AllowEdit = false;
            this.IL_1.OptionsColumn.AllowFocus = false;
            this.IL_1.OptionsColumn.FixedWidth = true;
            this.IL_1.OptionsColumn.ReadOnly = true;
            this.IL_1.Visible = true;
            this.IL_1.VisibleIndex = 4;
            this.IL_1.Width = 126;
            // 
            // btnSorgula
            // 
            this.btnSorgula.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSorgula.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSorgula.Appearance.Options.UseFont = true;
            this.btnSorgula.Image = global::SANSAR2013.Properties.Resources.arama;
            this.btnSorgula.Location = new System.Drawing.Point(11, 8);
            this.btnSorgula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSorgula.Size = new System.Drawing.Size(135, 34);
            this.btnSorgula.TabIndex = 0;
            this.btnSorgula.Text = "SORGULA";
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnListele);
            this.panelControl2.Controls.Add(this.btnSorgula);
            this.panelControl2.Controls.Add(this.btnKapat);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 228);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(183, 125);
            this.panelControl2.TabIndex = 20;
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKapat.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnKapat.Appearance.Options.UseFont = true;
            this.btnKapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKapat.Image = global::SANSAR2013.Properties.Resources.kapat;
            this.btnKapat.Location = new System.Drawing.Point(11, 84);
            this.btnKapat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(135, 34);
            this.btnKapat.TabIndex = 2;
            this.btnKapat.Text = "Kapat [ESC]";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 148);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Bayiilik Türü";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(189, 379);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnBayiilikTuru);
            this.xtraTabPage1.Controls.Add(this.panelControl2);
            this.xtraTabPage1.Controls.Add(this.txtSehir);
            this.xtraTabPage1.Controls.Add(this.txtFirmaAdi);
            this.xtraTabPage1.Controls.Add(this.txtMusteriKodu);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(183, 353);
            this.xtraTabPage1.Text = "Arama";
            // 
            // txtSehir
            // 
            this.txtSehir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSehir.Location = new System.Drawing.Point(11, 121);
            this.txtSehir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSehir.Name = "txtSehir";
            this.txtSehir.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtSehir.Properties.Appearance.Options.UseFont = true;
            this.txtSehir.Size = new System.Drawing.Size(167, 19);
            this.txtSehir.TabIndex = 2;
            // 
            // txtFirmaAdi
            // 
            this.txtFirmaAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFirmaAdi.Location = new System.Drawing.Point(10, 77);
            this.txtFirmaAdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirmaAdi.Name = "txtFirmaAdi";
            this.txtFirmaAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtFirmaAdi.Properties.Appearance.Options.UseFont = true;
            this.txtFirmaAdi.Size = new System.Drawing.Size(168, 19);
            this.txtFirmaAdi.TabIndex = 0;
            // 
            // txtMusteriKodu
            // 
            this.txtMusteriKodu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMusteriKodu.Location = new System.Drawing.Point(10, 36);
            this.txtMusteriKodu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMusteriKodu.Name = "txtMusteriKodu";
            this.txtMusteriKodu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtMusteriKodu.Properties.Appearance.Options.UseFont = true;
            this.txtMusteriKodu.Size = new System.Drawing.Size(168, 19);
            this.txtMusteriKodu.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 102);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Şehir";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 58);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Firma Adı";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Müşteri Kodu";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.Liste);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1101, 379);
            this.splitContainerControl1.SplitterPosition = 217;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // frmMusteriKodListesi
            // 
            this.AcceptButton = this.btnSorgula;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnKapat;
            this.ClientSize = new System.Drawing.Size(1101, 379);
            this.Controls.Add(this.splitContainerControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMusteriKodListesi";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Müşteri Listesi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMusteriKodListesi_FormClosing);
            this.Load += new System.EventHandler(this.frmMusteriKodListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnBayiilikTuru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSehir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirmaAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit btnBayiilikTuru;
        private DevExpress.XtraEditors.SimpleButton btnListele;
        private DevExpress.XtraGrid.GridControl Liste;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn MUSTERI_KODU;
        private DevExpress.XtraGrid.Columns.GridColumn FIRMA_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn ADRES_1;
        private DevExpress.XtraGrid.Columns.GridColumn ILCE_1;
        private DevExpress.XtraGrid.Columns.GridColumn IL_1;
        private DevExpress.XtraEditors.SimpleButton btnSorgula;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.TextEdit txtSehir;
        private DevExpress.XtraEditors.TextEdit txtFirmaAdi;
        private DevExpress.XtraEditors.TextEdit txtMusteriKodu;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}