using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Course
    {
        public Course()
        {
            Chapters = new HashSet<Chapter>();
        }

        public string Cid { get; set; }
        public string Cname { get; set; }
        public string CtypeAid { get; set; }
        public string Cauthor { get; set; }
        public int? Clv { get; set; }
        public int? CisOpen { get; set; }
        public string Cprofile { get; set; }
        public string Ccover { get; set; }
        public DateTime? CcreateTime { get; set; }
        public int? CstudyCount { get; set; }
        public int? CclickCount { get; set; }
        public int? CcommentCount { get; set; }
        public DateTime? ClastTime { get; set; }
        public int? CisPublish { get; set; }
        public int? Cstate { get; set; }
        public string Cdesc { get; set; }

        public virtual User CauthorNavigation { get; set; }
        public virtual Resource CcoverNavigation { get; set; }
        public virtual Attribute CtypeA { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}
