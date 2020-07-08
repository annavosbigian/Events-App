using Microsoft.EntityFrameworkCore;
using RSVPTake3.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSVPTake3.Database
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }
        public DbSet<Event> Event { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<Data> Data { get; set; }
    }
}
