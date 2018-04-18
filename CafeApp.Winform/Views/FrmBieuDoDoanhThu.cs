using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CafeApp.Model.Models;
using System.Data.Entity;
using DevExpress.XtraCharts;
using CafeApp.Common;


namespace CafeApp.Winform.Views
{
    public partial class FrmBieuDoDoanhThu : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public const string TuNgayDenNgay = "Từ ngày đến ngày";
        public const string TatCa = "Tất cả";
        public string KieuLoc { get; set; } = TatCa;
        public DateTime TuNgay { get; set; } = DateTime.Now;
        public DateTime DenNgay { get; set; } = DateTime.Now;
        public FrmBieuDoDoanhThu()
        {
            InitializeComponent();
            NapDuLieu();
            barEditItemKieuLoc.DataBindings.Add("EditValue", this, nameof(KieuLoc), false, DataSourceUpdateMode.OnPropertyChanged, TatCa);
            barEditItemTuNgay.DataBindings.Add("EditValue", this, nameof(TuNgay), false, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);
            barEditItemDenNgay.DataBindings.Add("EditValue", this, nameof(DenNgay), false, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);
        }
        public BindingList<HoaDon> query = null;
        private void NapDuLieu()
        {
            if (chartControlDoanhThu.Series.Count > 0)
            {
                var sr = chartControlDoanhThu.Series["Doanh thu"];
                chartControlDoanhThu.Series.Remove(sr);
            }
            Series curDoanhThu = new Series("Doanh thu", ViewType.Line);
            curDoanhThu.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            db = new ModelQuanLiCafeDbContext();
            db.HoaDons.Load();
            DateTime first_bill_date = DateTime.Now.Date;
            DateTime last_bill_date = DateTime.Now.Date;
            switch (KieuLoc)
            {
                case TuNgayDenNgay:
                    first_bill_date = TuNgay.Date;
                    last_bill_date = DenNgay.Date;
                    break;
                case TatCa:
                    var list2 = db.HoaDons.Local.ToBindingList();
                    query = new BindingList<HoaDon>(list2);
                    first_bill_date = query.FirstOrDefault().NgayTao.Date;
                    last_bill_date = query.LastOrDefault().NgayTao.Date;
                    break;
                default:
                    break;
            }
            chartControlDoanhThu.Series.Add(curDoanhThu);
            //var seriesDoanhThu = chartControlDoanhThu.Series["Doanh thu"];
            for (DateTime i = first_bill_date.Date; i <= last_bill_date.Date; i = i.AddDays(1))
            {
                var tongTien = db.HoaDons.Local.Where(s => s.NgayTao.Date >= i && s.NgayTao.Date <= i).Sum(s => s.ThanhTien);
                curDoanhThu.Points.Add(new SeriesPoint(i, tongTien));
            }

            curDoanhThu.ArgumentScaleType = ScaleType.DateTime;
            ((LineSeriesView)curDoanhThu.View).LineMarkerOptions.Kind = MarkerKind.Diamond;
            ((LineSeriesView)curDoanhThu.View).LineStyle.DashStyle = DashStyle.Solid;
            ((XYDiagram)chartControlDoanhThu.Diagram).EnableAxisXZooming = true;
            chartControlDoanhThu.RefreshData();
        }

        private void barButtonItemVeBieuDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NapDuLieu();
        }

        private void barButtonItemXuatThanhAnh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Core.XuatHinhAnh(chartControlDoanhThu);
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
    }

}