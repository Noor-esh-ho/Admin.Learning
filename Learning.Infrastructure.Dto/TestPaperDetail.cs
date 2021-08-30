using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class TestPaperDetail
    {
        public string Tpdid { get; set; }
        public string Tpdtpid { get; set; }
        public string Tpdqid { get; set; }
        public double? Tpdscore { get; set; }

        public virtual Question Tpdq { get; set; }
        public virtual TestPaper Tpdtp { get; set; }
    }
}
