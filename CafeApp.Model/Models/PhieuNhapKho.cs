namespace CafeApp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("PhieuNhapKho")]
    public partial class PhieuNhapKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhapKho()
        {
            PhieuNhapKhoChiTiets = new HashSet<PhieuNhapKhoChiTiet>();
        }
        [Key]
        [StringLength(200)]
        public string SoHoaDon { get; set; }

        public int IdDoiTac { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLapPhieu { get; set; } = DateTime.Now;

        public int NguoiTao { get; set; }

        public double ChietKhau { get; set; } = 0;
        [NotMapped]
        public double TienChietKhau
        {
            get
            {
                return TongTien * ChietKhau / 100;
            }
        }

        [StringLength(500)]
        public string GhiChu { get; set; }

        public virtual DoiTac DoiTac { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
       
        [NotMapped]
        public double TongTien
        {
            get
            {
                try
                {
                    var tien = PhieuNhapKhoChiTiets.Select(s => s.Tien).Sum();
                    return tien;
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }
        [NotMapped]
        public double ThanhTien
        {
            get
            {
                return TongTien - TienChietKhau;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapKhoChiTiet> PhieuNhapKhoChiTiets { get; set; }
        public const string TableName = "Phiếu";
    }
}