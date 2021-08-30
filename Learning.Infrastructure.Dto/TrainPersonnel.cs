using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class TrainPersonnel
    {
        public string Tpid { get; set; }
        public string Tptid { get; set; }
        public string Tpuid { get; set; }
        public int? Tpstate { get; set; }
        public DateTime? TpcreateTime { get; set; }
        public DateTime? TpupdateTime { get; set; }
        public int? Tpresult { get; set; }
        public double? Tpscore { get; set; }
        public string Tpcomment { get; set; }
        public string Tpdesc { get; set; }

        public virtual Train Tpt { get; set; }
        public virtual User Tpu { get; set; }
    }
}
