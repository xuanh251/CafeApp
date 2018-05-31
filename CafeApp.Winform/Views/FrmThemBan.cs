using CafeApp.Model.Models;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CafeApp.Winform.Views
{
    public partial class FrmThemBan : DevExpress.XtraEditors.XtraForm
    {
        private FrmBan _frmBan;
        private ModelQuanLiCafeDbContext db { get; set; }

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
                var LastRecord = db.Bans.OrderByDescending(s => s.IdBan).FirstOrDefault();
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