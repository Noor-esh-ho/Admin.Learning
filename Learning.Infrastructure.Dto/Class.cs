using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Class
    {
        public Class()
        {
            AttendanceConfigs = new HashSet<AttendanceConfig>();
            Attendances = new HashSet<Attendance>();
            ClassRoles = new HashSet<ClassRole>();
            ClassTeams = new HashSet<ClassTeam>();
            DutyArranges = new HashSet<DutyArrange>();
            DutyHistories = new HashSet<DutyHistory>();
            TeachRelations = new HashSet<TeachRelation>();
            TimeTables = new HashSet<TimeTable>();
            Users = new HashSet<User>();
            Works = new HashSet<Work>();
        }

        public string Cid { get; set; }
        public string Cname { get; set; }
        public int? Ccount { get; set; }
        public string CgradeAid { get; set; }
        public string Crid { get; set; }
        public DateTime? CcreateTime { get; set; }
        public int? Cstate { get; set; }
        public int? CisDel { get; set; }
        public string Cdesc { get; set; }

        public virtual Attribute CgradeA { get; set; }
        public virtual Resource Cr { get; set; }
        public virtual ICollection<AttendanceConfig> AttendanceConfigs { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<ClassRole> ClassRoles { get; set; }
        public virtual ICollection<ClassTeam> ClassTeams { get; set; }
        public virtual ICollection<DutyArrange> DutyArranges { get; set; }
        public virtual ICollection<DutyHistory> DutyHistories { get; set; }
        public virtual ICollection<TeachRelation> TeachRelations { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
