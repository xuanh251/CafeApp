using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeApp.Model;

namespace CafeApp.Model.Models
{
    public class BanLe
    {
        public BanLe()
        {
            hoaDonChiTiets = new BindingList<HoaDonChiTiet>();
        }
        public int Id { get; set; }
        public int IdBan { get; set; }
        public string TenBan { get; set; }
        public DateTime? NgayLapHoaDon { get; set; }
        public bool TrangThaiHoaDon { get; set; }
        public string GhiChu { get; set; }
        public string CaLamViec { get; set; }
        public double ChietKhau { get; set; }
        public BindingList<HoaDonChiTiet> hoaDonChiTiets { get; set; }

        public const string TableName = "Hoá đơn bán lẻ";
        [NotMapped]
        [Display(Name = "Tổng tiền")]
        public double TongTien
        {
            get
            {
                try
                {
                    var tongTien = (from hdct in this.hoaDonChiTiets select hdct.Tien).Sum();
                    return tongTien;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        [NotMapped]
        [Display(Name = "Tổng tiền (text)")]
        public string TongTienText
        {
            get
            {
                try
                {
                    return TongTien.ToString("c0");
                }
                catch (Exception)
                {
                    return "0 đ";
                }
            }

        }
        public Ban Ban { get; set; }
        private string thongTinChung;
        [NotMapped]
        [Display(Name = "Thông tin chung")]
        public string ThongTinChung
        {
            get
            {
                if (this.TrangThaiHoaDon)
                {
                    return string.Concat("<b>", this.TenBan, "</b><br>Sẵn sàng");
                }
                else
                {
                    return string.Concat("<b>", this.TenBan, "</b><br>Phiếu: ", this.Id);
                }
            }
            set
            {
                this.thongTinChung = value;
            }
        }

        /// <summary>
        /// Mapping dữ liệu từ Class BanLe sang hoá đơn
        /// </summary>
        /// <param name="banLeModel"></param>
        /// <returns></returns>
        public static HoaDon TaoHoaDon(BanLe banLeModel)
        {
            return new HoaDon
            {
                Id = banLeModel.Id,
                IdBan = banLeModel.IdBan,
                GhiChu = banLeModel.GhiChu,
                NgayTao = (banLeModel.NgayLapHoaDon.HasValue ? banLeModel.NgayLapHoaDon.Value : DateTime.MinValue),
                HoaDonChiTiets = banLeModel.hoaDonChiTiets,
                TrangThai = banLeModel.TrangThaiHoaDon,
                Ban = banLeModel.Ban
            };
        }
    }
}
