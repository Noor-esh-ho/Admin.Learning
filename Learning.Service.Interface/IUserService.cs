
using Learning.Infrastructure.Dto.Base;
using Learning.Infrastructure.Tool.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service.Interface
{
   [Provide]
   public interface IUserService
    {
        ApiResult getUserBylogin(string account,string password,string code, string ip);
        object getUserBylogin(string code);
        object getUserByInfoAll(out int total, int page, int limit, string name, string account, string parentId, string roleid);
        object getUserByAdd(user data);
        object getUserByUpdate(user data);
        object getUserResetPassword(string[] arrid, string password);
        object getUserByRemove(string[] arrid);
        bool getUserModifyavatar(string uid, string founder, string new_path);
        object getUserInfo(string uid);
        object getUserByUpdateBase(string avatar, string email, string id, string name, string phone, string realName, string oldPassword, string newPassword);
        object getUserByUpdatePassword(string uid, string oldPassword, string newPassword,string newPassword1);
    }
}
