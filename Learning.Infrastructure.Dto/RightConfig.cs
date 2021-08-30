using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class RightConfig
    {
        public RightConfig()
        {
            RightConfigDetails = new HashSet<RightConfigDetail>();
        }

        public string Rcid { get; set; }
        public string Rcname { get; set; }
        public string Rcaid { get; set; }
        public int? Rcstate { get; set; }
        public int? RcisDel { get; set; }
        public DateTime? RccreateTime { get; set; }
        public string Rcdesc { get; set; }

        public virtual Attribute Rca { get; set; }
        public virtual ICollection<RightConfigDetail> RightConfigDetails { get; set; }
    }
}
