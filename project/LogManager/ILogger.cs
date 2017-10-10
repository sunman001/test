using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
  public  interface ILogger
    {
        /// <summary>
        /// 写日志的方法
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="message">错误信息</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="location">报错位置【可选】</param>
        /// <param name="summary">错误摘要【可选】<</param>
        void log(int userid,string message,string ipAddress,string location="",string summary="");
    }
}
