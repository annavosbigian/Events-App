using RSVPTake3.Database.Entities;
using System.Collections.Generic;

namespace RSVPTake3.Services
{
    public interface IDataService
    {
        IEnumerable<Data> GetDataByEvent(int eventId);
    }
}