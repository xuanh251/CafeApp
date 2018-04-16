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

namespace CafeApp.Winform.Views
{
    public partial class FrmBieuDoDoanhThu : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public FrmBieuDoDoanhThu()
        {
            InitializeComponent();
            NapDuLieu();
        }
        private void NapDuLieu()
        {
            db = new ModelQuanLiCafeDbContext();
            db.HoaDons.Load();
            var first_bill_date = db.HoaDons.Local.FirstOrDefault().NgayTao.Date;
            var last_bill_date = db.HoaDons.Local.LastOrDefault().NgayTao.Date;
            var seriesDoanhThu = chartControlDoanhThu.Series["Doanh thu"];
            for (DateTime i = first_bill_date.Date; i < last_bill_date.Date;i=i.AddDays(1))
            {
                var tongTien = db.HoaDons.Local.Where(s => s.NgayTao.Date >= i&& s.NgayTao.Date <= i).Sum(s => s.ThanhTien);
                seriesDoanhThu.Points.Add(new SeriesPoint(i, tongTien));
            }

            seriesDoanhThu.ArgumentScaleType = ScaleType.DateTime;
            ((LineSeriesView)seriesDoanhThu.View).LineMarkerOptions.Kind = MarkerKind.Diamond;
            ((LineSeriesView)seriesDoanhThu.View).LineStyle.DashStyle = DashStyle.Solid;
            ((XYDiagram)chartControlDoanhThu.Diagram).EnableAxisXZooming = true;
        }


    }

}