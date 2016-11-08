using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Model;
using System.Web.Mvc;
namespace Common
{
    public static class SessionClass
    {
        public static EM_Employee GetSession
        {
            get
            {
                if (HttpContext.Current.Session["Login"] != null)
                {

                    return (EM_Employee)HttpContext.Current.Session["Login"];
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["Login"] = value;
            }
        }


    }
}
