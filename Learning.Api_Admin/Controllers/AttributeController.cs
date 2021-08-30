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
    [ApiExplorerSettings(GroupName = "Attribute")]
    public class AttributeController : ControllerBase
    {
        private IAttributesService _attributesService;

        public AttributeController(IAttributesService attributesService) {
            _attributesService = attributesService;
        }
        [HttpGet]
        public IActionResult getAttributeOnClass() {
            var reuslt = _attributesService.getAttributeOnClass();
            return Ok(reuslt);
        }
        [HttpGet]
        public IActionResult getAttributeOnRole()
        {
            var reuslt = _attributesService.getAttributeOnRole();
            return Ok(reuslt);
        }
        [HttpGet]
        public IActionResult getAttributeOnPost()
        {
            var reuslt = _attributesService.getAttributeOnPost();
            return Ok(reuslt);
        }
        [HttpPost]
        public IActionResult getAttributeTypeByList(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            int page = (int)json.page.Value;
            int limit = (int)json.limit.Value;
            string name = json.name.Value;
            string roleid = json.roleid.Value;
            var result = _attributesService.getAttributeTypeByList(out int total, page, limit, name, roleid);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getAttributeByAid(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            int page = (int)json.page.Value;
            int limit = (int)json.limit.Value;
            string aid = json.aid.Value;
            string name = json.name.Value;
            var result = _attributesService.getAttributeByAid(out int total, page, limit,aid, name);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getAttributeTypeByAdd(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            string name = json.name.Value;
            string value = json.value.Value;
            string desc = json.desc.Value;
            int necessary = (int)json.necessary.Value;
            int sort = (int)json.sort.Value;
            var result = _attributesService.getAttributeTypeByAdd(name,value,desc,necessary,sort);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getAttributeTypeByEdit(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            string id = json.id.Value;
            string name = json.name.Value;
            string value = json.value.Value;
            string desc = json.desc.Value;
            int necessary = (int)json.necessary.Value;
            int sort = (int)json.sort.Value;
            var result = _attributesService.getAttributeTypeByEdit(id,name, value, desc, necessary, sort);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getAttributeByAdd(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            string name = json.name.Value;
            string value1 = json.value1.Value;
            string value2 = json.value2.Value;
            string atid = json.atid.Value;
            int sort = (int)json.sort.Value;
            string desc = json.desc.Value;
            string uid = json.uid.Value;
            var result = _attributesService.getAttributeByAdd(name,value1,value2,atid,sort,desc,uid);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult getAttributeByOperate(dynamic data) {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            string id = json.id.Value;
            int state= (int)json.state.Value;
            var result = _attributesService.getAttributeByOperate(id, state);
            return Ok(result);
        }
        /// <summary>
        /// 属性编辑
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getAttributeByUpdate(dynamic data)
        {
            var json = JsonConvert.DeserializeObject(Convert.ToString(data));
            string id = json.id.Value;
            string name = json.name.Value;
            string value1 = json.value1.Value;
            string value2 = json.value2.Value;
            int sort = (int)json.sort.Value;
            string desc = json.desc.Value;
            var result = _attributesService.getAttributeByUpdate(id, name, value1,value2,sort,desc);
            return Ok(result);
        }
    }
}
