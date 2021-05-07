using System.Web;
using System.Web.Mvc;

namespace DESAFIO_INDIGO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
