using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class DutyHistory
    {
        public DutyHistory()
        {
            DutyArranges = new HashSet<DutyArrange>();
        }

        public string Dhid { get; set; }
        public int? Dhinning { get; set; }
        public string Dhcid { get; set; }
        public string Dhauthor { get; set; }
        public DateTime? DhbeginDate { get; set; }
        public DateTime? DhendDate { get; set; }
        public int? Dhcount { get; set; }
        public string Dhnames { get; set; }
        public DateTime? DhcreateTime { get; set; }
        public int? Dhstate { get; set; }
        public int? DhisDel { get; set; }
        public string Dhdesc { get; set; }

        public virtual User DhauthorNavigation { get; set; }
        public virtual Class Dhc { get; set; }
        public virtual ICollection<DutyArrange> DutyArranges { get; set; }
    }
}
