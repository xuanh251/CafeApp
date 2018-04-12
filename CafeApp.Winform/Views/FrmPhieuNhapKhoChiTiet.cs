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
using CafeApp.Common;

namespace CafeApp.Winform.Views
{
    public partial class FrmPhieuNhapKhoChiTiet : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        private bool isThemMoi = true;
        private PhieuNhapKho phieu;
        private FrmPhieuNhapKho _pnk;
        public FrmPhieuNhapKhoChiTiet(FrmPhieuNhapKho pnk)
        {
            InitializeComponent();
            _pnk = pnk;
        }
        public void KhoiTao(PhieuNhapKho info, bool isCreateNew)
        {
            phieu = info;
            isThemMoi = isCreateNew;
            NapDuLieu();
        }
        private void NapDuLieu()
        {
            if (!isThemMoi)
            {
                gridViewChiTietPhieu.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                spinEditChietKhau.ReadOnly = true;
                searchLookUpEditDoiTac.ReadOnly = true;
                gridViewChiTietPhieu.OptionsBehavior.ReadOnly = true;
                memoEditGhiChu.ReadOnly = true;
            }
            BtnInPhieu.Enabled = isThemMoi;

            Text = isThemMoi ? "Thêm mới phiếu nhập kho" : "Chi tiết phiếu nhập kho " + phieu.SoHoaDon;
            db = new ModelQuanLiCafeDbContext();
            db.DoiTacs.Load();
            var listDoitac = from dt in db.DoiTacs.Local select new { dt.IdDoiTac, dt.Ten, dt.DiaChi };
            searchLookUpEditDoiTac.Properties.DataSource = listDoitac.ToList();
            db.TaiKhoans.Load();
            var listTaiKhoan = from tk in db.TaiKhoans.Local select new { tk.Id, tk.TenDangNhap, tk.HoTen };
            searchLookUpEditNguoiTao.Properties.DataSource = listTaiKhoan.ToList();
            NapDuLieuPhieu(phieu);
            db.NguyenLieux.Load();
            db.DonViTinhs.Load();
            var listNguyenLieu = from nl in db.NguyenLieux.Local
                                 join dvt in db.DonViTinhs.Local on nl.IdDVT equals dvt.IdDVT
                                 select new { nl.IdNguyenLieu, nl.Ten, DonViTinh = dvt.TenDVT };
            repositoryItemSearchLookUpEditNguyenLieu.DataSource = listNguyenLieu.ToList();
            NapDuLieuChiTiet();
        }
        private void NapDuLieuPhieu(PhieuNhapKho p)
        {
            if (p != null)
            {
                textEditSoPhieu.Text = p.SoHoaDon;
                searchLookUpEditDoiTac.EditValue = p.IdDoiTac;
                dateEditNgayTao.EditValue = p.NgayLapPhieu;
                searchLookUpEditNguoiTao.EditValue = p.NguoiTao;
                spinEditChietKhau.EditValue = p.ChietKhau;
                memoEditGhiChu.EditValue = p.GhiChu;
                labelControlTongTien.Text = p.TongTien.ToString("c0");
                labelControlTienChietKhau.Text = p.TienChietKhau.ToString("c0");
                labelControlThanhTien.Text = p.ThanhTien.ToString("c0");

            }
            else
            {
                textEditSoPhieu.Text = DateTime.Now.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
                searchLookUpEditDoiTac.EditValue = null;
                dateEditNgayTao.EditValue = DateTime.Now.Date;
                searchLookUpEditNguoiTao.EditValue = FrmDangNhap.IdTaiKhoan;
                spinEditChietKhau.EditValue = null;
                memoEditGhiChu.EditValue = null;
                labelControlTongTien.Text = Core.NullData;
                labelControlTienChietKhau.Text = Core.NullData;
                labelControlThanhTien.Text = Core.NullData;
            }
        }
        private void NapDuLieuChiTiet()
        {
            db = new ModelQuanLiCafeDbContext();
            db.PhieuNhapKhoChiTiets.Where(s => s.SoHoaDon == textEditSoPhieu.Text).Load();
            gridControlChiTietPhieu.DataSource = db.PhieuNhapKhoChiTiets.Local.ToBindingList();
            gridViewChiTietPhieu.RefreshData();
        }
        private void gridViewChiTietPhieu_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //GridView view = sender as GridView;

        }

        private void gridViewChiTietPhieu_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.Caption != "Nguyên liệu") return;
            var dongia = db.NguyenLieux.Find((int)e.Value).DonGia;
            view.SetRowCellValue(e.RowHandle, view.Columns["DonGia"], dongia);
            view.SetRowCellValue(e.RowHandle, view.Columns["SoHoaDon"], textEditSoPhieu.Text);
        }

        private void BtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var tempDb = new ModelQuanLiCafeDbContext();
            var p = tempDb.PhieuNhapKhoes.Where(s => s.SoHoaDon == textEditSoPhieu.Text).FirstOrDefault();
            if (p==null)//thêm mới
            {
                p = new PhieuNhapKho();
                p.SoHoaDon = textEditSoPhieu.Text;
                p.IdDoiTac = int.Parse(searchLookUpEditDoiTac.EditValue.ToString());
                p.NgayLapPhieu = dateEditNgayTao.DateTime;
                p.NguoiTao = int.Parse(searchLookUpEditNguoiTao.EditValue.ToString());
                p.ChietKhau = double.Parse(spinEditChietKhau.EditValue.ToString());
                p.GhiChu = memoEditGhiChu.EditValue != null ? memoEditGhiChu.EditValue.ToString() : null;
                tempDb.PhieuNhapKhoes.Add(p);
                tempDb.SaveChanges();
            }
            else
            {
                p.IdDoiTac = int.Parse(searchLookUpEditDoiTac.EditValue.ToString());
                p.ChietKhau = double.Parse(spinEditChietKhau.EditValue.ToString());
                p.GhiChu = memoEditGhiChu.EditValue != null ? memoEditGhiChu.EditValue.ToString() : null;
                tempDb.SaveChanges();
            }
            
            try
            {
                gridControlChiTietPhieu.EmbeddedNavigator.Buttons.DoClick(gridControlChiTietPhieu.EmbeddedNavigator.Buttons.EndEdit);
                int dem = db.SaveChanges();
                if (dem > 0)
                {
                    XtraMessageBox.Show("Đã lưu " + dem + " mẩu tin!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NapDuLieuChiTiet();
                }
               
                NapDuLieuPhieu(p);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Không lưu được!" + Environment.NewLine + ex.ToString(), "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoaNguyenLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuNhapKhoChiTiet vitri = null;
            try
            {
                vitri = (PhieuNhapKhoChiTiet)gridViewChiTietPhieu.GetFocusedRow();
                if (vitri == null) return;
                else if (db.ChangeTracker.HasChanges())
                {
                    XtraMessageBox.Show("Bạn phải lưu dữ liệu vừa thêm/sửa trước khi xoá!", "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((XtraMessageBox.Show("Bạn có muốn xoá dữ liệu này không?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    db.PhieuNhapKhoChiTiets.Remove(vitri);
                    db.SaveChanges();
                    XtraMessageBox.Show("Đã xoá thành công!", "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NapDuLieuChiTiet();
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

        private void FrmPhieuNhapKhoChiTiet_Load(object sender, EventArgs e)
        {

        }

        private void FrmPhieuNhapKhoChiTiet_FormClosed(object sender, FormClosedEventArgs e)
        {
            _pnk.NapDuLieu();
        }

        private void BtnInPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuNhapKho phieu = db.PhieuNhapKhoes.Where(s => s.SoHoaDon == textEditSoPhieu.Text).FirstOrDefault();
            if (isThemMoi) CapNhatSoLuongTon(phieu);
            _pnk.InPhieu(phieu);
        }
        private void CapNhatSoLuongTon(PhieuNhapKho phieu)
        {
            db = new ModelQuanLiCafeDbContext();
            var listPct = db.PhieuNhapKhoChiTiets.Where(s => s.SoHoaDon == phieu.SoHoaDon).ToList();
            foreach (var item in listPct)
            {
                var nl = db.NguyenLieux.Where(s => s.IdNguyenLieu == item.IdNguyenLieu).FirstOrDefault();
                nl.SoLuongTon += item.SoLuong;
            }
            db.SaveChanges();
        }
    }
}