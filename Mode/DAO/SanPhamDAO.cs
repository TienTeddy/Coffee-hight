using Mode.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.DAO
{
    public class SanPhamDAO
    {
        Context_ db = null;
        public SanPhamDAO()
        {
            db = new Context_();
        }

        public List<SanPham> GetSanPham()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.SanPhams.ToList();
        }

        public List<SanPham> GetSanPham_id(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.SanPhams.Where(x=>x.id_loai==id).ToList();
        }
        
        public int CountSanPham()
        {
            db.Configuration.ProxyCreationEnabled = false;
            int sl = 0;
            var list = db.SanPhams.ToList();
            foreach(var item in list)
            {
                sl += item.soluong;
            }
            return sl;
        }

        public int CountSanPhamDaBan()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var dao = new HoaDonDAO();
            var hoadon = dao.HoaDonDaBan();
            return hoadon;
        }
    }
}
