using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.Models
{
    public class HoaDonCT_Model
    {
        public int idsanpham { get; set; }

        public int? idloai { get; set; }
        
        public int idhoadon { get; set; }

        public string tensp { get; set; }

        public double? giasp { get; set; }

        public int soluong { get; set; }

    }
}
