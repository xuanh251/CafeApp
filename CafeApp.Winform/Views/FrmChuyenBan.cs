using CafeApp.Model.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Card;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CafeApp.Winform.Views
{
    public partial class FrmChuyenBan : DevExpress.XtraEditors.XtraForm
    {
        private FrmBanHang _frmBanHang;
        private ModelQuanLiCafeDbContext db { get; set; }

        public FrmChuyenBan(FrmBanHang frmBanHang)
        {
            InitializeComponent();
            _frmBanHang = frmBanHang;
            NapDuLieu();
        }

        public int vitri_old;
        public int vitri_new;
        public int idHoaDon;

        private void NapDuLieu()
        {
            db = new ModelQuanLiCafeDbContext();
            ChuyenBanModel chuyenban = new ChuyenBanModel();
            //list bàn đang sử dụng
            var dangSuDung = db.HoaDons.Where(s => s.TrangThai == false).ToList();
            var idBanDangSuDung = from a in dangSuDung select a.IdBan;
            //var listBanTrong = db.Bans.Local.Where(s => !dangSuDung.Any(a => a.IdBan == s.Id)).ToList();
            var listBanTrong = (from a in db.Bans
                                where !idBanDangSuDung.Any(s => s == a.IdBan)
                                select new ChuyenBanModel
                                {
                                    IdBan = a.IdBan,
                                    TenBan = a.TenBan,
                                    GhiChu = a.GhiChu
                                }).ToList();
            gridControlViTri.DataSource = listBanTrong;
        }

        private void ChuyenViTri()
        {
            db = new ModelQuanLiCafeDbContext();
            var vitri = (ChuyenBanModel)cardViewViTri.GetFocusedRow();
            vitri_new = vitri.IdBan;
            if ((XtraMessageBox.Show("Bạn có muốn chuyển đến bàn " + vitri.TenBan, "Xác nhận chuyển", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                this.Close();
                _frmBanHang.ChuyenBan(vitri_old, vitri_new, idHoaDon);
            }
        }

        private void BtnChuyenViTri_Click(object sender, EventArgs e)
        {
            ChuyenViTri();
        }

        private void cardViewViTri_CustomDrawCardFieldValue(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            CardView view = sender as CardView;
            var data = (ChuyenBanModel)view.GetRow(e.RowHandle);
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            e.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            e.Appearance.ForeColor = Color.White;
            e.Appearance.BackColor = Color.FromArgb(0, 122, 204);
            e.DefaultDraw();
        }

        private void cardViewViTri_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void FrmChuyenBan_Load(object sender, EventArgs e)
        {
            db = new ModelQuanLiCafeDbContext();
            var tenBan_old = db.Bans.Find(vitri_old);
            this.Text = "Chuyển từ vị trí " + tenBan_old.TenBan + " - Hoá đơn số " + idHoaDon;
        }
    }
}