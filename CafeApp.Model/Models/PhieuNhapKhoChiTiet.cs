namespace CafeApp.Model.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PhieuNhapKhoChiTiet")]
    public partial class PhieuNhapKhoChiTiet
    {
        [Key]
        [Column(Order =1)]
        public int IdPhieuNhapKho { get; set; }
        [Key]
        [Column(Order = 2)]

        public int IdNguyenLieu { get; set; }

        public int SoLuong { get; set; }

        public double? ChietKhau { get; set; }

        public virtual NguyenLieu NguyenLieu { get; set; }

        public virtual PhieuNhapKho PhieuNhapKho { get; set; }
    }
}