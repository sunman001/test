
using System.Web;
namespace TOOL
{
  public   class UserInfo
    {
       /// <summary>
       /// 用户ID
       /// </summary>
        public static int UserId
        {
            get
            {
                return HttpContext.Current.Session["u_id"] == null ? 0 :
                    int.Parse(HttpContext.Current.Session["u_id"].ToString());
            }
            set { HttpContext.Current.Session["u_id"]= value; }
        }

        /// <summary>
        /// 从登录中获取用户ID
        /// </summary>
        public static int Uid
        {
            get
            {
                return HttpContext.Current.Session["u_id"] == null ? 0 : int.Parse(HttpContext.Current.Session["u_id"].ToString());
            }
        }

        /// <summary>
        /// 是否登录
        /// </summary>
        public static bool IsLogin
        {
            get { return Uid > 0; }
        }
        public static int UserRoleId
        {
            get { return HttpContext.Current.Session["u_role_id"] == null ? 0 : int.Parse(HttpContext.Current.Session["u_role_id "].ToString()); }
            set { HttpContext.Current.Session["u_role_id"] = value; }
        }
        /// <summary>
        /// 用户角色编码
        /// </summary>
        public static int UserRid
        {
            get
            {
                return HttpContext.Current.Session["u_role_id"] == null ? 0 : int.Parse(HttpContext.Current.Session["u_role_id"].ToString());
            }
        }

        /// <summary>
        /// 用户角色名
        /// </summary>
        public static string UserRoleName
        {
            get { return HttpContext.Current.Session["u_role_name"] == null ? null : HttpContext.Current.Session["u_role_name"].ToString(); }
            set { HttpContext.Current.Session["u_role_name"] = value; }
        }

        /// <summary>
        /// 用户登陆名
        /// </summary>
        public static string UserNo
        {
            get { return HttpContext.Current.Session["u_login_name"] == null ? null : HttpContext.Current.Session["u_login_name"].ToString(); }
            set { HttpContext.Current.Session["u_login_name"] = value; }
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public static string UserName
        {
            get { return HttpContext.Current.Session["u_real_name"] == null ? null : HttpContext.Current.Session["u_real_name"].ToString(); }
            set { HttpContext.Current.Session["u_real_name"] = value; }
        }

        /// <summary>
        /// 部门
        /// </summary>
        public static string UserDept
        {
            get { return HttpContext.Current.Session["u_department"] == null ? null : HttpContext.Current.Session["u_department"].ToString(); }
            set { HttpContext.Current.Session["u_department"] = value; }
        }

        /// <summary>
        /// 账户状态：0 冻结 1 正常
        /// </summary>
        public static string UserState
        {
            get { return HttpContext.Current.Session["u_state"] == null ? null : HttpContext.Current.Session["u_state"].ToString(); }
            set { HttpContext.Current.Session["u_state"] = value; }
        }

        /// <summary>
        /// 登录次数
        /// </summary>
        public static string UserLoginCount
        {
            get { return HttpContext.Current.Session["u_count"] == null ? null : HttpContext.Current.Session["u_count"].ToString(); }
            set { HttpContext.Current.Session["u_count"] = value; }
        }
        /// <summary>
        /// 审核状态：-1 未通过 0 等待审核
        /// </summary>
        public static string auditstate
        {
            get { return HttpContext.Current.Session["u_auditstate"] == null ? null : HttpContext.Current.Session["u_auditstate"].ToString(); }
            set { HttpContext.Current.Session["u_auditstate"] = value; }
        }
    }
}
