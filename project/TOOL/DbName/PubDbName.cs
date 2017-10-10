using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TOOL.DbName
{
    /// <summary>
    /// 获取数据名称公共方法
    /// </summary>
  public class PubDbName
    {
        private static string _dbbase;
        public static string dbbase
        {
            get
            {
              if(string.IsNullOrEmpty(_dbbase))
                {
                    _dbbase = ConfigurationManager.AppSettings["dbbase"];
                    if(string.IsNullOrEmpty(_dbbase))
                    {
                        throw new ArgumentNullException("获取数据库名称dbbase失败");
                    }
                }
                return _dbbase;
            }
           
        }

        private static string _dbtotal;
        public static string  dbtotal
        {
            get
            {
                if(string.IsNullOrEmpty(_dbtotal))
                {
                    _dbtotal = ConfigurationManager.AppSettings["dbtotal"];
                    if (string.IsNullOrEmpty(_dbtotal))
                    {
                        throw new ArgumentNullException("获取数据库名称dbtotal失败");
                    }
                }
                return _dbtotal;
            }
        }
        private static string _dbdevice;
        public static string dbdevice
        {
        get
            {
                if(string.IsNullOrEmpty(_dbdevice))
                {
                    _dbdevice = ConfigurationManager.AppSettings["dbdevice"];
                    if(string.IsNullOrEmpty(_dbdevice))
                    {
                        throw new ArgumentNullException("获取数据库名称dbdevice失败");
                    }
                }
                return _dbdevice;
            }
        }
    }
}
