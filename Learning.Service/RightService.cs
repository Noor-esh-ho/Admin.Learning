using Learning.Infrastructure.Dto;
using Learning.Infrastructure.Dto.Base;
using Learning.Infrastructure.IOC;
using Learning.Infrastructure.Tool.Attributes;
using Learning.Service.Base;
using Learning.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Infrasturcture.Tool;
using Microsoft.EntityFrameworkCore;

namespace Learning.Service
{
    [Inject]
    public class RightService:BaseService,IRightService
    {
        private readonly RightIOC _rightIOC;
        private readonly IConfiguration _Configuration;

        public RightService(RightIOC rightIOC, IConfiguration Configuration)
        {
            _rightIOC = rightIOC;
            _Configuration = Configuration;
        }

        public object getList()
        {
            var iq = _rightIOC._baseRightService.QueryAll(o=>o.Rno, true, d=>d.RprentRid == null).ToList();
            List<object> dataList = new List<object>();
            iq.ForEach(d =>
            {
                dataList.Add(new
                {
                    name = d.Rname,
                    id = d.Rid,
                    children = getListIsByAll(d.Rid)
                }) ;
            });
            return GetResult(Actions.query, 0,data:dataList);
        }

        private List<object> getListIsByAll(string rid)
        {
            var iq = _rightIOC._baseRightService.QueryAll(d => d.Rno, true, d => d.RprentRid.Contains(rid)).ToList();
            List<object> dataList = new List<object>();
            iq.ForEach(d =>
            {
                dataList.Add(new
                {
                    name = d.Rname,
                    id = d.Rid,
                    children = getListIsByAll(d.Rid)
                });
            });
            return dataList;
        }

        public object getRightByAdd(menu data)
        {
            try
            {
                var rid = Config.GUID();
                Right right = new Right
                {
                    Rid = Config.GUID(),
                    Rname = data.name,
                    Rexplain = data.alias,
                    RprentRid = data.parentId == "" ? null : data.parentId,
                    Ricon = data.icon,
                    Rurl = data.path,
                    Rlv = data.grade,
                    RisMenu = 1,
                    RisNecessary = data.necessary,
                    Rstate = 1,
                    RisDel = 0,
                    RcreateTime = DateTime.Now,
                    Rno = data.number,
                    Rdesc = data.textarea
                };
                _rightIOC._baseRightService.Add(right);
                _rightIOC._baseRightService.SaveChanges();
                return GetResult(Actions.add, 0);
            }
            catch (Exception)
            {
                return GetResult( Actions.add, -1);
            }
        }

        public object getRightBytermAll(out int total,int page, int limit, string rname, string rid)
        {

            try
            {
                total = 0;
                var list = _rightIOC._baseRightService.QueryAll(o => o.Rno, true, out total, page, limit, d => d.RprentRid == null && (d.Rname.Contains(rname)) && (d.Rid.Contains(rid))).ToList();
                //定义一个集合将数据返回出去
                List<menu> dataList = new List<menu>();
                //Models.TreeData dataList = new Models.TreeData();
                list.ForEach(d =>
                {
                    menu treeData = new menu()
                    {
                        id = d.Rid,
                        name = d.Rname,
                        path = d.Rurl,
                        parentId = d.RprentRid,
                        necessary = (int)d.RisNecessary,
                        grade = (int)d.Rlv,
                        icon = d.Ricon,
                        alias = d.Rexplain,
                        number = (int)d.Rno,
                        children = GetRIghtsIsByAll(d.Rid)
                    };
                    dataList.Add(treeData);
                });
                object data = new
                {
                    dataList,
                    count = total
                };
                return GetResult(action: Actions.query, 0, data: data);
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        /// <summary>
        /// 通过用户iD获取所有的权限&&Allmuse
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public object getRightByUid(string uid)
        {
            var ue = _rightIOC._baseUserService.QueryAll(d => d.Uid.Contains(uid)).Select(d => d.UroleAid).FirstOrDefault();
            var config = _rightIOC._baseRightConfigService.QueryAll(d => d.Rcaid == ue && (d.Rcstate == 1 && d.RcisDel == 0)).Select(d=>d.Rcid).FirstOrDefault();
            var configDateild = _rightIOC._baseRightConfigDetails.QueryAll(d => d.Rcdrcid.Contains(config)).Select(d => d.Rcrid).ToList();
            List<TreeData> dataList = new List<TreeData>();
            var RRRID = _rightIOC._baseRightRelationService.QueryAll(d => d.Rruid == uid).Select(d => d.Rrrid).ToList();
            RRRID.AddRange(configDateild);
            HashSet<string> hs = new HashSet<string>(RRRID);
            //获取拥有的一级权限
            var list = _rightIOC._baseRightService.QueryAll(d => d.Rno, true, d => hs.Contains(d.Rid)& d.RprentRid == null).ToList();
            list.ForEach(d =>
            {
                configDateild.Contains(d.Rid);
                TreeData treeData = new TreeData()
                {
                    id = d.Rid,
                    name = d.Rname,
                    path = d.Rurl,
                    icon = d.Ricon,
                    children = GetRIghtsByUidOnAll(d.Rid, uid, configDateild)
                };
                dataList.Add(treeData);
            });
            return GetResult(Actions.query,0,data: dataList);
        }
        public List<TreeData> GetRIghtsByUidOnAll(string rid, string uid,List<string> configDateild) {
            var RRRID = _rightIOC._baseRightRelationService.QueryAll(d => d.Rruid == uid).Select(d => d.Rrrid).ToList();//用户子级数据
            var iq = _rightIOC._baseRightService.QueryAll(d => d.Rno, true, d => d.RprentRid.Contains(rid)&& (RRRID.Contains(d.Rid) || configDateild.Contains(d.Rid))).Include(d=>d.RightsRelations).ToList();
            List<TreeData> treeDatas = new List<TreeData>();
            iq.ForEach(d =>
            {
                treeDatas.Add(new TreeData
                {
                    id = d.Rid,
                    name = d.Rname,
                    path = d.Rurl,
                    icon = d.Ricon,
                    alias = d.Rexplain,
                    number = (int)d.Rno,
                    children = GetRIghtsByUidOnAll(d.Rid,uid, configDateild)
                });
            });
            return treeDatas;
        }
        public List<menu> GetRIghtsIsByAll(string rid)
        {
            var iq = _rightIOC._baseRightService.QueryAll(d => d.Rno, true, d => d.RprentRid.Contains(rid)).ToList();
            List<menu> treeDatas = new List<menu>();
            iq.ForEach(d =>
            {
                treeDatas.Add(new menu
                {
                    id = d.Rid,
                    name = d.Rname,
                    path = d.Rurl,
                    parentId = d.RprentRid,
                    necessary = (int)d.RisNecessary,
                    grade = (int)d.Rlv,
                    icon = d.Ricon,
                    alias = d.Rexplain,
                    number = (int)d.Rno,
                    children = GetRIghtsIsByAll(d.Rid)
                }) ;
            });
            return treeDatas;
         }

        public object getRightByUpdate(menu data)
        {
            try
            {
                var iq = _rightIOC._baseRightService.QueryAll(d => d.Rid == data.id).FirstOrDefault();
                iq.Rname = data.name;
                iq.Rurl = data.path;
                iq.RprentRid = data.parentId;
                iq.Ricon = data.icon;
                iq.Rexplain = data.alias;
                iq.Rlv = data.grade;
                iq.RisNecessary = data.necessary;
                iq.Rno = data.number;
                iq.Rdesc = data.textarea;
                _rightIOC._baseRightService.Update(iq);
                _rightIOC._baseRightService.SaveChanges();
                return GetResult(Actions.update, 0);
            }
            catch (Exception)
            {
                return GetResult( Actions.update,-1);
            }
        }

        public object getRightByDelete(string[] arrid)
        {
            var iq = _rightIOC._baseRightService.QueryAll(d => arrid.Contains(d.RprentRid));
            if (iq.Any()) {
                return GetResult(Actions.update, -1, message: "该数据存在子级无法删除！");
            }
            else {
                var guard = _rightIOC._baseRightRelationService.QueryAll(d => arrid.Contains(d.Rrrid));
                if (guard.Any())
                {
                    return GetResult(Actions.update, -1, message: "该数据被引用无法删除！");
                }
                else {
                    List<Right> rights = new List<Right>();
                    foreach (var item in arrid)
                    {
                        var da = _rightIOC._baseRightService.QueryAll(d=>d.Rid==item).FirstOrDefault();
                        rights.Add(da);
                    }
                    if (rights.Any()) {
                        _rightIOC._baseRightService.RemoveRange(rights);
                        _rightIOC._baseRightService.SaveChanges();
                        return GetResult(Actions.update, 0);
                    }
                    return GetResult(Actions.update, -1,message:"异常错误");
                }
            }
            
        }

        public object getRightConfigByList(out int total,int page, int limit, string name, string roleid)
        {
            total = 0;
            var dataList = _rightIOC._baseRightConfigService.QueryAll(d => d.RccreateTime, true, out total, page, limit,d=>d.Rcname.Contains(name)&&d.Rcaid.Contains(roleid)).Select(d => new
            {
                id = d.Rcid,
                name = d.Rcname,
                roles = d.Rca.Aname,
                roleid=d.Rcaid,
                arrid=d.RightConfigDetails.Select(d=>d.Rcrid).ToList(),
                count = d.RightConfigDetails.Where(s => s.Rcdrcid.Contains(d.Rcid)).Count(),
                state = d.Rcstate == 1 ? "正在启用" : "已失效",
                reatetime = d.RccreateTime,
            }).ToList();
            object data = new
            {
                dataList,
                count = total
            };
            return GetResult( Actions.query,0, data: data);
        }

        public object getRoleList()
        {
            var iq = _rightIOC._baseAttributesService.QueryAll(d=>d.Aatid==_Configuration["Attribute:role"]).Select(d=>new { 
                id=d.Aid,
                name=d.Aname
            }).ToList();
            return GetResult(Actions.query, iq.Any() ? 0 : -1, data: iq.Any() ? iq : null);
        }

        public object getRightConfigByAdd(string name, string role, string[] arrid)
        {
            try
            {
                var iq = _rightIOC._baseRightConfigService.QueryAll(d => d.RccreateTime, false, d => d.Rcaid.Contains(role) && d.Rcstate == 1);
                if (iq.Any())
                {
                    foreach (var item in iq.ToList())
                    {
                        item.Rcstate = 0;
                        _rightIOC._baseRightConfigService.Update(item);
                        _rightIOC._baseRightConfigService.SaveChanges();
                    }
                }
                var Rcid =Config.GUID();
                RightConfig rightConfig = new RightConfig()
                {
                    Rcid = Rcid,
                    Rcname = name,
                    Rcaid = role,
                    Rcstate = 1,
                    RcisDel = 0,
                    RccreateTime = DateTime.Now,
                    Rcdesc = null
                };
                _rightIOC._baseRightConfigService.Add(rightConfig);
                _rightIOC._baseRightConfigService.SaveChanges();
                List<RightConfigDetail> rightConfigDetails1 = new List<RightConfigDetail>();
                foreach (var item in arrid)
                {
                    RightConfigDetail rightConfigDetails = new RightConfigDetail()
                    {
                        Rcdid = Config.GUID(),
                        Rcdrcid = Rcid,
                        Rcrid = item
                    };
                    rightConfigDetails1.Add(rightConfigDetails);
                }
                _rightIOC._baseRightConfigDetails.AddRange(rightConfigDetails1);
                _rightIOC._baseRightConfigDetails.SaveChanges();
                return GetResult( Actions.add,0);
            }
            catch (Exception)
            {
                return GetResult(Actions.add, -1);
            }
        }

        public object getRightByTree(string id)
        {   
            var Rcrid = _rightIOC._baseRightConfigDetails.QueryAll(d => d.Rcdrcid.Contains(id)).Select(d => d.Rcrid).ToList();
            var list = _rightIOC._baseRightService.QueryAll(d => Rcrid.Contains(d.Rid) && d.RprentRid == null).OrderBy(d => d.Rno).ToList();
            List<object> sonlist = new List<object>();
            list.ForEach(d =>
            {
                object treeData = new 
                {
                    id = d.Rid,
                    name = d.Rname,
                    children = GetIsRightsByAllChildren(d.Rid, Rcrid)
                };
                sonlist.Add(treeData);
            });
            object data = new
            {
                all = this.getList(),
                sonlist
            };
            return GetResult( Actions.query,0,data: data);
        }
        private List<object> GetIsRightsByAllChildren(string rID, List<string> rRRID)
        {
            //验证权限是否是子级并包含用户所拥有的权限
            var list =_rightIOC._baseRightService.QueryAll(d => d.Rno, true, d => rID.Contains(d.RprentRid) && rRRID.Contains(d.Rid)).ToList();
            List<object> sonlist = new List<object>();
            list.ForEach(d =>
            {
                object treeData = new 
                {
                    id = d.Rid,
                    name = d.Rname,
                    children = GetIsRightsByAllChildren(d.Rid, rRRID)
                };
                sonlist.Add(treeData);
            });
            return sonlist;
        }
        private List<object> GetIsRightsByAllChildren(string rID)
        {
            //验证权限是否是子级并包含用户所拥有的权限
            var list = _rightIOC._baseRightService.QueryAll(d => d.Rno, true, d => rID.Contains(d.RprentRid)).ToList();
            List<object> sonlist = new List<object>();
            list.ForEach(d =>
            {
                object treeData = new
                {
                    id = d.Rid,
                    name = d.Rname,
                    children = GetIsRightsByAllChildren(d.Rid)
                };
                sonlist.Add(treeData);
            });
            return sonlist;
        }

        public object getRightByEnable(string id)
        {
            try
            {
                var iq = _rightIOC._baseRightConfigService.QueryAll(d => d.Rcid == id).FirstOrDefault();
                iq.Rcstate = 1;
                _rightIOC._baseRightConfigService.Update(iq);
                _rightIOC._baseRightConfigService.SaveChanges();
                var RCAID = iq.Rcaid;
                var listRCAID = _rightIOC._baseRightConfigService.QueryAll(d => d.Rcaid.Contains(RCAID) && d.Rcid != id).Select(d => d.Rcid).ToList();
                foreach (var item in listRCAID)
                {
                    var result = _rightIOC._baseRightConfigService.QueryAll(d => d.Rcid.Contains(item) && d.Rcid != id).FirstOrDefault();
                    result.Rcstate = 0;  
                    _rightIOC._baseRightConfigService.Update(result);
                    _rightIOC._baseRightConfigService.SaveChanges();
                }
                return GetResult( Actions.update,0);
            }
            catch (Exception)
            {
              return  GetResult(Actions.update, -1);
            }
        }

        public object getRightByauthId(string uid)
        {
            //根据用户ID获取所有的权限
            var RRRID = _rightIOC._baseRightRelationService.QueryAll(d => d.Rruid == uid).Select(d => d.Rrrid).ToList();
            //获取拥有的一级权限
            var list = _rightIOC._baseRightService.QueryAll(d => d.Rno, true, d => RRRID.Contains(d.Rid) && d.RprentRid == null).ToList();
            //定义一个集合将数据返回出去
            List<TreeData> dataList = new List<TreeData>();
            list.ForEach(d =>
            {
                TreeData treeData = new TreeData()
                {
                    id = d.Rid,
                    name = d.Rname,
                    path = d.Rurl,
                    icon = d.Ricon,
                    children = GetRIghtsByUidOnAll(d.Rid, uid,null)
                };
                dataList.Add(treeData);
            });
            return GetResult( Actions.query,0,data:dataList);
        }

        public object getRightByAfresh(string[] arrid, string aid, string uid)
        {
            try
            {
                var rid =_rightIOC._baseRightRelationService.QueryAll(d => d.Rruid.Contains(aid)).ToList();
                _rightIOC._baseRightRelationService.RemoveRange(rid);
                List<RightsRelation> RightsRelation = new List<RightsRelation>();
                foreach (var item in arrid)
                {
                    RightsRelation.Add(new RightsRelation
                    {
                        Rrid = Config.GUID(),
                        Rruid = aid,
                        Rrrid = item,
                        Rrauthor = uid,
                        RrbeginTime = null,
                        RrendTime = null,
                        Rrstate = 1,
                        RrisDel = 0,
                        RrcreateTime = DateTime.Now,
                        Rrdesc = null,
                    });
                }
                _rightIOC._baseRightRelationService.AddRange(RightsRelation);
                _rightIOC._baseRightRelationService.SaveChanges();
                return GetResult( Actions.add,0);
            }
            catch (Exception)
            {
                return GetResult(Actions.add,-1);
            }
        }
    }
}
