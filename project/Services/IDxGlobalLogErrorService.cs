using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public  interface IDxGlobalLogErrorService:IService<DxGlobalLogError>
    {
        IPagedList<DxGlobalLogError> FindPagedListBySql(string orderby, string @where = "", object paramerters = null, int pageIndex = 0, int pageSize = 20);
    }
}
