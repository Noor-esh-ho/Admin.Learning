using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Train
    {
        public Train()
        {
            TrainPersonnel = new HashSet<TrainPersonnel>();
        }

        public string Tid { get; set; }
        public string Tname { get; set; }
        public string TtypeAid { get; set; }
        public string TdutyPeopleUid { get; set; }
        public DateTime? TbeginTime { get; set; }
        public DateTime? TendTime { get; set; }
        public int? Tstate { get; set; }
        public int? Tcount { get; set; }
        public DateTime? TcreateTime { get; set; }
        public int? TisDel { get; set; }
        public string Tdesc { get; set; }

        public virtual User TdutyPeopleU { get; set; }
        public virtual Attribute TtypeA { get; set; }
        public virtual ICollection<TrainPersonnel> TrainPersonnel { get; set; }
    }
}
