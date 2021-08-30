using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class WorkDetail
    {
        public string Wdid { get; set; }
        public string Wdwid { get; set; }
        public string Wduid { get; set; }
        public DateTime? WdcreateTime { get; set; }
        public int? Wdstate { get; set; }
        public int? WdisDel { get; set; }

        public virtual User Wdu { get; set; }
        public virtual Work Wdw { get; set; }
    }
}
