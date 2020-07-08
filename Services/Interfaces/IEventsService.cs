using System.Collections.Generic;
using RSVPTake3.Database.Entities;

namespace RSVPTake3.Services.Interfaces
{
    public interface IEventsService
    {
        IEnumerable<Event> GetEvent();
    }
}