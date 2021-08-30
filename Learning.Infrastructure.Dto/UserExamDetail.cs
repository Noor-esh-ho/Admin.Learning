using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class UserExamDetail
    {
        public string Uedid { get; set; }
        public string Uedeid { get; set; }
        public string Uedqid { get; set; }
        public string Uedanswers { get; set; }
        public int? UedisRight { get; set; }
        public double? Uescore { get; set; }
        public string Ueddesc { get; set; }

        public virtual UserExam Uede { get; set; }
        public virtual Question Uedq { get; set; }
    }
}
