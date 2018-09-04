using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace WebApiTest.Controllers
{
    /// <summary>
    /// 用户相关
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="strUser">用户名</param>
        /// <param name="strPwd">密码</param>
        /// <returns></returns>
        [HttpGet]
        public object Login(string strUser, string strPwd)
        {
            if (!ValidateUser(strUser, strPwd))
            {
                return new { bRes = false };
            }
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, strUser, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", strUser, strPwd),
                            FormsAuthentication.FormsCookiePath);
            //返回登录结果、用户信息、用户验证票据信息
            var oUser = new UserInfo { bRes = true, UserName = strUser, Password = strPwd, Ticket = FormsAuthentication.Encrypt(ticket) };
            //将身份信息保存在session中，验证当前请求是否是有效请求
            HttpContext.Current.Session[strUser] = oUser;
            return oUser;
        }

        //校验用户名密码（正式环境中应该是数据库校验）
        private bool ValidateUser(string strUser, string strPwd)
        {
            if (strUser == "admin" && strPwd == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 是否通过认证
        /// </summary>
        public bool bRes { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 票据
        /// </summary>
        public string Ticket { get; set; }
    }
}
