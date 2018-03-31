namespace CafeApp.Winform.Views
{
    partial class FrmChuyenBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChuyenBan));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.BtnChuyenViTri = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlViTri = new DevExpress.XtraGrid.GridControl();
            this.cardViewViTri = new DevExpress.XtraGrid.Views.Card.CardView();
            this.TenBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEditThongTinBan = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlViTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardViewViTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditThongTinBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.layoutControl2);
            this.layoutControl1.Controls.Add(this.BtnChuyenViTri);
            this.layoutControl1.Controls.Add(this.gridControlViTri);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(744, 376);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Location = new System.Drawing.Point(121, 12);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.Root;
            this.layoutControl2.Size = new System.Drawing.Size(611, 38);
            this.layoutControl2.TabIndex = 2;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(611, 38);
            this.Root.TextVisible = false;
            // 
            // BtnChuyenViTri
            // 
            this.BtnChuyenViTri.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnChuyenViTri.ImageOptions.Image")));
            this.BtnChuyenViTri.Location = new System.Drawing.Point(12, 12);
            this.BtnChuyenViTri.Name = "BtnChuyenViTri";
            this.BtnChuyenViTri.Size = new System.Drawing.Size(105, 38);
            this.BtnChuyenViTri.StyleController = this.layoutControl1;
            this.BtnChuyenViTri.TabIndex = 0;
            this.BtnChuyenViTri.Text = "Chuyển bàn";
            this.BtnChuyenViTri.Click += new System.EventHandler(this.BtnChuyenViTri_Click);
            // 
            // gridControlViTri
            // 
            this.gridControlViTri.Location = new System.Drawing.Point(12, 54);
            this.gridControlViTri.MainView = this.cardViewViTri;
            this.gridControlViTri.Name = "gridControlViTri";
            this.gridControlViTri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEditThongTinBan});
            this.gridControlViTri.Size = new System.Drawing.Size(720, 310);
            this.gridControlViTri.TabIndex = 3;
            this.gridControlViTri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardViewViTri});
            // 
            // cardViewViTri
            // 
            this.cardViewViTri.CardCaptionFormat = "{\"\"}";
            this.cardViewViTri.CardInterval = 4;
            this.cardViewViTri.CardWidth = 100;
            this.cardViewViTri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TenBan});
            this.cardViewViTri.FocusedCardTopFieldIndex = 0;
            this.cardViewViTri.GridControl = this.gridControlViTri;
            this.cardViewViTri.Name = "cardViewViTri";
            this.cardViewViTri.OptionsBehavior.Editable = false;
            this.cardViewViTri.OptionsBehavior.FieldAutoHeight = true;
            this.cardViewViTri.OptionsBehavior.ReadOnly = true;
            this.cardViewViTri.OptionsView.ShowCardCaption = false;
            this.cardViewViTri.OptionsView.ShowCardExpandButton = false;
            this.cardViewViTri.OptionsView.ShowEmptyFields = false;
            this.cardViewViTri.OptionsView.ShowFieldCaptions = false;
            this.cardViewViTri.OptionsView.ShowQuickCustomizeButton = false;
            this.cardViewViTri.OptionsView.ShowViewCaption = true;
            this.cardViewViTri.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardViewViTri.ViewCaption = "Danh sách bàn trống hiện tại";
            this.cardViewViTri.CustomDrawCardFieldValue += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.cardViewViTri_CustomDrawCardFieldValue);
            this.cardViewViTri.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.cardViewViTri_FocusedRowChanged);
            // 
            // TenBan
            // 
            this.TenBan.Caption = "Tên Bàn";
            this.TenBan.ColumnEdit = this.repositoryItemMemoEditThongTinBan;
            this.TenBan.FieldName = "ThongTinBan";
            this.TenBan.Name = "TenBan";
            this.TenBan.OptionsColumn.ReadOnly = true;
            this.TenBan.OptionsColumn.ShowCaption = false;
            this.TenBan.Visible = true;
            this.TenBan.VisibleIndex = 0;
            // 
            // repositoryItemMemoEditThongTinBan
            // 
            this.repositoryItemMemoEditThongTinBan.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemMemoEditThongTinBan.Name = "repositoryItemMemoEditThongTinBan";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(744, 376);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlViTri;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(724, 314);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.BtnChuyenViTri;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(109, 42);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.layoutControl2;
            this.layoutControlItem3.Location = new System.Drawing.Point(109, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(615, 42);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FrmChuyenBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 376);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChuyenBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển vị trí";
            this.Load += new System.EventHandler(this.FrmChuyenBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlViTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardViewViTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditThongTinBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControlViTri;
        private DevExpress.XtraGrid.Views.Card.CardView cardViewViTri;
        private DevExpress.XtraGrid.Columns.GridColumn TenBan;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton BtnChuyenViTri;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEditThongTinBan;
    }
}