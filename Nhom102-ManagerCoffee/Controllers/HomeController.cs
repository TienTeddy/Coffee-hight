using Mode;
using Mode.DAO;
using Mode.EF;
using Mode.Models;
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

        [HttpPost]
        public JsonResult DatHang(List<HoaDonCT_Model> data)
        {
            var session_acc = SessionHelper.GetSession();
            if (session_acc != null)
            {
                ViewBag.taikhoan = session_acc.TaiKhoan1;
            }

            //create hoadon
            var daohd = new HoaDonDAO();
            int resulthd = daohd.CreateHoaDon(session_acc.id_khachhang,session_acc.hoten); //id_hoadon

            //create hoadonct
            var daoct = new HoaDonCTDAO();
            var result = daoct.CreateHoaDonCTs(data,session_acc.id_khachhang,resulthd);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult GetHoaDonCTs()
        {
            var session_acc = SessionHelper.GetSession();
            if (session_acc != null)
            {
                var hoadonct = new HoaDonCTDAO();
                var result = hoadonct.GetHoaDonCTs(session_acc.id_khachhang);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetHoaDons()
        {
            var session_acc = SessionHelper.GetSession();
            if (session_acc != null)
            {
                var hoadon = new HoaDonDAO();
                var result = hoadon.GetHoaDons(session_acc.id_khachhang);

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Delete_HoaDonCT(int id)
        {
            var dao = new HoaDonCTDAO();
            int result = dao.Deleted(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GetCoupon_KH
        [HttpGet]
        public JsonResult GetCoupon_KH()
        {
            
            var session_acc = SessionHelper.GetSession();
            if (session_acc != null)
            {
                var dao = new CouponDAO();
                var result = dao.GetCoupon_KH(session_acc.id_khachhang);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}