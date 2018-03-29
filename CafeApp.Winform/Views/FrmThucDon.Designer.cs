namespace CafeApp.Winform.Views
{
    partial class FrmThucDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThucDon));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BtnNapDuLieu = new DevExpress.XtraBars.BarButtonItem();
            this.BtnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.BtnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.BtnXuatExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControlThucDon = new DevExpress.XtraGrid.GridControl();
            this.gridViewThucDon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSearchLookUpEditNhomThucDon = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSearchLookUpEditDonViTinh = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThucDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThucDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEditNhomThucDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEditDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.BtnLuu,
            this.BtnXoa,
            this.BtnXuatExcel});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BtnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BtnXuatExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            this.BtnLuu.Id = 1;
            this.BtnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnLuu.ImageOptions.Image")));
            this.BtnLuu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnLuu.ImageOptions.LargeImage")));
            this.BtnLuu.Name = "BtnLuu";
            this.BtnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnLuu_ItemClick);
            // 
            // BtnXoa
            // 
            this.BtnXoa.Caption = "Xoá(Delete)";
            this.BtnXoa.Id = 2;
            this.BtnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnXoa.ImageOptions.Image")));
            this.BtnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnXoa.ImageOptions.LargeImage")));
            this.BtnXoa.Name = "BtnXoa";
            this.BtnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnXoa_ItemClick);
            // 
            // BtnXuatExcel
            // 
            this.BtnXuatExcel.Caption = "Xuất Excel(Ctrl+Q)";
            this.BtnXuatExcel.Id = 3;
            this.BtnXuatExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnXuatExcel.ImageOptions.Image")));
            this.BtnXuatExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnXuatExcel.ImageOptions.LargeImage")));
            this.BtnXuatExcel.Name = "BtnXuatExcel";
            this.BtnXuatExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnXuatExcel_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(703, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 261);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(703, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 237);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(703, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 237);
            // 
            // gridControlThucDon
            // 
            this.gridControlThucDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlThucDon.Location = new System.Drawing.Point(0, 24);
            this.gridControlThucDon.MainView = this.gridViewThucDon;
            this.gridControlThucDon.MenuManager = this.barManager1;
            this.gridControlThucDon.Name = "gridControlThucDon";
            this.gridControlThucDon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSearchLookUpEditNhomThucDon,
            this.repositoryItemSearchLookUpEditDonViTinh});
            this.gridControlThucDon.Size = new System.Drawing.Size(703, 237);
            this.gridControlThucDon.TabIndex = 4;
            this.gridControlThucDon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewThucDon});
            // 
            // gridViewThucDon
            // 
            this.gridViewThucDon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridViewThucDon.GridControl = this.gridControlThucDon;
            this.gridViewThucDon.Name = "gridViewThucDon";
            this.gridViewThucDon.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewThucDon.OptionsView.ShowAutoFilterRow = true;
            this.gridViewThucDon.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên Món";
            this.gridColumn2.FieldName = "Ten";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Nhóm";
            this.gridColumn3.ColumnEdit = this.repositoryItemSearchLookUpEditNhomThucDon;
            this.gridColumn3.FieldName = "IdNhom";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // repositoryItemSearchLookUpEditNhomThucDon
            // 
            this.repositoryItemSearchLookUpEditNhomThucDon.AutoHeight = false;
            this.repositoryItemSearchLookUpEditNhomThucDon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEditNhomThucDon.DisplayMember = "Ten";
            this.repositoryItemSearchLookUpEditNhomThucDon.Name = "repositoryItemSearchLookUpEditNhomThucDon";
            this.repositoryItemSearchLookUpEditNhomThucDon.ValueMember = "Id";
            this.repositoryItemSearchLookUpEditNhomThucDon.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Đơn vị tính";
            this.gridColumn5.ColumnEdit = this.repositoryItemSearchLookUpEditDonViTinh;
            this.gridColumn5.FieldName = "IdDVT";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // repositoryItemSearchLookUpEditDonViTinh
            // 
            this.repositoryItemSearchLookUpEditDonViTinh.AutoHeight = false;
            this.repositoryItemSearchLookUpEditDonViTinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEditDonViTinh.DisplayMember = "Ten";
            this.repositoryItemSearchLookUpEditDonViTinh.Name = "repositoryItemSearchLookUpEditDonViTinh";
            this.repositoryItemSearchLookUpEditDonViTinh.ValueMember = "Id";
            this.repositoryItemSearchLookUpEditDonViTinh.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Đơn giá";
            this.gridColumn6.DisplayFormat.FormatString = "n0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "DonGia";
            this.gridColumn6.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ghi chú";
            this.gridColumn7.FieldName = "GhiChu";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // FrmThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 261);
            this.Controls.Add(this.gridControlThucDon);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmThucDon";
            this.Text = "Thực đơn";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmThucDon_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThucDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThucDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEditNhomThucDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEditDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem BtnNapDuLieu;
        private DevExpress.XtraBars.BarButtonItem BtnLuu;
        private DevExpress.XtraBars.BarButtonItem BtnXoa;
        private DevExpress.XtraBars.BarButtonItem BtnXuatExcel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControlThucDon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewThucDon;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEditNhomThucDon;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEditDonViTinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}