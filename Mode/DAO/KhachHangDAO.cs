using Mode.EF;
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

        public KhachHang GetKhachHang(int id_taikhoan)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.KhachHangs.FirstOrDefault(x => x.id_taikhoan == id_taikhoan);
        }

        public List<KhachHang> GetKhachHang_ListOner(int id_khachhang)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.KhachHangs.Where(x => x.id_khachhang == id_khachhang).ToList();
        }

        public KhachHang GetKhachHangs(int id_khachhang)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.KhachHangs.FirstOrDefault(x => x.id_khachhang == id_khachhang);
        }

        public List<KhachHang> GetKhachHang_All()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.KhachHangs.ToList();
        }
        
        public TaiKhoan SetKhachHang(int id_khachhang,string hoten, string diachi, string email, string matkhau)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var res = db.KhachHangs.FirstOrDefault(x=>x.id_khachhang==id_khachhang);
            var res2 = db.TaiKhoans.FirstOrDefault(x => x.id_taikhoan == res.id_taikhoan);
            if (res != null)
            {

                res.hoten = hoten;
                res.diachi = diachi;

                res2.matkhau = matkhau;

                db.SaveChanges();

                return res2;
            }
            return null;
        }
    }
}
