namespace CafeApp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguyenLieu")]
    public partial class NguyenLieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguyenLieu()
        {
            PhieuNhapKhoChiTiets = new HashSet<PhieuNhapKhoChiTiet>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Ten { get; set; }

        public int IdNhom { get; set; }

        public int IdDVT { get; set; }

        public double Gia { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual DonViTinh DonViTinh { get; set; }

        public virtual NhomNguyenLieu NhomNguyenLieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapKhoChiTiet> PhieuNhapKhoChiTiets { get; set; }
    }
}
