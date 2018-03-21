namespace CafeApp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("HoaDonChiTiet")]
    public partial class HoaDonChiTiet
    {
        ModelQuanLiCafeDbContext db = new ModelQuanLiCafeDbContext();
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdHoaDon { get; set; }

        public int IdMon { get; set; }

        public int SoLuong { get; set; } = 1;

        public virtual HoaDon HoaDon { get; set; }

        public virtual ThucDon ThucDon { get; set; }

        public double DonGia { get; set; }
        [NotMapped]
        public double Tien
        {
            get
            {
                try
                {
                    return SoLuong*DonGia;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
    }
}
