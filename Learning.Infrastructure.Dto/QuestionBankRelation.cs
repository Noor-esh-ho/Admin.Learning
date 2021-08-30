using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class QuestionBankRelation
    {
        public string Qbrid { get; set; }
        public string Qbrqbid { get; set; }
        public string Qbrqid { get; set; }
        public DateTime? QbrcreateTime { get; set; }
        public string Qbrauthor { get; set; }
        public int? Qbstate { get; set; }
        public string Qbdesc { get; set; }

        public virtual Question Qbrq { get; set; }
        public virtual QuestionBank Qbrqb { get; set; }
    }
}
