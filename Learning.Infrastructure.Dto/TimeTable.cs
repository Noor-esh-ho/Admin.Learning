using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class TimeTable
    {
        public string Ttid { get; set; }
        public DateTime? Ttdate { get; set; }
        public string Ttcid { get; set; }
        public string Ttauthor { get; set; }
        public string Ttam { get; set; }
        public string Ttpm { get; set; }
        public string Ttnight { get; set; }
        public DateTime? TtcreateTime { get; set; }
        public int? Ttstate { get; set; }
        public int? TtisDel { get; set; }
        public string Ttdesc { get; set; }

        public virtual User TtauthorNavigation { get; set; }
        public virtual Class Ttc { get; set; }
    }
}
