using Mode.DAO;
using Mode.Models;
using Nhom102_ManagerCoffee.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom102_ManagerCoffee.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            var session_acc = SessionHelper.GetSession();
            if (session_acc == null)
            {
                return RedirectToAction("Index", "TaiKhoan", new { area = "" });
            }
            return View();
        }
        public ActionResult Table()
        {
            return View();
        }
        public JsonResult SanPham_GetAll()
        {
            var dao = new SanPhamDAO();
            var result = dao.GetSanPham();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoaiSanPham_GetAll()
        {
            var dao = new LoaiSanPhamDAO();
            var result = dao.GetLoaiSanPham();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Table_show()
        {
            var dao = new TableDAO();
            var result = dao.GetTable_show();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_TableCT(int id)
        {
            var dao = new TableCTDAO();
            var result = dao.GetTableCT_id(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Push_TableCT(string data, int id_sanpham, int soluong)
        {
            //convert string -> int
            int[] nums = Array.ConvertAll(data.Split(','), int.Parse);

            var dao = new TableCTDAO();
            int result = dao.PushTableCT(nums, id_sanpham, soluong);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // COUPON
        [HttpGet]
        public JsonResult CouPon_GetAll()
        {
            var dao = new CouponDAO();
            var result = dao.GetCoupon_All();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // HOADON
        [HttpGet]
        public JsonResult HoaDon_GetAll()
        {
            var dao = new HoaDonDAO();
            var result = dao.GetHoaDon_All();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // TAIKHOAN
        [HttpGet]
        public JsonResult TaiKhoan_GetAll()
        {
            var dao = new TaiKhoanDAO();
            var result = dao.GetTaiKhoan_All();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // KHACHHANG 
        [HttpGet]
        public JsonResult KhachHang_GetAll()
        {
            var dao = new KhachHangDAO();
            var result = dao.GetKhachHang_All();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // NHANVIEN 
        [HttpGet]
        public JsonResult NhanVien_GetAll()
        {
            var dao = new NhanVienDAO();
            var result = dao.GetNhanVien_All();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // NHANVIEN 
        [HttpGet]
        public JsonResult LichSu_GetAll()
        {
            var dao = new LichSuDAO();
            var result = dao.GetHistorie_All();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// AddCoupon
        [HttpPost]
        public JsonResult AddCoupon(List<Coupon_Model> data) //List<HoaDonCT_Model> //fix null
        {
            var session_acc = SessionHelper.GetSession();
            if (session_acc != null)
            {
                var dao = new CouponDAO();
                var result = dao.CreateCoupon(data);

                if(result==1) return Json(1, JsonRequestBehavior.AllowGet);
            }
            
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Coupon_TenKH()
        {
            var dao = new KhachHangDAO();
            var result = dao.GetKhachHang_All();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        //Thống Kê
        [HttpGet]
        public JsonResult ThongKe()
        {
            //int today = DateTime.Today.Day;

            //int month = DateTime.Today.Month;
            //int year = DateTime.Today.Year;

            string tenthongke = "Tháng " + DateTime.Now.Month.ToString();

            string thoigian= DateTime.Now.ToString("MM/dd/yyyy");

            var dao = new HoaDonDAO();
            double tongthu = 0;
            tongthu = dao.GetHoaDon_TongGia_TrangThaiChua();

            var daothongke = new ThongKeDAO();
            int result = daothongke.CreateThongKe(tenthongke,thoigian,tongthu);

            if (result != 0) return Json(result, JsonRequestBehavior.AllowGet);
            else return Json(0, JsonRequestBehavior.AllowGet);
        }


        [HttpGet] 
        public JsonResult CountSoDon_Ngay()
        {
            var dao = new HoaDonDAO();
            int result = dao.CountHoaDon_Ngay();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult CountSoDon_Thang()
        {
            var dao = new HoaDonDAO();
            int result = dao.CountHoaDon_Thang();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DoanhThu_Ngay()
        {
            var dao = new HoaDonDAO();
            double result = dao.DoanhThu_Ngay();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DoanhThu_Thang()
        {
            var dao = new HoaDonDAO();
            double result = dao.DoanhThu_Thang();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CountSanPham()
        {
            var dao = new SanPhamDAO();
            int result = dao.CountSanPham();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult CountSanPhamDaBan()
        {
            var dao = new SanPhamDAO();
            int result = dao.CountSanPhamDaBan();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
