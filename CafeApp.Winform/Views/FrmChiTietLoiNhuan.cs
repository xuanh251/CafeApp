using CafeApp.Model.Models;
using System;
using System.Data;
using System.Linq;

namespace CafeApp.Winform.Views
{
    public partial class FrmChiTietLoiNhuan : DevExpress.XtraEditors.XtraForm
    {
        private ModelQuanLiCafeDbContext db { get; set; }

        public FrmChiTietLoiNhuan()
        {
            InitializeComponent();
            BtnOK.Focus();
        }

        public void KhoiTao(Mon mon)
        {
            db = new ModelQuanLiCafeDbContext();
            var giaMon = mon.DonGia;
            var listNguyenLieu = (from a in db.DinhLuongs
                                  join b in db.NguyenLieux
                                  on a.IdNguyenLieu equals b.IdNguyenLieu
                                  where a.IdMon == mon.IdMon
                                  select new { a.SoLuongNguyenLieu, b.DonGia, b.SoLuongQuyDoi }).ToList();
            double giavon = 0;
            if (listNguyenLieu.Any())
            {
                foreach (var item in listNguyenLieu)
                {
                    giavon += (item.SoLuongNguyenLieu / item.SoLuongQuyDoi) * item.DonGia;
                }
            }
            LblTieuDe.Text = "Lợi nhuận của món: " + mon.TenMon + "/1 món";
            LblGiaBan.Text = "Giá món: " + giaMon.ToString("c0");
            LblGiaVon.Text = "Tổng vốn:" + giavon.ToString("c0");
            LblLoiNhuan.Text = "Lợi nhuận: " + (giaMon - giavon).ToString("c0") + "(" + Math.Round(((giaMon - giavon) / giaMon * 100), 2) + "%)";
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}