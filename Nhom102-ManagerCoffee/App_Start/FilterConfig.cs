using System.Web;
using System.Web.Mvc;

namespace Nhom102_ManagerCoffee
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
