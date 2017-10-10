using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAbstract
{
    public class TomatoScrambledEggs : Food
    {
        /// <summary>
        /// 西红柿炒蛋这道菜
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("西红柿炒蛋好了！");
        }
    }
}
