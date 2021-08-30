using System;
using System.Collections.Generic;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class ClassRight
    {
        public string Crid { get; set; }
        public string CrroleCcdid { get; set; }
        public string CrrightAid { get; set; }
        public DateTime? CrcreateTime { get; set; }
        public string Crdesc { get; set; }

        public virtual Attribute CrrightA { get; set; }
        public virtual ClassConfigDetail CrroleCcd { get; set; }
    }
}
