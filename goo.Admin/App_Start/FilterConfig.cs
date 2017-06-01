using System.Web;
using System.Web.Mvc;
using Assistance.APIs.Logging;

namespace goo.Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleExceptionsAttribute());  // NEW ENTRIE

        }
    }
}
