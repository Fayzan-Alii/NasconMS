using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasCon_proj.Models
{
    internal class Feedback
    {
        public int FeedbackID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
        public int Ratings { get; set; }
        public string Comments { get; set; }
        public DateTime FeedbackDate { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
    }
}
