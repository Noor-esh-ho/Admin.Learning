using Learning.Api_Admin.Models;
using Learning.Infrastructure.Dto.Base;
using Learning.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;

namespace Learning.Api_Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Right")]
    public class RightController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IRightService _rightService;

        public RightController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IRightService rightService)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _rightService = rightService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult getRightByUid(string uid) {
            var reuslt = _rightService.getRightByUid(uid);
            return Ok(reuslt);
        }
        [HttpPost]
        public IActionResult getRightBytermAll(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            int page = (int)json.page.Value;
            int limit = (int)json.limit.Value;
            string rname = json.rname.Value;
            string rid = json.rid.Value;
            var result = _rightService.getRightBytermAll(out int total,page, limit, rname, rid);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getRightByAdd(menu data) {
            var reuslt = _rightService.getRightByAdd(data);
            return Ok(reuslt);
        }
        [HttpGet]
        public IActionResult getList() {
            var result = _rightService.getList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getRightByUpdate(menu data) {
            var result = _rightService.getRightByUpdate(data);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getRightByDelete(dynamic data) {
            string[] arrid = JsonConvert.DeserializeObject<string[]>(Convert.ToString(data));
            var result = _rightService.getRightByDelete(arrid);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getRightConfigByList(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            int page = (int)json.page.Value;
            int limit = (int)json.limit.Value;
            string name = json.name.Value;
            string roleid = json.roleid.Value;
            var result = _rightService.getRightConfigByList(out int total,page, limit,name, roleid);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult getRoleList() {
            var result = _rightService.getRoleList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getRightConfigByAdd(Rightconfig data) {
            var result = _rightService.getRightConfigByAdd(name:data.name,role:data.roleid, arrid:data.sort);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getRightByTree(string id) {
            var result = _rightService.getRightByTree(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getRightByEnable(string id) {
            var result = _rightService.getRightByEnable(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getRightByauthId(string id) {
            var result = _rightService.getRightByauthId(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getRightByAfresh(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            string uid = json.uid.Value;
            string aid = json.aid.Value;
            string[] arrid = JsonConvert.DeserializeObject<string[]>(Convert.ToString(json.arrid));
            var result = _rightService.getRightByAfresh(arrid, aid, uid);
            return Ok(result);
        }
    }
}
