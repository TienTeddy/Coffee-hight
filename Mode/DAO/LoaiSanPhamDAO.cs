using Mode.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.DAO
{
    public class LoaiSanPhamDAO
    {
        Context_ db = null;
        public LoaiSanPhamDAO()
        {
            db = new Context_();
        }

        public List<LoaiSanPham> GetLoaiSanPham()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.LoaiSanPhams.ToList();
        }

        public List<LoaiSanPham> GetLoaiSanPham_id(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.LoaiSanPhams.Where(x => x.id_loai == id).ToList();
        }
    }
}
