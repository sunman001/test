using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    /// <summary>
    /// 平台日志器工厂
    /// </summary>
   public  interface IPlatformLogFactory
    {
        ILogger CreateLogger();
    }
}
