using System.Web;
using Model;
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
