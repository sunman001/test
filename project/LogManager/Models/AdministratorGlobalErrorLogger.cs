using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOOL.EnumUtil;

namespace LogManager.Models
{
    /// <summary>
    /// 平台错误日志类
    /// </summary>
  public   class AdministratorGlobalErrorLogger:AbstractGlobalErrorLogModel,ILogger
    {
        public AdministratorGlobalErrorLogger ()
        {

        }
        protected override void SetClient()
        {
            base.DxGlobalLogError.ClientId =(int)DxClient.Administrator;
            base.DxGlobalLogError.ClientName = DxClient.Administrator.GetDescription();

        }
    }
}
