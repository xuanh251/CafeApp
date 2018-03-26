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
using CafeApp.Common;
using CafeApp.Model.Models;
using System.Threading;
using CafeApp.Winform.Models;

namespace CafeApp.Winform.Views
{
    public partial class FrmDangNhap : XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public FrmDangNhap()
        {
            InitializeComponent();
            KeyPreview = true;
            txtTaiKhoan.Focus();
            CkeNhoMatKhau.Checked = true;
            txtTaiKhoan.Text = Properties.Settings.Default.TaiKhoan;
            txtMatKhau.Text = Properties.Settings.Default.MatKhau;
        }
        public void LuuMatKhau(string un, string pw)
        {
            if (CkeNhoMatKhau.Checked)
            {
                Properties.Settings.Default.TaiKhoan = un;
                Properties.Settings.Default.MatKhau = pw;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.TaiKhoan = "";
                Properties.Settings.Default.MatKhau = "";
                Properties.Settings.Default.Save();
            }
        }
        public static int IdPhienDangNhap { get; set; }
        public static int IdTaiKhoan { get; set; }
        private bool DangNhap(string tk, string mk)
        {
            db = new ModelQuanLiCafeDbContext();
            var isUser = db.TaiKhoans.Where(s => s.TenDangNhap == tk && s.MatKhau == mk).FirstOrDefault();
            if (isUser==null)
            {
                return false;
            }
            else
            {
                LuuMatKhau(txtTaiKhoan.Text, txtMatKhau.Text);
                var idTaiKhoan = db.TaiKhoans.Where(s => s.TenDangNhap == tk).Select(s => s.Id).First();
                LichSuTruyCap lstc = new LichSuTruyCap() { IdTaiKhoan = idTaiKhoan, ThoiDiemDangNhap = DateTime.Now, TrangThai = true };
                db.LichSuTruyCaps.Add(lstc);
                db.SaveChanges();
                //Lưu thông tin phiên đăng nhập
                IdPhienDangNhap = lstc.Id;
                IdTaiKhoan = (int)lstc.IdTaiKhoan;

                return true;
            }
        }
        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTaiKhoan.Text;
            string matkhau = Core.Encrypt(txtMatKhau.Text);
            if (DangNhap(taikhoan, matkhau))
            {
                XtraMessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFormMain();
            }
            else
            {
                XtraMessageBox.Show("Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void OpenFrmMain()
        {
            Application.Run(new FrmMain());
        }
        private void LoadFormMain()
        {
            FrmMain fm = new FrmMain();
            this.Close();
            Thread t = new Thread(new ThreadStart(OpenFrmMain));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}