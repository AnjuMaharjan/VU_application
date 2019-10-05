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

        [Required(ErrorMessage ="You must provide First Name.")]
        public string AttendeeFirstName { get; set; }

        public string AttendeeLastName { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number.")]
        public string AttendeePhone { get; set; }

        [Required]
        public string AttendeeAddress { get; set; }

        [Required(ErrorMessage = "You must provide Email address.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage ="Not a valid Email address.")]
        public string AttendeeEmail { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}