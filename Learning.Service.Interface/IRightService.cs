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
    public interface IRightService
    {
        object getRightByUid(string uid);
        object getRightBytermAll(out int total,int page, int limit, string rname, string rid);
        object getRightByAdd(menu data);
        object getList();
        object getRightByUpdate(menu data);
        object getRightByDelete(string[] arrid);
        object getRightConfigByList(out int total, int page, int limit, string name, string roleid);
        object getRoleList();
        object getRightConfigByAdd(string name, string role, string[] arrid);
        object getRightByTree(string id);
        object getRightByEnable(string id);
        object getRightByauthId(string id);
        object getRightByAfresh(string[] arrid, string aid, string uid);
    }
}
