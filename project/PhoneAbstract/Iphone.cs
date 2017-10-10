using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneAbstract
{
    public  class Iphone:BasePhone,IphoneExtend 
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
            throw new NotImplementedException();
        }
    }
}
