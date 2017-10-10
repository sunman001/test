



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndx"></param>
        /// <param name="pageSize"></param>
        public PagedList(IQueryable<T> source,int pageIndx,int pageSize)
        {
            var total = source.Count();
            TotalCount = total;
            TotalPages = total / pageSize;
            if(total%pageSize>0)
            {
                TotalPages++;
            }
            PageSize = pageSize;
            PageIndex = pageIndx;
            AddRange(source.Skip(pageIndx *pageSize).Take(pageSize).ToList());

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public PagedList(IList<T>source,int pageIndex,int pageSize)
        {
            TotalCount = source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        public PagedList (IEnumerable<T> source ,int pageIndex,int pageSize,int totalCount)
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;
            if(TotalCount % pageSize>0)
            {
                TotalPages++;
            }
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalCount = totalCount;
            AddRange(source);
        }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage
        {
            get{ return (PageIndex +1<TotalPages); }
        }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        /// <summary>
        /// 分页索引
        /// </summary>
        public int PageIndex{get; }
        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize{get;private set;}

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount {  get; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages{ get;  }
    }
}
