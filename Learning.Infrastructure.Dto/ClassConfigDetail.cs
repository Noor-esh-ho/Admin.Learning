using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class ClassConfigDetail
    {
        public ClassConfigDetail()
        {
            ClassRights = new HashSet<ClassRight>();
            ClassRoles = new HashSet<ClassRole>();
        }

        public string Ccdid { get; set; }
        public string Ccdccid { get; set; }
        public string Ccdname { get; set; }
        public string Ccdvalue1 { get; set; }
        public string Ccdvalue2 { get; set; }
        public string Ccdvalue3 { get; set; }
        public string Ccdvalue4 { get; set; }
        public DateTime? CcdbeginTime { get; set; }
        public DateTime? CcdendTime { get; set; }
        public int? CcdisUse { get; set; }
        public string Ccdauthor { get; set; }
        public int? Ccdno { get; set; }
        public int? Ccdstate { get; set; }
        public DateTime? CcdcreateTime { get; set; }
        public int? CcdisDel { get; set; }
        public string Ccdexplain { get; set; }
        public string Ccddesc { get; set; }

        public virtual User CcdauthorNavigation { get; set; }
        public virtual ClassConfig Ccdcc { get; set; }
        public virtual ICollection<ClassRight> ClassRights { get; set; }
        public virtual ICollection<ClassRole> ClassRoles { get; set; }
    }
}
