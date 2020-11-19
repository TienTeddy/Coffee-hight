using Mode.DAO;
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
    }
}
