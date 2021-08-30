using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Infrastructure.Dto.Base
{
   public class user
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password{ get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string oNpassword { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name{ get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string phone{ get; set; }
       
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string email { get; set; }
       /// <summary>
       /// 性别
       /// </summary>
        public int gender{ get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string birthday { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string uid{ get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string role { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// 班级
        /// </summary>
        public string iclass { get; set; }
        public string state { get; set; }
    }
}
