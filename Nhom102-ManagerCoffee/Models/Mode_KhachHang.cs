using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom102_ManagerCoffee.Models
{
    public class Mode_KhachHang
    {
        public int id_khachhang { get; set; }

        public int? id_taikhoan { get; set; }

        public string hoten { get; set; }

        public string gioitinh { get; set; }

        public string diachi { get; set; }

        public int? sdt { get; set; }

        public double? diem { get; set; }
    }
}