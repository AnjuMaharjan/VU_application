using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VU.Models
{
    public class Attendee
    {
        public int AttendeeID { get; set; }
        public string AttendeeFirstName { get; set; }
        public string AttendeeLastName { get; set; }
        public string AttendeePhone { get; set; }
        public string AttendeeAddress { get; set; }
        public string AttendeeEmail { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}