using Mode;
using Mode.DAO;
using Nhom102_ManagerCoffee.Common;
using Nhom102_ManagerCoffee.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom102_ManagerCoffee.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var session_acc = SessionHelper.GetSession();
            if (session_acc != null)
            {
                if (session_acc.MatKhau == "")
                {
                    ViewBag.setpass = "YES";
                }
            }
            else
            {
                ViewBag.setpass = "NO";
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TaiKhoan()
        {
            return View();
        }

        public ActionResult ThucDon()
        {
            ViewBag.Message = "Thực Đơn";

            var sanpham = new SanPhamDAO();
            var result = sanpham.GetSanPham().ToList();

            
            return View(result);
        }

        //[HttpPost]
        public JsonResult LoaiSanPham_show()
        {
            var dao = new LoaiSanPhamDAO();
            var result = dao.GetLoaiSanPham();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetSanPham_id(int id)
        {
            var dao = new SanPhamDAO();
            var result = dao.GetSanPham_id(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}