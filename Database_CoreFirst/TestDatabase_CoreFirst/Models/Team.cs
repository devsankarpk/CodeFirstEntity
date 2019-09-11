using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestDatabase_CoreFirst.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        [MaxLength(30)]
        public string TeamName { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        public List<Player> Players { get; set; }

    }
}