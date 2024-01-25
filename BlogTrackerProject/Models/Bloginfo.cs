using System;
using System.Collections.Generic;

namespace BlogTrackerProject.Models
{
    public partial class Bloginfo
    {
        public int Blogid { get; set; }
        public string? Title { get; set; }
        public string? Subject { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public string? Blogurl { get; set; }
        public string? Empemail { get; set; }

        public virtual Employeeinfo? EmpemailNavigation { get; set; }
    }
}
