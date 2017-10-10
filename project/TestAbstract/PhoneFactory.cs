using PhoneAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAbstract
{
   public  class PhoneFactory
    {
        public static BasePhone CreatePhone(int type)
        {
            if(type == 1)
            {
                return new Iphone();
            }
            else if (type==2)
            {
                return new Galasy();
            }
            else
            {
                return new Iphone();
            }
        }
    }
}
