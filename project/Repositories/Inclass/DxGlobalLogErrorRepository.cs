using Domain;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using System.Data.SqlClient;
using Infrastructure.Dba;
using System.Data;
using Dba.Extensions;

namespace Repositories.Inclass
{
    public class DxGlobalLogErrorRepository : Repository<DxGlobalLogError>, IDxGlobalLogErrorRepository
    {
        public IPagedList<DxGlobalLogError> FindPagedListBySql(string orderby, string where = "", object paramerters = null, int pageIndex = 0, int pageSize = 20)
        {
            var sql = "select * from DxGlobalLogError";
            orderby = " order by  Id desc";
            sql = sql + where;
            // pageIndex += 1;
            SqlConnection con = new SqlConnection(DbHelperSql.connectionString);
            SqlDataAdapter da = new SqlDataAdapter("SqlPager", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@Sql", sql));
            da.SelectCommand.Parameters.Add(new SqlParameter("@Order", orderby));
            da.SelectCommand.Parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            da.SelectCommand.Parameters.Add(new SqlParameter("@PageSize", pageSize));
            da.SelectCommand.Parameters.Add("@TotalCount", SqlDbType.Int);
            da.SelectCommand.Parameters["@TotalCount"].Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            da.Fill(ds);
            var list = ds.Tables[0].Tolist<DxGlobalLogError>();
            var totalCount = Convert.ToInt32(da.SelectCommand.Parameters["@TotalCount"].Value);
            var items = new PagedList<DxGlobalLogError>(list, pageIndex, pageSize, totalCount);
            da.Dispose();
            return items;
        }
    }
}
