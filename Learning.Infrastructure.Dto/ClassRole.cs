using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class ClassRole
    {
        public string Crid { get; set; }
        public string Cruid { get; set; }
        public string Crccdid { get; set; }
        public string Crcid { get; set; }
        public int? CrisUse { get; set; }
        public DateTime? CrcreateTime { get; set; }
        public string Crdesc { get; set; }

        public virtual Class Crc { get; set; }
        public virtual ClassConfigDetail Crccd { get; set; }
        public virtual User Cru { get; set; }
    }
}
