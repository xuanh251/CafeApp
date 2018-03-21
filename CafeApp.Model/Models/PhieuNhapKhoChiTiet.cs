namespace CafeApp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhapKhoChiTiet")]
    public partial class PhieuNhapKhoChiTiet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdPhieuNhapKho { get; set; }

        public int IdNguyenLieu { get; set; }

        public int SoLuong { get; set; }

        public double? ChietKhau { get; set; }

        public virtual NguyenLieu NguyenLieu { get; set; }

        public virtual PhieuNhapKho PhieuNhapKho { get; set; }
    }
}
