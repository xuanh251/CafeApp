using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CafeApp.Winform.Properties;
using CafeApp.Model.Models;
using System.Linq;
using CafeApp.Common;
using DevExpress.XtraEditors;

namespace CafeApp.Winform.Reports
{
    public partial class ReportPhieuThanhToan : DevExpress.XtraReports.UI.XtraReport
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public ReportPhieuThanhToan()
        {
            InitializeComponent();
        }
        private HoaDon hoaDon;
        private dynamic listCT;
        public void NapDuLieu(HoaDon hd)
        {
            db = new ModelQuanLiCafeDbContext();
            var temp= (from a in db.HoaDons
                                     join b in db.HoaDonChiTiets on a.Id equals b.IdHoaDon
                                     join c in db.ThucDons on b.IdMon equals c.Id
                                     where a.Id == hd.Id
                                     select new { c.Ten, b.SoLuong, b.DonGia, Tien = (b.SoLuong * b.DonGia) }).ToList();
            hoaDon = db.HoaDons.Find(hd.Id);
            listCT = (from hdct in temp select new { hdct.Ten, SoLuong = hdct.SoLuong.ToString("n0"), DonGia = hdct.DonGia.ToString("n0"), Tien = hdct.Tien.ToString("n0") }).ToList();
            //xrTableCellViTri.Text = hd.IdBan.ToString();
        }

        private void ReportPhieuThanhToan_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTableCellTenDonVi.Text = Settings.Default.TenDonVi;
            xrTableCellDiaChi.Text = Settings.Default.DiaChi;
            xrTableCellSlogan.Text = Settings.Default.Slogan;
            xrTableCellLienHe.Text = "Liên hệ: "+Settings.Default.LienHe;
            xrTableCellViTri.Text = "Vị trí: "+hoaDon.Ban.TenBan;
            xrTableCellCaLamViec.Text = "Ca làm việc: "+hoaDon.CaLamViec;
            xrTableCellThoiGian.Text = "Giờ vào: "+ hoaDon.NgayTao.ToString("dd-MM-yyy HH:mm:ss");
            xrTableCellMaHoaDon.Text = "Hoá đơn số: " + hoaDon.Id;
            DataSource = listCT;
            xrTableCellTenMon.DataBindings.Add("Text", listCT, nameof(ThucDon.Ten));
            xrTableCellDonGia.DataBindings.Add("Text", listCT, nameof(ThucDon.DonGia));
            xrTableCellSoLuong.DataBindings.Add("Text", listCT, nameof(HoaDonChiTiet.SoLuong));
            xrTableCellTien.DataBindings.Add("Text", listCT, nameof(HoaDonChiTiet.Tien));
            xrTableCellGiamGia.Text = hoaDon.TienChietKhau.ToString("n0")+"đ";
            xrTableCellTongTien.Text = hoaDon.TongTien.ToString("n0")+"đ";
            xrTableCellThanhTien.Text = hoaDon.ThanhTien.ToString("n0")+"đ";
            xrTableCellThanhTien_Chu.Text = "("+VNCurrency.ToString(hoaDon.ThanhTien)+")";
        }

       
    }
}
