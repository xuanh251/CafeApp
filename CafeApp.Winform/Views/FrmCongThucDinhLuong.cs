using CafeApp.Model.Models;
using System;
using System.Data;
using System.Linq;

namespace CafeApp.Winform.Views
{
    public partial class FrmCongThucDinhLuong : DevExpress.XtraEditors.XtraForm
    {
        private ModelQuanLiCafeDbContext db { get; set; }

        public FrmCongThucDinhLuong()
        {
            InitializeComponent();
        }

        public void KhoiTao(Mon mon)
        {
            db = new ModelQuanLiCafeDbContext();
            LblTieuDe.Text = "Công thức định lượng của " + mon.TenMon;
            memoEditCongThuc.Text += "1 " + mon.DonViTinh.TenDVT + " " + mon.TenMon + " cần:" + Environment.NewLine;
            var listnl = db.DinhLuongs.Where(s => s.IdMon == mon.IdMon).ToList();
            foreach (var item in listnl)
            {
                var nl = db.NguyenLieux.Find(item.IdNguyenLieu);
                memoEditCongThuc.Text += "-> " + item.SoLuongNguyenLieu + " " + nl.DonViTinh.TenDVT + " " + nl.TenNguyenLieu + Environment.NewLine;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}