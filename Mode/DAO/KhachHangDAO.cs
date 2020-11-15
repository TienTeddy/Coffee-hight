using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.DAO
{
    public class KhachHangDAO
    {
        Context_ db = null;
        public KhachHangDAO()
        {
            db = new Context_();
        }

        public List<KhachHang> GetKhachHang_userTaiKhoan(int id_taikhoan)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.KhachHangs.Where(x=>x.id_taikhoan==id_taikhoan).ToList();
        }
    }
}
