using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Attribute
    {
        public Attribute()
        {
            Arranges = new HashSet<Arrange>();
            AttendanceAtimeSlotAs = new HashSet<Attendance>();
            AttendanceAtypeAs = new HashSet<Attendance>();
            AttendanceDetails = new HashSet<AttendanceDetail>();
            AttendanceSituations = new HashSet<AttendanceSituation>();
            ClassConfigs = new HashSet<ClassConfig>();
            ClassProjectCpgradeAs = new HashSet<ClassProject>();
            ClassProjectCpsubjetAs = new HashSet<ClassProject>();
            ClassProjectCptypeAs = new HashSet<ClassProject>();
            ClassRights = new HashSet<ClassRight>();
            ClassTeams = new HashSet<ClassTeam>();
            Classes = new HashSet<Class>();
            Courses = new HashSet<Course>();
            QuestionBanks = new HashSet<QuestionBank>();
            Questions = new HashSet<Question>();
            Resources = new HashSet<Resource>();
            RightConfigs = new HashSet<RightConfig>();
            Signs = new HashSet<Sign>();
            TeachRelations = new HashSet<TeachRelation>();
            TestPapers = new HashSet<TestPaper>();
            Trains = new HashSet<Train>();
            UserUdesignationAs = new HashSet<User>();
            UserUroleAs = new HashSet<User>();
            Works = new HashSet<Work>();
        }

        public string Aid { get; set; }
        public string Aname { get; set; }
        public string Avalue { get; set; }
        public string Avalue2 { get; set; }
        public string Aatid { get; set; }
        public int? Astate { get; set; }
        public int? Ano { get; set; }
        public int? AisDel { get; set; }
        public DateTime? AcreateTime { get; set; }
        public string Auid { get; set; }
        public string Adesc { get; set; }

        public virtual AttributeType Aat { get; set; }
        public virtual User Au { get; set; }
        public virtual ICollection<Arrange> Arranges { get; set; }
        public virtual ICollection<Attendance> AttendanceAtimeSlotAs { get; set; }
        public virtual ICollection<Attendance> AttendanceAtypeAs { get; set; }
        public virtual ICollection<AttendanceDetail> AttendanceDetails { get; set; }
        public virtual ICollection<AttendanceSituation> AttendanceSituations { get; set; }
        public virtual ICollection<ClassConfig> ClassConfigs { get; set; }
        public virtual ICollection<ClassProject> ClassProjectCpgradeAs { get; set; }
        public virtual ICollection<ClassProject> ClassProjectCpsubjetAs { get; set; }
        public virtual ICollection<ClassProject> ClassProjectCptypeAs { get; set; }
        public virtual ICollection<ClassRight> ClassRights { get; set; }
        public virtual ICollection<ClassTeam> ClassTeams { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<QuestionBank> QuestionBanks { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<RightConfig> RightConfigs { get; set; }
        public virtual ICollection<Sign> Signs { get; set; }
        public virtual ICollection<TeachRelation> TeachRelations { get; set; }
        public virtual ICollection<TestPaper> TestPapers { get; set; }
        public virtual ICollection<Train> Trains { get; set; }
        public virtual ICollection<User> UserUdesignationAs { get; set; }
        public virtual ICollection<User> UserUroleAs { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
