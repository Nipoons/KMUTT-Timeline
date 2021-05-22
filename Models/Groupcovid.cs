using System;
using System.Collections.Generic;

#nullable disable

namespace kmutt_x_covid.Models
{
    public partial class Groupcovid
    {
        public Groupcovid()
        {
            Users = new HashSet<User>();
        }

        public int RiskId { get; set; }
        public string RiskLevel { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
