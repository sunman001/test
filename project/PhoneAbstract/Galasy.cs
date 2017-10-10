using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneAbstract
{
    /// <summary>
    /// 
    /// </summary>
    public class Galasy : BasePhone,IphoneExtend
    {
        public void pay()
        {
            throw new NotImplementedException();
        }

        public void photo()
        {
            throw new NotImplementedException();
        }

        public override void System()
        {
            Console.WriteLine("这里是安卓系统");
        }
    }
}
