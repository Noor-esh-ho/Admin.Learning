using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Organization
    {
        public Organization()
        {
            OrganizationRelations = new HashSet<OrganizationRelation>();
        }

        public string Oid { get; set; }
        public string Oname { get; set; }
        public string Oexplain { get; set; }
        public int? Olv { get; set; }
        public string OparentOid { get; set; }
        public string Oprincipal { get; set; }
        public DateTime? OcreateTime { get; set; }
        public int? Ono { get; set; }
        public int? Ostate { get; set; }
        public int? OisDel { get; set; }
        public string Odesc { get; set; }

        public virtual ICollection<OrganizationRelation> OrganizationRelations { get; set; }
    }
}
