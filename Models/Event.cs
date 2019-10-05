using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VU.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public int OrganizerID { get; set; }
        public string EventName { get; set; }
        public string EventLocation { get; set; }

        [Required(ErrorMessage ="You must provide Event date.")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "You must provide Event Start time.")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "You must provide Event End time.")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime EndTime { get; set; }
        public virtual Organizer Organizer { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}