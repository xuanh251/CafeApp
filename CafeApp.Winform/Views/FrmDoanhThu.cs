﻿using CafeApp.Model.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CafeApp.Winform.Views
{
    public partial class FrmDoanhThu : DevExpress.XtraEditors.XtraForm
    {
        private ModelQuanLiCafeDbContext db { get; set; }
        public const string TrongNgay = "Trong ngày";
        public const string TuNgayDenNgay = "Từ ngày đến ngày";
        public const string TatCa = "Tất cả";
        public string KieuLoc { get; set; } = TrongNgay;
        public DateTime TuNgay { get; set; } = DateTime.Now;
        public DateTime DenNgay { get; set; } = DateTime.Now;

        public FrmDoanhThu()
        {
            InitializeComponent();
            NapDuLieu();
            barEditItemKieuLoc.DataBindings.Add("EditValue", this, nameof(KieuLoc), false, DataSourceUpdateMode.OnPropertyChanged, TrongNgay);
            barEditItemTuNgay.DataBindings.Add("EditValue", this, nameof(TuNgay), false, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);
            barEditItemDenNgay.DataBindings.Add("EditValue", this, nameof(DenNgay), false, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);
        }

        private void barButtonItemNapDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TuNgay.Date > DenNgay.Date)
            {
                XtraMessageBox.Show("Giá trị Từ ngày không được nhỏ hơn giá trị Đến ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (TuNgay.Date > DateTime.Now.Date || DenNgay.Date > DateTime.Now.Date)
            {
                XtraMessageBox.Show("Ngày nhập vào phải nhỏ hơn hoặc bằng ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NapDuLieu();
        }

        public BindingList<HoaDon> query;

        private void NapDuLieu()
        {
            try
            {
                db = new ModelQuanLiCafeDbContext();
                db.Bans.Load();
                repositoryItemSearchLookUpEditBan.DataSource = db.Bans.Local.ToBindingList();
                db.Mons.Load();
                repositoryItemSearchLookUpEditMon.DataSource = db.Mons.Local.ToBindingList();
                db.HoaDons.Load();
                switch (KieuLoc)
                {
                    case TrongNgay:
                        var list = db.HoaDons.Local.Where(s => s.NgayTao.Date >= DateTime.Now.Date && s.NgayTao.Date <= DateTime.Now.Date).ToList();
                        query = new BindingList<HoaDon>(list);
                        break;

                    case TuNgayDenNgay:
                        var list1 = db.HoaDons.Local.Where(s => s.NgayTao.Date >= TuNgay.Date && s.NgayTao.Date <= DenNgay.Date).ToList();
                        query = new BindingList<HoaDon>(list1);
                        break;

                    case TatCa:
                        var list2 = db.HoaDons.Local.ToBindingList();
                        query = new BindingList<HoaDon>(list2);
                        break;

                    default:
                        break;
                }
                gridControlHoaDon.DataSource = query;
                gridViewHoaDon.RefreshData();
                gridViewHoaDon.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Xảy ra lỗi khi nạp dữ liệu" + Environment.NewLine + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridViewHoaDon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            NapDuLieuChiTiet();
        }

        private void NapDuLieuChiTiet()
        {
            var vitri = (HoaDon)gridViewHoaDon.GetFocusedRow();
            textEditBan.Text = vitri.Ban.TenBan;
            textEditNgayTao.Text = vitri.NgayTao.ToString();
            textEditNguoiTao.Text = vitri.TaiKhoan.TenDangNhap;
            textEditTrangThai.Text = vitri.STrangThai;
            textEditChietKhau.Text = vitri.ChietKhau.ToString();
            memoEditGhiChu.Text = vitri.GhiChu;
            db = new ModelQuanLiCafeDbContext();
            db.HoaDonChiTiets.Where(s => s.IdHoaDon == vitri.IdHoaDon).Load();
            gridControlChiTietPhieu.DataSource = db.HoaDonChiTiets.Local.ToBindingList();
            gridViewChiTietPhieu.RefreshData();
            gridViewChiTietPhieu.BestFitColumns();
            textEditTienChietKhau.Text = vitri.TienChietKhau.ToString("c0");
            textEditThanhTien.Text = vitri.ThanhTien.ToString("c0");
        }

        private void barButtonItemXemPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vitri = (HoaDon)gridViewHoaDon.GetFocusedRow();
            var report = new Reports.ReportPhieuThanhToan();
            var hd = db.HoaDons.Find(vitri.IdHoaDon);
            report.NapDuLieu(hd);
            var printTool = new ReportPrintTool(report);
            printTool.Report.CreateDocument(true);
            printTool.ShowPreview();
        }

        private void barButtonItemBieuDoDoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmBieuDoDoanhThu f = new FrmBieuDoDoanhThu();
            f.ShowDialog();
        }

        private void barEditItemKieuLoc_EditValueChanged(object sender, EventArgs e)
        {
            if (barEditItemKieuLoc.EditValue.ToString() == TuNgayDenNgay)
            {
                barEditItemTuNgay.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barEditItemDenNgay.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                barEditItemTuNgay.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barEditItemDenNgay.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
    }
}