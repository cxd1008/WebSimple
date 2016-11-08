using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class IsLogin : ActionFilterAttribute
    {
        public IsLogin()
        { }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Common.SessionClass.GetSession == null)
            {
                var url = filterContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectResult("/Account/Login?returnUrl=" + url);
            }
        }

    }
}