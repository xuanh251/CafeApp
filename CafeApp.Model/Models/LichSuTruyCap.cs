namespace CafeApp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichSuTruyCap")]
    public partial class LichSuTruyCap
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? IdTaiKhoan { get; set; }

        public DateTime? ThoiDiemDangNhap { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
