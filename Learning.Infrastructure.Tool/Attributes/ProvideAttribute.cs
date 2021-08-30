using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Infrastructure.Tool.Attributes
{
    /// <summary>
    /// 是否允许被注入
    /// </summary>
    [AttributeUsage(AttributeTargets.All,AllowMultiple =true)]
   public class ProvideAttribute:Attribute
    {
    }
}
