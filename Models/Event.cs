using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VU.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public int OrganizerID { get; set; }
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Organizer Organizer { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}