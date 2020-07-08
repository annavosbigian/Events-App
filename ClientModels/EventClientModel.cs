using RSVPTake3.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSVPTake3.ClientModels
{
    public class EventClientModel
    {
        public string Title { get; set; }
        //public string Date { get; set; }
        //public DateTime Date { get; set; }
        public DateTime DateFormatted { get; set; }
        public string LocationName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Details { get; set; }
        public int Friends { get; set; }
        public bool Publish { get; set; }
        public string ImgPath { get; set; }
    }
}
