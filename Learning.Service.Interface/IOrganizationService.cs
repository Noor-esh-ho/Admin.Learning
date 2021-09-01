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
    public interface IOrganizationService
    {
        object getOrganizationByList(out int total, int page, int limit, string name, string roleid);
        object getOrganizationByAll();
        object getOrganizationByAdd(dept data);
        object getOrganizationRelationByAdd(string[] arrid, string oid);
        object getOrganizationTreeUser(out int total, int page, int limit, string name, string account, string oid, string jobid);
        object getOrganizationDeletebase(string[] arruid, string oid);
    }
}
