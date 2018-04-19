using CafeApp.Common;
using CafeApp.Model.Models;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CafeApp.Winform.Views
{
    public partial class FrmDangNhap : XtraForm
    {
        private ModelQuanLiCafeDbContext db { get; set; }

        public FrmDangNhap()
        {
            InitializeComponent();
            KeyPreview = true;
            KhoiTao();
        }
        private void KhoiTao()
        {
            try
            {
                txtTaiKhoan.Focus();
                CkeNhoMatKhau.Checked = true;
                if (String.IsNullOrEmpty(Properties.Settings.Default.TaiKhoan))
                {
                    return;
                }
                txtTaiKhoan.Text = Properties.Settings.Default.TaiKhoan;
                db = new ModelQuanLiCafeDbContext();
                db.TaiKhoans.Load();
                var EnPass = db.TaiKhoans.Where(s => s.TenDangNhap == txtTaiKhoan.Text).FirstOrDefault().MatKhau;
                txtMatKhau.Text = Core.Decrypt(EnPass);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Đã xảy ra lỗi!" + Environment.NewLine + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LuuMatKhau(string un)
        {
            if (CkeNhoMatKhau.Checked)
            {
                Properties.Settings.Default.TaiKhoan = un;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.TaiKhoan = "";
                Properties.Settings.Default.Save();
            }
        }

        public static int IdPhienDangNhap { get; set; }
        public static int IdTaiKhoan { get; set; }

        private bool DangNhap(string tk, string mk)
        {
            db = new ModelQuanLiCafeDbContext();
            var isUser = db.TaiKhoans.Where(s => s.TenDangNhap == tk && s.MatKhau == mk).FirstOrDefault();
            if (isUser == null)
            {
                return false;
            }
            else
            {
                LuuMatKhau(txtTaiKhoan.Text);
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
        public static int accType=0;
        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTaiKhoan.Text;
            string matkhau = Core.Encrypt(txtMatKhau.Text);
            if (DangNhap(taikhoan, matkhau))//đăng nhập thành công
            {
                db = new ModelQuanLiCafeDbContext();
                accType=db.TaiKhoans.Where(s => s.TenDangNhap == taikhoan).FirstOrDefault().NhomTaiKhoan.IdNhom;
                if (accType==Core.Admin)
                {
                    LoadFormMain();
                }
                else
                {
                    LoadFormBanHang();
                } 
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
        public static void OpenFrmBanHang()
        {
            Application.Run(new FrmBanHang());
        }

        private void LoadFormMain()
        {
            FrmMain fm = new FrmMain();
            this.Close();
            Thread t = new Thread(new ThreadStart(OpenFrmMain));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void LoadFormBanHang()
        {
            FrmBanHang fm = new FrmBanHang();
            this.Close();
            Thread t = new Thread(new ThreadStart(OpenFrmBanHang));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}