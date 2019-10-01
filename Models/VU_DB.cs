﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VU.Models
{
    public class VU_DB : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VU_DB() : base("name=VU_DB")
        {
        }

        public System.Data.Entity.DbSet<VU.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<VU.Models.Organizer> Organizers { get; set; }

        public System.Data.Entity.DbSet<VU.Models.Attendee> Attendees { get; set; }

        public System.Data.Entity.DbSet<VU.Models.Registration> Registrations { get; set; }
    }
}