using Mode.DAO;
using Mode.Models;
using Facebook;
using Nhom102_ManagerCoffee.Common;
using Nhom102_ManagerCoffee.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        //Login FB
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email" // Add other permissions as needed
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            // Store the access token in the session for farther use
            Session["AccessToken"] = accessToken;

            // update the facebook client with the access token so 
            // we can make requests on behalf of the user
            fb.AccessToken = accessToken;

            // Get the user's information
            dynamic me = fb.Get("me?fields=name,id,email,picture");
            string email = me.email;
            string name = me.name;
            string id = me.id;
            string picture = "https://graph.facebook.com/" + id + "/picture?type=normal";


            var dao = new TaiKhoanDAO();
            int result_tk = dao.Create_TaiKhoan("Khách Hàng",email,"");

            if (result_tk == 1)
            {
                //TempData["NewCustomer"] = user;

                // Set the auth cookie
                FormsAuthentication.SetAuthCookie(email, false);

                SessionHelper.SetSession(new AccLogin() { TaiKhoan1 = email, MatKhau = "" });
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            if (result_tk == 2)
            {
                var result2 = dao.GetTaiKhoan(email);
                SessionHelper.SetSession(new AccLogin() { TaiKhoan1 = result2.taikhoan1, MatKhau=result2.matkhau });
                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        //LoginGG
        public ActionResult LoginGoogle(string name, string email)
        {
            var dao = new TaiKhoanDAO();
            int result_tk = dao.Create_TaiKhoan("Khách Hàng", email, "");

            if (result_tk == 1)
            {
                //TempData["NewCustomer"] = user;

                // Set the auth cookie
                FormsAuthentication.SetAuthCookie(email, false);

                SessionHelper.SetSession(new AccLogin() { TaiKhoan1 = email, MatKhau = "" });
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            if (result_tk == 2)
            {
                var result2 = dao.GetTaiKhoan(email);
                SessionHelper.SetSession(new AccLogin() { TaiKhoan1 = result2.taikhoan1, MatKhau = result2.matkhau });
                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }
    }
}