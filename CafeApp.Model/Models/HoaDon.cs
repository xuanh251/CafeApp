namespace CafeApp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            HoaDonChiTiets = new BindingList<HoaDonChiTiet>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdBan { get; set; }

        public int NguoiTao { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayTao { get; set; }

        public bool TrangThai { get; set; }

        [Required]
        [StringLength(50)]
        public string CaLamViec { get; set; }

        public double? ChietKhau { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual Ban Ban { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual BindingList<HoaDonChiTiet> HoaDonChiTiets { get; set; }

        [NotMapped]
        public double ThanhTien
        {
            get
            {
                try
                {
                    var tongTien = (from hdct in HoaDonChiTiets select hdct.Tien).Sum();
                    return tongTien;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
    }
}