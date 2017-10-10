using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAbstract
{
    /// <summary>
    /// 抽象工厂类
    /// </summary>
   public  abstract class Creator
    {
        //工厂方法
        public abstract Food CreateFoodFactory();
    }
}
