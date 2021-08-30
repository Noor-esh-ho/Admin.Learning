using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class ClassTeamProject
    {
        public string Ctpid { get; set; }
        public string Ctpctid { get; set; }
        public string Ctpcpid { get; set; }
        public int? CtpisStart { get; set; }
        public string CtpauthorUid { get; set; }
        public DateTime? CtpcreateTime { get; set; }
        public DateTime? CtpbeginTime { get; set; }
        public DateTime? CtpendTime { get; set; }
        public int? Ctpstate { get; set; }
        public int? CtpisDel { get; set; }
        public string Ctpexplain { get; set; }
        public string Ctpdesc { get; set; }

        public virtual User CtpauthorU { get; set; }
        public virtual ClassProject Ctpcp { get; set; }
        public virtual ClassTeam Ctpct { get; set; }
    }
}
