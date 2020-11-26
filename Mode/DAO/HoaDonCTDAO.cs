using Mode.EF;
using Mode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.DAO
{
    public class HoaDonCTDAO
    {
        Context_ db = null;
        public HoaDonCTDAO()
        {
            db = new Context_();
        }

        public List<HoaDonCT> GetHoaDonCT_All()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.HoaDonCTs.ToList();
        }

        public List<HoaDonCT> GetHoaDonCTs(int id_khachhang)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.HoaDonCTs.Where(x => x.id_khachhang == id_khachhang).ToList();
        }

        public int CreateHoaDonCTs(List<HoaDonCT_Model> hd, int id_khachhang,int id_hoadon)
        {
            if (hd != null)
            {
                HoaDonCT result = new HoaDonCT();

                string now = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                foreach (var item in hd)
                {
                    var modal_To_EF = new HoaDonCT()
                    {
                        id_sanpham = item.idsanpham,
                        id_loai = item.idloai,
                        id_hoadon = id_hoadon,
                        discount = 0,
                        dongia = item.giasp,
                        soluong = item.soluong,
                        id_khachhang = id_khachhang
                    };

                    result = db.HoaDonCTs.Add(modal_To_EF);
                    db.SaveChanges();
                }

                if (result != null) return 1;
                return -1;
            }
            return 0;
        }
        
       
        public int Deleted(int id_hoadonct)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var result = db.HoaDonCTs.FirstOrDefault(x => x.id_hoadonct == id_hoadonct);
            var success = db.HoaDonCTs.Remove(result);

            db.SaveChanges();
            if (success != null) return 1;
            return 0;
        }
    }
}
