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
using CafeApp.Models;
using System.Data.Entity;

namespace CafeApp
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
            cafeDbContext db = new cafeDbContext();
            db.Bans.Load();
            var temp = from pbh in db.PhieuBanHangs
                       join b in db.Bans on pbh.IdBan equals b.Id
                       select new tempModel
                       {
                           Id = pbh.Id,
                           IdBan = b.Id,
                           GhiChu = pbh.GhiChu,
                           NgayLapPhieu = pbh.NgayLapPhieu,
                           TenBan = b.TenBan,
                           TrangThaiPhieu = pbh.TrangThaiPhieu
                       };
            var t2 = temp.ToList();
            var idCoKhach = from a in temp select a.IdBan;
            var idSanSang = from ban in db.Bans where !idCoKhach.Any(s => s == ban.Id) select ban;
            foreach (var item in idSanSang)
            {
                var b = new tempModel
                {
                    Id = 0,
                    IdBan = item.Id,
                    GhiChu = item.GhiChu,
                    NgayLapPhieu = null,
                    TenBan = item.TenBan,
                    TrangThaiPhieu = true
                };
                t2.Add(b);
            }

            t2 = t2.OrderBy(s => s.IdBan).ToList();
            var query = new BindingList<tempModel>(t2);
            gridControl1.DataSource = query;
            cardView1.RefreshData();
        }

        private void cardView1_CustomDrawCardFieldValue(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.CardView view = sender as DevExpress.XtraGrid.Views.Card.CardView;
            var data = (tempModel)view.GetRow(e.RowHandle);
            if (data == null)
            {


            }
            else
            {
                if (!data.TrangThaiPhieu)
                {
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    e.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.BackColor = Color.FromArgb(0, 120, 215);
                    e.DefaultDraw();
                }
                else
                {
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    e.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 255);
                    e.DefaultDraw();
                }
            }
        }
    }
}