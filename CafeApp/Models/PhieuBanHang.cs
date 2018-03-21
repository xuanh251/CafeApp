using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Models
{
    public class PhieuBanHang
    {
        [Key]
        public int Id { get; set; }
        public int IdBan { get; set; }
        public DateTime NgayLapPhieu { get; set; }
        public string GhiChu { get; set; }
        public bool TrangThaiPhieu { get; set; }
        public virtual Ban Ban { get; set; }
        public string CaLamViec { get; set; }
    }
}
