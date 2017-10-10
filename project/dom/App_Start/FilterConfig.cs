using dom.Util.Logger;
using System.Web.Mvc;
using TOOL;

namespace dom.App_Start
{
    public class FilterConfig
    {

        public static void RegisterGlobalFiters( GlobalFilterCollection filters)
        {
            filters.Add(new MyHandleErrorAttribute());
        }
    }
    //处理异常
    public class MyHandleErrorAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            int u_id = UserInfo.Uid;
            string bcxx = filterContext.Exception.Message;//报错信息
            string bcController = filterContext.Controller.ToString();//报错控制器
            string bcff = filterContext.Exception.TargetSite.ToString();//报错方法
            string bcdx = filterContext.Exception.Source;
            string bcwz = filterContext.Exception.StackTrace;//引发异常位置
            var message = "报错信息：" + bcxx + "，报错控制器：" + bcController + ",报错方法：" + bcff + ",报错对象：" + bcdx + ",报错位置：" + bcwz;
            GlobalErrorLogger.Log(message,filterContext.Exception.Source);
            filterContext.ExceptionHandled = true;//设置异常已处理
            if( filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    Data = new
                    {
                        success = 9997,
                        msg = "出错了！",
                        Redirect = ""
                    }
                };

            }
            else
            {
                filterContext.Result = new RedirectResult("");
            }
            base.OnException(filterContext);

        }
    }

    /// <summary>
    /// 验证用户是否登录
    /// </summary>
    public class LoginCheckFilterAttribute:ActionFilterAttribute
    {
        //表示是否检查登录
        public bool IsCheck { get; set; }
        public bool IsRole { get; set; }
        /// <summary>
        /// Action方法执行之前执行此方法(控制器)
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        public class VisitRecordAttribute:ActionFilterAttribute
        {
            //是否记录此页面的访问记录
            public bool IsRecord { get; set; }
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                //如记录 记录访问的详细信息

                if(IsRecord)
                {
                    var desriptor = filterContext.ActionDescriptor;
                    var actionName = desriptor.ActionName;
                    var controllerName = desriptor.ControllerDescriptor.ControllerName;
                    var location = string.Format("/{0}/{1}",controllerName,actionName);
                   
                }
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
