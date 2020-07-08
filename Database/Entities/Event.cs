using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSVPTake3.Database.Entities
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string LocationName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Details { get; set; }
        public int Friends { get; set; }
        public bool Publish { get; set; }

        public string ImgPath { get; set; }

        public ICollection<Guest> Guests { get; set; }

    }
}
