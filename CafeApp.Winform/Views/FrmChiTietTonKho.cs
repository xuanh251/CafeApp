using CafeApp.Model.Models;
using System;
using System.Data;
using System.Linq;

namespace CafeApp.Winform.Views
{
    public partial class FrmChiTietTonKho : DevExpress.XtraEditors.XtraForm
    {
        private ModelQuanLiCafeDbContext db { get; set; }

        public FrmChiTietTonKho()
        {
            InitializeComponent();
            BtnOK.Focus();
        }

        public void KhoiTao(NguyenLieu nl)
        {
            db = new ModelQuanLiCafeDbContext();
            var temp = db.NguyenLieux.Find(nl.IdNguyenLieu);
            if (temp != null)
            {
                var dvt = (from a in db.DonViTinhs
                           join b in db.NguyenLieux
          on a.IdDVT equals b.IdDVT
                           where b.IdNguyenLieu == temp.IdNguyenLieu
                           select a.TenDVT).FirstOrDefault();
                var slLe = ((int)((temp.SoLuongTon - (int)temp.SoLuongTon) * temp.SoLuongQuyDoi)).ToString();
                slLe = int.Parse(slLe) > 0 ? slLe + " " + temp.DonViTinh.TenDVT : "";
                LblTieuDe.Text = "Chi tiết tồn kho của nguyên liệu: " + temp.TenNguyenLieu;
                LblSLTon.Text = "Số lượng tồn: " + (int)temp.SoLuongTon + " " + dvt + " " + slLe + "  (" + temp.TongSoLuongTonQuyDoi + " " + temp.DonViTinh.TenDVT + ")";
                LblGiaTriTon.Text = "Giá trị tồn: " + (temp.SoLuongTon * temp.DonGia).ToString("c0");
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}