using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dba
{
    public interface ISqlQueryable<T>
    {
        ISqlQueryable<T> Where(string @where, object para = null);
        ISqlQueryable<T> OrderBy(string orderBy);

        int Count();
    }
}
