using System;
using System.Collections.Generic;

namespace BlogTrackerProject.Models
{
    public partial class Employeeinfo
    {
        public Employeeinfo()
        {
            Bloginfos = new HashSet<Bloginfo>();
        }

        public string Emailid { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime? Doj { get; set; }
        public int? Passcode { get; set; }

        public virtual ICollection<Bloginfo> Bloginfos { get; set; }
    }
}
