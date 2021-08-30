using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Chapter
    {
        public Chapter()
        {
            ChapterRelations = new HashSet<ChapterRelation>();
        }

        public string Cid { get; set; }
        public string Ccid { get; set; }
        public string Cname { get; set; }
        public int? Cno { get; set; }
        public DateTime? CcreateTime { get; set; }
        public int? CclickCount { get; set; }
        public int? CstudyCount { get; set; }
        public int? CcommentCount { get; set; }
        public int? Cstate { get; set; }
        public int? CisDel { get; set; }
        public string Cdesc { get; set; }

        public virtual Course Cc { get; set; }
        public virtual ICollection<ChapterRelation> ChapterRelations { get; set; }
    }
}
