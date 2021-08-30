using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Work
    {
        public Work()
        {
            WorkDetails = new HashSet<WorkDetail>();
        }

        public string Wid { get; set; }
        public string Wname { get; set; }
        public string Wcid { get; set; }
        public string WsubjectAid { get; set; }
        public DateTime? Wdate { get; set; }
        public string Wtype { get; set; }
        public string Wcontent { get; set; }
        public DateTime? WcreateTime { get; set; }
        public DateTime? WlastTime { get; set; }
        public int? WisDel { get; set; }
        public int? Wstate { get; set; }
        public string Wdesc { get; set; }

        public virtual Class Wc { get; set; }
        public virtual Attribute WsubjectA { get; set; }
        public virtual ICollection<WorkDetail> WorkDetails { get; set; }
    }
}
