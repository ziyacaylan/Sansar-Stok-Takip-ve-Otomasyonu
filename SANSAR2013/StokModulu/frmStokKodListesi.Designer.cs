namespace SANSAR2013.StokModulu
{
    partial class frmStokKodListesi
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
            this.Liste = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STOK_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MODEL_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.URUN_GRUBU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STOK_BIRIMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STOK_TURU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtModelNo = new DevExpress.XtraEditors.TextEdit();
            this.txtStokKodu = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnUrunGrubu = new DevExpress.XtraEditors.ButtonEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnListele = new DevExpress.XtraEditors.SimpleButton();
            this.btnSorgula = new DevExpress.XtraEditors.SimpleButton();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStokKodu.Properties)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUrunGrubu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Liste
            // 
            this.Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Liste.Location = new System.Drawing.Point(0, 0);
            this.Liste.MainView = this.gridView1;
            this.Liste.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Liste.Name = "Liste";
            this.Liste.Size = new System.Drawing.Size(838, 358);
            this.Liste.TabIndex = 10;
            this.Liste.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.Liste.DoubleClick += new System.EventHandler(this.Liste_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.STOK_KODU,
            this.MODEL_NO,
            this.URUN_GRUBU,
            this.STOK_BIRIMI,
            this.STOK_TURU});
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
            // STOK_KODU
            // 
            this.STOK_KODU.Caption = "STOK KODU";
            this.STOK_KODU.FieldName = "STOK_KODU";
            this.STOK_KODU.Name = "STOK_KODU";
            this.STOK_KODU.OptionsColumn.AllowEdit = false;
            this.STOK_KODU.OptionsColumn.AllowFocus = false;
            this.STOK_KODU.OptionsColumn.FixedWidth = true;
            this.STOK_KODU.OptionsColumn.ReadOnly = true;
            this.STOK_KODU.Visible = true;
            this.STOK_KODU.VisibleIndex = 0;
            this.STOK_KODU.Width = 150;
            // 
            // MODEL_NO
            // 
            this.MODEL_NO.Caption = "MODEL NO";
            this.MODEL_NO.FieldName = "MODEL_NO";
            this.MODEL_NO.Name = "MODEL_NO";
            this.MODEL_NO.OptionsColumn.AllowEdit = false;
            this.MODEL_NO.OptionsColumn.AllowFocus = false;
            this.MODEL_NO.OptionsColumn.ReadOnly = true;
            this.MODEL_NO.Visible = true;
            this.MODEL_NO.VisibleIndex = 1;
            this.MODEL_NO.Width = 225;
            // 
            // URUN_GRUBU
            // 
            this.URUN_GRUBU.Caption = "ÜRÜN GRUBU";
            this.URUN_GRUBU.FieldName = "URUN_GRUBU";
            this.URUN_GRUBU.Name = "URUN_GRUBU";
            this.URUN_GRUBU.OptionsColumn.AllowEdit = false;
            this.URUN_GRUBU.OptionsColumn.AllowFocus = false;
            this.URUN_GRUBU.OptionsColumn.FixedWidth = true;
            this.URUN_GRUBU.OptionsColumn.ReadOnly = true;
            this.URUN_GRUBU.Visible = true;
            this.URUN_GRUBU.VisibleIndex = 2;
            this.URUN_GRUBU.Width = 177;
            // 
            // STOK_BIRIMI
            // 
            this.STOK_BIRIMI.Caption = "STOK BİRİMİ";
            this.STOK_BIRIMI.FieldName = "STOK_BIRIMI";
            this.STOK_BIRIMI.Name = "STOK_BIRIMI";
            this.STOK_BIRIMI.OptionsColumn.AllowEdit = false;
            this.STOK_BIRIMI.OptionsColumn.AllowFocus = false;
            this.STOK_BIRIMI.OptionsColumn.FixedWidth = true;
            this.STOK_BIRIMI.OptionsColumn.ReadOnly = true;
            this.STOK_BIRIMI.Visible = true;
            this.STOK_BIRIMI.VisibleIndex = 3;
            this.STOK_BIRIMI.Width = 85;
            // 
            // STOK_TURU
            // 
            this.STOK_TURU.Caption = "STOK TÜRÜ";
            this.STOK_TURU.FieldName = "STOK_TURU";
            this.STOK_TURU.Name = "STOK_TURU";
            this.STOK_TURU.OptionsColumn.AllowEdit = false;
            this.STOK_TURU.OptionsColumn.AllowFocus = false;
            this.STOK_TURU.OptionsColumn.FixedWidth = true;
            this.STOK_TURU.OptionsColumn.ReadOnly = true;
            this.STOK_TURU.Visible = true;
            this.STOK_TURU.VisibleIndex = 4;
            this.STOK_TURU.Width = 126;
            // 
            // txtModelNo
            // 
            this.txtModelNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModelNo.Location = new System.Drawing.Point(10, 77);
            this.txtModelNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtModelNo.Properties.Appearance.Options.UseFont = true;
            this.txtModelNo.Size = new System.Drawing.Size(168, 19);
            this.txtModelNo.TabIndex = 0;
            // 
            // txtStokKodu
            // 
            this.txtStokKodu.Location = new System.Drawing.Point(10, 36);
            this.txtStokKodu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStokKodu.Name = "txtStokKodu";
            this.txtStokKodu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtStokKodu.Properties.Appearance.Options.UseFont = true;
            this.txtStokKodu.Size = new System.Drawing.Size(168, 19);
            this.txtStokKodu.TabIndex = 2;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnUrunGrubu);
            this.xtraTabPage1.Controls.Add(this.panelControl2);
            this.xtraTabPage1.Controls.Add(this.txtModelNo);
            this.xtraTabPage1.Controls.Add(this.txtStokKodu);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(187, 336);
            this.xtraTabPage1.Text = "Arama";
            // 
            // btnUrunGrubu
            // 
            this.btnUrunGrubu.Location = new System.Drawing.Point(10, 117);
            this.btnUrunGrubu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUrunGrubu.Name = "btnUrunGrubu";
            this.btnUrunGrubu.Properties.AllowFocused = false;
            this.btnUrunGrubu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnUrunGrubu.Properties.Appearance.Options.UseFont = true;
            this.btnUrunGrubu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnUrunGrubu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnUrunGrubu.Size = new System.Drawing.Size(168, 19);
            this.btnUrunGrubu.TabIndex = 3;
            this.btnUrunGrubu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnUrunGrubu_ButtonClick);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnListele);
            this.panelControl2.Controls.Add(this.btnSorgula);
            this.panelControl2.Controls.Add(this.btnKapat);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 211);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(187, 125);
            this.panelControl2.TabIndex = 3;
            // 
            // btnListele
            // 
            this.btnListele.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnListele.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnListele.Appearance.Options.UseFont = true;
            this.btnListele.Image = global::SANSAR2013.Properties.Resources.tumunu_goster;
            this.btnListele.Location = new System.Drawing.Point(14, 46);
            this.btnListele.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListele.Name = "btnListele";
            this.btnListele.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnListele.Size = new System.Drawing.Size(135, 34);
            this.btnListele.TabIndex = 1;
            this.btnListele.Text = "Tümünü Göster";
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // btnSorgula
            // 
            this.btnSorgula.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSorgula.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSorgula.Appearance.Options.UseFont = true;
            this.btnSorgula.Image = global::SANSAR2013.Properties.Resources.arama;
            this.btnSorgula.Location = new System.Drawing.Point(14, 8);
            this.btnSorgula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSorgula.Size = new System.Drawing.Size(135, 34);
            this.btnSorgula.TabIndex = 0;
            this.btnSorgula.Text = "SORGULA";
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnKapat.Appearance.Options.UseFont = true;
            this.btnKapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKapat.Image = global::SANSAR2013.Properties.Resources.kapat;
            this.btnKapat.Location = new System.Drawing.Point(10, 84);
            this.btnKapat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(135, 34);
            this.btnKapat.TabIndex = 2;
            this.btnKapat.Text = "Kapat [ESC]";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 100);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Ürün Grubu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 58);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Model Numarası";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Stok Kodu";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(189, 358);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1061, 358);
            this.splitContainerControl1.SplitterPosition = 217;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // frmStokKodListesi
            // 
            this.AcceptButton = this.btnSorgula;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnKapat;
            this.ClientSize = new System.Drawing.Size(1061, 358);
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStokKodListesi";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Listesi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStokKodListesi_FormClosing);
            this.Load += new System.EventHandler(this.frmStokKodListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStokKodu.Properties)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUrunGrubu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl Liste;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn STOK_KODU;
        private DevExpress.XtraGrid.Columns.GridColumn MODEL_NO;
        private DevExpress.XtraGrid.Columns.GridColumn URUN_GRUBU;
        private DevExpress.XtraGrid.Columns.GridColumn STOK_BIRIMI;
        private DevExpress.XtraEditors.TextEdit txtModelNo;
        private DevExpress.XtraEditors.TextEdit txtStokKodu;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.SimpleButton btnListele;
        private DevExpress.XtraEditors.SimpleButton btnSorgula;
        private DevExpress.XtraEditors.ButtonEdit btnUrunGrubu;
        private DevExpress.XtraGrid.Columns.GridColumn STOK_TURU;
    }
}