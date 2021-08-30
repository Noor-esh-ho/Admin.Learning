using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class ClassConfig
    {
        public ClassConfig()
        {
            ClassConfigDetails = new HashSet<ClassConfigDetail>();
        }

        public string Ccid { get; set; }
        public string CctypeAid { get; set; }
        public string Cccid { get; set; }
        public DateTime? CccreateTime { get; set; }
        public string Ccauthor { get; set; }
        public int? Ccstate { get; set; }
        public int? CcisDel { get; set; }
        public int? CcisUse { get; set; }
        public string Ccexplain { get; set; }
        public string Ccdesc { get; set; }

        public virtual User CcauthorNavigation { get; set; }
        public virtual Attribute CctypeA { get; set; }
        public virtual ICollection<ClassConfigDetail> ClassConfigDetails { get; set; }
    }
}
