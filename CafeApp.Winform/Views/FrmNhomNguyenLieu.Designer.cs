namespace CafeApp.Winform.Views
{
    partial class FrmNhomNguyenLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNhomNguyenLieu));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BtnNapDuLieu = new DevExpress.XtraBars.BarButtonItem();
            this.BtnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.BtnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.BtnThemTuDong = new DevExpress.XtraBars.BarButtonItem();
            this.gridViewNhomNguyenLieu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlNhomNguyenLieu = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhomNguyenLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNhomNguyenLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BtnNapDuLieu,
            this.barButtonItem2,
            this.barEditItem1,
            this.barButtonItem3,
            this.barSubItem1,
            this.barEditItem2,
            this.barSubItem2,
            this.barButtonItem4,
            this.barButtonItem5,
            this.BtnLuu,
            this.BtnXoa,
            this.BtnThemTuDong});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 12;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BtnNapDuLieu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BtnLuu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BtnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BtnNapDuLieu
            // 
            this.BtnNapDuLieu.Caption = "Nạp dữ liệu(F5)";
            this.BtnNapDuLieu.Id = 0;
            this.BtnNapDuLieu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnNapDuLieu.ImageOptions.Image")));
            this.BtnNapDuLieu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnNapDuLieu.ImageOptions.LargeImage")));
            this.BtnNapDuLieu.Name = "BtnNapDuLieu";
            this.BtnNapDuLieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnNapDuLieu_ItemClick);
            // 
            // BtnLuu
            // 
            this.BtnLuu.Caption = "Lưu(Ctrl+S)";
            this.BtnLuu.Id = 9;
            this.BtnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnLuu.ImageOptions.Image")));
            this.BtnLuu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnLuu.ImageOptions.LargeImage")));
            this.BtnLuu.Name = "BtnLuu";
            this.BtnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnLuu_ItemClick);
            // 
            // BtnXoa
            // 
            this.BtnXoa.Caption = "Xoá(Delete)";
            this.BtnXoa.Id = 10;
            this.BtnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnXoa.ImageOptions.Image")));
            this.BtnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnXoa.ImageOptions.LargeImage")));
            this.BtnXoa.Name = "BtnXoa";
            this.BtnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnXoa_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(702, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 298);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(702, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 274);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(702, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 274);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 2;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 4;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "barEditItem2";
            this.barEditItem2.Edit = this.repositoryItemTextEdit2;
            this.barEditItem2.Id = 5;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "barSubItem2";
            this.barSubItem2.Id = 6;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 7;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Thêm tự động";
            this.barButtonItem5.Id = 8;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // BtnThemTuDong
            // 
            this.BtnThemTuDong.Caption = "Thêm tự động(Ctrl+N)";
            this.BtnThemTuDong.Id = 11;
            this.BtnThemTuDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnThemTuDong.ImageOptions.Image")));
            this.BtnThemTuDong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnThemTuDong.ImageOptions.LargeImage")));
            this.BtnThemTuDong.Name = "BtnThemTuDong";
            this.BtnThemTuDong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnThemTuDong_ItemClick);
            // 
            // gridViewNhomNguyenLieu
            // 
            this.gridViewNhomNguyenLieu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridViewNhomNguyenLieu.GridControl = this.gridControlNhomNguyenLieu;
            this.gridViewNhomNguyenLieu.Name = "gridViewNhomNguyenLieu";
            this.gridViewNhomNguyenLieu.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewNhomNguyenLieu.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "IdNhom";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên nhóm";
            this.gridColumn2.FieldName = "TenNhom";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ghi chú";
            this.gridColumn3.FieldName = "GhiChu";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridControlNhomNguyenLieu
            // 
            this.gridControlNhomNguyenLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlNhomNguyenLieu.Location = new System.Drawing.Point(0, 24);
            this.gridControlNhomNguyenLieu.MainView = this.gridViewNhomNguyenLieu;
            this.gridControlNhomNguyenLieu.MenuManager = this.barManager1;
            this.gridControlNhomNguyenLieu.Name = "gridControlNhomNguyenLieu";
            this.gridControlNhomNguyenLieu.Size = new System.Drawing.Size(702, 274);
            this.gridControlNhomNguyenLieu.TabIndex = 4;
            this.gridControlNhomNguyenLieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNhomNguyenLieu});
            // 
            // FrmNhomNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 298);
            this.Controls.Add(this.gridControlNhomNguyenLieu);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmNhomNguyenLieu";
            this.Text = "Quản lí Nhóm nguyên liệu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmNhomNguyenLieu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhomNguyenLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNhomNguyenLieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem BtnNapDuLieu;
        private DevExpress.XtraBars.BarButtonItem BtnThemTuDong;
        private DevExpress.XtraBars.BarButtonItem BtnLuu;
        private DevExpress.XtraBars.BarButtonItem BtnXoa;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraGrid.GridControl gridControlNhomNguyenLieu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNhomNguyenLieu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}