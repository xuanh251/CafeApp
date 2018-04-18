using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CafeApp.Model.Models;
using System.Data.Entity;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;

namespace CafeApp.Winform.Views
{
    public partial class FrmPhieuNhapKho : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public DateTime TuNgay { get; set; } = DateTime.Now;
        public DateTime DenNgay { get; set; } = DateTime.Now;
        public FrmPhieuNhapKho()
        {
            InitializeComponent();
            barEditItemTuNgay.DataBindings.Add(nameof(barEditItemTuNgay.EditValue), this, nameof(TuNgay), true, DataSourceUpdateMode.OnPropertyChanged);
            barEditItemDenNgay.DataBindings.Add(nameof(barEditItemDenNgay.EditValue), this, nameof(DenNgay), true, DataSourceUpdateMode.OnPropertyChanged);
            KeyPreview = true;
            NapDuLieu();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        public void NapDuLieu()
        {
            db = new ModelQuanLiCafeDbContext();
            db.DoiTacs.Load();
            db.TaiKhoans.Load();
            var listDoiTac = from dt in db.DoiTacs.Local select new { dt.IdDoiTac, dt.Ten, dt.DiaChi, dt.SoDienThoai };
            var listTaiKhoan = from tk in db.TaiKhoans.Local select new { tk.Id, tk.TenDangNhap };
            repositoryItemSearchLookUpEditDoiTac.DataSource = listDoiTac.ToList();
            repositoryItemSearchLookUpEditNguoiTao.DataSource = listTaiKhoan.ToList();
            db.PhieuNhapKhoes.Load();
            gridControlPhieuNhapKho.DataSource = db.PhieuNhapKhoes.Local.ToBindingList();
            gridViewPhieuNhapKho.RefreshData();
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XoaPhieuNhapKho();
        }
        private void XoaPhieuNhapKho()
        {
            try
            {
                PhieuNhapKho vitri = (PhieuNhapKho)gridViewPhieuNhapKho.GetFocusedRow();
                if (vitri == null) return;
                else if (db.ChangeTracker.HasChanges())
                {
                    XtraMessageBox.Show("Bạn phải lưu dữ liệu vừa thêm/sửa trước khi xoá!", "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((XtraMessageBox.Show("Việc nãy sẽ xoá dữ liệu nhập kho của bạn! Bạn chắc chắn muốn xoá " + PhieuNhapKho.TableName + " này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    var ctp = db.PhieuNhapKhoChiTiets.Where(s => s.SoHoaDon == vitri.SoHoaDon).ToList();
                    db.PhieuNhapKhoChiTiets.RemoveRange(ctp);
                    db.PhieuNhapKhoes.Remove(vitri);
                    db.SaveChanges();
                    XtraMessageBox.Show("Đã xoá thành công!", "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NapDuLieu();
                }
                else
                {
                    XtraMessageBox.Show("Chưa xoá được!", "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Không xoá được!" + Environment.NewLine + "Lỗi: " + ex.ToString(), "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnNapChiTietPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vitri = (PhieuNhapKho)gridViewPhieuNhapKho.GetFocusedRow();
            FrmPhieuNhapKhoChiTiet f = new FrmPhieuNhapKhoChiTiet(this);
            f.KhoiTao(vitri,false);
            f.ShowDialog();
            
        }
        private void BtnInPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vitri = (PhieuNhapKho)gridViewPhieuNhapKho.GetFocusedRow();
            InPhieu(vitri);
        }
       
        public void InPhieu(PhieuNhapKho phieu)
        {
            if (phieu == null) return;
            var report = new Reports.ReportPhieuNhapKho();
            report.KhoiTao(phieu);
            var printTool = new ReportPrintTool(report);
            printTool.Report.CreateDocument(true);
            printTool.ShowPreview();
        }

        private void barButtonItemLocTheoThoiGian_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            db = new ModelQuanLiCafeDbContext();
            TuNgay = TuNgay.Date; DenNgay = DenNgay.Date;
            db.PhieuNhapKhoes.Where(p => p.NgayLapPhieu >= TuNgay && p.NgayLapPhieu <= DenNgay).Load();
            gridControlPhieuNhapKho.DataSource = db.PhieuNhapKhoes.Local.ToBindingList();
            gridViewPhieuNhapKho.RefreshData();
        }

        private void BtnTaoMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmPhieuNhapKhoChiTiet f = new FrmPhieuNhapKhoChiTiet(this);
            f.KhoiTao(null, true);
            f.ShowDialog();
            f.Text = "Thêm mới phiếu nhập kho";
        }

        private void gridViewPhieuNhapKho_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
        }
    }
}