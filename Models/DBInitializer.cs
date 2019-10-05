using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VU.Models
{
    public class DBInitializer : DropCreateDatabaseAlways<VU_DB>
    {
        protected override void Seed(VU_DB context)
        {
            var organizers = new List<Organizer>
            {
                new Organizer
                {
                    OrganizerName="",
                    OrganizerEmail="",
                    OrganizerPhone="",
                    OrganizerAddress=""
                },
                new Organizer
                {
                    OrganizerName="",
                    OrganizerEmail="",
                    OrganizerPhone="",
                    OrganizerAddress=""
                },
                new Organizer
                {
                    OrganizerName="",
                    OrganizerEmail="",
                    OrganizerPhone="",
                    OrganizerAddress=""
                }
            };
            organizers.ForEach(o => context.Organizers.Add(o));
            context.SaveChanges();

            var events = new List<Event>
            {
                new Event
                {
                    EventName="",
                    OrganizerID=1,
                    EventDate=DateTime.Parse("2019-10-05"),
                    EventLocation="",
                    StartTime=DateTime.Parse("10:00"),
                    EndTime=DateTime.Parse("17:00")
                },
                new Event
                {
                    EventName="",
                    OrganizerID=1,
                    EventDate=DateTime.Parse("2019-10-05"),
                    EventLocation="",
                    StartTime=DateTime.Parse("10:00"),
                    EndTime=DateTime.Parse("17:00")
                },
                new Event
                {
                    EventName="",
                    OrganizerID=1,
                    EventDate=DateTime.Parse("2019-10-05"),
                    EventLocation="",
                    StartTime=DateTime.Parse("10:00"),
                    EndTime=DateTime.Parse("17:00")
                },
                new Event
                {
                    EventName="",
                    OrganizerID=1,
                    EventDate=DateTime.Parse("2019-10-05"),
                    EventLocation="",
                    StartTime=DateTime.Parse("10:00"),
                    EndTime=DateTime.Parse("17:00")
                }
            };
            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();

            var attendees = new List<Attendee>
            {
                new Attendee
                {
                    AttendeeFirstName="",
                    AttendeeLastName="",
                    AttendeeEmail="",
                    AttendeeAddress="",
                    AttendeePhone=""
                },
                new Attendee
                {
                    AttendeeFirstName="",
                    AttendeeLastName="",
                    AttendeeEmail="",
                    AttendeeAddress="",
                    AttendeePhone=""
                },
                new Attendee
                {
                    AttendeeFirstName="",
                    AttendeeLastName="",
                    AttendeeEmail="",
                    AttendeeAddress="",
                    AttendeePhone=""
                },
                new Attendee
                {
                    AttendeeFirstName="",
                    AttendeeLastName="",
                    AttendeeEmail="",
                    AttendeeAddress="",
                    AttendeePhone=""
                }
            };
            attendees.ForEach(a => context.Attendees.Add(a));
            context.SaveChanges();

            var registrations = new List<Registration>
            {
                new Registration
                {
                    EventID = 1,
                    AttendeeID = 1,
                    RegistrationFee = 50.00
                },
                new Registration
                {
                    EventID = 1,
                    AttendeeID = 1,
                    RegistrationFee = 50.00
                },
                new Registration
                {
                    EventID = 1,
                    AttendeeID = 1,
                    RegistrationFee = 50.00
                },
                new Registration
                {
                    EventID = 1,
                    AttendeeID = 1,
                    RegistrationFee = 50.00
                }
            };
            registrations.ForEach(r => context.Registrations.Add(r));
            context.SaveChanges();
        }
    }
}