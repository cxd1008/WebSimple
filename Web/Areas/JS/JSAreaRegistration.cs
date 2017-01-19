using System.Web.Mvc;

namespace Web.Areas.JS
{
    public class JSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "JS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "JS_default",
                "JS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}