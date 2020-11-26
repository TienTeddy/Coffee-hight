using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.Models
{
    public class Coupon_Model
    {
        public int? id_khachhang { get; set; }

        public string tencoupon { get; set; }

        public string lifetime { get; set; }

        public string thestart { get; set; }

        public string theend { get; set; }

        public string discount { get; set; }

        public string status { get; set; }
    }
}
