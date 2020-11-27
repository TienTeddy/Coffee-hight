using Mode.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.DAO
{
    public class ThongKeDAO
    {
        Context_ db = null;
        public ThongKeDAO()
        {
            db = new Context_();
        }

        public int CreateThongKe(string tenthongke,string thoigian,double tongthu)
        {
            ThongKe res = new ThongKe();
            var modal_To_EF = new ThongKe()
            {
                tenthongke = tenthongke,
                tongthu = tongthu,
                thoigian = thoigian
            };

            res = db.ThongKes.Add(modal_To_EF);
            db.SaveChanges();

            if (res != null) return res.id_thongke;
            return 0;
        }

    }
}
