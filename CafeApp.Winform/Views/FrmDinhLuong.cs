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
            db.ThucDons.Load();
            repositoryItemSearchLookUpEditDVT_NguyenLieu.DataSource = db.DonViTinhs.Local.ToBindingList();
            repositoryItemSearchLookUpEditDVT_Mon.DataSource = db.DonViTinhs.Local.ToBindingList();
            repositoryItemSearchLookUpEditNguyenLieu_DinhLuong.DataSource = db.NguyenLieux.Local.ToBindingList();
            repositoryItemSearchLookUpEditMon_DinhLuong.DataSource = db.ThucDons.Local.ToBindingList();
        }
        private void NapDuLieu()
        {
            db = new ModelQuanLiCafeDbContext();
            //load nguyên liêu
            db.NguyenLieux.Load();
            gridControlNguyenLieu.DataSource = db.NguyenLieux.Local.ToBindingList();
            gridViewNguyenLieu.RefreshData();
            gridViewNguyenLieu.BestFitColumns();
            //load món
            db.ThucDons.Load();
            gridControlMon.DataSource = db.ThucDons.Local.ToBindingList();
            gridViewMon.RefreshData();
            gridViewMon.BestFitColumns();
           
        }
        private NguyenLieu nguyenLieu;
        private ThucDon mon;
        private DinhLuong dinhLuong;
        private void gridViewNguyenLieu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //load danh sách định lượng của nguyên liệu được chọn
            nguyenLieu = (NguyenLieu)gridViewNguyenLieu.GetFocusedRow();
            if (nguyenLieu==null)
            {
                return;
            }
            LblTenNguyenLieu.Caption = nguyenLieu.Ten;
            NapDinhLuongChiTiet();
        }
        private void NapDinhLuongChiTiet()
        {
            dbDinhLuong = new ModelQuanLiCafeDbContext();
            dbDinhLuong.DinhLuongs.Where(s => s.IdNguyenLieu == nguyenLieu.Id).Load();
            listDinhLuongs= dbDinhLuong.DinhLuongs.Local.ToBindingList();
            gridControlDinhLuong.DataSource = listDinhLuongs;
            gridViewDinhLuong.RefreshData();
            gridViewDinhLuong.BestFitColumns();
        }

        private void CapNhatDinhLuong()
        {
            mon = (ThucDon)gridViewMon.GetFocusedRow();
            //kiểm tra xem nguyên liệu hiện tại có danh sách định lượng hay chưa
            var listDl = listDinhLuongs.Where(s => s.IdNguyenLieu == nguyenLieu.Id).FirstOrDefault();
            if (listDl==null)
            {//nếu chưa thì thêm mới
                listDinhLuongs.Add(new DinhLuong {IdNguyenLieu=nguyenLieu.Id,TiLeNguyenLieu=1, IdMon=mon.Id,TiLeMon=1 });
            }
            else
            {//nếu có rồi thì kiểm tra món được chọn có trong danh sách định lượng hay chưa
                var listMon = listDinhLuongs.Where(s => s.IdNguyenLieu == nguyenLieu.Id && s.IdMon == mon.Id).FirstOrDefault();
                if (listMon==null)//nếu chưa có thì thêm mới
                {
                    listDinhLuongs.Add(new DinhLuong { IdNguyenLieu = nguyenLieu.Id, TiLeNguyenLieu = 1, IdMon = mon.Id, TiLeMon = 1 });
                }
                else
                {
                    listMon.TiLeMon += 1;
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
            nguyenLieu = (NguyenLieu)gridViewNguyenLieu.GetFocusedRow();
            dinhLuong = (DinhLuong)gridViewDinhLuong.GetFocusedRow();
            mon = (ThucDon)gridViewMon.GetFocusedRow();
            if (nguyenLieu!=null)
            {
                gridViewNguyenLieuRowHandle = gridViewNguyenLieu.LocateByValue("Id", nguyenLieu.Id);
            }
            if (dinhLuong!=null)
            {
                gridViewDinhLuongRowHandle = gridViewDinhLuong.LocateByValue("Id", dinhLuong.Id);
            }
            if (mon != null)
            {
                gridViewMonRowHandle = gridViewMon.LocateByValue("Id", mon.Id);
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
            try
            {
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
                XtraMessageBox.Show("Chưa lưu được!"+Environment.NewLine+ex.ToString(), "Định lượng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void FrmDinhLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control&&e.KeyCode==Keys.S)
            {
                BtnLuu_ItemClick(null, null);
            }
        }

        private void BtnXoaMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XoaMon();
        }
        private void XoaMon()
        {
            var currMon = (DinhLuong)gridViewDinhLuong.GetFocusedRow();
            if (currMon == null) return;
            else
            {
                listDinhLuongs.Remove(currMon);
                gridViewDinhLuong.RefreshData();
            }
        }
        private void BtnNapDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NapDuLieu();
        }
    }
}