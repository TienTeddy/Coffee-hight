using Mode.EF;
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

        public List<TaiKhoan> GetTaiKhoan_All()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.TaiKhoans.ToList();
        }

        public TaiKhoan GetTaiKhoan(string taikhoan)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TaiKhoans.FirstOrDefault(x=>x.Taikhoan==taikhoan);
        }

        public TaiKhoan GetTaiKhoan_user(string user, string pass)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.TaiKhoans.FirstOrDefault(x=>x.Taikhoan==user&&x.matkhau==pass);
        }

        public int CheckLogin(string user,string pass)
        {
            var ok= new TaiKhoan();
            if (db.TaiKhoans.Count(x => x.Taikhoan == user)>0)
            {
                //int k = db.TaiKhoans.Count(x=>x.matkhau==pass);
                if(db.TaiKhoans.Count(x=>x.Taikhoan ==user & x.matkhau == pass) > 0)
                {
                    ok = db.TaiKhoans.Single(a => a.Taikhoan == user);
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

        public List<TaiKhoan> GetTaiKhoan_userList(string user, string pass)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.TaiKhoans.Where(x => x.Taikhoan == user && x.matkhau == pass).ToList();
        }

        public int Create_TaiKhoan(string loaitk,string taikhoan, string matkhau)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (db.TaiKhoans.Count(x => x.Taikhoan == taikhoan) > 0)
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
                    Taikhoan = taikhoan,
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
