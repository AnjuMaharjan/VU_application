using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VU.Models
{
    public class Organizer
    {
        public int OrganizerID { get; set; }
        public string OrganizerName { get; set; }
        public string ContactPerson { get; set; }
        public string OrganizerEmail { get; set; }
        public string OrganizerPhone { get; set; }
        public string OrganizerAddress { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}