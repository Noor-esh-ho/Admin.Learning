using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class AttendanceDetail
    {
        public string Adid { get; set; }
        public string Adaid { get; set; }
        public string Aduid { get; set; }
        public string AdtypeAid { get; set; }
        public string Adasid { get; set; }
        public string Addesc { get; set; }

        public virtual Attendance Ada { get; set; }
        public virtual AttendanceSituation Adas { get; set; }
        public virtual Attribute AdtypeA { get; set; }
        public virtual User Adu { get; set; }
    }
}
