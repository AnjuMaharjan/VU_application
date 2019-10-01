using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace VU.Models
{
    public class Registration
    {
        [Required]
        public int RegistrationID { get; set; }

        [Required]
        public int EventID { get; set; }

        [Required]
        public int AttendeeID { get; set; }

        [Required]
        public double RegistrationFee { get; set; }

        public virtual Event Event { get; set; }

        public virtual Attendee Attendee { get; set; }
    }
}