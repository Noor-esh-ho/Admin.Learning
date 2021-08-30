using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Question
    {
        public Question()
        {
            Options = new HashSet<Option>();
            QuestionBankRelations = new HashSet<QuestionBankRelation>();
            TestPaperDetails = new HashSet<TestPaperDetail>();
            UserExamDetails = new HashSet<UserExamDetail>();
        }

        public string Qid { get; set; }
        public string Qcontent { get; set; }
        public string QtypeAid { get; set; }
        public int? QisSubjective { get; set; }
        public string Qlabels { get; set; }
        public int? Qlv { get; set; }
        public string Qauthor { get; set; }
        public int? QisPublish { get; set; }
        public DateTime? QcreateTime { get; set; }
        public DateTime? QupdateTime { get; set; }
        public int? Qstate { get; set; }
        public int? QisDel { get; set; }
        public string Qdesc { get; set; }

        public virtual User QauthorNavigation { get; set; }
        public virtual Attribute QtypeA { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        public virtual ICollection<QuestionBankRelation> QuestionBankRelations { get; set; }
        public virtual ICollection<TestPaperDetail> TestPaperDetails { get; set; }
        public virtual ICollection<UserExamDetail> UserExamDetails { get; set; }
    }
}
