using CafeApp.Model.Models;
using System;
using CafeApp.Common;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace CafeApp.Winform.Views
{
    public partial class FrmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        private ModelQuanLiCafeDbContext db { get; set; }

        public FrmDoiMatKhau()
        {
            InitializeComponent();
            KeyPreview = true;
            db = new ModelQuanLiCafeDbContext();
            LoadThongTin();
        }

        private void LoadThongTin()
        {
            var username = db.TaiKhoans.Find(FrmDangNhap.IdTaiKhoan).TenDangNhap;
            LblUserInfo.Text = "Tài khoản: " + username;
        }

        private void BtnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text != txtXacNhan.Text)
            {
                XtraMessageBox.Show("Mật khẩu xác nhận không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var curUser = db.TaiKhoans.Find(FrmDangNhap.IdTaiKhoan);
            if (curUser.MatKhau== Core.Encrypt(txtMatKhauCu.Text))
            {
                curUser.MatKhau = Core.Encrypt(txtMatKhauMoi.Text);
                db.SaveChanges();
                XtraMessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                XtraMessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}