using Nhom102_ManagerCoffee.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nhom102_ManagerCoffee.Controllers
{
    public class BaseController : Controller
    {
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var session = (AccLogin)Session[CommonConstants.ACCOUNT_SESSION];
        //    if (session == null)
        //    {
        //        filterContext.Result = new RedirectToRouteResult(new
        //            RouteValueDictionary(new { Controller = "TaiKhoan", action = "Index" }));
        //    }
        //    else if (String.Compare(session.TaiKhoan1, "tien") == 0)
        //    {
        //        filterContext.Result = new RedirectToRouteResult(new
        //            RouteValueDictionary(new { Controller = "Admin", action = "Index", Area = "admin" }));
        //    }
        //    base.OnActionExecuting(filterContext);
        //}
    }
}