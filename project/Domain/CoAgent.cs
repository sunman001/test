using Dba.Attributes;
using System;



namespace Domain
{
    /// <summary>
    /// 代理商
    /// </summary>
   //[Table(Name= "CoAgent")]
   public   class CoAgent
    {
     [DxColumn(Primarykey =true,AutoIncrement=true)]
      public int Id { get; set; }
        /// <summary>
        /// 登录名称
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 加密的密码字符串
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 显示姓名
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// QQ号码
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 网址
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
        public int CreatedById { get; set; }
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public string CreatedByName { get; set; }
        /// <summary>
        /// 所属商务ID
        /// </summary>
        public int OwnerId { get; set; }
        /// <summary>
        /// 所属商务姓名
        /// </summary>
        public string OwnerName { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginCount { get; set; }
        /// <summary>
        /// 状态[0:正常,1:冻结]
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 开户银行全称
        /// </summary>
        public string BankFullName { get; set; }
        /// <summary>
        /// 开户名
        /// </summary>
        public string BankAccountName { get; set; }
        /// <summary>
        /// 开户账号
        /// </summary>
        public string BankAccount { get; set; }
        /// <summary>
        /// 类别：0 个人 1 企业
        /// </summary>
        public int Classify { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCardNumber { get; set; }
        /// <summary>
        /// 持证照片地址
        /// </summary>
        public string PersonalPhotoPath { get; set; }
        /// <summary>
        /// 营业执照照片
        /// </summary>
        public string BusinessLicensePhotoPath { get; set; }
        /// <summary>
        /// 营业执照编号
        /// </summary>
        public string BusinessLicenseNumber { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string ContactAddress { get; set; }
        /// <summary>
        /// 审核状态：-1 未通过 0 等待审核
        /// </summary>
        public int AuditState { get; set; }
        /// <summary>
        /// 用户角色ID
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 代理商服务费关联表ID(商务设置此项)
        /// </summary>
        public int ServiceFeeRatioGradeId { get; set; }

    }
}
