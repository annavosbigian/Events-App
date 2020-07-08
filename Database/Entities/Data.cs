using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSVPTake3.Database.Entities
{
    public class Data
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Guests { get; set; }
        public int EventId { get; set; }
    }
}
