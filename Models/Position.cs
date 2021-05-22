using System;
using System.Collections.Generic;

#nullable disable

namespace kmutt_x_covid.Models
{
    public partial class Position
    {
        public Position()
        {
            Users = new HashSet<User>();
        }

        public int PositionId { get; set; }
        public string PositionType { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
