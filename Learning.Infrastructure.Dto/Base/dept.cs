using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Infrastructure.Dto.Base
{
    public class dept
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string name{ get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string explain { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int grade { get; set; }
        /// <summary>
        /// 上级部门
        /// </summary>
        public string parentId { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string principal { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string desc { get; set; }
    }
}
