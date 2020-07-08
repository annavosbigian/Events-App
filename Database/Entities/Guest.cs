using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSVPTake3.Database.Entities
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string RSVP { get; set; }
        public int Friends { get; set; }
        public string Message { get; set; }
        public int EventId { get; set; }

    }
}
