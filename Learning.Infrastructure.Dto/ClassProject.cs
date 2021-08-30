using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class ClassProject
    {
        public ClassProject()
        {
            ClassProjectDetails = new HashSet<ClassProjectDetail>();
            ClassTeamProjects = new HashSet<ClassTeamProject>();
        }

        public string Cpid { get; set; }
        public string Cpname { get; set; }
        public string Cpcids { get; set; }
        public string Cpexplain { get; set; }
        public string CptypeAid { get; set; }
        public string CpgradeAid { get; set; }
        public string CpsubjetAid { get; set; }
        public int? CpminCount { get; set; }
        public int? CpmaxCount { get; set; }
        public int? Cpdays { get; set; }
        public int? Cplv { get; set; }
        public int? CpisUse { get; set; }
        public string CpauthorUid { get; set; }
        public DateTime? CpcreateTime { get; set; }
        public int? Cpstate { get; set; }
        public int? CpisDel { get; set; }
        public int? CpisPublish { get; set; }
        public string Cpdesc { get; set; }

        public virtual User CpauthorU { get; set; }
        public virtual Attribute CpgradeA { get; set; }
        public virtual Attribute CpsubjetA { get; set; }
        public virtual Attribute CptypeA { get; set; }
        public virtual ICollection<ClassProjectDetail> ClassProjectDetails { get; set; }
        public virtual ICollection<ClassTeamProject> ClassTeamProjects { get; set; }
    }
}
