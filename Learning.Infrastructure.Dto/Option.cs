using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Option
    {
        public string Oid { get; set; }
        public string Oqid { get; set; }
        public string Ocontent { get; set; }
        public int? OisRight { get; set; }
        public int? Ostate { get; set; }
        public int? OisDel { get; set; }
        public string Odesc { get; set; }

        public virtual Question Oq { get; set; }
    }
}
