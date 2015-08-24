using System.Web;
using System.Web.Mvc;

namespace wm.sqlsat.alt.ui_mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
