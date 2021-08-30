using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Api_Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Exam")]
    public class ExamController : ControllerBase
    {
        /// <summary>
        /// 考试模块
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetArranges()
        {
            return Ok();
        }
    }
}
