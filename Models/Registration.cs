using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VU.Models
{
    public class Registration
    {
        public int RegistrationID { get; set; }
        public int EventID { get; set; }
        public int AttendeeID { get; set; }
        public double RegistrationFee { get; set; }
        public virtual Event Event { get; set; }
        public virtual Attendee Attendee { get; set; }
    }
}