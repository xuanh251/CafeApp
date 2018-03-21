namespace CafeApp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhapKho")]
    public partial class PhieuNhapKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhapKho()
        {
            PhieuNhapKhoChiTiets = new HashSet<PhieuNhapKhoChiTiet>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdDoiTac { get; set; }

        [Required]
        [StringLength(200)]
        public string SoHoaDon { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLapPhieu { get; set; }

        public int NguoiTao { get; set; }

        public bool TrangThaiPhieu { get; set; }

        public double? ChietKhau { get; set; }

        public virtual DoiTac DoiTac { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapKhoChiTiet> PhieuNhapKhoChiTiets { get; set; }
    }
}
