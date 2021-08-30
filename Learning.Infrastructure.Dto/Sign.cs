using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Sign
    {
        public Sign()
        {
            Users = new HashSet<User>();
        }

        public string Sgid { get; set; }
        public string Sgcode { get; set; }
        public string Sgphone { get; set; }
        public DateTime? SgcreateTime { get; set; }
        public DateTime? SgendTime { get; set; }
        public DateTime? SguseTime { get; set; }
        public string Sgip { get; set; }
        public string Sgaid { get; set; }
        public int? SgisDel { get; set; }
        public int? Sgstate { get; set; }
        public string Sgdesc { get; set; }

        public virtual Attribute Sga { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
