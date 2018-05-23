namespace CafeApp.Model.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PhieuNhapKhoChiTiet")]
    public partial class PhieuNhapKhoChiTiet
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string SoHoaDon { get; set; }

        [Key]
        [Column(Order = 2)]
        public int IdNguyenLieu { get; set; }

        public int SoLuong { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }
        [NotMapped]
        public double DonGia
        {
            get
            {
                try
                {
                    return NguyenLieu.DonGia;
                }
                catch (System.Exception)
                {
                    return 0;
                }
                
            }
            set { }
        }
        public string GhiChu { get; set; }
        [NotMapped]
        public int STT { get; set; }
        [NotMapped]
        public double Tien
        {
            get
            {
                return SoLuong * DonGia;
            }
        }

        

        public virtual PhieuNhapKho PhieuNhapKho { get; set; }
        public const string TableName = "Phiếu nhập kho chi tiết";
    }
}