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
using DevExpress.XtraGrid.Views.Card;

namespace CafeApp.Winform.Views
{
    public partial class FrmBanHang : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public FrmBanHang()
        {
            InitializeComponent();
            NapDuLieu();
        }
        public BindingList<BanLe> query;
        private void NapThucDon()
        {
            db = new ModelQuanLiCafeDbContext();
            db.ThucDons.Load();
            db.NhomThucDons.Load();
            repositoryItemSearchLookUpEditNhomMon.DataSource = db.NhomThucDons.Local.ToBindingList();
            repositoryItemSearchLookUpEditNhomMon.View.Columns.AddField("Ten").Visible = true;
            gridControlThucDon.DataSource = db.ThucDons.Local.ToBindingList().OrderBy(s => s.NhomThucDon.Id);
            gridViewThucDon.RefreshData();
            gridViewThucDon.BestFitColumns();
        }
        private void NapDuLieu()
        {
            db = new ModelQuanLiCafeDbContext();
            db.Bans.Load();
            var temp = (from hd in db.HoaDons.Include(p => p.HoaDonChiTiets)
                        join b in db.Bans on hd.IdBan equals b.Id
                        where hd.TrangThai == false
                        select new BanLe
                        {
                            Id = hd.Id,
                            IdBan = b.Id,
                            GhiChu = hd.GhiChu,
                            NgayLapHoaDon = hd.NgayTao,
                            hoaDonChiTiets = hd.HoaDonChiTiets,
                            TenBan = b.TenBan,
                            ChietKhau = hd.ChietKhau,
                        });
            //chỗ này mới load được những bàn đang mở nhưng chưa thanh toán
            var listBan = temp.ToList();
            var tempBanDangMo = from bl in temp select bl.IdBan;
            var tempBanChuaMo = from b in db.Bans
                                where !tempBanDangMo.Any(s => s == b.Id)
                                select b;
            foreach (var item in tempBanChuaMo)
            {
                var b = new BanLe
                {
                    Id = 0,
                    IdBan = item.Id,
                    GhiChu = item.GhiChu,
                    NgayLapHoaDon = null,
                    hoaDonChiTiets = null,
                    TenBan = item.TenBan,
                    TrangThaiHoaDon = true,
                };
                listBan.Add(b);
            }
            listBan = listBan.OrderBy(s => s.IdBan).ToList();
            query = new BindingList<BanLe>(listBan);
            gridControlBan.DataSource = query;
            cardViewBan.RefreshData();
            NapThucDon();
        }
        
        private void cardViewBan_CustomDrawCardFieldValue(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            CardView view = sender as CardView;
            var data = (BanLe)view.GetRow(e.RowHandle);
            if (data!=null)
            {
                if (!data.TrangThaiHoaDon)
                {
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    e.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.BackColor = Color.FromArgb(255, 17, 0);
                    e.DefaultDraw();
                }
                else
                {
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    e.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.BackColor = Color.FromArgb(0, 122, 204);
                    e.DefaultDraw();
                }
            }
        }

        private void BtnNapDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NapDuLieu();
        }
        private BanLe ban;
        private void cardViewBan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var vitri = (BanLe)cardViewBan.GetFocusedRow();
            XtraMessageBox.Show(vitri.TenBan);
        }
    }
}