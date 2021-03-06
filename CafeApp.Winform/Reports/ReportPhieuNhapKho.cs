﻿using CafeApp.Common;
using CafeApp.Model.Models;
using CafeApp.Winform.Properties;
using System.Data.Entity;
using System.Linq;

namespace CafeApp.Winform.Reports
{
    public partial class ReportPhieuNhapKho : DevExpress.XtraReports.UI.XtraReport
    {
        private ModelQuanLiCafeDbContext db { get; set; }

        public ReportPhieuNhapKho()
        {
            InitializeComponent();
        }

        private PhieuNhapKho phieu;

        public void KhoiTao(PhieuNhapKho p)
        {
            phieu = p;
        }

        private void NapDuLieu()
        {
            xrLabelTenDonVi.Text = Settings.Default.TenDonVi;
            xrLabelDiaChiDonVi.Text = "Địa chỉ: " + Settings.Default.DiaChi;
            xrLabelDienThoaiDonVi.Text = "Điện thoại: " + Settings.Default.LienHe;
            var temp = phieu.PhieuNhapKhoChiTiets.ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                temp[i].STT = i + 1;
            }
            db = new ModelQuanLiCafeDbContext();
            db.DonViTinhs.Load();
            db.PhieuNhapKhoChiTiets.Where(s => s.SoHoaDon == phieu.SoHoaDon).Load();
            var tempPhieu = db.PhieuNhapKhoChiTiets.Local.ToBindingList();
            var myList = from a in tempPhieu
                         join b in db.DonViTinhs.Local
                         on a.NguyenLieu.IdDVT equals b.IdDVT
                         select new { a.STT, a.NguyenLieu.TenNguyenLieu, a.SoLuong, a.DonGia, b.TenDVT, a.Tien };
            DataSource = myList.ToList();
            STT.DataBindings.Add("Text", DataSource, nameof(PhieuNhapKhoChiTiet.STT));
            Ten.DataBindings.Add("Text", DataSource, nameof(NguyenLieu.TenNguyenLieu));
            DonGia.DataBindings.Add("Text", DataSource, nameof(PhieuNhapKhoChiTiet.DonGia), "{0:n0}đ");
            SoLuong.DataBindings.Add("Text", DataSource, nameof(PhieuNhapKhoChiTiet.SoLuong));
            DVT.DataBindings.Add("Text", DataSource, nameof(DonViTinh.TenDVT));
            Tien.DataBindings.Add("Text", DataSource, nameof(PhieuNhapKhoChiTiet.Tien), "{0:n0}đ");

            xrLabelNgay.Text = "Ngày lập phiếu: " + phieu.NgayLapPhieu.ToString("dd/MM/yyyy");
            xrLabelSoPhieu.Text = "Số HĐ: " + phieu.SoHoaDon;
            xrLabelTenDoiTac.Text = phieu.DoiTac.TenDoiTac;
            xrLabelSoDienThoaiDoiTac.Text = phieu.DoiTac.SoDienThoai;
            xrLabelDiaChiDoiTac.Text = phieu.DoiTac.DiaChi;
            xrTableCellTongTien.Text = phieu.TongTien.ToString("n0") + "đ";
            xrLabelChietKhau.Text = phieu.TienChietKhau.ToString("n0") + "đ";
            xrLabelThanhToan.Text = phieu.ThanhTien.ToString("n0") + "đ";
            xrTableCellTongTienBangChu.Text = VNCurrency.ToString(phieu.TongTien);
        }

        private void ReportPhieuNhapKho_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            NapDuLieu();
        }
    }
}