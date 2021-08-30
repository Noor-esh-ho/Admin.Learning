using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class AttributeType
    {
        public AttributeType()
        {
            Attributes = new HashSet<Attribute>();
        }

        public string Atid { get; set; }
        public string Atname { get; set; }
        public string Atvalue { get; set; }
        public int? AtisNecessary { get; set; }
        public int? Atstate { get; set; }
        public int? AtisDel { get; set; }
        public DateTime? AtcreateTime { get; set; }
        public string Atuid { get; set; }
        public string Atdesc { get; set; }
        public int Atno { get; set; }

        public virtual User Atu { get; set; }
        public virtual ICollection<Attribute> Attributes { get; set; }
    }
}
