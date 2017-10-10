using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using TOOL.DbName;
using Dba.Extensions;
using Dba;
using Infrastructure.Dba;

namespace Repositories.Inclass
{
    public  abstract class Repository<T> : IRepository<T> where T : class, new()  
    {
        protected readonly string ReportDbName = PubDbName.dbtotal;
        protected readonly string BaseBbName = PubDbName.dbbase;
        protected readonly string DeviceDbName = PubDbName.dbdevice;
        public virtual bool Delete(string ids)
        {
            var type = typeof(T);
            var sql = type.GenerateBatchDeleteSqlString(ids);
            var rows = DbHelperSql.ExecuteSql(sql);
            return rows > 0;
            
        }

        public virtual bool Delete(int id)
        {
            var type = typeof(T);
            var sql = type.GenerateDeleteSqlString(id);
            var rows = DbHelperSql.ExecuteSql(sql);
            return rows > 0;
        }

        public virtual IEnumerable<T> FindAll()
        {
            var type = typeof(T);
            var propMapping = type.Mapping();
            var strSql = new StringBuilder();
            strSql.AppendFormat("SELECT {0}",propMapping.PropertiesString);
            strSql.AppendFormat("FROM {0}",propMapping.ClassName);
            var ds = DbHelperSql.Query(strSql.ToString());
            return ds.Tables[0].Tolist<T>();
        }

        public IEnumerable<T> FindByCause(string orderby, string where = "", object parmeters = null)
        {
            var type = typeof(T);
            var propMapping = type.Mapping();
            var dxQueryable = new DxQueryable<T>(propMapping);
            dxQueryable.Where(@where,parmeters);
            dxQueryable.OrderBy(orderby);
            var ds = DbHelperSql.Query(dxQueryable.ToSql,dxQueryable.DbParameters.ToArray());
            return ds.Tables[0].Tolist<T>();
        }

        public T FindById(int id)
        {
            var type = typeof(T);
            var propMapping = type.Mapping();
            var strSql = new StringBuilder();
            strSql.AppendFormat("SELECT {0}",propMapping.PropertiesString);
            strSql.AppendFormat("FROM {0}",propMapping.ClassName);
            strSql.AppendFormat("WHERE {0}=@PrimaryKey",propMapping.PrimaryKey);
            var paraPrimaryKey = SqlParameterFactory.GetParameter;
            paraPrimaryKey.ParameterName = "@PrimaryKey";
            paraPrimaryKey.Value = id;
            paraPrimaryKey.DbType = System.Data.DbType.String;
            var ds = DbHelperSql.Query(strSql.ToString(),paraPrimaryKey);
            return ds.Tables[0].ToEntity<T>();

        }

        public IEnumerable<T> FindByTopCause(int top, string orderBy, string where = "", object parameters = null)
        {
            throw new NotImplementedException();
        }

        public virtual IPagedList<T> FindPagedList(string orderBy, string @where = "", object parameters = null, int pageIndx = 0, int pageSize = 20)
        {
            var type = typeof(T);
            var propMapping = type.Mapping();
            var dxQueryable = new DxQueryable<T>(propMapping);
            dxQueryable.Where(@where,parameters);
            dxQueryable.OrderBy(orderBy);
            var ds = DbHelperSql.Query(dxQueryable.ToPagingSql(pageIndx, pageSize),dxQueryable.DbParameters.ToArray());
            var list = ds.Tables[0].Tolist<T>();
            var totalCount = ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["RowNumTotalCount"] : 0;
            var items = new PagedList<T>(list, pageIndx, pageSize, int.Parse(totalCount.ToString()));
            return items;
        }

        public virtual  int Insert(T entity)
        {
            var type = typeof(T);
            var sql = type.GengerateInertSqlString();
            var obj = DbHelperSql.GetSingle(sql,AdoUtil.GetParameters(entity));
            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        public bool Update(T entity)
        {
            var type = typeof(T);
            var sql = type.GenerateUpdateSqlString();
            var rows = DbHelperSql.ExecuteSql(sql,AdoUtil.GetParameters(entity));
            return rows > 0;
        }
    }
}
