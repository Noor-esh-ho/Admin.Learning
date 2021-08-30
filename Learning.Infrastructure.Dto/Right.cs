using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Right
    {
        public Right()
        {
            InverseRprentR = new HashSet<Right>();
            RightConfigDetails = new HashSet<RightConfigDetail>();
            RightsRelations = new HashSet<RightsRelation>();
        }

        public string Rid { get; set; }
        public string Rname { get; set; }
        public string Rexplain { get; set; }
        public string RprentRid { get; set; }
        public string Ricon { get; set; }
        public string Rurl { get; set; }
        public int? Rlv { get; set; }
        public int? RisMenu { get; set; }
        public int? RisNecessary { get; set; }
        public int? Rstate { get; set; }
        public int? RisDel { get; set; }
        public DateTime? RcreateTime { get; set; }
        public int? Rno { get; set; }
        public string Rdesc { get; set; }

        public virtual Right RprentR { get; set; }
        public virtual ICollection<Right> InverseRprentR { get; set; }
        public virtual ICollection<RightConfigDetail> RightConfigDetails { get; set; }
        public virtual ICollection<RightsRelation> RightsRelations { get; set; }
    }
}
