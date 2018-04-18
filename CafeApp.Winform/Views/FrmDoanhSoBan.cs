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
using DevExpress.XtraCharts;
using CafeApp.Common;

namespace CafeApp.Winform.Views
{
    public partial class FrmDoanhSoBan : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public const string TrongNgay = "Trong ngày";
        public const string TuNgayDenNgay = "Từ ngày đến ngày";
        public const string TatCa = "Tất cả";
        public string KieuLoc { get; set; } = TatCa;
        public DateTime TuNgay { get; set; } = DateTime.Now;
        public DateTime DenNgay { get; set; } = DateTime.Now;
        public FrmDoanhSoBan()
        {
            InitializeComponent();
            NapDuLieu();
            barEditItemKieuLoc.DataBindings.Add("EditValue", this, nameof(KieuLoc), false, DataSourceUpdateMode.OnPropertyChanged, TrongNgay);
            barEditItemTuNgay.DataBindings.Add("EditValue", this, nameof(TuNgay), false, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);
            barEditItemDenNgay.DataBindings.Add("EditValue", this, nameof(DenNgay), false, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);
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
        private void NapDuLieu()
        {
            db = new ModelQuanLiCafeDbContext();
            List<DoanhSoBan_NhomMon> r = new List<DoanhSoBan_NhomMon>();
            db.NhomMons.Load();
            db.Mons.Load();
            db.HoaDons.Load();
            db.HoaDonChiTiets.Load();
            var listNhom = db.NhomMons.Local.ToBindingList();
            switch (KieuLoc)
            {
                case TatCa:
                    foreach (var item in listNhom)
                    {
                        var tempSlBan = (from a in db.NhomMons.Local
                                         from b in db.Mons.Local.Where(s => s.IdNhom == a.IdNhom)
                                         from c in db.HoaDonChiTiets.Local.Where(s => s.IdMon == b.IdMon)
                                         where a.IdNhom == item.IdNhom
                                         select (int?)c.SoLuong).Sum() ?? 0;
                        r.Add(new DoanhSoBan_NhomMon { IdNhom = item.IdNhom, TenNhom = item.Ten, SoLuongBan = tempSlBan });
                    }
                    break;
                case TrongNgay:
                    foreach (var item in listNhom)
                    {
                        var tempSlBan = (from a in db.NhomMons.Local
                                         from b in db.Mons.Local.Where(s => s.IdNhom == a.IdNhom)
                                         from c in db.HoaDonChiTiets.Local.Where(s => s.IdMon == b.IdMon)
                                         from d in db.HoaDons.Local.Where(s=>s.IdHoaDon==c.IdHoaDon)
                                         where a.IdNhom == item.IdNhom
                                         && d.NgayTao.Date >= DateTime.Now.Date && d.NgayTao.Date <= DateTime.Now.Date
                                         select (int?)c.SoLuong).Sum() ?? 0;
                        r.Add(new DoanhSoBan_NhomMon { IdNhom = item.IdNhom, TenNhom = item.Ten, SoLuongBan = tempSlBan });
                    }
                    break;
                case TuNgayDenNgay:
                    foreach (var item in listNhom)
                    {
                        var tempSlBan = (from a in db.NhomMons.Local
                                         from b in db.Mons.Local.Where(s => s.IdNhom == a.IdNhom)
                                         from c in db.HoaDonChiTiets.Local.Where(s => s.IdMon == b.IdMon)
                                         from d in db.HoaDons.Local.Where(s => s.IdHoaDon == c.IdHoaDon)
                                         where a.IdNhom == item.IdNhom
                                         && d.NgayTao.Date >= TuNgay.Date && d.NgayTao.Date <= DenNgay.Date
                                         select (int?)c.SoLuong).Sum() ?? 0;
                        r.Add(new DoanhSoBan_NhomMon { IdNhom = item.IdNhom, TenNhom = item.Ten, SoLuongBan = tempSlBan });
                    }
                    break;
                default:
                    break;
            }

            gridControlNhomMon.DataSource = r;
            gridViewNhomMon.RefreshData();
            gridViewNhomMon.RefreshData();
            NapDoanhSoMon();
        }

        private void gridViewNhomMon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            NapDoanhSoMon();
        }
        private void NapDoanhSoMon()
        {
            var vitri = (DoanhSoBan_NhomMon)gridViewNhomMon.GetFocusedRow();
            if (vitri == null) return;
            layoutControlItem2.Text = "Doanh số theo món thuộc nhóm " + vitri.TenNhom;
            db = new ModelQuanLiCafeDbContext();
            List<DoanhSoBan_Mon> r = new List<DoanhSoBan_Mon>();
            db.Mons.Where(s => s.IdNhom == vitri.IdNhom).Load();
            db.HoaDons.Load();
            db.HoaDonChiTiets.Load();
            var listMon = db.Mons.Local;
            switch (KieuLoc)
            {
                case TatCa:
                    foreach (var item in listMon)
                    {
                        var tempSlBan = (from a in db.HoaDonChiTiets.Local.Where(s => s.IdMon == item.IdMon)
                                         select (int?)a.SoLuong).Sum() ?? 0;
                        r.Add(new DoanhSoBan_Mon { IdMon = item.IdMon, TenMon = item.Ten, SoLuongBan = tempSlBan });
                    }
                    break;
                case TrongNgay:
                    foreach (var item in listMon)
                    {
                        var tempSlBan = (from a in db.HoaDonChiTiets.Local.Where(s => s.IdMon == item.IdMon)
                                         from b in db.HoaDons.Local.Where(s=>s.IdHoaDon==a.IdHoaDon)
                                         where b.NgayTao.Date >= DateTime.Now.Date && b.NgayTao.Date <= DateTime.Now.Date
                                         select (int?)a.SoLuong).Sum() ?? 0;
                        r.Add(new DoanhSoBan_Mon { IdMon = item.IdMon, TenMon = item.Ten, SoLuongBan = tempSlBan });
                    }
                    break;
                case TuNgayDenNgay:
                    foreach (var item in listMon)
                    {
                        var tempSlBan = (from a in db.HoaDonChiTiets.Local.Where(s => s.IdMon == item.IdMon)
                                         from b in db.HoaDons.Local.Where(s => s.IdHoaDon == a.IdHoaDon)
                                         where b.NgayTao.Date >= TuNgay.Date && b.NgayTao.Date <= DenNgay.Date
                                         select (int?)a.SoLuong).Sum() ?? 0;
                        r.Add(new DoanhSoBan_Mon { IdMon = item.IdMon, TenMon = item.Ten, SoLuongBan = tempSlBan });
                    }
                    break;
                default:
                    break;
            }
            gridControlMon.DataSource = r;
            gridViewMon.RefreshData();
            gridViewMon.BestFitColumns();
            XuatBieuDo(r);

        }
        private void XuatBieuDo(List<DoanhSoBan_Mon> dt, bool isTop10 = false)
        {
            if (chartControlBieuDo.Series.Count > 0)
            {
                chartControlBieuDo.Series.Clear();
            }
            var nhom = (DoanhSoBan_NhomMon)gridViewNhomMon.GetFocusedRow();
            if (dt.Count == 0)
            {
                XtraMessageBox.Show("Không có dữ liệu chi tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Series pie = new Series(!isTop10 ? "Biểu đồ doanh thu của nhóm " + nhom.TenNhom : "Top 10 sản phẩm bán chạy", ViewType.Pie);
            var TongSL = dt.Select(s => s.SoLuongBan).Sum();
            foreach (var item in dt)
            {
                var phantram = (double)item.SoLuongBan / TongSL;
                pie.Points.Add(new SeriesPoint(item.TenMon, phantram));
            }
            chartControlBieuDo.Series.Add(pie);
            pie.Label.TextPattern = "{A}: {VP:p0}";
            ((PieSeriesLabel)pie.Label).Position = PieSeriesLabelPosition.TwoColumns;

            // Detect overlapping of series labels.
            ((PieSeriesLabel)pie.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the view-type-specific options of the series.
            PieSeriesView myView = (PieSeriesView)pie.View;

            // Show a title for the series.
            myView.Titles.Add(new SeriesTitle());
            myView.Titles[0].Text = pie.Name;


            // Hide the legend (if necessary).
            chartControlBieuDo.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

        }

        private void barButtonItemTop10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetTop10();
        }
        private void GetTop10()
        {
            layoutControlItem2.Text = "Danh sách 10 món bán chạy nhất";
            gridControlNhomMon.DataSource = null;
            gridViewNhomMon.RefreshData();
            //gridViewNhomMon.
            db = new ModelQuanLiCafeDbContext();
            List<DoanhSoBan_Mon> r = new List<DoanhSoBan_Mon>();
            db.Mons.Load();
            var listMon = db.Mons.Local;
            foreach (var item in listMon)
            {
                var tempSlBan = (from a in db.HoaDonChiTiets.Where(s => s.IdMon == item.IdMon)
                                 select (int?)a.SoLuong).Sum() ?? 0;
                r.Add(new DoanhSoBan_Mon { IdMon = item.IdMon, TenMon = item.Ten, SoLuongBan = tempSlBan });
            }
            var top10 = r.OrderByDescending(s => s.SoLuongBan).Take(10).ToList();
            gridControlMon.DataSource = top10;
            gridViewMon.RefreshData();
            gridViewMon.BestFitColumns();
            XuatBieuDo(top10, true);
        }
        private void barButtonItemLocDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NapDuLieu();
        }

        private void barButtonItemXuatHinhAnh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Core.XuatHinhAnh(chartControlBieuDo);
        }
    }
    public class DoanhSoBan_NhomMon
    {
        public int IdNhom { get; set; }
        public string TenNhom { get; set; }
        public int SoLuongBan { get; set; }
    }
    public class DoanhSoBan_Mon
    {
        public int IdMon { get; set; }
        public string TenMon { get; set; }
        public int SoLuongBan { get; set; }
    }

}