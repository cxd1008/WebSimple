using System.Web.Mvc;

namespace Web.Areas.JF
{
    public class JFAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "JF";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "JF_default",
                "JF/{controller}/{action}/{id}",
                //"{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}