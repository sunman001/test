using LogManager.LogManager;
using TOOL;

namespace dom.Util.Logger
{
    public class GlobalErrorLogger
    {
        public static void Log(string message,string location="",string summary="服务器错误")
        {
            var logger = new AdministratorGlobalFactory().CreateLogger();
            logger.log(UserInfo.Uid,message, RequestHelper.GetClientIp(),location,summary);
        }
    }
}