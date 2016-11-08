using System.Web.Mvc;

namespace Web.Areas.CssJquery
{
    public class CssJqueryAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CssJquery";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CssJquery_default",
                "CssJquery/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}