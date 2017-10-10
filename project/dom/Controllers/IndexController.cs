using Dba;
using Factory;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using PhoneAbstract;
using TestAbstract;

namespace dom.Controllers
{
    public class IndexController : Controller
    {
        private readonly IDxGlobalLogErrorService _DxGlobalLogErrorService;
        public IndexController()
        {
            _DxGlobalLogErrorService = ServiceFactory.DxGlobalLogErrorService;
        }
        // GET: Index
        public ActionResult Index()
        {
            var list = _DxGlobalLogErrorService.FindPagedListBySql("","",null ,1,20);
            Common.ShowT<int>(1);//调用泛型
            Common.ShowT("1111");//T可以省去 系统会自定推算    
            BasePhone basePhone = PhoneFactory.CreatePhone(1); 
            
           // Common.Getclass("111");
            return View();
        }

       
    }
}