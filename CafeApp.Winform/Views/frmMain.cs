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
using System.Globalization;
using CafeApp.Winform.Models;
using CafeApp.Model.Models;
using System.Threading;

namespace CafeApp.Winform.Views
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public FrmMain()
        {
            InitializeComponent();
            db = new ModelQuanLiCafeDbContext();
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
            //var a = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            //var b = Core.Encrypt(a);
            //var c = Core.Decrypt(b);
            //XtraMessageBox.Show(b +" - "+c);
        }

        private void BtnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var curSession = db.LichSuTruyCaps.FirstOrDefault(s => s.IdTaiKhoan == FrmDangNhap.IdTaiKhoan&&s.Id==FrmDangNhap.IdPhienDangNhap);
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
    }
}