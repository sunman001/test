using Dba.Attributes;
using Dba.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dba.Extensions
{
    public static class ReflectionExtension
    {
        /// <summary>
        /// 获取属性信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperyInfos(this Type t)
        {
            if (t == null)
            {
                throw new NullReferenceException("泛型对象为空");
            }
            return t.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
        }

        /// <summary>
        /// 获取属性字段
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetAllPropertyNameString(this Type t)
        {
            if (t == null)
            {
                throw new NullReferenceException("泛型对象为空");
            }
            var properties = t.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance).Select(x => x.Name).ToList();

            return string.Join(",", properties);
        }
        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetPrimaryKey(this Type type)
        {
            var props = type.GetProperyInfos();
            var primaryKey = "";
            foreach (var prop in props)
            {
                var attr = (DxColumnAttribute)prop.GetCustomAttribute(typeof(DxColumnAttribute), false);
                if (attr == null || !attr.Primarykey) continue;
                primaryKey = prop.Name;
                break;
            }
            if (!string.IsNullOrEmpty(primaryKey))
                return primaryKey;
            var p = props.First(x => x.Name.ToLower() == "id");
            if (p != null)
            {
                primaryKey = p.Name;
            }
            if (!string.IsNullOrEmpty(primaryKey)) return primaryKey;
            {
                var first = props.FirstOrDefault(x => x.Name.ToLower().EndsWith("_id"));
                if (first != null)
                {
                    primaryKey = first.Name;
                }
                else
                {
                    first = props.FirstOrDefault(x => x.Name.ToLower().EndsWith("id"));
                    if (first != null)
                    {
                        primaryKey = first.Name;
                    }
                }
            }
            return primaryKey;
        }
        public static PropertyMapping Mapping(this Type type)
        {
            var mapping = new PropertyMapping
            {
                ClassName = type.Name,
                PropertyInfos = type.GetProperyInfos(),
                PropertiesString = type.GetAllPropertyNameString(),
                PrimaryKey = ""
            };
            var primaryKeyProperty = type.GetPrimaryKey();

            if (primaryKeyProperty != null)
            {
                mapping.PrimaryKey = primaryKeyProperty;
            }
            else
            {
                var p = mapping.PropertyInfos.First(x => x.Name.ToLower() == "id");
                if (p != null)
                {
                    mapping.PrimaryKey = p.Name;
                }
                if (string.IsNullOrEmpty(mapping.PrimaryKey))
                {
                    var first = mapping.PropertyInfos.FirstOrDefault(x => x.Name.ToLower().EndsWith("_id"));
                    if (first != null)
                    {
                        mapping.PrimaryKey = first.Name;
                    }
                    else
                    {
                        first = mapping.PropertyInfos.FirstOrDefault(x => x.Name.ToLower().EndsWith("id"));
                        if (first != null)
                        {
                            mapping.PrimaryKey = first.Name;
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(mapping.PrimaryKey))
            {
                throw new Exception(string.Format("请为表{0}指定一个主键", mapping.ClassName));
            }
            return mapping;
        }

        /// <summary>
        /// 获取自增列的列名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetIncrementColumnName(this Type type)
        {
            var props = type.GetProperyInfos();
            var columnName = "";
            foreach (var prop in props)
            {
                var attr = (DxColumnAttribute)prop.GetCustomAttribute(typeof(DxColumnAttribute), false);
                if (attr == null || !attr.AutoIncrement) continue;
                columnName = prop.Name;
                break;
            }
            return columnName;
        }

        /// <summary>
        /// 读取对象所有属性名称的集合
        /// </summary>
        /// <param name="t">泛型对象</param>
        /// <returns>对象所有属性名称的集合</returns>
        public static List<string> GetMappedPropertyNameList(this Type t)
        {
            if (t == null)
            {
                throw new NullReferenceException("泛型对象为空");
            }
            var props = t.GetProperyInfos();
            var list = (from prop in props
                        let attr = (DxColumnAttribute)prop.GetCustomAttribute(typeof(DxColumnAttribute), false)
                        where attr == null || !attr.Ignore
                        select prop.Name).ToList();
            return list;
        }
    }
}

