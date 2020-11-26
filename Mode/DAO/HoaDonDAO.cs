using Mode.EF;
using Mode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.DAO
{
    public class HoaDonDAO
    {
        Context_ db = null;
        public HoaDonDAO()
        {
            db = new Context_();
        }

        public List<HoaDon> GetHoaDon_All()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.HoaDons.ToList();
        }

        public List<HoaDon> GetHoaDon(int id_khachhang)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.HoaDons.Where(x => x.id_khachhang == id_khachhang).ToList();
        }
        
        public List<HoaDon> GetHoaDons(int id_khachhang)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.HoaDons.Where(x => x.id_khachhang == id_khachhang).ToList();
        }

        public int Deleted(int id_hoadon)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var result = db.HoaDons.FirstOrDefault(x => x.id_hoadon == id_hoadon);
            var success= db.HoaDons.Remove(result);
            db.SaveChanges();
            if (success != null) return 1;
            return 0;
        }

        public int CreateHoaDon(int id_khachhang, string hoten)
        {
            HoaDon result = new HoaDon();
            string now = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");

                var modal_To_EF = new HoaDon()
                {
                    id_khachhang = id_khachhang,
                    thoigian = now,
                    discount = 0,
                    diemcong = 0,
                    tonggia = 0,
                    soluong = 0,
                    trangthai = "Chưa Thanh Toán",
                    tenkhachhang = hoten
                };

                result = db.HoaDons.Add(modal_To_EF);
                db.SaveChanges();

            if (result != null) return result.id_hoadon;
            return -1;
        }

    }
}
