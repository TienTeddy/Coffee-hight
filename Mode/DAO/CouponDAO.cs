using Mode.EF;
using Mode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.DAO
{
    public class CouponDAO
    {
        Context_ db = null;
        public CouponDAO()
        {
            db = new Context_();
        }

        public List<Coupon> GetCoupon_All()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.Coupons.ToList();
        }
        
        public int CreateCoupon(List<Coupon_Model> cp)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var ok = new Coupon();
            foreach (var item in cp)
            {
                var add = new Coupon()
                {
                    id_khachhang = item.id_khachhang,
                    tencoupon = item.tencoupon,
                    lifetime = item.lifetime,
                    thestart = item.thestart,
                    theend = item.theend,
                    discount = item.discount,
                    status = "Chưa Sử Dụng"
                };
                ok = db.Coupons.Add(add);
            }
            db.SaveChanges();

            if (ok!=null) return 1;
            return 0;
        }

        public List<Coupon> GetCoupon_KH(int id_khachhang)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.Coupons.Where(x=>x.id_khachhang==id_khachhang & x.status=="Chưa Sử Dụng").ToList();
        }
    }
}
