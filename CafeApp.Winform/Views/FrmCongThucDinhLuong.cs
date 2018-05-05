using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeApp.Model.Models;
using DevExpress.XtraEditors;

namespace CafeApp.Winform.Views
{
    public partial class FrmCongThucDinhLuong : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public FrmCongThucDinhLuong()
        {
            InitializeComponent();
        }
        public void KhoiTao(Mon mon)
        {
            db = new ModelQuanLiCafeDbContext();
            LblTieuDe.Text = "Công thức định lượng của " + mon.TenMon;
            memoEditCongThuc.Text+= "1 " + mon.DonViTinh.TenDVT + " " + mon.TenMon + " cần:"+Environment.NewLine;
            var listnl = db.DinhLuongs.Where(s => s.IdMon == mon.IdMon).ToList();
            foreach (var item in listnl)
            {
                var nl = db.NguyenLieux.Find(item.IdNguyenLieu);
                memoEditCongThuc.Text += "-> " + item.SoLuongNguyenLieu + " " + nl.DonViTinh.TenDVT + " " + nl.TenNguyenLieu+Environment.NewLine;
            }
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}