
using Learning.Infrastructure.Dto.Base;
using Learning.Infrastructure.IOC;
using Learning.Infrastructure.Tool.Attributes;
using Learning.Infrastructure.Tool;
using Learning.Service.Base;
using Learning.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Infrasturcture.Tool;
using Microsoft.EntityFrameworkCore;
using Learning.Infrastructure.Dto;

namespace Learning.Service
{
    [Inject]
    public class UserService : BaseService, IUserService
    {
        private readonly UserIOC _userIOC;
        private readonly IConfiguration _Configuration;

        public UserService(UserIOC userIOC, IConfiguration Configuration)
        {
            _userIOC = userIOC;
            _Configuration = Configuration;
        }

        public object getUserByAdd(user us)
        {

            try
            {
                var uid = us.uid == "" ? Config.GUID() : us.uid;
                var password = EncryptUtil.LoginMd5(us.password, _Configuration["Admin:default"]);
                User user = new User()
                {
                    Uid = uid,
                    Uaccount = us.account,
                    Upassword = password,
                    Uname = us.name,
                    Ucid = us.iclass == "" ? null : us.iclass,
                    UroleAid = us.role == "" ? null : us.role,
                    UdesignationAid = us.position == "" ? null : us.position,
                    Ucode = null,
                    UlastIp = null,
                    UlastTime = null,
                    UcreateTime = DateTime.Now,
                    Ulv = null,
                    Ulabels = null,
                    Ustate = 1,
                    UisDel = 0,
                    Usign = null,
                    UopenId = null,
                    Udesc = null,
                };
                _userIOC._baseuserService.Add(user);
                _userIOC._baseuserService.SaveChanges();
                UserInfo userInfo = new UserInfo()
                {
                    Uiid = Config.GUID(),
                    Uiuid = uid,
                    Uinick = us.nickname == "" ? null : us.nickname,
                    Uiphone = us.phone == "" ? null : us.phone,
                    Uimail = us.email == "" ? null : us.email,
                    Uibirthday = us.birthday == "" ? null : Convert.ToDateTime(us.birthday),
                    Uigender = us.gender == 0 ? "男" : (us.gender == 1 ? "女" : "未知"),
                    Uipoint = null,
                    Uirid = null,
                    Uigrade = null,
                    Uistate = 1,
                    UiisDel = 0,
                    UicreateTime = DateTime.Now,
                    Uidesc = null,
                };
                _userIOC._baseUserInfoService.Add(userInfo);
                _userIOC._baseUserInfoService.SaveChanges();
                return GetResult(Actions.add, 0);
            }
            catch (Exception e)
            {
                return GetResult(Actions.add, -1);
            }

        }

        public object getUserByInfoAll(out int total, int page, int limit, string name, string account, string parentId, string roleid)
        {
            total = 0;
            if (parentId != "")
            {
                List<user> dataList = new List<user>();
                var Oruid = _userIOC._baseOrganizationRelationService.QueryAll(d => d.Oroid.Contains(parentId)).Select(d => d.Oruid).ToList();
                var iq = _userIOC._baseuserService.QueryAll(d => d.UcreateTime, true, out total, page, limit, d => Oruid.Contains(d.Uid) && (d.Uname.Contains(name) && d.Uaccount.Contains(account)) && (d.Ustate == 1 && d.UisDel == 0)).Include(r => r.OrganizationRelations).Include(r => r.UserInfos).ToList();
                iq.ForEach(d =>
                {
                    dataList.Add(new user
                    {
                        uid = d.Uid,
                        account = d.Uaccount,
                        password = d.Upassword,
                        oNpassword = d.Upassword,
                        nickname = d.UserInfos.FirstOrDefault().Uinick,
                        name = d.Uname,
                        phone = d.UserInfos.FirstOrDefault().Uiphone,
                        email = d.UserInfos.FirstOrDefault().Uimail,
                        gender = d.UserInfos.FirstOrDefault().Uigender == "男" ? 0 : (d.UserInfos.FirstOrDefault().Uigender == "女" ? 1 : 3),
                        birthday = d.UserInfos.FirstOrDefault().Uibirthday.ToString(),
                        role = d.UroleAid,
                        position = d.UdesignationAid,
                        iclass = d.Ucid,
                        state = d.Ustate == 1 ? "正常" : "禁用",
                    });

                });
                object data = new
                {
                    dataList,
                    count = total
                };
                return GetResult(Actions.query, 0, data: data);

            }
            else
            {
                List<user> dataList = new List<user>();
                var iq = _userIOC._baseuserService.QueryAll(d => d.UcreateTime, true, out total, page, limit, d => d.Uname.Contains(name) && d.Uaccount.Contains(account) && (d.Ustate == 1 && d.UisDel == 0)).Include(d => d.UserInfos).ToList();
                iq.ForEach(d =>
                {
                    dataList.Add(new user
                    {
                        uid = d.Uid,
                        account = d.Uaccount,
                        password = d.Upassword,
                        oNpassword = d.Upassword,
                        nickname = d.UserInfos.FirstOrDefault().Uinick,
                        name = d.Uname,
                        phone = d.UserInfos.FirstOrDefault().Uiphone,
                        email = d.UserInfos.FirstOrDefault().Uimail,
                        gender = d.UserInfos.FirstOrDefault().Uigender == "男" ? 0 : (d.UserInfos.FirstOrDefault().Uigender == "女" ? 1 : 3),
                        birthday = d.UserInfos.FirstOrDefault().Uibirthday.ToString(),
                        role = d.UroleAid,
                        position = d.UdesignationAid,
                        iclass = d.Ucid,
                        state = d.Ustate == 1 ? "正常" : "禁用",
                    });
                });
                object data = new
                {
                    dataList,
                    count = total
                };
                return GetResult(Actions.query, 0, data: data);
            }
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="code"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public ApiResult getUserBylogin(string account, string password, string code, string ip)
        {
            password = EncryptUtil.LoginMd5(password, _Configuration["Admin:default"]);
            var iq = _userIOC._baseuserService.QueryAll(d => d.Uaccount == account && d.Upassword == password);
            if (iq.Any())
            {
                var user = iq.SingleOrDefault();
                if (user.Ustate == -1)
                {
                    return GetResult(Actions.login, apiCode: ApiCode.notAcive);
                }
                else if (user.Ustate == 2)
                {
                    return GetResult(Actions.login, apiCode: ApiCode.ban);
                }
                else
                {
                    user.Ucode = code;
                    user.UlastIp = ip;
                    _userIOC._baseuserService.Update(user);
                    var result = _userIOC._baseuserService.SaveChanges();
                    return GetResult(Actions.action, result > 0 ? 0 : -1);
                }
            }
            else
            {
                return GetResult(Actions.paraError, message: "账号或者密码错误");
            }
        }

        public object getUserBylogin(string code)
        {
            var iq = _userIOC._baseuserService.QueryAll(d => d.Ucode == code).Select(d => new
            {
                uid = d.Uid,
                uName = d.Uname,
                NickName = d.UserInfos.FirstOrDefault().Uinick,
                Phone = d.UserInfos.FirstOrDefault().Uiphone,
                Email = d.UserInfos.FirstOrDefault().Uimail,
                Birthday = d.UserInfos.FirstOrDefault().Uibirthday,
                uAccount = d.Uaccount,
                avatar = d.Resources.FirstOrDefault().Rpath,

            });
            if (iq.Any())
            {
                return iq.FirstOrDefault();
            }
            return null;
        }

        public object getUserByRemove(string[] arrid)
        {
            List<User> user = new List<User>();
            foreach (var item in arrid)
            {
                var iq = _userIOC._baseuserService.QueryAll(d => d.Uid.Contains(item)).Include(d => d.UserInfos).FirstOrDefault();
                iq.UisDel = 1;
                iq.UserInfos.FirstOrDefault().UiisDel = 1;
                user.Add(iq);
            }
            _userIOC._baseuserService.RemoveRange(user);
            _userIOC._baseuserService.SaveChanges();
            return GetResult(Actions.delete, 0);
        }

        public object getUserByUpdate(user us)
        {
            try
            {
                var iq = _userIOC._baseuserService.QueryAll(d => d.Uid.Contains(us.uid)).FirstOrDefault();
                var password = EncryptUtil.LoginMd5(us.password, _Configuration["Admin:default"]);
                iq.Uid = us.uid == "" ? iq.Uid : us.uid;
                iq.Uaccount = us.account;
                iq.Upassword = password;
                iq.Uname = us.name;
                iq.Ucid = us.iclass == "" ? null : us.iclass;
                iq.UroleAid = us.role == "" ? null : us.role;
                iq.UdesignationAid = us.position == "" ? null : us.position;
                iq.Ustate = 1;
                iq.UisDel = 0;
                iq.Uaccount = us.account;
                iq.Upassword = password;
                iq.Uname = us.name;
                iq.Ucid = us.iclass == "" ? null : us.iclass;
                iq.UroleAid = us.role == "" ? null : us.role;
                iq.UdesignationAid = us.position == "" ? null : us.position;
                iq.UcreateTime = DateTime.Now;
                iq.Ustate = 1;
                iq.UisDel = 0;
                _userIOC._baseuserService.Update(iq);
                _userIOC._baseuserService.SaveChanges();
                var info = _userIOC._baseUserInfoService.QueryAll(d => d.Uiuid.Contains(us.uid)).FirstOrDefault();
                info.Uinick = us.nickname == "" ? null : us.nickname;
                info.Uiphone = us.phone == "" ? null : us.phone;
                info.Uimail = us.email == "" ? null : us.email;
                info.Uibirthday = us.birthday == "" ? null : Convert.ToDateTime(us.birthday);
                info.Uigender = us.gender == 0 ? "男" : (us.gender == 1 ? "女" : "未知");
                _userIOC._baseUserInfoService.Update(info);
                _userIOC._baseUserInfoService.SaveChanges();

                return GetResult(Actions.update, 0);
            }
            catch (Exception e)
            {
                return GetResult(Actions.add, -1);
            }
        }

        public object getUserByUpdateBase(string avatar, string email, string id, string name, string phone, string realName, string oldPassword, string newPassword)
        {
            var rid = Config.GUID();
            var raid = _Configuration["Attribute:avatar"];
            var iq = _userIOC._baseuserService.QueryAll(d => d.Uid.Contains(id)).Include(d=>d.UserInfos).FirstOrDefault();
            Resource resource = new Resource()
            {
                Rid = rid,
                Rtitle = "用户头像",
                Raid = raid,
                Ruid = id,
                Rname = null,
                Rpath = avatar,
                Rsize = 500,
                RisUse = 1,
                RisPublic = 1,
                RbeginTime = null,
                RendTime = null,
                Rstate = 1,
                RisDel = 0,
                Rdesc = null
            };
            _userIOC._baseResourcesService.Add(resource);
            _userIOC._baseResourcesService.SaveChanges();
            iq.UserInfos.FirstOrDefault().Uiphone = phone;
            iq.UserInfos.FirstOrDefault().Uinick = realName;
            iq.UserInfos.FirstOrDefault().Uimail = email;
            iq.UserInfos.FirstOrDefault().Uirid = rid;
            iq.Uname = name;
            _userIOC._baseuserService.Update(iq);
            _userIOC._baseuserService.SaveChanges();
            var res = _userIOC._baseResourcesService.QueryAll(d => !iq.UserInfos.FirstOrDefault().Uirid.Contains(d.Rid) && d.Raid == raid);
            if (res.Any())
            {
                var da = res.ToList();
                _userIOC._baseResourcesService.RemoveRange(da);
                _userIOC._baseResourcesService.SaveChanges();
            }
            return GetResult(Actions.update,0);
        }

        public object getUserByUpdatePassword(string uid, string oldPassword, string newPassword,string newPassword1)
        {
            if (newPassword != newPassword1) {
                return GetResult(Actions.update, -1, message: "两次输入密码不一致!");
            }
            oldPassword = EncryptUtil.LoginMd5(oldPassword, _Configuration["Admin:default"]);
            var iq = _userIOC._baseuserService.QueryAll(d => d.Uid == uid).FirstOrDefault();
            if (iq.Upassword != oldPassword)
            {
                return GetResult(Actions.update, -1, message: "原密码错误,请重新输入！");
            }
            else {
                newPassword = EncryptUtil.LoginMd5(newPassword, _Configuration["Admin:default"]);
                iq.Upassword = newPassword;
                _userIOC._baseuserService.Update(iq);
                _userIOC._baseuserService.SaveChanges();
                return GetResult(Actions.update,0);
            }
        }

        public object getUserInfo(string uid)
        {
            var iq = _userIOC._baseuserService.QueryAll(d => d.Uid == uid).Include(d => d.UserInfos).Select(d => new
            {
                id = d.Uid,
                avatar = d.Resources.FirstOrDefault().Rpath,
                name = d.Uname,
                realName = d.UserInfos.FirstOrDefault().Uinick,
                phone = d.UserInfos.FirstOrDefault().Uiphone,
                email = d.UserInfos.FirstOrDefault().Uimail,
            }).FirstOrDefault();
            return GetResult(Actions.query, 0, data: iq);
        }

        public bool getUserModifyavatar(string uid, string founder, string new_path)
        {
            throw new NotImplementedException();
        }

        public object getUserResetPassword(string[] arrid, string password)
        {
            List<User> list = new List<User>();
            password = EncryptUtil.LoginMd5(password, _Configuration["Admin:default"]);
            foreach (var item in arrid)
            {
                var iq = _userIOC._baseuserService.QueryAll(d => d.Uid.Contains(item)).FirstOrDefault();
                iq.Upassword = password;
                list.Add(iq);
            }
            _userIOC._baseuserService.UpdateRange(list);
            _userIOC._baseuserService.SaveChanges();
            return GetResult(Actions.update, 0);
        }
    }
}
