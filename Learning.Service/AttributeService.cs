using Learning.Infrastructure.IOC;
using Learning.Infrastructure.Tool.Attributes;
using Learning.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Learning.Infrastructure.Dto.Base;
using System.Text;
using System.Threading.Tasks;
using Learning.Infrastructure.Dto;
using Learning.Infrasturcture.Tool;
using Attribute = Learning.Infrastructure.Dto.Attribute;
using Microsoft.EntityFrameworkCore;

namespace Learning.Service
{
    [Inject]
    public class AttributeService : BaseService, IAttributesService
    {
        private readonly IConfiguration _Configuration;
        private readonly AttributeIOC _attributeIOC;

        public  AttributeService(AttributeIOC attributeIOC, IConfiguration Configuration) {
            _Configuration = Configuration;
            _attributeIOC = attributeIOC;
        }

        public object getAttributeByAdd(string name, string value1, string value2, string atid, int sort, string desc, string uid)
        {
            Attribute attribute = new Attribute
            {
                Aid=Config.GUID(),
                Aname=name,
                Avalue=value1,
                Avalue2=value2,
                Aatid=atid,
                Astate=1,
                Ano=sort,
                AisDel=0,
                AcreateTime=DateTime.Now,
                Auid=uid,
                Adesc=desc
            };
            _attributeIOC._baseAttributesService.Add(attribute);
            _attributeIOC._baseAttributesService.SaveChanges();
            return GetResult(Actions.add,0);
        }

        public object getAttributeByAid(out int total, int page, int limit, string aid,string name)
        {
            total = 0;
            var data = _attributeIOC._baseAttributesService.QueryAll(d=>d.Ano,true,out total,page,limit,d => d.Aatid.Contains(aid)&&d.Aname.Contains(name)).Include(d=>d.UserUdesignationAs).Select(d => new
            {
                id=d.Aid,
                name=d.Aname,
                value1=d.Avalue,
                value2=d.Avalue2,
                aatid=d.Aat.Atname,
                state=d.Astate,
                sort=d.Ano,
                isdel=d.AisDel,
                date=d.AcreateTime,
                auid=d.Au.Uname,
                desc=d.Adesc,
            }).ToList();
            return GetResult(Actions.query, 0, data: new
            {
                total,
                data
            });
        }

        public object getAttributeByOperate(string id, int state)
        {
            var iq = _attributeIOC._baseAttributesService.QueryAll(d => d.Aid.Contains(id)).FirstOrDefault();
            iq.Astate = state;
            _attributeIOC._baseAttributesService.Update(iq);
            _attributeIOC._baseAttributesService.SaveChanges();
            return GetResult(Actions.update, 0);
        }

        public object getAttributeByUpdate(string id, string name, string value1, string value2, int sort, string desc)
        {
            var iq = _attributeIOC._baseAttributesService.QueryAll(d => d.Aid.Contains(id)).FirstOrDefault();
            iq.Avalue = value1;
            iq.Avalue2 = value2;
            iq.Aname = name;
            iq.Ano = sort;
            iq.Adesc = desc;
            _attributeIOC._baseAttributesService.Update(iq);
            _attributeIOC._baseAttributesService.SaveChanges();
            return GetResult(Actions.update, 0);
        }

       

        public object getAttributeOnClass()
        {
            var iq = _attributeIOC._baseAttributesService.QueryAll(d => d.Aatid == _Configuration["Attribute:class"] && (d.Astate == 1 && d.AisDel == 0)).Select(d=>new { 
            id=d.Aid,
            title=d.Aname,
            }).ToList();
            return GetResult( Actions.query,0,data:iq);
        }

        public object getAttributeOnPost()
        {
            var iq = _attributeIOC._baseAttributesService.QueryAll(d => d.Aatid == _Configuration["Attribute:post"] && (d.Astate == 1 && d.AisDel == 0)).Select(d => new {
                id = d.Aid,
                title = d.Aname,
            }).ToList();
            return GetResult(Actions.query, 0, data: iq);
        }

        public object getAttributeOnRole()
        {
            var iq = _attributeIOC._baseAttributesService.QueryAll(d => d.Aatid == _Configuration["Attribute:role"] && (d.Astate == 1 && d.AisDel == 0)).Select(d => new {
                id = d.Aid,
                title = d.Aname,
            }).ToList();
            return GetResult(Actions.query, 0, data: iq);
        }

        public object getAttributeTypeByAdd(string name, string value, string desc, int necessary, int sort)
        {
            AttributeType attributeType = new AttributeType()
            {
                Atid=Config.GUID(),
                Atname=name,
                Atvalue=value,
                AtisNecessary=necessary,
                Atstate=1,
                AtisDel=0,
                AtcreateTime=DateTime.Now,
                Atdesc=desc,
                Atno= sort
            };
            _attributeIOC._baseAttributeTypeService.Add(attributeType);
            _attributeIOC._baseAttributeTypeService.SaveChanges();
            return GetResult( Actions.add,0);
        }

        public object getAttributeTypeByEdit(string id,string name, string value, string desc, int necessary, int sort)
        {
            var iq = _attributeIOC._baseAttributeTypeService.QueryAll(d => d.Atid == id).FirstOrDefault();
            iq.Atname = name;
            iq.Atvalue = value;
            iq.Atdesc = desc;
            iq.AtisNecessary = necessary;
            iq.Atno = sort;
            _attributeIOC._baseAttributeTypeService.Update(iq);
            _attributeIOC._baseAttributeTypeService.SaveChanges();
            return GetResult(Actions.update, 0);
        }

        public object getAttributeTypeByList(out int total, int page, int limit, string name, string roleid)
        {
            total = 0;
            var data = _attributeIOC._baseAttributeTypeService.QueryAll(d=>d.Atno,true,out total,page,limit,d => d.AtisDel == 0).Select(d=>new { 
            id=d.Atid,
            name=d.Atname,
            value=d.Atvalue,
            necessary=d.AtisNecessary,
            state=d.Atstate,
            isdel=d.AtisDel,
            date=d.AtcreateTime,
            attrs=d.Attributes.Count(),
            atuid =d.Atuid,
            sort = d.Atno,
            desc=d.Atdesc
            }).ToList();
            return GetResult(Actions.query,0,data:new {
                total,
                data
            });
        }
    }
}
