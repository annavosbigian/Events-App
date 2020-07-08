using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NHibernate.Criterion;
using RSVPTake3.ClientModels;
using RSVPTake3.Database;
using RSVPTake3.Database.Entities;
using RSVPTake3.Services;

namespace RSVPTake3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class GuestsController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IGuestService guestService;

        public GuestsController(EventContext context, IGuestService guestService)
        {
            _context = context;
            this.guestService = guestService;
        }

        //GET: api/Guests
        [HttpGet]
        public IEnumerable<Guest> GetGuest()
        {
            return  _context.Guest.ToList();
        }

        //GET: api/Guests/5
        [HttpGet("{id}")]
        public Guest GetGuest(int id)
        {
            var guest =  _context.Guest.Find(id);

            if (guest == null)
            {
                return NotFoundResult();
            }

            return guest;
        }

        private Guest NotFoundResult()
        {
            throw new NotImplementedException();
        }

        [HttpGet("eventId/{EventId}")]
        public IEnumerable<Guest> GetGuestsByEvent(int eventId)
        {
            return guestService.GetGuestsByEvent(eventId);
        }

        [HttpGet("email")]
        public IEnumerable<GuestEmailClientModel> GetGuestEmails()
        {
            return guestService.GetGuestEmails();
        }

        // PUT: api/Guests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutGuest(int id, Guest guest)
        {
            if (id != guest.GuestId)
            {
                return BadRequest();
            }

            _context.Entry(guest).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Guests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostGuest(GuestClientModel guest)
        {
            var efGuest = new Guest()
            {
                Email = guest.Email,
                EventId = guest.EventId,
                Friends = guest.Friends,
                Name = guest.Name,
                Message = guest.Message,
                RSVP = guest.RSVP
            };

            _context.Guest.Add(efGuest);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/Guests/5
        [HttpDelete("{id}")]
        public Guest DeleteGuest(int id)
        {
            var guest =  _context.Guest.Find(id);
            if (guest == null)
            {
                return NotFoundResult();
            }

            _context.Guest.Remove(guest);
            _context.SaveChanges();

            return guest;
        }

        private bool GuestExists(int id)
        {
            return _context.Guest.Any(e => e.GuestId == id);
        }
    }
}