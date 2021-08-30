using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class OrganizationRelation
    {
        public string Orid { get; set; }
        public string Oroid { get; set; }
        public string Oruid { get; set; }
        public int? OrisPrincipal { get; set; }
        public DateTime? OrcreateTime { get; set; }
        public int? Orstate { get; set; }
        public string Ordesc { get; set; }

        public virtual Organization Oro { get; set; }
        public virtual User Oru { get; set; }
    }
}
