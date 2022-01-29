using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolTemplate.Models
{
    public class HomeViewModel
    {
        public List<object> NewsEvents { get; set; }

        public List<AcademicMemberModelView> AcademicMembers { get; set; }

        public HomeViewModel()
        {
            NewsEvents = new List<object>();
            AcademicMembers = new List<AcademicMemberModelView>();
        }
    }
}
