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
using CafeApp.Model.Models;

namespace CafeApp.Winform.Views
{
    public partial class FrmThemBan : DevExpress.XtraEditors.XtraForm
    {
        private FrmBan _frmBan;
        ModelQuanLiCafeDbContext db { get; set; }

        public FrmThemBan(FrmBan frmBan)
        {
            InitializeComponent();
            _frmBan = frmBan;
            db = new ModelQuanLiCafeDbContext();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSoLuong.Text))
            {
                XtraMessageBox.Show("Bạn cần nhập số lượng bàn cần thêm để tiếp tục!", "Thêm bàn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int sl = int.Parse(txtSoLuong.Text);
                var LastRecord = db.Bans.OrderByDescending(s => s.Id).FirstOrDefault();
                if (LastRecord != null)
                {
                    int getNumber = int.Parse(LastRecord.TenBan.Substring(4, LastRecord.TenBan.Length - 4));

                    for (int i = 1; i <= sl; i++)
                    {
                        Ban ban = new Ban { TenBan = "Bàn " + (i + getNumber).ToString() };
                        db.Bans.Add(ban);
                    }
                }
                else
                {
                    for (int i = 1; i <= sl; i++)
                    {
                        Ban ban = new Ban { TenBan = "Bàn " + i.ToString() };
                        db.Bans.Add(ban);
                    }
                }

                db.SaveChanges();
                XtraMessageBox.Show("Đã thêm " + sl + " bàn thành công!", "Thêm bàn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _frmBan.NapDuLieu();
                Close();
            }

        }
    }
}