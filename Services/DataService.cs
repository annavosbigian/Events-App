using RSVPTake3.Database;
using RSVPTake3.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using RSVPTake3.Services.Interfaces;
using System.Threading.Tasks;

namespace RSVPTake3.Services
{
    public class DataService : IDataService
    {
        private readonly EventContext _context;

        public DataService(EventContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //retrieves data from only specific event
        public IEnumerable<Data> GetDataByEvent(int eventId)
        {
            if (_context.Data
                .Where(d => d.EventId == eventId) == null)
            {
                return new Data[0];
            }
            return _context.Data
                .Where(d => d.EventId == eventId)
                .ToArray();
        }


    }
}
