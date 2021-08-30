using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Infrastructure.Dto.Base
{
    public class TreeData
    {
        public string id{ get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 路由地址
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 上级菜单
        /// </summary>
        public string parentId { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 菜单别名
        /// </summary>
        public string alias { get; set; }
        /// <summary>
        /// 固定权限
        /// </summary>
        public int necessary { get; set; }
        /// <summary>
        /// 权限等级
        /// </summary>
        public int grade { get; set; }
        /// <summary>
        /// 菜单排序
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// 菜单备注
        /// </summary>
        public string textarea { get; set; }
        public List<TreeData> children { get; set; }

    }
}
