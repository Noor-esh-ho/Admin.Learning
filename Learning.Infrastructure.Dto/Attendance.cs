using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Attendance
    {
        public Attendance()
        {
            AttendanceDetails = new HashSet<AttendanceDetail>();
            AttendanceSituations = new HashSet<AttendanceSituation>();
        }

        public string Aid { get; set; }
        public string Acid { get; set; }
        public DateTime? Adate { get; set; }
        public string AtimeSlotAid { get; set; }
        public DateTime? AcreateTime { get; set; }
        public DateTime? AlastTime { get; set; }
        public double? Apercent { get; set; }
        public string Aauthor { get; set; }
        public string AtypeAid { get; set; }
        public int? Astate { get; set; }
        public int? AisDel { get; set; }
        public string Adesc { get; set; }

        public virtual User AauthorNavigation { get; set; }
        public virtual Class Ac { get; set; }
        public virtual Attribute AtimeSlotA { get; set; }
        public virtual Attribute AtypeA { get; set; }
        public virtual ICollection<AttendanceDetail> AttendanceDetails { get; set; }
        public virtual ICollection<AttendanceSituation> AttendanceSituations { get; set; }
    }
}
