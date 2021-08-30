using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class DutyArrange
    {
        public string Daid { get; set; }
        public string Dadhid { get; set; }
        public string Dauids { get; set; }
        public string Dacid { get; set; }
        public string Danames { get; set; }
        public DateTime? Dadate { get; set; }
        public DateTime? DacompletDate { get; set; }
        public string DacompletAuthor { get; set; }
        public DateTime? DalastTime { get; set; }
        public int? Dastate { get; set; }
        public int? DaisDel { get; set; }
        public string Dadesc { get; set; }

        public virtual Class Dac { get; set; }
        public virtual User DacompletAuthorNavigation { get; set; }
        public virtual DutyHistory Dadh { get; set; }
    }
}
