using Learning.Infrastructure.Dto.Base;
using Learning.Infrastructure.Dto;
using Learning.Infrastructure.IOC;
using Learning.Infrastructure.Tool.Attributes;
using Learning.Infrasturcture.Tool;
using Learning.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service
{
    [Inject]
    public  class OrganizationService:BaseService,IOrganizationService
    {
        private readonly OrganizationICO _organizationICO;

        public OrganizationService(OrganizationICO organizationICO) {
            _organizationICO = organizationICO;
        }

        public object getOrganizationByAll()
        {
            List<object> list = new List<object>();
            var iq = _organizationICO._baseOrganizationService.QueryAll(d => d.OparentOid == null && (d.Ostate == 1 && d.OisDel == 0)).ToList();
            iq.ForEach(d =>
            {
                list.Add(new
                {
                    parentId = d.Oid,
                    title = d.Oname,
                    children= getOrganizationDrenByOID(d.Oid)
                });
            });
            return GetResult( Actions.query,0,data:list);
        }

        private List<object> getOrganizationDrenByOID(string oid)
        {
            List<object> list = new List<object>();
            var iq = _organizationICO._baseOrganizationService.QueryAll(d => d.OparentOid.Contains(oid)&& (d.Ostate == 1 && d.OisDel == 0)).ToList();
            iq.ForEach(d =>
            {
                list.Add(new
                {
                    parentId = d.Oid,
                    title = d.Oname,
                    children = getOrganizationDrenByOID(d.Oid)
                });
            });
            return list;
        }

        public object getOrganizationByList(out int total, int page, int limit, string name, string roleid)
        {
            List<object> list = new List<object>();
            total = 0;
            var iq = _organizationICO._baseOrganizationService.QueryAll(d => d.OcreateTime, true, out total, page, limit,d=>d.OparentOid==null).Include(s=>s.OrganizationRelations).ToList();
            iq.ForEach(d =>
            {
                list.Add(new
                {
                    id = d.Oid,
                    name = d.Oname,
                    explain = d.Oexplain,
                    grade = d.Olv,
                    number = d.Ono,
                    parentId = d.OparentOid,
                    principal = d.Oprincipal,
                    owner = d.OrganizationRelations.Select(s => s.Oruid).ToList(),
                    staff=d.OrganizationRelations.Count(),
                    selected=d.OrganizationRelations.Select(a=>a.Oruid).ToList(),
                    state = d.Ostate,
                    remark = d.Odesc,
                    children = getOrganizationByListBase(d.Oid)
                });
            });
            object data = new
            {
                count = total,
                datalist= list
            };
            return GetResult(Actions.query, 0, data: data);
        }

        private List<object> getOrganizationByListBase(string oid)
        {
            List<object> list = new List<object>();
            var iq = _organizationICO._baseOrganizationService.QueryAll(d => d.OparentOid.Contains(oid)).Include(s => s.OrganizationRelations).ToList();
            iq.ForEach(d =>
            {
                list.Add(new
                {
                    id = d.Oid,
                    name = d.Oname,
                    explain = d.Oexplain,
                    grade = d.Olv,
                    number = d.Ono,
                    parentId = d.OparentOid,
                    principal = d.Oprincipal,
                    owner = d.OrganizationRelations.Select(s => s.Oruid).ToList(),
                    staff = d.OrganizationRelations.Count(),
                    selected = d.OrganizationRelations.Select(a => a.Oruid).ToList(),
                    state = d.Ostate,
                    remark = d.Odesc,
                    children = getOrganizationByListBase(d.Oid)
                });
            });
            return list;
        }

        public object getOrganizationByAdd(dept data)
        {
            Organization list = new Organization() {
                Oid = Config.GUID(),
                Oname=data.name,
                Oexplain=data.explain,
                Olv=data.grade,
                OparentOid=data.parentId == "" ? null : data.parentId,
                Oprincipal=data.principal,
                OcreateTime=DateTime.Now,
                Ono=data.number,
                Ostate=1,
                OisDel=0,
                Odesc=data.desc
            };
            _organizationICO._baseOrganizationService.Add(list);
            _organizationICO._baseOrganizationService.SaveChanges();
            return GetResult( Actions.add,0);
        }

        public object getOrganizationRelationByAdd(string[] arrid, string oid)
        {
            List<OrganizationRelation> data = new List<OrganizationRelation>();
            foreach (var item in arrid)
            {
                data.Add(new OrganizationRelation
                { 
                    Orid= Config.GUID(),
                    Oroid=oid,
                    Oruid=item,
                    OrisPrincipal=0,
                    OrcreateTime=DateTime.Now,
                    Orstate=1,
                    Ordesc=null
                });
            }
            _organizationICO._baseOrganizationRelationService.AddRange(data);
            _organizationICO._baseOrganizationRelationService.SaveChanges();
            return GetResult( Actions.add,0);
        }
    }
}
