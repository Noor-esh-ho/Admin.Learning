using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class RightConfigDetail
    {
        public string Rcdid { get; set; }
        public string Rcdrcid { get; set; }
        public string Rcrid { get; set; }

        public virtual RightConfig Rcdrc { get; set; }
        public virtual Right Rcr { get; set; }
    }
}
