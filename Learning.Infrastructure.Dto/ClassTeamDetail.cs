using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class ClassTeamDetail
    {
        public string Ctdid { get; set; }
        public string Ctdctid { get; set; }
        public string Ctduid { get; set; }
        public string Ctcid { get; set; }
        public int? Ctdgroup { get; set; }
        public int? CtdisLeader { get; set; }
        public int? Ctdno { get; set; }
        public int? Ctdstate { get; set; }
        public string Ctdesc { get; set; }

        public virtual ClassTeam Ctdct { get; set; }
        public virtual User Ctdu { get; set; }
    }
}
