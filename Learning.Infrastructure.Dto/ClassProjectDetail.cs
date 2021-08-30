using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class ClassProjectDetail
    {
        public string Cpdid { get; set; }
        public string Cpdcpid { get; set; }
        public int? Cpno { get; set; }
        public string Cpcontent { get; set; }
        public int? Cpdays { get; set; }
        public DateTime? CpcreateTime { get; set; }

        public virtual ClassProject Cpdcp { get; set; }
    }
}
