using RSVPTake3.ClientModels;
using RSVPTake3.Database.Entities;
using System.Collections.Generic;

namespace RSVPTake3.Services
{
    public interface IGuestService
    {
        IEnumerable<Guest> GetGuestsByEvent(int eventId);
        IEnumerable<GuestEmailClientModel> GetGuestEmails();

    }
}