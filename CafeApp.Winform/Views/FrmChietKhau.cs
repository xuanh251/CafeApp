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

namespace CafeApp.Winform.Views
{
    public partial class FrmChietKhau : DevExpress.XtraEditors.XtraForm
    {
        FrmBanHang _frmBanHang;
        public double chietKhau;
        public FrmChietKhau(FrmBanHang frmBanHang)
        {
            _frmBanHang = frmBanHang;
            InitializeComponent();
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (int.Parse(spinEditChietKhau.EditValue.ToString())<=0)
            {
                XtraMessageBox.Show("Chiết khấu nhập vào phải lớn hơn 0","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            chietKhau =double.Parse(spinEditChietKhau.EditValue.ToString());
            Close();
            _frmBanHang.CapNhatChietKhau(chietKhau);
        }
    }
}