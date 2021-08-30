using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Courseware
    {
        public Courseware()
        {
            ChapterRelations = new HashSet<ChapterRelation>();
        }

        public string Cwid { get; set; }
        public string Cwname { get; set; }
        public long? Cwsize { get; set; }
        public string Cwlabels { get; set; }
        public string Cwtype { get; set; }
        public string Cwauthor { get; set; }
        public int? Cwstate { get; set; }
        public string CwpathRid { get; set; }
        public int? CwisPublish { get; set; }
        public int? CwisDel { get; set; }
        public DateTime? CwcreateTime { get; set; }
        public string Cwdesc { get; set; }

        public virtual User CwauthorNavigation { get; set; }
        public virtual Resource CwpathR { get; set; }
        public virtual ICollection<ChapterRelation> ChapterRelations { get; set; }
    }
}
