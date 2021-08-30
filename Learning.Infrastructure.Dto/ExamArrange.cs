using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class ExamArrange
    {
        public ExamArrange()
        {
            UserExams = new HashSet<UserExam>();
        }

        public string Eaid { get; set; }
        public string Eaname { get; set; }
        public DateTime? EabeginTime { get; set; }
        public DateTime? EaendTime { get; set; }
        public string Eatpid { get; set; }
        public string Eaauthor { get; set; }
        public string Eacids { get; set; }
        public string Eauids { get; set; }
        public string EacheckUid { get; set; }
        public DateTime? EacreateTime { get; set; }
        public int? Eastate { get; set; }
        public int? EaisDel { get; set; }
        public string Eadesc { get; set; }

        public virtual User EaauthorNavigation { get; set; }
        public virtual User EacheckU { get; set; }
        public virtual TestPaper Eatp { get; set; }
        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
