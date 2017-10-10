using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public  interface IService<T> where T:class
    {
        /// <summary>
        /// 查询全部（泛型）
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();

        IPagedList<T> FindPagedList( string orderBy,string @where="",object parameters=null,int pageIndex=0,int pageSize=20);
             T FindById(int id);
        int Insert(T entity);
        bool Update(T entity);

        bool Delete(int id);
        bool Delete(string ids);

    }
}
