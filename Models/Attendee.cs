using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VU.Models
{
    public class Attendee
    {
        [Required]
        public int AttendeeID { get; set; }

        [Required]
        public string AttendeeFirstName { get; set; }

        [Required]
        public string AttendeeLastName { get; set; }

        [Required]
        public string AttendeePhone { get; set; }

        [Required]
        public string AttendeeAddress { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string AttendeeEmail { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}