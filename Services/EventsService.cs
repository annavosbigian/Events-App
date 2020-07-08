using System;
using System.Collections.Generic;
using System.Linq;
using RSVPTake3.Database;
using RSVPTake3.Database.Entities;
using RSVPTake3.Services.Interfaces;

namespace RSVPTake3.Services
{
    public class EventsService : IEventsService
    {
        private readonly EventContext _context;

        public EventsService(EventContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public IEnumerable<Event> GetEvent()
        {
            return _context.Event
                .OrderByDescending(x => x.Date);
        }
    }
}