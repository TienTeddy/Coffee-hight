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
        
        public double GetHoaDon_TongGia_TrangThaiChua()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var list = db.HoaDons.Where(x=>x.trangthai=="Chưa Thanh Toán");

            double sum = 0;
            foreach(var item in list)
            {
                sum += item.tonggia;
            }
            return sum;
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

        #region ThongKe
        public int CountHoaDon_Ngay()
        {
            DateTime now = DateTime.Now;
            db.Configuration.ProxyCreationEnabled = false;

            var num = 0;
            var list = db.HoaDons.Where(x => x.trangthai == "Đã Thanh Toán").ToList();

            foreach(var item in list)
            {
                DateTime s = Convert.ToDateTime(item.thoigian);
                string ss = now.Day.ToString();
                if ( ss == s.Day.ToString())
                {
                    num += 1;
                }
            }

            return num;
        }
        public int CountHoaDon_Thang()
        {
            DateTime now = DateTime.Now;
            db.Configuration.ProxyCreationEnabled = false;

            var num = 0;
            var list = db.HoaDons.Where(x => x.trangthai == "Đã Thanh Toán").ToList();

            foreach (var item in list)
            {
                DateTime s = Convert.ToDateTime(item.thoigian);
                string ss = now.Month.ToString();
                if (ss == s.Month.ToString())
                {
                    num += 1;
                }
            }

            return num;
        }
        public double DoanhThu_Ngay()
        {
            DateTime now = DateTime.Now;
            db.Configuration.ProxyCreationEnabled = false;

            double num = 0;
            var list = db.HoaDons.Where(x => x.trangthai == "Đã Thanh Toán").ToList();

            foreach (var item in list)
            {
                DateTime s = Convert.ToDateTime(item.thoigian);
                string ss = now.Day.ToString();
                if (ss == s.Day.ToString())
                {
                    num += item.tonggia;
                }
            }

            return num;
        }
        public double DoanhThu_Thang()
        {
            DateTime now = DateTime.Now;
            db.Configuration.ProxyCreationEnabled = false;

            double num = 0;
            var list = db.HoaDons.Where(x => x.trangthai == "Đã Thanh Toán").ToList();

            foreach (var item in list)
            {
                DateTime s = Convert.ToDateTime(item.thoigian);
                string ss = now.Month.ToString();
                if (ss == s.Month.ToString())
                {
                    num += item.tonggia;
                }
            }

            return num;
        }
        #endregion

        public int HoaDonDaBan()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var num = 0;
            var list = db.HoaDons.Where(x => x.trangthai == "Đã Thanh Toán").ToList();

            var dao = new HoaDonCTDAO();
            foreach (var item in list)
            {
                var hdct = db.HoaDonCTs.Where(x => x.id_hoadon == item.id_hoadon).ToList();
                if (hdct != null) { 
                    foreach(var item2 in hdct)
                    {
                        if (item.id_hoadon == item2.id_hoadon)
                        {
                            num += item2.soluong;
                        }
                    }
                }
            }

            return num;
        }

    }
}
