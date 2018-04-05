namespace CafeApp.Model.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LichSuTruyCap")]
    public partial class LichSuTruyCap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? IdTaiKhoan { get; set; }

        public DateTime ThoiDiemDangNhap { get; set; }

        public bool? TrangThai { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}