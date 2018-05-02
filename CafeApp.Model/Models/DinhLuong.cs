namespace CafeApp.Model.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DinhLuong")]
    public partial class DinhLuong
    {
        [Key, Column(Order = 1)]
        public int IdNguyenLieu { get; set; }

        public double SoLuongNguyenLieu { get; set; }
        [Key, Column(Order = 2)]

        public int IdMon { get; set; }


        public virtual NguyenLieu NguyenLieu { get; set; }

        public virtual Mon Mon { get; set; }
    }
}