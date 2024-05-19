using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasCon_proj.Models
{
    internal class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int LeaderID { get; set; }

        public User Leader { get; set; }
    }
}
