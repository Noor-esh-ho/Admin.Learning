using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Arrange
    {
        public string Aid { get; set; }
        public string Aname { get; set; }
        public string Aexplain { get; set; }
        public string AtypeAid { get; set; }
        public string AauthorUid { get; set; }
        public string ArelationId { get; set; }
        public string Acids { get; set; }
        public string Auids { get; set; }
        public string Actids { get; set; }
        public int? AisExclude { get; set; }
        public int? Astate { get; set; }
        public string AbackUpId { get; set; }
        public DateTime? AcreateTimeDate { get; set; }
        public DateTime? AbeginTime { get; set; }
        public DateTime? AendTime { get; set; }
        public int? AisTrain { get; set; }
        public int? AisDel { get; set; }
        public string Adesc { get; set; }

        public virtual User AauthorU { get; set; }
        public virtual Attribute AtypeA { get; set; }
    }
}
