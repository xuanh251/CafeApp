using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Models
{
    public class Ban
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string TenBan { get; set; }
        public string GhiChu { get; set; }
        public virtual ICollection<PhieuBanHang> PhieuBanHangs { get; set; }
    }
}
