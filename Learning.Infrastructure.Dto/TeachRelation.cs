using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class TeachRelation
    {
        public string Trid { get; set; }
        public string TrteacherUid { get; set; }
        public string TrclassCid { get; set; }
        public string TrtypeAid { get; set; }
        public int? Trstate { get; set; }
        public DateTime? TrcreateTime { get; set; }
        public DateTime? TrendTime { get; set; }
        public int? TrisDel { get; set; }
        public string Trexplain { get; set; }
        public string Trdesc { get; set; }

        public virtual Class TrclassC { get; set; }
        public virtual User TrteacherU { get; set; }
        public virtual Attribute TrtypeA { get; set; }
    }
}
