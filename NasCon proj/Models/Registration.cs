using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasCon_proj.Models
{
    internal class Registration
    {
        public int RegistrationID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
        public int? TeamID { get; set; } // Nullable team ID
        public string RegistrationType { get; set; }
        public DateTime RegistrationDate { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
        public Team Team { get; set; }
    }
}
