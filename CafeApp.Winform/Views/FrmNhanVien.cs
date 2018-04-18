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
using System.IO;
using System.Diagnostics;

namespace CafeApp.Winform.Views
{
    public partial class FrmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public ModelQuanLiCafeDbContext Db { get; set; }
        public FrmNhanVien()
        {
            InitializeComponent();
            KeyPreview = true;
            Db = new ModelQuanLiCafeDbContext();
            Db.ChucVus.Load();
            repositoryItemSearchLookUpEditChucVu.DataSource = Db.ChucVus.Local.ToBindingList();
            repositoryItemSearchLookUpEditChucVu.View.Columns.AddField("Ten").Visible = true;
            NapDuLieu();
            KeyPreview = true;
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
        
        }
        private void NapDuLieu()
        {
            try
            {
                Db = new ModelQuanLiCafeDbContext();
                Db.NhanViens.Load();
                gridControlNhanVien.DataSource = Db.NhanViens.Local.ToBindingList();
                gridViewNhanVien.RefreshData();
                gridViewNhanVien.BestFitColumns();
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
                gridControlNhanVien.EmbeddedNavigator.Buttons.DoClick(gridControlNhanVien.EmbeddedNavigator.Buttons.EndEdit);
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
        private NhanVien vitri;
        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xoa();
        }
        private void Xoa()
        {
            try
            {
                vitri = (NhanVien)gridViewNhanVien.GetFocusedRow();
                if (vitri == null) return;
                else if (Db.ChangeTracker.HasChanges())
                {
                    XtraMessageBox.Show("Bạn phải lưu dữ liệu vừa thêm/sửa trước khi xoá!", "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((XtraMessageBox.Show("Bạn có muốn xoá dữ liệu " + NhanVien.TableName + " này không?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    Db.NhanViens.Remove(vitri);
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
        
        

        private void GridViewNhanVien_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["MatKhau"], Core.Encrypt(Core.MatKhauMacDinh));
        }

        private void FrmNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                BtnNapDuLieu_ItemClick(null, null);
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                BtnLuu_ItemClick(null, null);
            }
            if (e.KeyCode == Keys.Delete)
            {
                BtnXoa_ItemClick(null, null);
            }
            
        }

        private void BtnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fileName = string.Concat(Guid.NewGuid().ToString(), ".xls");
            string exportFilePath = string.Concat(Application.StartupPath, @"\", fileName);
            gridViewNhanVien.ExportToXls(exportFilePath);

            if (File.Exists(exportFilePath))
            {
                try
                {
                    //Try to open the file and let windows decide how to open it.
                    Process.Start(exportFilePath);
                }
                catch
                {
                    String msg = "Không thể mở tệp tin." + Environment.NewLine + Environment.NewLine + "Đường dẫn: " + exportFilePath;
                    XtraMessageBox.Show(msg, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Đường dẫn: " + exportFilePath;
                XtraMessageBox.Show(msg, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridViewNhanVien_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            var vitri = (NhanVien)gridViewNhanVien.GetFocusedRow();
            if (view == null) return;
            if (e.Column.Caption == "Số điện thoại")
            {
                string sdt = e.Value.ToString();
                if (!IsPhoneNumber(sdt))
                {
                    vitri.SoDienThoai = "";
                }
            }
        }
        public static bool IsPhoneNumber(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!Char.IsNumber(s[i])) return false;
            }
            return true;
        }
    }
}