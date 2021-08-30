using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class QuestionBank
    {
        public QuestionBank()
        {
            QuestionBankRelations = new HashSet<QuestionBankRelation>();
        }

        public string Qbid { get; set; }
        public string Qbname { get; set; }
        public string Qbexplain { get; set; }
        public string QbtypeAid { get; set; }
        public string Qbauthor { get; set; }
        public int? QbisReadonly { get; set; }
        public int? QbisPublish { get; set; }
        public DateTime? QbcreateTime { get; set; }
        public int? Qbstate { get; set; }
        public DateTime? QbupdateTime { get; set; }
        public string Qbdesc { get; set; }

        public virtual User QbauthorNavigation { get; set; }
        public virtual Attribute QbtypeA { get; set; }
        public virtual ICollection<QuestionBankRelation> QuestionBankRelations { get; set; }
    }
}
