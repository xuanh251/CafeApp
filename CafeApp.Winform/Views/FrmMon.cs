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
using System.IO;
using System.Diagnostics;

namespace CafeApp.Winform.Views
{
    public partial class FrmMon : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public FrmMon()
        {
            db = new ModelQuanLiCafeDbContext();
            InitializeComponent();
            KeyPreview = true;
            db.NhomMons.Load();
            repositoryItemSearchLookUpEditNhomThucDon.DataSource = db.NhomMons.Local.ToBindingList();
            repositoryItemSearchLookUpEditNhomThucDon.View.Columns.AddField("TenNhom").Visible = true;
            db.DonViTinhs.Load();
            repositoryItemSearchLookUpEditDonViTinh.DataSource = db.DonViTinhs.Local.ToBindingList();
            repositoryItemSearchLookUpEditDonViTinh.View.Columns.AddField("TenDVT").Visible = true;
            NapDuLieu();
        }
        private void NapDuLieu()
        {
            db.Mons.Load();
            gridControlThucDon.DataSource = db.Mons.Local.ToBindingList();
            gridViewThucDon.RefreshData();
            gridViewThucDon.BestFitColumns();
        }
        private void BtnNapDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NapDuLieu();
        }
        private void Luu()
        {
            try
            {
                gridControlThucDon.EmbeddedNavigator.Buttons.DoClick(gridControlThucDon.EmbeddedNavigator.Buttons.EndEdit);
                int dem = db.SaveChanges();
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
        private Mon vitri;
        private void Xoa()
        {
            try
            {
                vitri = (Mon)gridViewThucDon.GetFocusedRow();
                if (vitri == null) return;
                else if (db.ChangeTracker.HasChanges())
                {
                    XtraMessageBox.Show("Bạn phải lưu dữ liệu vừa thêm/sửa trước khi xoá!", "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((XtraMessageBox.Show("Bạn có muốn xoá dữ liệu " + Mon.TableName + " này không?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    db.Mons.Remove(vitri);
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
        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xoa();
        }

        private void BtnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fileName = string.Concat(Guid.NewGuid().ToString(), ".xls");
            string exportFilePath = string.Concat(Application.StartupPath, @"\", fileName);
            gridViewThucDon.ExportToXls(exportFilePath);

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

        private void FrmThucDon_KeyDown(object sender, KeyEventArgs e)
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
            if (e.Control && e.KeyCode == Keys.Q)
            {
                BtnXuatExcel_ItemClick(null, null);
            }
        }

        private void BtnXemLoiNhuan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vitri = (Mon)gridViewThucDon.GetFocusedRow();
            FrmChiTietLoiNhuan f = new FrmChiTietLoiNhuan();
            f.KhoiTao(vitri);
            f.ShowDialog();
        }
    }
}