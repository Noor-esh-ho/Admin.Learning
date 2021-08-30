using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class UserInfo
    {
        public string Uiid { get; set; }
        public string Uiuid { get; set; }
        public string Uinick { get; set; }
        public string Uiphone { get; set; }
        public string Uimail { get; set; }
        public DateTime? Uibirthday { get; set; }
        public string Uigender { get; set; }
        public double? Uipoint { get; set; }
        public string Uirid { get; set; }
        public string Uigrade { get; set; }
        public int? Uistate { get; set; }
        public int? UiisDel { get; set; }
        public DateTime? UicreateTime { get; set; }
        public string Uidesc { get; set; }

        public virtual Resource Uir { get; set; }
        public virtual User Uiu { get; set; }
    }
}
