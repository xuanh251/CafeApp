using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Models
{
    public class tempModel
    {
        public int Id { get; set; }
        public int IdBan { get; set; }
        public string TenBan { get; set; }
        public DateTime? NgayLapPhieu { get; set; }
        public string GhiChu { get; set; }
        public bool TrangThaiPhieu { get; set; } = false;
        public string CaLamViec { get; set; }
        private string thongTinChung;
        [NotMapped]
        public string ThongTinChung {
            get
            {
                if (TrangThaiPhieu)
                {
                    return string.Concat("<b>", TenBan, "</b><br>Sẵn sàng");
                }
                else
                {
                    return string.Concat("<b>", TenBan, "</b><br>Phiếu: ", Id);
                }
            }
            set
            {
                thongTinChung = value;
            }
        }

    }
}
