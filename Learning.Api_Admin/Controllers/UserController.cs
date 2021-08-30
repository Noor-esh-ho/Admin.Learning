using Learning.Api_Admin.Models;
using Learning.Infrastructure.Dto.Base;
using Learning.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Learning.Api_Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Base")]
    public class UserController : BaseController
    {
        public UserController(IHttpContextAccessor httpContextAccessor, IUserService userService, IConfiguration confiugration) : base(httpContextAccessor, userService, confiugration)
        {

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getUserBylogin(Models.Users users)
        {
            string code = Learning.Infrasturcture.Tool.Config.GUID();
            var result = _userService.getUserBylogin(
                account: users.account, password: users.password,
                code: code, ip: GetIp());
            if (result.code == ApiCode.ok)
            {
                //判断不同的角色 给予不同的身份 到时候就可以去通过角色来验证是否拥有对action的访问权限
                //JWT加密
                int role = 1;
                Claim[] claims = claims = new[]
                 {
                    new Claim(ClaimTypes.Name, code),
                    new Claim(ClaimTypes.Role,"user") //身份要是更改的
                 };
                if (role == 2)
                {
                    claims[1] = new Claim(ClaimTypes.Role, "admin");//身份要是更改的
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                string jwtKey = _configuration["JWT:issuer"];
                var token = new JwtSecurityToken(
                    issuer: jwtKey,
                    audience: jwtKey,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60 * 12), //token 过期时间
                    signingCredentials: creds);
                //var tokenss = new JwtSecurityTokenHandler().ReadJwtToken(token.ToString());
                ////得到保存的code 验证code是否过期
                //string codes = tokenss.Claims.ToList().First(o => o.Type == System.Security.Claims.ClaimTypes.Name).Value.ToString();
                var userinfo = _userService.getUserBylogin(code);
                result.data = new { token = new JwtSecurityTokenHandler().WriteToken(token), userinfo = userinfo };

            }
            return Ok(result);
        }

        //[Authorize(Roles = "user,admin")]
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult getUserByInfo(string token)
        {
            var tokenss = new JwtSecurityTokenHandler().ReadJwtToken(token);
            //得到保存的code 验证code是否过期
            string code = tokenss.Claims.ToList().First(o => o.Type == System.Security.Claims.ClaimTypes.Name).Value.ToString();
            var result = _userService.getUserBylogin(code);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult getUserByInfoAll(dynamic data)
        {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            int page = (int)json.page.Value;
            int limit = (int)json.limit.Value;
            string name = json.name.Value;
            string account = json.account.Value;
            string parentId = json.parentId.Value;
            string roleid = json.roleid.Value;
            var result = _userService.getUserByInfoAll(out int total, page, limit, name, account, parentId, roleid);
            return Ok(result);
        }
        /// <summary>
        /// 新增单个用户
        /// </summary>
        /// <param name="user">数据</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getUserByAdd(user data)
        {
            var result = _userService.getUserByAdd(data);
            return Ok(result);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getUserByUpdate(user data)
        {
            var result = _userService.getUserByUpdate(data);
            return Ok(result);
        }
        /// <summary>
        /// 密码重置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getUserResetPassword(dynamic data)
        {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            string password = Convert.ToString(json.password.Value);
            string[] arrid = JsonConvert.DeserializeObject<string[]>(Convert.ToString(json.arrid));
            var result = _userService.getUserResetPassword(arrid, password);
            return Ok(result);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getUserByRemove(dynamic data)
        {
            string[] arrid = JsonConvert.DeserializeObject<string[]>(Convert.ToString(data));
            var result = _userService.getUserByRemove(arrid);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult getUserInfo(string uid) {
            var result = _userService.getUserInfo(uid);
            return Ok(result);
        }
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getUserByUpdateBase(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            string avatar = json.avatar.Value;
            string email = json.email.Value;
            string id = json.id.Value;
            string name = json.name.Value;
            string phone = json.phone.Value;
            string realName = json.realName.Value;
            string oldPassword = json.oldPassword.Value;
            string newPassword = json.newPassword.Value;
            var result = _userService.getUserByUpdateBase(avatar,email,id,name,phone,realName,oldPassword,newPassword);
            return Ok(result);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="data">参数</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getUserByUpdatePassword(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            string oldPassword = json.oldPassword.Value;
            string newPassword = json.newPassword.Value; 
            string newPassword1 = json.newPassword1.Value;
            string uid = json.uid.Value;
            var result = _userService.getUserByUpdatePassword(uid,oldPassword, newPassword, newPassword1);
            return Ok(result);
        }
        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="Files"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Upload(IFormCollection Files)
        {
            try
            {
                //var form = Request.Form;//直接从表单里面获取文件名不需要参数
                string dd = Files["File"];
                var form = Files;//定义接收类型的参数
                Hashtable hash = new Hashtable();
                IFormFileCollection cols = Request.Form.Files;
                if (cols == null || cols.Count == 0)
                {
                    return Ok(new { status = -1, message = "没有上传文件", data = hash });
                }
                foreach (IFormFile file in cols)
                {
                    //定义图片数组后缀格式
                    string[] LimitPictureType = { ".JPG", ".JPEG", ".GIF", ".PNG", ".BMP" };
                    //获取图片后缀是否存在数组中
                    string currentPictureExtension = Path.GetExtension(file.FileName).ToUpper();
                    if (LimitPictureType.Contains(currentPictureExtension))
                    {

                        //为了查看图片就不在重新生成文件名称了
                        // var new_path = DateTime.Now.ToString("yyyyMMdd")+ file.FileName;
                        var new_path = Path.Combine("uploads/images/", file.FileName);
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", new_path);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {

                            //图片路径保存到数据库里面去
                            //bool flage = _userService.getUserModifyavatar(uid, founder, new_path);
                            //if (flage == true)
                            //{
                            //    //再把文件保存的文件夹中
                            //    file.CopyTo(stream);
                            //    hash.Add("file", "/" + new_path);
                            //}
                            file.CopyTo(stream);
                            hash.Add("file", "/" + new_path);
                            return Ok(new
                            {
                                code = 2000,
                                data = new
                                {
                                    link = "http://localhost:2312/images/" + file.FileName,
                                    data = ""
                                }
                            });
                        }
                    }
                    else
                    {
                        return Ok(new { status = -2, message = "请上传指定格式的图片", data = hash });
                    }
                }

                return Ok(new { status = 0, message = "上传成功", data = hash });
            }
            catch (Exception ex)
            {

                return Ok(new { status = -3, message = "上传失败", data = ex.Message });
            }

        }
       
    }
}
