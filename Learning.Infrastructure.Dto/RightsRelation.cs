using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class RightsRelation
    {
        public string Rrid { get; set; }
        public string Rruid { get; set; }
        public string Rrrid { get; set; }
        public string Rrauthor { get; set; }
        public DateTime? RrbeginTime { get; set; }
        public DateTime? RrendTime { get; set; }
        public int? Rrstate { get; set; }
        public int? RrisDel { get; set; }
        public DateTime? RrcreateTime { get; set; }
        public string Rrdesc { get; set; }

        public virtual User RrauthorNavigation { get; set; }
        public virtual Right Rrr { get; set; }
        public virtual User Rru { get; set; }
    }
}
