namespace CafeApp.Model.Models
{
    using System;
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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHoaDon { get; set; }

        public int IdBan { get; set; }

        public int NguoiTao { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayTao { get; set; }

        public bool TrangThai { get; set; }

        [NotMapped]
        public string STrangThai
        {
            get
            {
                return TrangThai ? "Đã thanh toán" : "Chưa thanh toán";
            }
        }

        [Required]
        [StringLength(50)]
        public string CaLamViec { get; set; }

        [Display(Name = "Chiết khấu", Description = "Giảm giá theo % trên tổng tiền của phiếu")]
        [Required, DefaultValue(0)]
        public double ChietKhau { get; set; }

        [NotMapped]
        [Display(Name = "Tiền CK", Description = "Tiền chiết khẩu sản phẩm")]
        public double TienChietKhau
        {
            get
            {
                return (this.TongTien) * ChietKhau / 100;
            }
        }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual Ban Ban { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual BindingList<HoaDonChiTiet> HoaDonChiTiets { get; set; }

        [NotMapped]
        public double TongTien
        {
            get
            {
                try
                {
                    var tongTien = HoaDonChiTiets.Select(s => s.Tien).Sum();
                    return tongTien;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        [NotMapped]
        [Display(Name = "Thành tiền", Description = "Tổng tiền sản phẩm")]
        public double ThanhTien
        {
            get
            {
                return this.TongTien - TienChietKhau;
            }
        }
    }
}