namespace CafeApp.Model.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string HoDem { get; set; }

        [Required]
        [StringLength(100)]
        public string Ten { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgaySinh { get; set; }

        public bool GioiTinh { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(50)]
        public string SoDienThoai { get; set; }

        public int ChucVu { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual ChucVu ChucVu1 { get; set; }
    }
}