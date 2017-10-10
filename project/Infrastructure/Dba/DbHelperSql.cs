using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dba
{
    /// <summary>
    /// 数据访问抽象基础类
    /// </summary>
    public abstract class DbHelperSql
    {
        public static string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        #region 公用方法
        /// <summary>
        /// 查询某表是否存在某字段
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">字段名</param>
        /// <returns></returns>
        public static bool ColumnExists(string tableName, string columnName)
        {
            string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
            object res = GetSingle(sql);
            if (res == null)
            {
                return false;
            }
            return Convert.ToInt32(res) > 0;
        }
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            return Convert.ToInt32(obj.ToString());
        }

        /// <summary>
        /// 数据库是否存在
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>返回结果</returns>
        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;

            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool TabExists(string TableName)
        {
            string strsql = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            object obj = GetSingle(strsql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static List<T> ToList<T>(DataTable table) where T:class
        {
            List<T> list = new List<T>();
            if(!IsEmptyDataTable(table))
            {
              foreach (DataRow row in table.Rows)
                {
                    var obj = ToModels<T>(row);
                    list.Add(obj);
                }
            }
            return list;
        }

        public static bool IsEmptyDataTable(DataTable table)
        {
            if(table==null || table.Rows.Count==0)
            {
                return true;
            }
            return false;
        }

        public static T ToModels<T> (DataRow row ) where T :class
        {
            try
            {
                var obj = Activator.CreateInstance<T>();
                var props = obj.GetType().GetProperties();
                foreach (var prop in props)
                {
                 if(row.Table.Columns.Contains(prop.Name))
                    {
                        prop.SetValue(obj,row.IsNull(prop.Name)?null:row[prop.Name],null);
                    }
                }
                return obj;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region 执行简单SQL语句
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">sql语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection=new SqlConnection (connectionString))
            {
                using (SqlCommand cmd=new SqlCommand (SQLString ,connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }  
        }

        public static int ExecuteSql(string SQLString,params SqlParameter[]cmdParms)
        {
            using (SqlConnection connection=new SqlConnection (connectionString))
            {
                using (SqlCommand cmd=new SqlCommand ())
                {
                    try
                    {
                        PrepareCommand(cmd,connection,null,SQLString ,cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch(SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        public static int ExecuteSqlByTime(string SQLString ,int Times)
        {
            using (SqlConnection connection =new SqlConnection (connectionString))
            {
                using (SqlCommand cmd=new SqlCommand (SQLString,connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch(SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        public static int ExecuteSqlTran(List<string> SQLStringList)
        {
            using (SqlConnection conn=new SqlConnection (connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for(int n=0; n<SQLStringList.Count;n++)
                    {
                        string strsql = SQLStringList[n];
                        if(strsql.Trim().Length>1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();

                        }

                    }
                    tx.Commit();
                    return count;
                       
                }
                catch(Exception ex)
                {
                    tx.Rollback();
                    return 0;
                }
            }

        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection=new SqlConnection (connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString ,connection);
                    command.Fill(ds,"ds");
                }
                catch(SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
                    
            }
        }

        public static DataSet Query(string SQLString,int Times)
        {
            using (SqlConnection connection=new SqlConnection (connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString,connection );
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds,"ds");
                }
                catch(SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        public static DataSet Query(string SQLString ,params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection=new SqlConnection (connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd,connection,null,SQLString,cmdParms);
                using (SqlDataAdapter da=new SqlDataAdapter (cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds,"ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message); 
                    }
                    return ds;
                }
            }

        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>查询结果</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd,connection,null,SQLString ,cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if((Object.Equals(obj,null))|| (Object.Equals(obj,System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }

                    catch(System.Data.SqlClient.SqlException e)
                    {
                        throw e;

                    }
                }
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
            }
            if (trans != null)
            {
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.Text;
            }
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }

            }

        }
        #endregion
    }
}
