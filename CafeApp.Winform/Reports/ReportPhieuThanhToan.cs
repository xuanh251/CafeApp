using CafeApp.Common;
using CafeApp.Model.Models;
using CafeApp.Winform.Properties;
using System.Data.Entity;
using System.Linq;

namespace CafeApp.Winform.Reports
{
    public partial class ReportPhieuThanhToan : DevExpress.XtraReports.UI.XtraReport
    {
        private ModelQuanLiCafeDbContext db { get; set; }

        public ReportPhieuThanhToan()
        {
            InitializeComponent();
        }

        private HoaDon hoaDon;
        private dynamic listCT;

        public void NapDuLieu(HoaDon hd)
        {
            db = new ModelQuanLiCafeDbContext();
            db.HoaDonChiTiets.Where(s => s.IdHoaDon == hd.IdHoaDon).Load();
            var temp = db.HoaDonChiTiets.Local.ToBindingList();
            hoaDon = db.HoaDons.Find(hd.IdHoaDon);
            listCT = (from hdct in temp select new { hdct.Mon.TenMon, SoLuong = hdct.SoLuong.ToString("n0"), DonGia = hdct.DonGia.ToString("n0"), Tien = hdct.Tien.ToString("n0"), hdct.Mon.DonViTinh.TenDVT }).ToList();
        }

        private void ReportPhieuThanhToan_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTableCellTenDonVi.Text = Settings.Default.TenDonVi;
            xrTableCellDiaChi.Text = Settings.Default.DiaChi;
            xrTableCellSlogan.Text = Settings.Default.Slogan;
            xrTableCellLienHe.Text = "Liên hệ: " + Settings.Default.LienHe;
            xrTableCellViTri.Text = "Vị trí: " + hoaDon.Ban.TenBan;
            xrTableCellCaLamViec.Text = "Ca làm việc: " + hoaDon.CaLamViec;
            xrTableCellThoiGian.Text = "Giờ vào: " + hoaDon.NgayTao.ToString("dd-MM-yyy HH:mm");
            xrTableCellMaHoaDon.Text = "Hoá đơn số: " + hoaDon.IdHoaDon;
            DataSource = listCT;
            xrTableCellTenMon.DataBindings.Add("Text", listCT, nameof(Mon.TenMon));
            xrTableCellDonGia.DataBindings.Add("Text", listCT, nameof(Mon.DonGia));
            xrTableCellDVT.DataBindings.Add("Text", listCT, nameof(Mon.DonViTinh.TenDVT));
            xrTableCellSoLuong.DataBindings.Add("Text", listCT, nameof(HoaDonChiTiet.SoLuong));
            xrTableCellTien.DataBindings.Add("Text", listCT, nameof(HoaDonChiTiet.Tien));
            xrTableCellGiamGia.Text = hoaDon.TienChietKhau.ToString("n0") + "đ";
            xrTableCellTongTien.Text = hoaDon.TongTien.ToString("n0") + "đ";
            xrTableCellThanhTien.Text = hoaDon.ThanhTien.ToString("n0") + "đ";
            xrTableCellThanhTien_Chu.Text = "(" + VNCurrency.ToString(hoaDon.ThanhTien) + ")";
        }
    }
}