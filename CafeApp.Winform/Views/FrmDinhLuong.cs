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
using DevExpress.XtraGrid;

namespace CafeApp.Winform.Views
{
    public partial class FrmDinhLuong : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        ModelQuanLiCafeDbContext dbDinhLuong { get; set; }
        private BindingList<DinhLuong> listDinhLuongs { get; set; }
        public FrmDinhLuong()
        {
            InitializeComponent();
            KeyPreview = true;
            NapDVT();
            NapDuLieu();
        }
        private void NapDVT()
        {
            db = new ModelQuanLiCafeDbContext();
            db.DonViTinhs.Load();
            db.NguyenLieux.Load();
            db.Mons.Load();
            repositoryItemSearchLookUpEditDVTMon.DataSource = db.DonViTinhs.Local.ToBindingList();
            repositoryItemSearchLookUpEditDVTNguyenLieu.DataSource = db.DonViTinhs.Local.ToBindingList();
            repositoryItemSearchLookUpEditMonDinhLuong.DataSource = db.Mons.Local.ToBindingList();
            repositoryItemSearchLookUpEditNguyenLieuDinhLuong.DataSource = db.NguyenLieux.Local.ToBindingList();
        }
        private void NapDuLieu()
        {
            db = new ModelQuanLiCafeDbContext();
            //load món
            db.NguyenLieux.Load();
            gridControlMon.DataSource = db.Mons.Local.ToBindingList();
            gridViewMon.RefreshData();
            gridViewMon.BestFitColumns();
            //load nguyên liêu
            db.Mons.Load();
            gridControlNguyenLieu.DataSource = db.NguyenLieux.Local.ToBindingList();
            gridViewNguyenLieu.RefreshData();
            gridViewNguyenLieu.BestFitColumns();

        }
        private NguyenLieu nguyenLieu;
        private Mon mon;
        private DinhLuong dinhLuong;
        private void gridViewMon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //load danh sách định lượng của món được chọn
            mon = (Mon)gridViewMon.GetFocusedRow();
            if (mon == null)
            {
                return;
            }
            LblTenMon.Caption = mon.Ten;
            NapDinhLuongChiTiet();
        }
        private void NapDinhLuongChiTiet()
        {
            dbDinhLuong = new ModelQuanLiCafeDbContext();
            dbDinhLuong.DinhLuongs.Where(s => s.IdMon == mon.IdMon).Load();
            listDinhLuongs = dbDinhLuong.DinhLuongs.Local.ToBindingList();
            gridControlDinhLuong.DataSource = listDinhLuongs;
            gridViewDinhLuong.RefreshData();
            gridViewDinhLuong.BestFitColumns();
        }

        private void CapNhatDinhLuong()
        {
            nguyenLieu = (NguyenLieu)gridViewNguyenLieu.GetFocusedRow();
            //kiểm tra xem món hiện tại có danh sách định lượng hay chưa
            var dl = listDinhLuongs.Where(s => s.IdMon == mon.IdMon).FirstOrDefault();
            if (dl == null)
            {//nếu chưa thì thêm mới
                listDinhLuongs.Add(new DinhLuong { IdMon = mon.IdMon, SoLuongMon = 1, IdNguyenLieu = nguyenLieu.IdNguyenLieu, SoLuongNguyenLieu = 1 });
            }
            else
            {//nếu có rồi thì kiểm tra nguyên liệu được chọn có trong danh sách định lượng hay chưa
                var nl = listDinhLuongs.Where(s => s.IdMon == mon.IdMon && s.IdNguyenLieu == nguyenLieu.IdNguyenLieu).FirstOrDefault();
                if (nl == null)//nếu chưa có thì thêm mới
                {
                    listDinhLuongs.Add(new DinhLuong { IdMon = mon.IdMon, SoLuongMon = 1, IdNguyenLieu = nguyenLieu.IdNguyenLieu, SoLuongNguyenLieu = 1 });
                }
                else
                {
                    nl.SoLuongNguyenLieu += 1;
                }

            }
            gridViewDinhLuong.RefreshData();
        }

        private void repositoryItemButtonEditChonMon_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CapNhatDinhLuong();
        }
        int gridViewNguyenLieuRowHandle = 0;
        int gridViewDinhLuongRowHandle = 0;
        int gridViewMonRowHandle = 0;
        private void LuuViTri()
        {
            //lưu vị trí hiện tại của các bảng
            mon = (Mon)gridViewMon.GetFocusedRow();
            dinhLuong = (DinhLuong)gridViewDinhLuong.GetFocusedRow();
            nguyenLieu = (NguyenLieu)gridViewNguyenLieu.GetFocusedRow();
            if (nguyenLieu != null)
            {
                gridViewNguyenLieuRowHandle = gridViewNguyenLieu.LocateByValue("IdNguyenLieu", nguyenLieu.IdNguyenLieu);
            }
            if (dinhLuong != null)
            {
                gridViewDinhLuongRowHandle = gridViewDinhLuong.LocateByValue("IdMon", dinhLuong.IdMon);
            }
            if (mon != null)
            {
                gridViewMonRowHandle = gridViewMon.LocateByValue("IdMon", mon.IdMon);
            }
        }
        private void NapViTri()
        {
            if (gridViewNguyenLieuRowHandle != GridControl.InvalidRowHandle)
            {
                gridViewNguyenLieu.FocusedRowHandle = gridViewNguyenLieuRowHandle;
            }
            if (gridViewDinhLuongRowHandle != GridControl.InvalidRowHandle)
            {
                gridViewDinhLuong.FocusedRowHandle = gridViewDinhLuongRowHandle;
            }
            if (gridViewMonRowHandle != GridControl.InvalidRowHandle)
            {
                gridViewMon.FocusedRowHandle = gridViewMonRowHandle;
            }
        }
        private void BtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Luu();
        }

        private void FrmDinhLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Luu();
            }
        }
        private void Luu()
        {
            try
            {
                //gridControlDinhLuong.
                var dem = dbDinhLuong.SaveChanges();
                if (dem > 0)
                {
                    XtraMessageBox.Show("Đã lưu công thức định lượng!", "Định lượng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LuuViTri();
                    NapDuLieu();
                    NapViTri();

                }
                else
                {
                    XtraMessageBox.Show("Chưa lưu được!", "Định lượng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Không lưu được!" + Environment.NewLine + ex.ToString(), "Định lượng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnXoaNL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XoaNL();
        }
        private void XoaNL()
        {
            var currNL = (DinhLuong)gridViewDinhLuong.GetFocusedRow();
            if (currNL == null) return;
            else
            {
                listDinhLuongs.Remove(currNL);
                gridViewDinhLuong.RefreshData();
            }
        }
        private void BtnNapDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NapDuLieu();
        }

        private void BtnXemCongThuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var mon = (Mon)gridViewMon.GetFocusedRow();
            if (mon==null)
            {
                XtraMessageBox.Show("Chưa chọn món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmCongThucDinhLuong f = new FrmCongThucDinhLuong();
            f.KhoiTao(mon);
            f.ShowDialog();
        }
    }
}