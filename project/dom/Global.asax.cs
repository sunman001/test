using dom.App_Start;
using dom.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;

namespace dom
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //移动设备显示模式检测器
            DisplayModeProvider.Instance.Modes.Insert(0,new CustomMobileDisplayMode());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFiters(GlobalFilters.Filters);
          
        }
    }
}
