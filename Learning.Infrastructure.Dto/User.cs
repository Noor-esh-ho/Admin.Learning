using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class User
    {
        public User()
        {
            Arranges = new HashSet<Arrange>();
            AttendanceDetails = new HashSet<AttendanceDetail>();
            AttendanceSituations = new HashSet<AttendanceSituation>();
            Attendances = new HashSet<Attendance>();
            AttributeTypes = new HashSet<AttributeType>();
            Attributes = new HashSet<Attribute>();
            ClassConfigDetails = new HashSet<ClassConfigDetail>();
            ClassConfigs = new HashSet<ClassConfig>();
            ClassProjects = new HashSet<ClassProject>();
            ClassRoles = new HashSet<ClassRole>();
            ClassTeamCtcaptainAdjutantUs = new HashSet<ClassTeam>();
            ClassTeamCtcaptainUs = new HashSet<ClassTeam>();
            ClassTeamDetails = new HashSet<ClassTeamDetail>();
            ClassTeamProjects = new HashSet<ClassTeamProject>();
            Courses = new HashSet<Course>();
            Coursewares = new HashSet<Courseware>();
            DutyArranges = new HashSet<DutyArrange>();
            DutyHistories = new HashSet<DutyHistory>();
            ExamArrangeEaauthorNavigations = new HashSet<ExamArrange>();
            ExamArrangeEacheckUs = new HashSet<ExamArrange>();
            OrganizationRelations = new HashSet<OrganizationRelation>();
            QuestionBanks = new HashSet<QuestionBank>();
            Questions = new HashSet<Question>();
            Resources = new HashSet<Resource>();
            RightsRelationRrauthorNavigations = new HashSet<RightsRelation>();
            RightsRelationRrus = new HashSet<RightsRelation>();
            TeachRelations = new HashSet<TeachRelation>();
            TestPapers = new HashSet<TestPaper>();
            TimeTables = new HashSet<TimeTable>();
            TrainPersonnel = new HashSet<TrainPersonnel>();
            Trains = new HashSet<Train>();
            UserExamUecheckUs = new HashSet<UserExam>();
            UserExamUeus = new HashSet<UserExam>();
            UserInfos = new HashSet<UserInfo>();
            WorkDetails = new HashSet<WorkDetail>();
        }

        public string Uid { get; set; }
        public string Uaccount { get; set; }
        public string Upassword { get; set; }
        public string Uname { get; set; }
        public string Ucid { get; set; }
        public string UroleAid { get; set; }
        public string UdesignationAid { get; set; }
        public string Ucode { get; set; }
        public string UlastIp { get; set; }
        public DateTime? UlastTime { get; set; }
        public DateTime? UcreateTime { get; set; }
        public int? Ulv { get; set; }
        public string Ulabels { get; set; }
        public int? Ustate { get; set; }
        public int? UisDel { get; set; }
        public string Usign { get; set; }
        public string UopenId { get; set; }
        public string Udesc { get; set; }

        public virtual Class Uc { get; set; }
        public virtual Attribute UdesignationA { get; set; }
        public virtual Attribute UroleA { get; set; }
        public virtual Sign UsignNavigation { get; set; }
        public virtual ICollection<Arrange> Arranges { get; set; }
        public virtual ICollection<AttendanceDetail> AttendanceDetails { get; set; }
        public virtual ICollection<AttendanceSituation> AttendanceSituations { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<AttributeType> AttributeTypes { get; set; }
        public virtual ICollection<Attribute> Attributes { get; set; }
        public virtual ICollection<ClassConfigDetail> ClassConfigDetails { get; set; }
        public virtual ICollection<ClassConfig> ClassConfigs { get; set; }
        public virtual ICollection<ClassProject> ClassProjects { get; set; }
        public virtual ICollection<ClassRole> ClassRoles { get; set; }
        public virtual ICollection<ClassTeam> ClassTeamCtcaptainAdjutantUs { get; set; }
        public virtual ICollection<ClassTeam> ClassTeamCtcaptainUs { get; set; }
        public virtual ICollection<ClassTeamDetail> ClassTeamDetails { get; set; }
        public virtual ICollection<ClassTeamProject> ClassTeamProjects { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Courseware> Coursewares { get; set; }
        public virtual ICollection<DutyArrange> DutyArranges { get; set; }
        public virtual ICollection<DutyHistory> DutyHistories { get; set; }
        public virtual ICollection<ExamArrange> ExamArrangeEaauthorNavigations { get; set; }
        public virtual ICollection<ExamArrange> ExamArrangeEacheckUs { get; set; }
        public virtual ICollection<OrganizationRelation> OrganizationRelations { get; set; }
        public virtual ICollection<QuestionBank> QuestionBanks { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<RightsRelation> RightsRelationRrauthorNavigations { get; set; }
        public virtual ICollection<RightsRelation> RightsRelationRrus { get; set; }
        public virtual ICollection<TeachRelation> TeachRelations { get; set; }
        public virtual ICollection<TestPaper> TestPapers { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
        public virtual ICollection<TrainPersonnel> TrainPersonnel { get; set; }
        public virtual ICollection<Train> Trains { get; set; }
        public virtual ICollection<UserExam> UserExamUecheckUs { get; set; }
        public virtual ICollection<UserExam> UserExamUeus { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
        public virtual ICollection<WorkDetail> WorkDetails { get; set; }
    }
}
