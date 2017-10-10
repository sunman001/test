using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{

   public  class ServiceFactory
    {
        /// <summary>
        /// 创建泛型实列
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
       private static TService CreateService<TService>() where TService:class
        {
            var service = InstanceFactory.GetServiceInstance<TService>();
            return service;
        }

        public static IDxGlobalLogErrorService DxGlobalLogErrorService
        {
            get
            {
                return CreateService<DxGlobalLogErrorService>();
            }
        }

        

    }

}
