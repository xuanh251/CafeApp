namespace CafeApp.Model.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ban")]
    public partial class Ban
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ban()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBan { get; set; }

        [Required]
        [StringLength(50)]
        public string TenBan { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public const string TableName = "Bàn";
    }

    public class ChuyenBanModel
    {
        public int IdBan { get; set; }
        public string TenBan { get; set; }
        public string GhiChu { get; set; }
        private string thongTinBan;

        [NotMapped]
        public string ThongTinBan
        {
            get
            {
                return string.Concat("<b>", this.TenBan, "</b><br>Sẵn sàng");
            }
            set
            {
                this.thongTinBan = value;
            }
        }
    }
}