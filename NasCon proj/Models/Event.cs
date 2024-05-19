using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasCon_proj.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; } 
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public decimal RegistrationPrice { get; set; }
        public bool EventType { get; set; }
        public int Capacity { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
