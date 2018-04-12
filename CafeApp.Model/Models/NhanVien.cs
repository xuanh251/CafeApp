namespace CafeApp.Model.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNhanVien { get; set; }

        [Required]
        [StringLength(100)]
        public string HoDem { get; set; }

        [Required]
        [StringLength(100)]
        public string Ten { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; } = "Nam";

        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(50)]
        public string SoDienThoai { get; set; }
        public double Luong { get; set; }=0;

        public int IdChucVu { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual ChucVu ChucVu { get; set; }
        public const string TableName = "Nhân viên";

    }
}