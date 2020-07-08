using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSVPTake3.Database;
using RSVPTake3.Database.Entities;
using RSVPTake3.Services;

namespace RSVPTake3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class DataController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IDataService dataService;

        public DataController(EventContext context, IDataService dataService)
        {
            _context = context;
            this.dataService = dataService;
        }

        // GET: api/Data
        [HttpGet]
        public IEnumerable<Data> GetData()
        {
            return _context.Data.ToList();
        }

        [HttpGet("DatabyEventId/{EventId}")]
        public IEnumerable<Data> GetDataByEvent(int eventId)
        {
            return dataService.GetDataByEvent(eventId);
        }

        // GET: api/Data/5
        [HttpGet("{id}")]
        public Data GetData(int id)
        {
            var data = _context.Data.Find(id);

            if (data == null)
            {
                return NotFoundResult();
            }

            return data;
        }

        private Data NotFoundResult()
        {
            throw new NotImplementedException();
        }

        // PUT: api/Data/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutData(int id, Data data)
        {
            if (id != data.Id)
            {
                return BadRequest();
            }

            _context.Entry(data).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataExists(id))
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

        // POST: api/Data
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostData(Data data)
        {
            _context.Data.Add(data);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/Data/5
        [HttpDelete("{id}")]
        public Data DeleteData(int id)
        {
            var data = _context.Data.Find(id);
            if (data == null)
            {
                return NotFoundResult();
            }

            _context.Data.Remove(data);
            _context.SaveChanges();

            return data;
        }

        private bool DataExists(int id)
        {
            return _context.Data.Any(e => e.Id == id);
        }
    }
}
