using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Model.Models
{
    public class QuyDoiDVT
    {
        [Key,Column(Order =1)]
        public int IdDVTBanDau { get; set; }
        [Key, Column(Order = 2)]
        public int IdDVTQuyDoi { get; set; }
        public int SLQuyDoi { get; set; }
        public virtual DonViTinh DVTBanDau { get; set; }
        public virtual DonViTinh DVTQuyDoi { get; set; }
    }
}
