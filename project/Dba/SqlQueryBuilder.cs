using Dba.Extensions;
using System;
using System.Linq;

namespace Dba
{
   public static  class SqlQueryBuilder
    {
        /// <summary>
        /// 读取类的字段并生成SQL插入语句
        /// </summary>
        /// <param name="type">泛型对象</param>
        /// <returns>以逗号连接的对象所有属性名称字符串</returns>
        public static string GengerateInertSqlString(this Type type)
        {
           if(type==null )
            {
                throw new NullReferenceException();
            }
            var autoIncrementColumnName = type.GetIncrementColumnName();
            var props = type.GetMappedPropertyNameList().Where(x=>x!=autoIncrementColumnName).ToList();
            if(props==null || props.Count()<=0 )
            {
                throw new ArgumentNullException(string.Format("对象【{0}】没有可用的映射属性",type.Name));
            }
            var insert = string.Format("INSERT INTO {0} ({1}) VALUES ({2});select @@IDENTITY",type.Name ,string.Join(",",props),string.Join(",",props.Select(x=>"@"+x)));
            return insert;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static  string  GenerateUpdateSqlString(this Type type)
        {
            if(type==null)
            {
                throw new NullReferenceException();
            }
            var primaryKey = type.GetPrimaryKey();
            var autoIncrementColumnName = type.GetIncrementColumnName();
            if (string.IsNullOrEmpty(autoIncrementColumnName))
            {
                autoIncrementColumnName = primaryKey;
            }
            if (string.IsNullOrEmpty(autoIncrementColumnName))
            {
                throw new NotFiniteNumberException(string.Format("请为对象[{0}]指定标识列或主键",type.Name));
            }
            var props = type.GetMappedPropertyNameList().Where(x => x != autoIncrementColumnName).ToList();
            if(props==null || props.Count<=0)
            {
                throw new ArgumentNullException(string.Format("对象[{0}]没有可用的映射属性",type.Name));
            }
            var sql = string.Format("UPDATE {0} SET {1} WHERE {2}=@{2}",type.Name,string.Join(",",props.Select(x=>x+"=@" +x)),primaryKey);
            return sql;
        }
        /// <summary>
        /// 根据指定的自定义对象生成更新语句（可指定要更新的字段）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">自定义的更新对象</param>
        /// <param name="id">主键对应的值</param>
        /// <param name="objUpdate">自定义的更新对象</param>
        /// <returns></returns>
        public static string GengratePartialUpdateSqlById<T>(this Type type,object id,object objUpdate)
        {
            if(type==null)
            {
                throw new NullReferenceException();
            }
            var primaryKey = type.GetPrimaryKey();
            var autoIncrementColumnName = type.GetIncrementColumnName();
            var props = type.GetMappedPropertyNameList().ToList();
            var upType = objUpdate.GetType();
            if(upType==null)
            {
                throw new NullReferenceException();
            }
            var needUpdateProps = upType.GetProperties().Where(x=>x.Name!=autoIncrementColumnName).Select(x=>x.Name);
            var needUpdates = needUpdateProps.Where(updateProp=>props.Any(x=>string.Equals(x,updateProp,StringComparison.CurrentCultureIgnoreCase))).ToList();
            var sql = string.Format("UPDATE {0} SET {1} WHERE {2}=@{2} ",type.Name,string.Join("",needUpdates.Select(x=>x+="=@"+x)),primaryKey);
            return sql;

        }
        /// <summary>
        /// 读取类的字段并生成SQL删除语句
        /// </summary>
        /// <param name="type">泛型对象</param>
        /// <param name="id">id</param>
        /// <returns>以</returns>
        public static string GenerateDeleteSqlString(this Type type,object id)
        {
            if (type ==null)
            {
                throw new NullReferenceException();
            }
            var primaryKey = type.GetPrimaryKey();
            var props = type.GetMappedPropertyNameList();
            if(props==null || props.Count<=0)
            {
                throw new ArgumentNullException(string.Format("对象[{0}] 没有可用的映射属性"),type.Name);
            }
            var sql = string.Format("DELETE FROM {0} WHERE {1}={2}", type.Name,primaryKey ,id);
            return sql;
        }

        /// <summary>
        /// 读取类的字段并生成sql批量删除语句
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static string GenerateBatchDeleteSqlString(this Type type ,string ids)
        {
            if(type ==null )
            {
                throw new NullReferenceException();
            }
            var primaryKey = type.GetPrimaryKey();
            var props = type.GetMappedPropertyNameList();
            if(props ==null ||props.Count <=0)
            {
                throw new ArgumentNullException(string.Format("对象[{0}]没有可用的映射属性"),type.Name);
            }
            var sql = string.Format("DELETE FROM {0} WHERE {1} IN {2}",type.Name,primaryKey,ids);
            return sql;
            
        }
        
      
    }
}
