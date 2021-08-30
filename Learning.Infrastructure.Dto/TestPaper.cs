using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class TestPaper
    {
        public TestPaper()
        {
            ExamArranges = new HashSet<ExamArrange>();
            TestPaperDetails = new HashSet<TestPaperDetail>();
        }

        public string Tpid { get; set; }
        public string Tpname { get; set; }
        public string Tpcids { get; set; }
        public double? TptotalScore { get; set; }
        public int? Tpqcount { get; set; }
        public double? TppassScore { get; set; }
        public int? Tplv { get; set; }
        public string TptypeAid { get; set; }
        public string Tplabels { get; set; }
        public int? Tpaction { get; set; }
        public string Tpauthor { get; set; }
        public int? TpisPublish { get; set; }
        public DateTime? TpcreateTime { get; set; }
        public int? Tpstate { get; set; }
        public int? TpisDel { get; set; }
        public string Tpdesc { get; set; }

        public virtual User TpauthorNavigation { get; set; }
        public virtual Attribute TptypeA { get; set; }
        public virtual ICollection<ExamArrange> ExamArranges { get; set; }
        public virtual ICollection<TestPaperDetail> TestPaperDetails { get; set; }
    }
}
