using Mode.DAO;
using Mode.Models;
using Nhom102_ManagerCoffee.Common;
using Nhom102_ManagerCoffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom102_ManagerCoffee.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            var session_acc = SessionHelper.GetSession();
            if (session_acc != null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models_TaiKhoan taikhoan)
        {
            var dao = new TaiKhoanDAO();
            int result = dao.CheckLogin(taikhoan.taikhoan1, taikhoan.matkhau);
            if (result >= 12) //managemant
            {
                // add session
                if (taikhoan.checkbox == true)
                {
                    HttpCookie newCookie = new HttpCookie("Account-Cookie");
                    newCookie["TaiKhoan"] = taikhoan.taikhoan1.ToString();
                    newCookie.Expires = DateTime.Now.AddDays(365);
                    newCookie["MatKhau"] = taikhoan.matkhau.ToString();
                    newCookie.Expires = DateTime.Now.AddDays(365);
                    Response.AppendCookie(newCookie);
                }
                ViewBag.Message = "true";
                SessionHelper.SetSession(new AccLogin() { TaiKhoan1 = taikhoan.taikhoan1, MatKhau = taikhoan.matkhau });
                return RedirectToAction("Index", "Admin/Admin/Index");
            }
            else if (result == 11) //customer
            {
                // add session
                if (taikhoan.checkbox == true)
                {
                    HttpCookie newCookie = new HttpCookie("Account-Cookie");
                    newCookie["TaiKhoan"] = taikhoan.taikhoan1.ToString();
                    newCookie.Expires = DateTime.Now.AddDays(365);
                    newCookie["MatKhau"] = taikhoan.matkhau.ToString();
                    newCookie.Expires = DateTime.Now.AddDays(365);
                    Response.AppendCookie(newCookie);
                }
                ViewBag.Message = "true";
                SessionHelper.SetSession(new AccLogin() { TaiKhoan1 = taikhoan.taikhoan1, MatKhau = taikhoan.matkhau });
                return RedirectToAction("Index", "Home");
            }
            else if (result == 0 || result == -1) //fail login
            {
                ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu!"); //-sumary
                return View("Index", taikhoan);
            }

            return View("Index");
        }

        public ActionResult Logout()
        {
            SessionHelper.ClearSession();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Infor()
        {
            return View();
        }
        public JsonResult GetInfor()
        {
            var session_acc = SessionHelper.GetSession();
            if (session_acc != null)
            {
                var daotk = new TaiKhoanDAO();
                var resulttk = daotk.GetTaiKhoan_user(session_acc.TaiKhoan1, session_acc.MatKhau);

                var dao = new KhachHangDAO();
                var result = dao.GetKhachHang_userTaiKhoan(resulttk.id_taikhoan);

                return Json(result, JsonRequestBehavior.AllowGet);

            }
            else { return null; }
        }

        public JsonResult GetInfor_TaiKhoan()
        {
            var session_acc = SessionHelper.GetSession();
            if (session_acc != null)
            {
                var daotk = new TaiKhoanDAO();
                var resulttk = daotk.GetTaiKhoan_user(session_acc.TaiKhoan1, session_acc.MatKhau);
                return Json(resulttk, JsonRequestBehavior.AllowGet);
            }
            else { return null; }
        } 

        public ActionResult Reset()
        {
            return View();
        }
    }
}