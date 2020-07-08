using RSVPTake3.ClientModels;
using RSVPTake3.Database;
using RSVPTake3.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSVPTake3.Services
{
    public class GuestService : IGuestService
    {
        private readonly EventContext _context;
        public GuestService(EventContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //retreives guests from only specific event
        public IEnumerable<Guest> GetGuestsByEvent(int eventId)
        {
            if (_context.Guest
                .Where(g => g.EventId == eventId) == null)
            {
                return new Guest[0];
            }
            return _context.Guest
                .Where(g => g.EventId == eventId)
                .ToArray();

        }

        //retreives all distinct guest emails
        public IEnumerable<GuestEmailClientModel> GetGuestEmails()
        {
            var emails = _context.Guest
                  .OrderBy(x => x.Email)
                  .Select(x => new GuestEmailClientModel()
                  {
                      Name = x.Name,
                      Email = x.Email
                  })
                  .Distinct();

            return emails;
        }
    }
}
