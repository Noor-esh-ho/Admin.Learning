using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class AttendanceConfig
    {
        public string Acid { get; set; }
        public string Accid { get; set; }
        public string Acname { get; set; }
        public string AcpositionName { get; set; }
        public double? Aclat { get; set; }
        public double? Aclng { get; set; }
        public int? Actype { get; set; }
        public DateTime? AcbeginDate { get; set; }
        public DateTime? AcendDate { get; set; }
        public TimeSpan? AcbeginTime { get; set; }
        public TimeSpan? AcendTime { get; set; }
        public string Acweeks { get; set; }
        public int? Acflexible { get; set; }
        public int? Acwucha { get; set; }
        public DateTime? AccreateTime { get; set; }
        public int? Acstate { get; set; }
        public int? AcisDel { get; set; }
        public string Acdesc { get; set; }

        public virtual Class Acc { get; set; }
    }
}
