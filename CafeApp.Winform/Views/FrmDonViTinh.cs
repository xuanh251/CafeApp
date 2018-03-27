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

namespace CafeApp.Winform.Views
{
    public partial class FrmDonViTinh : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public FrmDonViTinh()
        {
            InitializeComponent();
            KeyPreview = true;
            db = new ModelQuanLiCafeDbContext();
            NapDuLieu();
        }
        public void NapDuLieu()
        {
            db.DonViTinhs.Load();
            gridControlDonViTinh.DataSource = db.DonViTinhs.Local.ToBindingList();
            gridViewDonViTinh.RefreshData();
            gridViewDonViTinh.BestFitColumns();
        }

        private void BtnNapDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NapDuLieu();
        }

        private void BtnThemTuDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void BtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Luu();
        }
        private void Luu()
        {
            try
            {
                gridControlDonViTinh.EmbeddedNavigator.Buttons.DoClick(gridControlDonViTinh.EmbeddedNavigator.Buttons.EndEdit);
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

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xoa();
        }
        private DonViTinh vitri;
        private void Xoa()
        {
            try
            {
                vitri = (DonViTinh)gridViewDonViTinh.GetFocusedRow();
                if (vitri == null) return;
                else if (db.ChangeTracker.HasChanges())
                {
                    XtraMessageBox.Show("Bạn phải lưu dữ liệu vừa thêm/sửa trước khi xoá!", "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((XtraMessageBox.Show("Bạn có muốn xoá dữ liệu " + DonViTinh.TableName + " này không?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    db.DonViTinhs.Remove(vitri);
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

        private void FrmDonViTinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.F5)
            {
                BtnNapDuLieu_ItemClick(null, null);
            }
            if (e.Control&&e.KeyCode==Keys.N)
            {
                BtnThemTuDong_ItemClick(null, null);
            }
            if (e.Control&&e.KeyCode==Keys.S)
            {
                BtnLuu_ItemClick(null, null);
            }
            if (e.KeyCode==Keys.Delete)
            {
                BtnXoa_ItemClick(null, null);
            }
        }
    }
}