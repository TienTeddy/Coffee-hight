using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom102_ManagerCoffee.Common
{
    //lưu thông tin cần nhớ tạm  lên ổ đĩa (session, ...)
    [Serializable]
    public class AccLogin
    {
        public long id_taikhoan { get; set; }
        public string TaiKhoan1 { get; set; }
        public string MatKhau { get; set; }
    }
}