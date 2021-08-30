using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class ChapterRelation
    {
        public string Crid { get; set; }
        public string Crcid { get; set; }
        public string Crcsid { get; set; }
        public DateTime? CrcreateTime { get; set; }
        public int? Crno { get; set; }
        public int? Crstate { get; set; }

        public virtual Chapter Crc { get; set; }
        public virtual Courseware Crcs { get; set; }
    }
}
