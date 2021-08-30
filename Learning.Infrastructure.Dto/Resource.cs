using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class Resource
    {
        public Resource()
        {
            Classes = new HashSet<Class>();
            Courses = new HashSet<Course>();
            Coursewares = new HashSet<Courseware>();
            UserInfos = new HashSet<UserInfo>();
        }

        public string Rid { get; set; }
        public string Rtitle { get; set; }
        public string Raid { get; set; }
        public string Ruid { get; set; }
        public string Rname { get; set; }
        public string Rpath { get; set; }
        public int? Rsize { get; set; }
        public int? RisUse { get; set; }
        public int? RisPublic { get; set; }
        public DateTime? RbeginTime { get; set; }
        public DateTime? RendTime { get; set; }
        public int? Rstate { get; set; }
        public int? RisDel { get; set; }
        public DateTime? RcreateTime { get; set; }
        public string Rdesc { get; set; }

        public virtual Attribute Ra { get; set; }
        public virtual User Ru { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Courseware> Coursewares { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
