﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeApp.Model.Models;
using DevExpress.XtraEditors;

namespace CafeApp.Winform.Views
{
    public partial class FrmChiTietLoiNhuan : DevExpress.XtraEditors.XtraForm
    {
        ModelQuanLiCafeDbContext db { get; set; }
        public FrmChiTietLoiNhuan()
        {
            InitializeComponent();
        }
        public void KhoiTao(Mon mon)
        {
            db = new ModelQuanLiCafeDbContext();
            var giaMon = mon.DonGia;
            var listNguyenLieu = (from a in db.DinhLuongs
                                  join b in db.NguyenLieux
                                  on a.IdNguyenLieu equals b.IdNguyenLieu
                                  where a.IdMon == mon.IdMon
                                  select new { a.SoLuongNguyenLieu ,b.DonGia,b.SoLuongQuyDoi}).ToList();
            double giavon = 0;
            if (listNguyenLieu.Any())
            {
                foreach (var item in listNguyenLieu)
                {
                    giavon += (item.SoLuongNguyenLieu / item.SoLuongQuyDoi) * item.DonGia;
                }
            }
            LblTieuDe.Text = "Lợi nhuận của món: " + mon.Ten+"/1 món";
            LblGiaBan.Text = "Giá món: "+giaMon.ToString("c0");
            LblGiaVon.Text = "Tổng vốn:" +giavon.ToString("c0");
            LblLoiNhuan.Text = "Lợi nhuận: "+(giaMon - giavon).ToString("c0")+"("+Math.Round(((giaMon-giavon)/giaMon*100),2)+"%)";
            
            

        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}