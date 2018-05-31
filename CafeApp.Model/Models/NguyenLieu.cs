namespace CafeApp.Model.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NguyenLieu")]
    public partial class NguyenLieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguyenLieu()
        {
            PhieuNhapKhoChiTiets = new HashSet<PhieuNhapKhoChiTiet>();
            DinhLuongs = new HashSet<DinhLuong>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNguyenLieu { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNguyenLieu { get; set; }

        public int IdNhom { get; set; }

        public int IdDVT { get; set; }
        public double SoLuongTon { get; set; }
        public int IdDVTQuyDoi { get; set; }
        public double SoLuongQuyDoi { get; set; }

        public double DonGia { get; set; }

        public virtual DonViTinh DonViTinh { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual NhomNguyenLieu NhomNguyenLieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapKhoChiTiet> PhieuNhapKhoChiTiets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DinhLuong> DinhLuongs { get; set; }

        public const string TableName = "Nguyên Liệu";

        [NotMapped]
        public double TongSoLuongTonQuyDoi
        {
            get
            {
                return SoLuongTon * SoLuongQuyDoi;
            }
        }
    }
}