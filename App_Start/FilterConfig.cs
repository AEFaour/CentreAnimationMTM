using System.Web;
using System.Web.Mvc;

namespace WebApplicationAuthManyToManyTest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            // Mettre en place les autorisations au niveau des action en mettant des attributs d'acces - autorisations
            // Créer un role Admin dans AccountController
        }
    }
}
