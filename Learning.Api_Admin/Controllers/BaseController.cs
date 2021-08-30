using Learning.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Learning.Api_Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IUserService _userService;
        protected readonly IConfiguration _configuration;

        public BaseController(IHttpContextAccessor httpContextAccessor,IUserService userService,IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _configuration = configuration;
        }

       
        //获取IP
       // public string GetIp() => _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        //是相同的，两个方法一样
        //public string GetIp() {
        //    return _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        //}

        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>返回对应的值</returns>
        protected string GetCookies(string key)
        {
            HttpContext.Request.Cookies.TryGetValue(key, out string value);
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }

        /// <summary>
        /// 设置本地cookie
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>  
        /// <param name="minutes">过期时长，单位：分钟</param>      
        protected void SetCookies(string key, string value, int minutes = 0)
        {
            if (minutes == 0)
            {
                HttpContext.Response.Cookies.Append(key, value);
            }
            else
            {
                HttpContext.Response.Cookies.Append(key, value, new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(minutes)
                });

            }
        }

        /// <summary>
        /// 删除指定的cookie
        /// </summary>
        /// <param name="key">键</param>
        protected void DeleteCookies(string key)
        {
            HttpContext.Response.Cookies.Delete(key);
        }

        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        protected string GetIp()
        {
            // return "127.0.0.1"; //正式环境请注释
            return _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();//测试环境请注释
        }
        ///// <summary>
        ///// 获取当前登录对象
        ///// </summary>
        ///// <returns></returns>
        //protected User GetCu()
        //{
        //    var code = Response.HttpContext.User.Identity.Name;
        //    string ip = this.GetIp();
        //    var user = _userService.GetUsersByCode(code, ip);
        //    if (user == null)
        //    {
        //        throw new Exception("身份验证出错");
        //    }
        //    return user;

        //}

    }
}
