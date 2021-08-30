using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class History
    {
        public string Hid { get; set; }
        public string Htable { get; set; }
        public string Haction { get; set; }
        public string HthemeId { get; set; }
        public int? Hno { get; set; }
        public int? HisFinish { get; set; }
        public DateTime? HcreateTime { get; set; }
        public string Hdesc { get; set; }
    }
}
