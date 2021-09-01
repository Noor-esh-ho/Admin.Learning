using Learning.Infrastructure.Dto.Base;
using Learning.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Api_Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Organization")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _baseOrganizationService;

        public OrganizationController(IOrganizationService baseOrganizationService) {
            _baseOrganizationService = baseOrganizationService;
        }
        [HttpPost]
        public IActionResult getOrganizationByList(dynamic data)
        {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            int page = (int)json.page.Value;
            int limit = (int)json.limit.Value;
            string name = json.name.Value;
            string roleid = json.roleid.Value;
            var result = _baseOrganizationService.getOrganizationByList(out int total, page, limit, name, roleid);
            return Ok(result);
        }
        /// <summary>
        /// 批量删除组织人员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getOrganizationDeletebase(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            string oid = json.oid.Value;
            string[] arruid = JsonConvert.DeserializeObject<string[]>(Convert.ToString(json.arruid));
            var result = _baseOrganizationService.getOrganizationDeletebase(arruid, oid);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult getOrganizationByAll() {
            var result = _baseOrganizationService.getOrganizationByAll();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getOrganizationByAdd(dept data) {
            var result = _baseOrganizationService.getOrganizationByAdd(data);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getOrganizationRelationByAdd(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            var oid = json.oid.Value;
            string[] arrid = JsonConvert.DeserializeObject<string[]>(Convert.ToString(json.arrid));
            var result = _baseOrganizationService.getOrganizationRelationByAdd(arrid, oid);
            return Ok(result);
        }
        /// <summary>
        /// 获取组织人员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getOrganizationTreeUser(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            int page = (int)json.page.Value;
            int limit = (int)json.limit.Value;
            string name = json.name.Value;
            string account = json.account.Value;
            string oid = json.oid.Value;
            string jobid = json.jobid.Value;
            var result = _baseOrganizationService.getOrganizationTreeUser(out int total, page, limit, name, account,oid,jobid);
            return Ok(result);
        }
    }
}
