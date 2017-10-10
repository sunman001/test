using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOL.EnumUtil
{
   public static   class EnumExtensions
    {
        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        /// <typeparam name="T">泛型枚举</typeparam>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static string GetDescription<T>(this T value) where T:struct
        {
            var type = value.GetType();
            if(!type.IsEnum)
            {
                throw new ArgumentException("不是可用的枚举类型");
            }
            var memberInfo = type.GetMember(value.ToString());
            if(memberInfo.Length>0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),false);
                if(attrs.Length>0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return value.ToString();

        }
    }
}
