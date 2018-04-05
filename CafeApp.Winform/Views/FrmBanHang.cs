﻿using System;
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
using System.Data.Entity;
using DevExpress.XtraGrid.Views.Card;
using CafeApp.Common;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;

namespace CafeApp.Winform.Views
{
    public partial class FrmBanHang : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public FrmBanHang()
        {
            InitializeComponent();
            NapDuLieu();
        }
        public BindingList<BanLe> query;
        private void NapThucDon()
        {
            db = new ModelQuanLiCafeDbContext();
            db.Mons.Load();
            db.NhomMons.Load();
            repositoryItemSearchLookUpEditNhomMon.DataSource = db.NhomMons.Local.ToBindingList();
            repositoryItemSearchLookUpEditNhomMon.View.Columns.AddField("Ten").Visible = true;
            gridControlThucDon.DataSource = db.Mons.Local.ToBindingList().OrderBy(s => s.NhomMon.IdNhom);
            gridViewThucDon.RefreshData();
            gridViewThucDon.BestFitColumns();
        }
        private void NapDuLieu()
        {
            db = new ModelQuanLiCafeDbContext();
            db.Bans.Load();
            var temp = (from hd in db.HoaDons.Include(p => p.HoaDonChiTiets)
                        join b in db.Bans on hd.IdBan equals b.IdBan
                        where hd.TrangThai == false
                        select new BanLe
                        {
                            IdPhieu = hd.IdHoaDon,
                            IdBan = b.IdBan,
                            GhiChu = hd.GhiChu,
                            NgayLapHoaDon = hd.NgayTao,
                            hoaDonChiTiets = hd.HoaDonChiTiets,
                            TenBan = b.TenBan,
                            ChietKhau = hd.ChietKhau,
                        });
            //chỗ này mới load được những bàn đang mở nhưng chưa thanh toán
            var listBan = temp.ToList();
            var tempBanDangMo = from bl in temp select bl.IdBan;
            var tempBanChuaMo = from b in db.Bans
                                where !tempBanDangMo.Any(s => s == b.IdBan)
                                select b;
            foreach (var item in tempBanChuaMo)
            {
                var b = new BanLe
                {
                    IdPhieu = 0,
                    IdBan = item.IdBan,
                    GhiChu = item.GhiChu,
                    NgayLapHoaDon = null,
                    hoaDonChiTiets = null,
                    TenBan = item.TenBan,
                    TrangThaiHoaDon = true,
                };
                listBan.Add(b);
            }
            listBan = listBan.OrderBy(s => s.IdBan).ToList();
            query = new BindingList<BanLe>(listBan);
            gridControlBan.DataSource = query;
            cardViewBan.RefreshData();
            NapThucDon();
        }
        
        private void cardViewBan_CustomDrawCardFieldValue(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            CardView view = sender as CardView;
            var data = (BanLe)view.GetRow(e.RowHandle);
            if (data!=null)
            {
                if (!data.TrangThaiHoaDon)
                {
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    e.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.BackColor = Color.FromArgb(255, 17, 0);
                    e.DefaultDraw();
                }
                else
                {
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    e.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.BackColor = Color.FromArgb(0, 122, 204);
                    e.DefaultDraw();
                }
            }
        }

        private void BtnNapDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NapDuLieu();
        }
   
        private void NapDuLieuChiTiet()
        {
            var vitri = (BanLe)cardViewBan.GetFocusedRow();
            
            if (!vitri.TrangThaiHoaDon)//bàn đang có khách
            {
                gridControlThucDon.Enabled = true;
                gridControlHoaDonChiTiet.Enabled = true;
                BtnTaoBan.Enabled = false;
                BtnChuyenBan.Enabled = true;
                BtnXoaBan.Enabled = true;
                BtnThanhToan.Enabled = true;
                BtnChietKhau.Enabled = true;
                simpleLabelItemGioVao.Text = "Giờ vào: " + vitri.NgayLapHoaDon.Value.ToString("dd-MM-yyyy HH:mm:ss");
            }
            else
            {
                gridControlThucDon.Enabled = false;
                gridControlHoaDonChiTiet.Enabled = false;
                BtnTaoBan.Enabled = true;
                BtnChuyenBan.Enabled = false;
                BtnXoaBan.Enabled = false;
                BtnThanhToan.Enabled = false;
                BtnChietKhau.Enabled = false;
                simpleLabelItemGioVao.Text = Core.NullData;
               
            }
            if (vitri.ChietKhau!=0)
            {
                simpleLabelItemTenBan.Text = vitri.TenBan+"(Chiết khấu: "+vitri.ChietKhau+" %)";
            }
            else
            {
                simpleLabelItemTenBan.Text = vitri.TenBan;
            }
            
            gridViewHoaDonChiTiet.ViewCaption = "Dữ liệu chi tiết của hoá đơn " + vitri.IdPhieu;
            var tienchuack = vitri.TongTien;
            simpleLabelItemTongTien.Text = tienchuack.ToString("0 đ");
            simpleLabelItemChietKhau.Text = (tienchuack * vitri.ChietKhau / 100).ToString("0 đ");
            simpleLabelItemThanhTien.Text = (tienchuack * (1 - vitri.ChietKhau / 100)).ToString("0 đ");

            db = new ModelQuanLiCafeDbContext();
            db.Mons.Load();
            repositoryItemSearchLookUpEditHoaDon_ThucDon.DataSource = db.Mons.Local.ToBindingList();
            
            db.HoaDonChiTiets.Where(s=>s.IdHoaDon==vitri.IdPhieu).Load();
            gridControlHoaDonChiTiet.DataSource = db.HoaDonChiTiets.Local.ToBindingList();
            gridViewHoaDonChiTiet.RefreshData();
            gridViewHoaDonChiTiet.BestFitColumns();
        }
        private void cardViewBan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            NapDuLieuChiTiet();
        }

        private void BtnTaoBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaoBan();
        }
        private void TaoBan()
        {
            var vitri = (BanLe)cardViewBan.GetFocusedRow();
            if (vitri == null) return;
            //phiếu đã tạo hoặc chưa thanh toán
            if (vitri.IdPhieu > 0 || !vitri.TrangThaiHoaDon) return;
            var hoadon = new HoaDon()
            {
                IdBan = vitri.IdBan,
                NguoiTao = FrmDangNhap.IdTaiKhoan,
                NgayTao = DateTime.Now,
                TrangThai = false,
                CaLamViec = Core.SetCaLamViec(),
                GhiChu=vitri.GhiChu
            };
            using (ModelQuanLiCafeDbContext tempDb = new ModelQuanLiCafeDbContext())
            {
                tempDb.HoaDons.Add(hoadon);
                var hd = tempDb.SaveChanges();
                if (hd==1)
                {
                    NapDuLieu();
                    for (int i = 0; i < this.cardViewBan.RowCount; i++)
                    {
                        var current = (BanLe)this.cardViewBan.GetRow(i);
                        if (current.IdPhieu == hoadon.IdHoaDon)
                        {
                            this.cardViewBan.FocusedRowHandle = i;
                            break;
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show(string.Concat("Chưa tạo được phiếu mới cho vị trí: ", vitri.TenBan), "Tạo phiếu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridViewHoaDonChiTiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db = new ModelQuanLiCafeDbContext();
            var vitri = (HoaDonChiTiet)gridViewHoaDonChiTiet.GetFocusedRow();
            var hdct = db.HoaDonChiTiets.Where(s => s.IdHoaDon == vitri.IdHoaDon &&s.IdMon==vitri.IdMon).FirstOrDefault();
            hdct.SoLuong = vitri.SoLuong;
            db.SaveChanges();
            LuuViTri();
            NapDuLieu();
            NapDuLieuChiTiet();
            NapViTri();
        }

        private void repositoryItemButtonEditChonMon_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            db = new ModelQuanLiCafeDbContext();
            var mon = (Mon)gridViewThucDon.GetFocusedRow();
            var hoadon = (BanLe)cardViewBan.GetFocusedRow();
            var hdct = db.HoaDonChiTiets.Where(s => s.IdHoaDon == hoadon.IdPhieu && s.IdMon == mon.IdMon).FirstOrDefault();
            if (hdct==null)//nếu món được chọn chưa có
            {
                db.HoaDonChiTiets.Add(new HoaDonChiTiet { IdHoaDon = hoadon.IdPhieu, IdMon = mon.IdMon, SoLuong = 1, DonGia = mon.DonGia });
            }
            else
            {//nếu đã có thì cộng số lượng lên
                hdct.SoLuong += 1;
            }
            db.SaveChanges();
            LuuViTri();
            NapDuLieu();
            NapDuLieuChiTiet();
            NapViTri();
        }
        private BanLe banLe;
        private Mon mon;
        int cardViewBanRowHandle = 0;
        int gridViewThucDonRowHandle = 0;
        private void LuuViTri()
        {
            //lưu vị trí hiện tại của các bảng
            banLe= (BanLe)cardViewBan.GetFocusedRow();
            mon = (Mon)gridViewThucDon.GetFocusedRow();
            if (banLe != null)
            {
                cardViewBanRowHandle = cardViewBan.LocateByValue("Id", banLe.IdBan);
            }
            if (mon != null)
            {
                gridViewThucDonRowHandle = gridViewThucDon.LocateByValue("Id", mon.IdMon);
            }
        }
        private void NapViTri()
        {
            if (cardViewBanRowHandle != GridControl.InvalidRowHandle)
            {
                cardViewBan.FocusedRowHandle = cardViewBanRowHandle;
            }
            if (gridViewThucDonRowHandle!=GridControl.InvalidRowHandle)
            {
                gridViewThucDon.FocusedRowHandle = gridViewThucDonRowHandle;
            }
            
        }

        private void BtnChuyenBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var oldViTri = (BanLe)cardViewBan.GetFocusedRow();
            if (oldViTri == null) return;
            
            FrmChuyenBan f = new FrmChuyenBan(this);
            f.vitri_old = oldViTri.IdBan;
            f.idHoaDon = oldViTri.IdPhieu;
            f.ShowDialog();
            
        }
        public void ChuyenBan(int vitricu, int vitrimoi, int idHoaDon)
        {
            db = new ModelQuanLiCafeDbContext();
            Ban vtc = db.Bans.Find(vitricu);
            Ban vtm = db.Bans.Find(vitrimoi);
            HoaDon hd = db.HoaDons.Find(idHoaDon);
            hd.IdBan = vitrimoi;
            db.SaveChanges();
            XtraMessageBox.Show("Đã chuyển từ bàn " + vtc.TenBan + " sang bàn " + vtm.TenBan, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NapDuLieu();
            NapDuLieuChiTiet();
            var a = cardViewBan.LocateByValue("Id", idHoaDon);
            cardViewBan.FocusedRowHandle = a;
        }

        private void BtnXoaBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XoaHoaDon();
        }
        private void XoaHoaDon()
        {
            try
            {
                db = new ModelQuanLiCafeDbContext();
                var vitri = (BanLe)cardViewBan.GetFocusedRow();
                if (vitri == null) return;
                if ((XtraMessageBox.Show("Việc này sẽ xoá hoá đơn hiện tại của "+vitri.TenBan+", bạn có muốn thực hiện không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    var hdct = db.HoaDonChiTiets.Where(s => s.IdHoaDon == vitri.IdPhieu).FirstOrDefault();
                    if (hdct == null)//hoá đơn chi tiết chưa có sản phẩm nào thì xoá hoá đơn
                    {
                        var hd = db.HoaDons.Find(vitri.IdPhieu);
                        db.HoaDons.Remove(hd);
                    }
                    else
                    {//ngược lại thì xoá hoá đơn chi tiết và hoá đơn
                        IEnumerable<HoaDonChiTiet> listHdct = db.HoaDonChiTiets.Where(s => s.IdHoaDon == vitri.IdPhieu);
                        db.HoaDonChiTiets.RemoveRange(listHdct);
                        var hoadon = db.HoaDons.Find(vitri.IdPhieu);
                        db.HoaDons.Remove(hoadon);
                    }
                    db.SaveChanges();
                    XtraMessageBox.Show("Đã xoá hoá đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NapDuLieu();
                    NapDuLieuChiTiet();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Đã xảy ra lỗi, không xoá được!"+Environment.NewLine+ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnChietKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmChietKhau f = new FrmChietKhau(this);
            f.ShowDialog();
        }
        public void CapNhatChietKhau(double chietkhau)
        {
            db = new ModelQuanLiCafeDbContext();
            var vitri = (BanLe)cardViewBan.GetFocusedRow();
            var hd = db.HoaDons.Find(vitri.IdPhieu);
            hd.ChietKhau = chietkhau;
            db.SaveChanges();
            LuuViTri();
            NapDuLieu();
            NapDuLieuChiTiet();
            NapViTri();
        }

        private void BtnThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vitri = (BanLe)cardViewBan.GetFocusedRow();
            if (vitri == null) return;
            if ((XtraMessageBox.Show("Bạn có muốn thực hiện thanh toán cho "+vitri.TenBan+" ?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question))==DialogResult.Yes)
            {
                db = new ModelQuanLiCafeDbContext();
                var report = new Reports.ReportPhieuThanhToan();
                var hd = db.HoaDons.Find(vitri.IdPhieu);
                report.NapDuLieu(hd);
                var printTool = new ReportPrintTool(report);
                printTool.Report.CreateDocument(true);
                printTool.ShowPreview();
                DaThanhToan(vitri.IdPhieu);
            }
        }
        private void DaThanhToan(int idHD)
        {
            db = new ModelQuanLiCafeDbContext();
            var hd=db.HoaDons.Find(idHD);
            hd.TrangThai = true;
            db.SaveChanges();
            NapDuLieu();
            NapDuLieuChiTiet();
        }
    }
}