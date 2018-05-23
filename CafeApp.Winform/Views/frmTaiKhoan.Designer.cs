namespace CafeApp.Winform.Views
{
    partial class FrmTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaiKhoan));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnNapDuLieu = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnKhoiPhucMatKhau = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnThemTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlTaiKhoan = new DevExpress.XtraGrid.GridControl();
            this.gridViewTaiKhoan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDangNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSearchLookUpEditLoaiTaiKhoan = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEditLoaiTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
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
            this.btnNapDuLieu,
            this.btnLuu,
            this.btnKhoiPhucMatKhau,
            this.btnThemTaiKhoan,
            this.btnXoa,
            this.barButtonItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNapDuLieu),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLuu),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnKhoiPhucMatKhau)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnNapDuLieu
            // 
            this.btnNapDuLieu.Caption = "Nạp dữ liệu(F5)";
            this.btnNapDuLieu.Id = 0;
            this.btnNapDuLieu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNapDuLieu.ImageOptions.Image")));
            this.btnNapDuLieu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNapDuLieu.ImageOptions.LargeImage")));
            this.btnNapDuLieu.Name = "btnNapDuLieu";
            this.btnNapDuLieu.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnNapDuLieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnNapDuLieu_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu thay đổi(Ctrl+S)";
            this.btnLuu.Id = 1;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.LargeImage")));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnLuu_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xoá(Delete)";
            this.btnXoa.Id = 4;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.LargeImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnXoa_ItemClick);
            // 
            // btnKhoiPhucMatKhau
            // 
            this.btnKhoiPhucMatKhau.Caption = "Khôi phục mật khẩu(Ctrl+R)";
            this.btnKhoiPhucMatKhau.Id = 2;
            this.btnKhoiPhucMatKhau.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoiPhucMatKhau.ImageOptions.Image")));
            this.btnKhoiPhucMatKhau.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKhoiPhucMatKhau.ImageOptions.LargeImage")));
            this.btnKhoiPhucMatKhau.Name = "btnKhoiPhucMatKhau";
            this.btnKhoiPhucMatKhau.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnKhoiPhucMatKhau.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnKhoiPhucMatKhau_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(625, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 355);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(625, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 331);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(625, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 331);
            // 
            // btnThemTaiKhoan
            // 
            this.btnThemTaiKhoan.Caption = "Thêm tài khoản";
            this.btnThemTaiKhoan.Id = 3;
            this.btnThemTaiKhoan.Name = "btnThemTaiKhoan";
            this.btnThemTaiKhoan.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControlTaiKhoan);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(625, 331);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControlTaiKhoan
            // 
            this.gridControlTaiKhoan.Location = new System.Drawing.Point(12, 12);
            this.gridControlTaiKhoan.MainView = this.gridViewTaiKhoan;
            this.gridControlTaiKhoan.MenuManager = this.barManager1;
            this.gridControlTaiKhoan.Name = "gridControlTaiKhoan";
            this.gridControlTaiKhoan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSearchLookUpEditLoaiTaiKhoan});
            this.gridControlTaiKhoan.Size = new System.Drawing.Size(601, 307);
            this.gridControlTaiKhoan.TabIndex = 4;
            this.gridControlTaiKhoan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTaiKhoan});
            // 
            // gridViewTaiKhoan
            // 
            this.gridViewTaiKhoan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.TenDangNhap,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn1});
            this.gridViewTaiKhoan.GridControl = this.gridControlTaiKhoan;
            this.gridViewTaiKhoan.Name = "gridViewTaiKhoan";
            this.gridViewTaiKhoan.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridViewTaiKhoan.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewTaiKhoan.OptionsView.ShowAutoFilterRow = true;
            this.gridViewTaiKhoan.OptionsView.ShowGroupPanel = false;
            this.gridViewTaiKhoan.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.GridViewTaiKhoan_InitNewRow);
            this.gridViewTaiKhoan.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewTaiKhoan_CellValueChanged);
            // 
            // Id
            // 
            this.Id.Caption = "Mã tài khoản";
            this.Id.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = true;
            this.Id.VisibleIndex = 0;
            this.Id.Width = 51;
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.Caption = "Tên đăng nhập";
            this.TenDangNhap.FieldName = "TenDangNhap";
            this.TenDangNhap.Name = "TenDangNhap";
            this.TenDangNhap.Visible = true;
            this.TenDangNhap.VisibleIndex = 1;
            this.TenDangNhap.Width = 87;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Nhóm tài khoản";
            this.gridColumn3.ColumnEdit = this.repositoryItemSearchLookUpEditLoaiTaiKhoan;
            this.gridColumn3.FieldName = "IdNhom";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 87;
            // 
            // repositoryItemSearchLookUpEditLoaiTaiKhoan
            // 
            this.repositoryItemSearchLookUpEditLoaiTaiKhoan.AutoHeight = false;
            this.repositoryItemSearchLookUpEditLoaiTaiKhoan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEditLoaiTaiKhoan.DisplayMember = "TenNhom";
            this.repositoryItemSearchLookUpEditLoaiTaiKhoan.Name = "repositoryItemSearchLookUpEditLoaiTaiKhoan";
            this.repositoryItemSearchLookUpEditLoaiTaiKhoan.ValueMember = "IdNhom";
            this.repositoryItemSearchLookUpEditLoaiTaiKhoan.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Họ Tên";
            this.gridColumn4.FieldName = "HoTen";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 87;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Email";
            this.gridColumn5.FieldName = "Email";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 87;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Số điện thoại";
            this.gridColumn6.FieldName = "SoDienThoai";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 87;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ghi Chú";
            this.gridColumn7.FieldName = "GhiChu";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 94;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "MK";
            this.gridColumn1.FieldName = "MatKhau";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(625, 331);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlTaiKhoan;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(605, 311);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 355);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmTaiKhoan";
            this.Text = "Tài khoản";
            this.Load += new System.EventHandler(this.FrmTaiKhoan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTaiKhoan_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEditLoaiTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnNapDuLieu;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControlTaiKhoan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTaiKhoan;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn TenDangNhap;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEditLoaiTaiKhoan;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraBars.BarButtonItem btnThemTaiKhoan;
        private DevExpress.XtraBars.BarButtonItem btnKhoiPhucMatKhau;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}