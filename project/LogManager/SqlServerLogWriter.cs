using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Services;
using Factory;

namespace LogManager
{
    public sealed class SqlServerLogWriter : ILogWriter
    {
        private readonly IDxGlobalLogErrorService _dxGlobalLogErrorService;
        public SqlServerLogWriter()
        {
            _dxGlobalLogErrorService = ServiceFactory.DxGlobalLogErrorService;
        }
        /// <summary>
        /// 向SQL SERVER 中写入全局错误日志
        /// </summary>
        /// <param name="logEntity"></param>
        public void Write(DxGlobalLogError logEntity)
        {
            _dxGlobalLogErrorService.Insert(logEntity);
        }
    }
}
