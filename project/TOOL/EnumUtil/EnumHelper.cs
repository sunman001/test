using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOL.EnumUtil
{
    
   public enum DxClient
    {
        /// <summary>
        /// 管理平台
        /// </summary>
        [Description("管理平台")]
        Administrator=0,
        /// <summary>
        /// 开发平台
        /// </summary>
        [Description("开发平台")]
        Developer=1,
        /// <summary>
        /// 业务平台
        /// </summary>
        [Description("业务平台")]
        BusinessPersonnel=2
    }
}
