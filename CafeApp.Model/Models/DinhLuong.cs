namespace CafeApp.Model.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DinhLuong")]
    public partial class DinhLuong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdNguyenLieu { get; set; }

        public int TiLeNguyenLieu { get; set; }

        public int IdMon { get; set; }

        public int TiLeMon { get; set; }

        public virtual NguyenLieu NguyenLieu { get; set; }

        public virtual ThucDon ThucDon { get; set; }
    }
}