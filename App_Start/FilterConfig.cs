using System.Web;
using System.Web.Mvc;

namespace PracticaReportes_AngelSaravia_ErickReyes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
