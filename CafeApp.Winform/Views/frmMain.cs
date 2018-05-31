using CafeApp.Common;
using CafeApp.Model.Models;
using CafeApp.Winform.Properties;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

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
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Settings.Default.Skin;
        }

        public void XtraTabbedMdiManager_Add_Or_Select_ChildForm(Form pForm, System.Drawing.Image pImage = null, bool pAllowReplaceForm = false)
        {
            try
            {
                //Cho phép đè lên Form cũ
                if ((pAllowReplaceForm))
                {
                    Form _Form = default(Form);

                    foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage _Page in this.xtraTabbedMdiManagerMain.Pages)
                    {
                        if ((_Page.MdiChild.Name == pForm.Name))
                        {
                            this.xtraTabbedMdiManagerMain.Pages.Remove(_Page);
                            _Form = pForm;
                            _Form.Text = _Form.Text.ToUpper();
                            _Form.MdiParent = xtraTabbedMdiManagerMain.MdiParent;
                            if ((pImage != null))
                            {
                                xtraTabbedMdiManagerMain.Pages[_Form].Image = pImage;
                            }
                            _Form.Show();
                            return;
                        }
                    }

                    _Form = pForm;
                    _Form.Text = _Form.Text.ToUpper();
                    _Form.MdiParent = xtraTabbedMdiManagerMain.MdiParent;
                    if ((pImage != null))
                    {
                        xtraTabbedMdiManagerMain.Pages[_Form].Image = pImage;
                    }
                    _Form.Show();
                    //Không cho phép đè lên Form cũ, mà chỉ hiển thị lại
                }
                else
                {
                    foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage _Page in this.xtraTabbedMdiManagerMain.Pages)
                    {
                        if ((_Page.MdiChild.Name == pForm.Name))
                        {
                            if ((pImage != null))
                            {
                                _Page.Image = pImage;
                            }

                            _Page.MdiChild.Activate();
                            return;
                        }
                    }
                    Form _Form = pForm;
                    _Form.Text = _Form.Text.ToUpper();
                    _Form.MdiParent = xtraTabbedMdiManagerMain.MdiParent;
                    if ((pImage != null))
                    {
                        xtraTabbedMdiManagerMain.Pages[_Form].Image = pImage;
                    }
                    _Form.Show();
                }
            }
            catch (System.Exception _Ex)
            {
                XtraMessageBox.Show(_Ex.Message, "XtraTabbedMdiManager_Add_Or_Select_ChildForm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadStatusBar()
        {
            lblThongTin.Caption = "@" + DateTime.Now.Year + " CafeApp Manager";
            var user = db.TaiKhoans.Find(FrmDangNhap.IdTaiKhoan);
            lblUserInfo.Caption = "Phiên làm việc: " + user.HoTen + " - " + user.NhomTaiKhoan.TenNhom;
        }

        private void BtnTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmTaiKhoan());
        }

        private void BtnLichSuTruyCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmLichSuTruyCap());
        }

        private void DangXuat()
        {
            var curSession = db.LichSuTruyCaps.FirstOrDefault(s => s.IdTaiKhoan == FrmDangNhap.IdTaiKhoan && s.Id == FrmDangNhap.IdPhienDangNhap);
            curSession.TrangThai = false;
            db.SaveChanges();
            closeAllActiveForm();
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
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmBan());
        }

        private void BtnNhomNguyenLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmNhomNguyenLieu());
        }

        private void BtnNhomThucDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmNhomMon());
        }

        private void BtnDonViTinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmDonViTinh());
        }

        private void BtnDoiTac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmDoiTac());
        }

        private void BtnNguyenLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmNguyenLieu());
        }

        private void BtnThucDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmMon());
        }

        private void BtnDinhLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmDinhLuong());
        }

        private void BtnBanLe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmBanHang());
        }

        private void BtnPhieuNhapKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmPhieuNhapKho());
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (PreClosingConfirmation() == DialogResult.Yes)
            {
                DangXuat();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private DialogResult PreClosingConfirmation()
        {
            DialogResult res = XtraMessageBox.Show("Kết thúc phiên làm việc?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {
        }

        private void BtnSaoLuuDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Core.SaoLuuDuLieu();
        }

        private void BtnCauHinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmCauHinh());
        }

        private void BtnDoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmDoanhThu());
        }

        private void BtnDoanhSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmDoanhSoBan());
        }

        private void skinRibbonGalleryBarItem3_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            var skin = (string)e.Item.Tag;
            Settings.Default.Skin = skin;
            Settings.Default.Save();
        }
    }
}