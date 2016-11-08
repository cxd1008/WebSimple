using System.Web.Mvc;

namespace Web.Areas.Jiaoyu361
{
    public class Jiaoyu361AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Jiaoyu361";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Jiaoyu361_default",
                "Jiaoyu361/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}