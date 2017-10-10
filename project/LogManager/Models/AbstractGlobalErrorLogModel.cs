using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager.Models
{
    public abstract class AbstractGlobalErrorLogModel : ILogger
    {
        protected readonly ILogWriter LogWriter;
        protected AbstractGlobalErrorLogModel()
        {
            DxGlobalLogError = new DxGlobalLogError { TypeValue=1,};
            LogWriter = new SqlServerLogWriter();
            Init();
        }
        protected void Init()
        {
            SetClient();
        }
        protected abstract void SetClient();
        protected DxGlobalLogError DxGlobalLogError { get; set; }
        public void log(int userid, string message, string ipAddress, string location = "", string summary = "")
        {
            DxGlobalLogError.UserId = userid;
            DxGlobalLogError.Message = message;
            DxGlobalLogError.IpAddress = ipAddress;
            DxGlobalLogError.Location = location;
            DxGlobalLogError.Summary = summary;
            DxGlobalLogError.CreatedOn = DateTime.Now;
            LogWriter.Write(DxGlobalLogError);
        }
    }
}
