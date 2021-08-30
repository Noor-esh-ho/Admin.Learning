using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class ClassTeam
    {
        public ClassTeam()
        {
            ClassTeamDetails = new HashSet<ClassTeamDetail>();
            ClassTeamProjects = new HashSet<ClassTeamProject>();
        }

        public string Ctid { get; set; }
        public string Ctcid { get; set; }
        public string Ctname { get; set; }
        public string CtcaptainUid { get; set; }
        public string CtcaptainAdjutantUid { get; set; }
        public string Ctexplain { get; set; }
        public string CttypeAid { get; set; }
        public int? Ctcount { get; set; }
        public int? Ctno { get; set; }
        public int? Ctstate { get; set; }
        public int? CtisStart { get; set; }
        public string Ctcode { get; set; }
        public int? CtisDel { get; set; }
        public DateTime? CtcreateTime { get; set; }
        public DateTime? CtlastTime { get; set; }
        public string Ctdesc { get; set; }

        public virtual Class Ctc { get; set; }
        public virtual User CtcaptainAdjutantU { get; set; }
        public virtual User CtcaptainU { get; set; }
        public virtual Attribute CttypeA { get; set; }
        public virtual ICollection<ClassTeamDetail> ClassTeamDetails { get; set; }
        public virtual ICollection<ClassTeamProject> ClassTeamProjects { get; set; }
    }
}
