using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
  public  interface IRepository<T>
    {
        /// <summary>
        /// 根据ID 查询单条件数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindById(int id);

        IEnumerable<T> FindAll();
        /// <summary>
        /// 根据条件查询前n条数据
        /// </summary>
        /// <param name="top">前N条数据</param>
        /// <param name="orderBy">排序字段，不允许为空</param>
        /// <param name="where">查询条件</param>
        /// <param name="parameters">查询条件参数对象</param>
        /// <returns></returns>
        IEnumerable<T> FindByTopCause(int top,string orderBy,string @where="",object parameters=null);

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="orderby"></param>
        /// <param name="where"></param>
        /// <param name="parmeters"></param>
        /// <returns></returns>
        IEnumerable<T> FindByCause(string orderby ,string @where="",object parmeters=null);

        /// <summary>
        /// 根据条件查询分页数据
        /// </summary>
        /// <param name="orderBy">排序字段，不允许为 空</param>
        /// <param name="where">查询条件</param>
        /// <param name="parameters">查询条件参数对象</param>
        /// <param name="pageIndx">当前页面索引</param>
        /// <param name="pageSize">页数大小</param>
        /// <returns></returns>
        IPagedList<T> FindPagedList(string orderBy,string @where="",object parameters=null,int pageIndx=0,int pageSize=20);

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(T entity);

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(T entity);

        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 删除指定ID集合的数据（批量删除）
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Delete(string ids);
    }
}
