using CafeApp.Model.Models;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CafeApp.Winform.Views
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        private ModelQuanLiCafeDbContext db { get; set; }

        public FrmMain()
        {
            InitializeComponent();
            db = new ModelQuanLiCafeDbContext();
            LoadStatusBar();
        }
        private void LoadStatusBar()
        {
            lblThongTin.Caption = "@" + DateTime.Now.Year + " CafeApp Manager";
            var user = db.TaiKhoans.Find(FrmDangNhap.IdTaiKhoan);
            lblUserInfo.Caption = "Phiên làm việc: " + user.HoTen + " - " + user.LoaiTaiKhoan.Ten;
        }
        private void BtnTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTaiKhoan f = new FrmTaiKhoan
            {
                MdiParent = this
            };
            f.Show();
        }

        private void BtnLichSuTruyCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmLichSuTruyCap f = new FrmLichSuTruyCap
            {
                MdiParent = this
            };
            f.Show();
        }

        private void BtnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var curSession = db.LichSuTruyCaps.FirstOrDefault(s => s.IdTaiKhoan == FrmDangNhap.IdTaiKhoan && s.Id == FrmDangNhap.IdPhienDangNhap);
            curSession.TrangThai = false;
            db.SaveChanges();
            closeAllActiveForm();
            Close();
            Thread t = new Thread(new ThreadStart(OpenFrmLogin));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        public static void OpenFrmLogin()
        {
            Application.Run(new FrmDangNhap());
        }

        private void closeAllActiveForm()
        {
            Form[] childArray = this.MdiChildren;
            foreach (Form childForm in childArray)
            {
                childForm.Close();
            }
        }
        private void BtnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDoiMatKhau f = new FrmDoiMatKhau();
            f.ShowDialog();
        }

        private void BtnBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmBan f = new FrmBan
            {
                MdiParent = this
            };
            f.Show();
        }

        private void BtnNhomNguyenLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmNhomNguyenLieu f = new FrmNhomNguyenLieu
            {
                MdiParent = this
            };
            f.Show();
        }

        private void BtnNhomThucDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmNhomSanPham f = new FrmNhomSanPham
            {
                MdiParent = this
            };
            f.Show();
        }

        private void BtnDonViTinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDonViTinh f = new FrmDonViTinh
            {
                MdiParent = this
            };
            f.Show();
        }

        private void BtnDoiTac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDoiTac f = new FrmDoiTac
            {
                MdiParent = this
            };
            f.Show();
        }

        private void BtnNguyenLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmNguyenLieu f = new FrmNguyenLieu
            {
                MdiParent = this
            };
            f.Show();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //XtraMessageBox.Show("fjdhfjdsf");
            //return;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CP_NOCLOSE = 0x200;
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE;
                return myCp;
            }
        }

        private void BtnThucDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThucDon f = new FrmThucDon
            {
                MdiParent = this
            };
            f.Show();
        }

        private void BtnDinhLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDinhLuong f = new FrmDinhLuong
            {
                MdiParent = this
            };
            f.Show();
        }

        private void BtnBanLe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmBanHang f = new FrmBanHang
            {
                MdiParent = this
            };
            f.Show();
        }
    }
}