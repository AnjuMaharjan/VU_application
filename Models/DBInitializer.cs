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
                    OrganizerName="Asia Pacific Tourism Association",
                    ContactPerson="Tim Clarke",
                    OrganizerEmail="apta@apta.asia",
                    OrganizerPhone="8251200842",
                    OrganizerAddress="Sydney, Australia"
                },
                new Organizer
                {
                    OrganizerName="Department of Tourism",
                    ContactPerson="Will Johnson",
                    OrganizerEmail="dept@dept.gov",
                    OrganizerPhone="0213456701",
                    OrganizerAddress="Melbourne, Australia"
                },
                new Organizer
                {
                    OrganizerName="Tourism Board",
                    ContactPerson="Michelle",
                    OrganizerEmail="contact@tb.au",
                    OrganizerPhone="02887192",
                    OrganizerAddress="Sydney, Australia"
                }
            };
            organizers.ForEach(o => context.Organizers.Add(o));
            context.SaveChanges();

            var events = new List<Event>
            {
                new Event
                {
                    EventName="Annual Day",
                    OrganizerID=1,
                    EventDate=DateTime.Parse("2019-10-05"),
                    EventLocation="Sydney, Australia",
                    StartTime=DateTime.Parse("10:00"),
                    EndTime=DateTime.Parse("17:00")
                },
                new Event
                {
                    EventName="Conference",
                    OrganizerID=1,
                    EventDate=DateTime.Parse("2019-11-25"),
                    EventLocation="Brisbane, Australia",
                    StartTime=DateTime.Parse("09:00"),
                    EndTime=DateTime.Parse("18:00")
                },
                new Event
                {
                    EventName="Promotional Program",
                    OrganizerID=2,
                    EventDate=DateTime.Parse("2019-12-18"),
                    EventLocation="Melbourne, Australia",
                    StartTime=DateTime.Parse("10:00"),
                    EndTime=DateTime.Parse("14:00")
                },
                new Event
                {
                    EventName="Meetup",
                    OrganizerID=3,
                    EventDate=DateTime.Parse("2019-10-20"),
                    EventLocation="Adelaide, Australia",
                    StartTime=DateTime.Parse("10:00"),
                    EndTime=DateTime.Parse("15:00")
                }
            };
            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();

            var attendees = new List<Attendee>
            {
                new Attendee
                {
                    AttendeeFirstName="Anju",
                    AttendeeLastName="Maharjan",
                    AttendeeEmail="anju.maharjan@vu.edu.au",
                    AttendeeAddress="Sydeny, Australia",
                    AttendeePhone="0401897564"
                },
                new Attendee
                {
                    AttendeeFirstName="Yasoda",
                    AttendeeLastName="Rai",
                    AttendeeEmail="yasoda.rai@vu.edu.au",
                    AttendeeAddress="Sydney, Australia",
                    AttendeePhone="0401289675"
                },
                new Attendee
                {
                    AttendeeFirstName="Sam",
                    AttendeeLastName="Head",
                    AttendeeEmail="sam.head@gmail.com",
                    AttendeeAddress="Melbourne, Australia",
                    AttendeePhone="0401987130"
                },
                new Attendee
                {
                    AttendeeFirstName="Tom",
                    AttendeeLastName="Root",
                    AttendeeEmail="root.tom@gmail.com",
                    AttendeeAddress="Brisbane, Australia",
                    AttendeePhone="0401987620"
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
                    AttendeeID = 2,
                    RegistrationFee = 50.00
                },
                new Registration
                {
                    EventID = 2,
                    AttendeeID = 3,
                    RegistrationFee = 100.00
                },
                new Registration
                {
                    EventID = 3,
                    AttendeeID = 4,
                    RegistrationFee = 150.00
                }
            };
            registrations.ForEach(r => context.Registrations.Add(r));
            context.SaveChanges();
        }
    }
}