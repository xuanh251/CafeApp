namespace CafeApp.Model.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Mon")]
    public partial class Mon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mon()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
            DinhLuongs = new HashSet<DinhLuong>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMon { get; set; }

        [Required]
        [StringLength(100)]
        public string TenMon { get; set; }

        public int IdNhom { get; set; }

        public int IdDVT { get; set; }

        public double DonGia { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public virtual DonViTinh DonViTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }

        public virtual NhomMon NhomMon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DinhLuong> DinhLuongs { get; set; }

        public const string TableName = "Món";
    }
}