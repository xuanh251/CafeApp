namespace CafeApp.Model.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HoaDonChiTiet")]
    public partial class HoaDonChiTiet
    {
        private ModelQuanLiCafeDbContext db = new ModelQuanLiCafeDbContext();

        [Key, Column(Order = 1)]
        public int IdHoaDon { get; set; }

        [Key, Column(Order = 2)]
        public int IdMon { get; set; }

        public int SoLuong { get; set; } = 1;

        public virtual HoaDon HoaDon { get; set; }

        public virtual Mon Mon { get; set; }

        [NotMapped]
        public double DonGia
        {
            get
            {
                return Mon.DonGia;
            }
            set { }
        }

        [NotMapped]
        public double Tien
        {
            get
            {
                try
                {
                    return SoLuong * DonGia;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
    }
}