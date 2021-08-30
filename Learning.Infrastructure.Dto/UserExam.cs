using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class UserExam
    {
        public UserExam()
        {
            UserExamDetails = new HashSet<UserExamDetail>();
        }

        public string Ueid { get; set; }
        public string Ueuid { get; set; }
        public string Ueeaid { get; set; }
        public string Uecode { get; set; }
        public DateTime? UestartTime { get; set; }
        public DateTime? UefinishTime { get; set; }
        public string UecheckUid { get; set; }
        public double? Uescore { get; set; }
        public DateTime? UecreateTime { get; set; }
        public int? Uestate { get; set; }
        public int? UeisDel { get; set; }
        public string Uedesc { get; set; }

        public virtual User UecheckU { get; set; }
        public virtual ExamArrange Ueea { get; set; }
        public virtual User Ueu { get; set; }
        public virtual ICollection<UserExamDetail> UserExamDetails { get; set; }
    }
}
