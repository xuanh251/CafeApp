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
using System.Data.Entity;

namespace CafeApp.Winform.Views
{
    public partial class FrmLichSuTruyCap : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public FrmLichSuTruyCap()
        {
            InitializeComponent();
            db = new ModelQuanLiCafeDbContext();
            comboBoxEditKieuLoc.SelectedIndex = 2;
            comboBoxEditTrangThai.SelectedIndex = 2;
            KiemTraTuyChon();
            NapDuLieu(comboBoxEditKieuLoc.SelectedIndex, comboBoxEditTrangThai.SelectedIndex);
        }

        public void NapDuLieu(int KieuLoc, int TrangThai)
        {
            if (comboBoxEditKieuLoc.SelectedIndex == 0) //trong ngay
            {
                if (comboBoxEditTrangThai.SelectedIndex != 2)
                {
                    try
                    {
                        var listData = (from lstc in db.LichSuTruyCaps
                                        join tk in db.TaiKhoans
                                        on lstc.IdTaiKhoan equals tk.Id
                                        where lstc.ThoiDiemDangNhap == DateTime.Today
                                        && lstc.TrangThai == (comboBoxEditTrangThai.SelectedIndex == 0 ? true : false)
                                        select new { lstc.Id, tk.TenDangNhap, SThoiDiemDangNhap = lstc.ThoiDiemDangNhap.ToString(), STrangThai = lstc.TrangThai == true ? "Đang sử dụng" : "Đã thoát" }).ToList();
                        gridControlLichSuTruyCap.DataSource = listData;
                        gridViewLichSuTruyCap.RefreshData();
                        gridViewLichSuTruyCap.BestFitColumns();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Xảy ra lỗi khi nạp dữ liệu!", "Nạp dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    try
                    {
                        var listData = (from lstc in db.LichSuTruyCaps
                                        join tk in db.TaiKhoans
                                        on lstc.IdTaiKhoan equals tk.Id
                                        where lstc.ThoiDiemDangNhap == DateTime.Today
                                        select new { lstc.Id, tk.TenDangNhap, SThoiDiemDangNhap = lstc.ThoiDiemDangNhap.ToString(), STrangThai = lstc.TrangThai == true ? "Đang sử dụng" : "Đã thoát" }).ToList();
                        gridControlLichSuTruyCap.DataSource = listData;
                        gridViewLichSuTruyCap.RefreshData();
                        gridViewLichSuTruyCap.BestFitColumns();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Xảy ra lỗi khi nạp dữ liệu!", "Nạp dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            if (comboBoxEditKieuLoc.SelectedIndex == 1)//từ ngày đến ngày
            {
                if (comboBoxEditTrangThai.SelectedIndex != 2)
                {
                    try
                    {
                        var listData = (from lstc in db.LichSuTruyCaps
                                        join tk in db.TaiKhoans
                                        on lstc.IdTaiKhoan equals tk.Id
                                        where lstc.ThoiDiemDangNhap > dateTimePickerTuNgay.Value.Date && lstc.ThoiDiemDangNhap < dateTimePickerDenNgay.Value.Date
                                        && lstc.TrangThai == (comboBoxEditTrangThai.SelectedIndex == 0 ? true : false)
                                        select new { lstc.Id, tk.TenDangNhap, SThoiDiemDangNhap = lstc.ThoiDiemDangNhap.ToString(), STrangThai = lstc.TrangThai == true ? "Đang sử dụng" : "Đã thoát" }).ToList();
                        gridControlLichSuTruyCap.DataSource = listData;
                        gridViewLichSuTruyCap.RefreshData();
                        gridViewLichSuTruyCap.BestFitColumns();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Xảy ra lỗi khi nạp dữ liệu!", "Nạp dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    try
                    {
                        var listData = (from lstc in db.LichSuTruyCaps
                                        join tk in db.TaiKhoans
                                        on lstc.IdTaiKhoan equals tk.Id
                                        where lstc.ThoiDiemDangNhap > dateTimePickerTuNgay.Value.Date && lstc.ThoiDiemDangNhap < dateTimePickerDenNgay.Value.Date
                                        select new { lstc.Id, tk.TenDangNhap, SThoiDiemDangNhap = lstc.ThoiDiemDangNhap.ToString(), STrangThai = lstc.TrangThai == true ? "Đang sử dụng" : "Đã thoát" }).ToList();
                        gridControlLichSuTruyCap.DataSource = listData;
                        gridViewLichSuTruyCap.RefreshData();
                        gridViewLichSuTruyCap.BestFitColumns();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Xảy ra lỗi khi nạp dữ liệu!", "Nạp dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            else//tất cả
            {
                if (comboBoxEditTrangThai.SelectedIndex!=2)
                {
                    try
                    {
                        var listData = (from lstc in db.LichSuTruyCaps
                                        join tk in db.TaiKhoans
                                        on lstc.IdTaiKhoan equals tk.Id
                                        where lstc.TrangThai == (comboBoxEditTrangThai.SelectedIndex == 0 ? true : false)
                                        select new { lstc.Id, tk.TenDangNhap, SThoiDiemDangNhap = lstc.ThoiDiemDangNhap.ToString(), STrangThai = lstc.TrangThai == true ? "Đang sử dụng" : "Đã thoát" }).ToList();
                        gridControlLichSuTruyCap.DataSource = listData;
                        gridViewLichSuTruyCap.RefreshData();
                        gridViewLichSuTruyCap.BestFitColumns();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Xảy ra lỗi khi nạp dữ liệu!", "Nạp dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    try
                    {
                        var listData = (from lstc in db.LichSuTruyCaps
                                        join tk in db.TaiKhoans
                                        on lstc.IdTaiKhoan equals tk.Id
                                        select new { lstc.Id, tk.TenDangNhap, SThoiDiemDangNhap = lstc.ThoiDiemDangNhap.ToString(), STrangThai = lstc.TrangThai == true ? "Đang sử dụng" : "Đã thoát" }).ToList();
                        gridControlLichSuTruyCap.DataSource = listData;
                        gridViewLichSuTruyCap.RefreshData();
                        gridViewLichSuTruyCap.BestFitColumns();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Xảy ra lỗi khi nạp dữ liệu!", "Nạp dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
            }

        }

        private void BtnLoc_Click(object sender, EventArgs e)
        {
            NapDuLieu(comboBoxEditKieuLoc.SelectedIndex,comboBoxEditTrangThai.SelectedIndex);
        }
        private void KiemTraTuyChon()
        {
            if (comboBoxEditKieuLoc.SelectedIndex == 0 || comboBoxEditKieuLoc.SelectedIndex == 2)
            {
                dateTimePickerTuNgay.Enabled = false;
                dateTimePickerDenNgay.Enabled = false;
            }
            else
            {
                dateTimePickerTuNgay.Enabled = true;
                dateTimePickerDenNgay.Enabled = true;
            }
        }
        private void comboBoxEditKieuLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            KiemTraTuyChon();
        }
    }
}