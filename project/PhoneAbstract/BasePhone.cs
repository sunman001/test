using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneAbstract
{
    /// <summary>
    /// 有抽象方法 ，类必须是抽象类
    /// 抽象类本质就是个类 有部门方法是抽象方法没有具体实现 
    /// 这个类作为父类时 某些方法也有不同的实现这是需要抽象类
    /// 继承抽象类必须现实抽象方法 
    /// 抽象类单继承
    /// 抽象类是现实生活的抽象描述的是什么
    /// 接口描述的是做什么，有什么扩展功能可多继承实现
    /// </summary>
    public abstract   class BasePhone 
    {
        public int Price { get; set; }
        public void Call()
        {
            Console.WriteLine("这里是Call");
        }

        public void Message()
        {
            Console.WriteLine("这里是Message");
        }
        public abstract void System();//抽象方法 没有方法体没有具体的实现
     
    }
}
