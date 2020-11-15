using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.Models
{
    public class TaiKhoan_KhachHang
    {
        public int id_taikhoan { get; set; }

        public int id_khachhang { get; set; }

        public string loaitk { get; set; }

        public string taikhoan1 { get; set; }

        public string matkhau { get; set; }

        public string hoten { get; set; }

        public string gioitinh { get; set; }

        public string diachi { get; set; }

        public int? sdt { get; set; }

        public double? diem { get; set; }
    }
}
