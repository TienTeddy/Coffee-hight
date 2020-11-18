using Mode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.DAO
{
    public class TaiKhoanDAO
    {
        Context_ db = null;
        public TaiKhoanDAO()
        {
            db = new Context_();
        }

        public TaiKhoan GetTaiKhoan(string taikhoan)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TaiKhoans.Single(x=>x.taikhoan1==taikhoan);
        }

        public TaiKhoan GetTaiKhoan_user(string user, string pass)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.TaiKhoans.Single(x=>x.taikhoan1==user&&x.matkhau==pass);
        }

        public int CheckLogin(string user,string pass)
        {
            var ok= new TaiKhoan();
            if (db.TaiKhoans.Count(x => x.taikhoan1 == user)>0)
            {
                if(db.TaiKhoans.Count(x => x.matkhau == pass) > 0)
                {
                    ok = db.TaiKhoans.FirstOrDefault(a => a.taikhoan1 == user);
                    if(ok.loaitk=="Khách Hàng")
                    {
                        return 11;
                    }
                    else if(ok.loaitk=="Nhân Viên")
                    {
                        return 12;
                    }
                    else
                    {
                        return 13;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }

        }

        public int Create_TaiKhoan(string loaitk,string taikhoan, string matkhau)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (db.TaiKhoans.Count(x => x.taikhoan1 == taikhoan) > 0)
            {
                if(db.TaiKhoans.Count(x => x.matkhau == matkhau) > 0)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else //not exits account
            {
                var tk = new TaiKhoan()
                {
                    loaitk = loaitk,
                    taikhoan1 = taikhoan,
                    matkhau = matkhau
                };
                var result = db.TaiKhoans.Add(tk);

                db.SaveChanges();
                if (result != null) return 1;
                else return 0;
            }  
        }
    }
}
