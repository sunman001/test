using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dba
{
  internal static   class IsWhatExtensions
    {
        public static bool IsIn<T>(this T thisValue,params T[] values)
        {
            return values.Contains(thisValue);
        }
    }
}
