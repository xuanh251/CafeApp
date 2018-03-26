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
using CafeApp.Common;
using DevExpress.XtraGrid.Views.Grid;

namespace CafeApp.Winform.Views
{
    public partial class FrmTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public ModelQuanLiCafeDbContext Db { get; set; }
        public FrmTaiKhoan()
        {
            InitializeComponent();
            
            Db = new ModelQuanLiCafeDbContext();
            Db.LoaiTaiKhoans.Load();
            repositoryItemSearchLookUpEditLoaiTaiKhoan.DataSource = Db.LoaiTaiKhoans.Local.ToBindingList();
            repositoryItemSearchLookUpEditLoaiTaiKhoan.View.Columns.AddField("Ten").Visible = true;
            NapDuLieu();
            KeyPreview = true;
        }

        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
        
        }
        private void NapDuLieu()
        {
            try
            {
                Db = new ModelQuanLiCafeDbContext();
                Db.TaiKhoans.Load();
                gridControlTaiKhoan.DataSource = Db.TaiKhoans.Local.ToBindingList();
                gridViewTaiKhoan.RefreshData();
                gridViewTaiKhoan.BestFitColumns();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Xảy ra lỗi khi nạp dữ liệu!", "Nạp dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Luu()
        {
            try
            {
                gridControlTaiKhoan.EmbeddedNavigator.Buttons.DoClick(gridControlTaiKhoan.EmbeddedNavigator.Buttons.EndEdit);
                int dem = Db.SaveChanges();
                if (dem > 0)
                {
                    XtraMessageBox.Show("Đã lưu " + dem + " mẩu tin!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NapDuLieu();
                }
                else
                {
                    XtraMessageBox.Show("Không có gì để lưu!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Không lưu được!" + Environment.NewLine + ex.ToString(), "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Luu();
        }

        private void BtnNapDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NapDuLieu();
        }
        private TaiKhoan vitri;
        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xoa();
        }
        private void Xoa()
        {
            try
            {
                vitri = (TaiKhoan)gridViewTaiKhoan.GetFocusedRow();
                if (vitri == null) return;
                else if (Db.ChangeTracker.HasChanges())
                {
                    XtraMessageBox.Show("Bạn phải lưu dữ liệu vừa thêm/sửa trước khi xoá!", "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((XtraMessageBox.Show("Bạn có muốn xoá dữ liệu " + TaiKhoan.TableName + " này không?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    Db.TaiKhoans.Remove(vitri);
                    Db.SaveChanges();
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
                XtraMessageBox.Show("Không xoá được!" + Environment.NewLine + "Lỗi: "+ex.ToString(), "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void KhoiPhucMatKhau()
        {
            try
            {
                vitri = (TaiKhoan)gridViewTaiKhoan.GetFocusedRow();
                if (vitri == null) return;
                else if (Db.ChangeTracker.HasChanges())
                {
                    XtraMessageBox.Show("Bạn phải lưu dữ liệu vừa thêm/sửa trước khi khôi phục mật khẩu!", "Khôi phục mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((XtraMessageBox.Show("Bạn có muốn khôi phục mật khẩu cho tài khoản " + vitri.TenDangNhap + " này không?" + Environment.NewLine + "Mật khẩu mặc định: 123456", "Khôi phục mật khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    var tk = Db.TaiKhoans.Find(vitri.Id);
                    tk.MatKhau = Core.Encrypt(Core.MatKhauMacDinh);
                    Db.SaveChanges();
                    XtraMessageBox.Show("Đã thiết lập mật khẩu mặc định cho " + TaiKhoan.TableName + " " +tk.TenDangNhap + " thành công!", "Khôi phục mật khẩu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NapDuLieu();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Đã xảy ra lỗi!" + Environment.NewLine + "Lỗi: " + ex.ToString(), "Khôi phục mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnKhoiPhucMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiPhucMatKhau();
        }

        private void GridViewTaiKhoan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["MatKhau"], Core.Encrypt(Core.MatKhauMacDinh));
        }
    }
}