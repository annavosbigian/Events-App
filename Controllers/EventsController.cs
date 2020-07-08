using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NHibernate.Dialect.Schema;
using RSVPTake3.ClientModels;
using RSVPTake3.Database;
using RSVPTake3.Database.Entities;
using RSVPTake3.Services.Interfaces;

namespace RSVPTake3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EventsController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IEventsService _eventsService;

        public EventsController(EventContext context, IEventsService eventsService)
        {
            _context = context;
            _eventsService = eventsService ?? throw new ArgumentNullException(nameof(eventsService));
        }

        [HttpGet]
        public IEnumerable<Event> GetEvent()
        {
            return _eventsService.GetEvent();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public Event GetEvent(int id)
        {
            var @event =  _context.Event.Find(id);

            if (@event == null)
            {
                return NotFoundResult();
            }

            return @event;
        }

        private Event NotFoundResult()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult PutEvent(int id, EventClientModel realEvent)
        {
            var efEvent = new Event()
            {
                EventId = id,
                Title = realEvent.Title,
                Date = realEvent.DateFormatted,
                LocationName = realEvent.LocationName,
                Address1 = realEvent.Address1,
                Address2 = realEvent.Address2,
                Details = realEvent.Details,
                Friends = realEvent.Friends,
                Publish = realEvent.Publish,
                ImgPath = realEvent.ImgPath
            };

            if (id != efEvent.EventId)
            {
                return BadRequest();
            }

            _context.Entry(efEvent).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostEvent(EventClientModel realEvent)
        {
            var efEvent = new Event()
            {
                Title = realEvent.Title,
                Date = realEvent.DateFormatted,
                LocationName = realEvent.LocationName,
                Address1 = realEvent.Address1,
                Address2 = realEvent.Address2,
                Details = realEvent.Details,
                Friends = realEvent.Friends,
                Publish = realEvent.Publish,
                ImgPath = realEvent.ImgPath
            };
            _context.Event.Add(efEvent);
            _context.SaveChanges();

            return Ok();
        }

        //DELETE: api/Events/5
        [HttpDelete("{id}")]
        public Event DeleteEvent(int id)
        {
            var @event = _context.Event.Find(id);
            if (@event == null)
            {
                return NotFoundResult();
            }
            if (@event.ImgPath != null)
            {
                var fullPath = Path.Combine("ClientApp", "src", @event.ImgPath);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }

            _context.Event.Remove(@event);
            _context.SaveChanges();

            return @event;
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }
    }
}
