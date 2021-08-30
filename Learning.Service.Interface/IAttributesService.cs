using Learning.Infrastructure.Tool.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service.Interface
{
    [Provide]
    public interface IAttributesService
    {
        object getAttributeOnPost();
        object getAttributeOnRole();
        object getAttributeOnClass();
        object getAttributeTypeByList(out int total, int page, int limit, string name, string roleid);
        object getAttributeByAid(out int total, int page, int limit, string aid,string name);
        object getAttributeTypeByAdd(string name, string value, string desc, int necessary, int sort);
        object getAttributeTypeByEdit(string id,string name, string value, string desc, int necessary, int sort);
        object getAttributeByAdd(string name, string value1, string value2, string atid, int sort, string desc, string uid);
        object getAttributeByOperate(string id, int state);
        object getAttributeByUpdate(string id,string name, string value1, string value2, int sort, string desc);
    }
}
