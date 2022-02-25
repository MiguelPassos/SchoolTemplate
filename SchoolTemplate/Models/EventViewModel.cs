using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolTemplate.Models
{
    public class EventViewModel
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public string UriImage { get; set; }

        public string Author { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
