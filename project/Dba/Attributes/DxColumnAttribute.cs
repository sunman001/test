using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dba.Attributes
{
    /// <summary>
    /// 特性就是一个类继承Attribute
    /// </summary>
   public  class DxColumnAttribute:Attribute
    {
        /// <summary>
        /// 是否为自动字段
        /// </summary>
        public bool AutoIncrement { get; set; }

        /// <summary>
        /// 是否为主键
        /// </summary>
        public bool Primarykey { get; set; }

        /// <summary>
        /// 是否忽略此字段
        /// </summary>
        public bool Ignore { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 字段描述
        /// </summary>
        public string Description { get; set; }

    }
}
