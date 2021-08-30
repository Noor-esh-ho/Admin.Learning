using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class AttendanceSituation
    {
        public AttendanceSituation()
        {
            AttendanceDetails = new HashSet<AttendanceDetail>();
        }

        public string Asid { get; set; }
        public string Asaid { get; set; }
        public string Asuid { get; set; }
        public string AstypeAid { get; set; }
        public DateTime? AsbeginTime { get; set; }
        public DateTime? AsendTime { get; set; }
        public int? Asstate { get; set; }
        public string Asdesc { get; set; }

        public virtual Attendance Asa { get; set; }
        public virtual Attribute AstypeA { get; set; }
        public virtual User Asu { get; set; }
        public virtual ICollection<AttendanceDetail> AttendanceDetails { get; set; }
    }
}
