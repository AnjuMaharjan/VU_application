using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VU.Models
{
    public class Organizer
    {
        public int OrganizerID { get; set; }

        [Required(ErrorMessage ="You must provide Organizer name.")]
        public string OrganizerName { get; set; }
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "You must provide Organizer Email address.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Not a valid Email address.")]
        public string OrganizerEmail { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number.")]
        public string OrganizerPhone { get; set; }
        public string OrganizerAddress { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}