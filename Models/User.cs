using System;
using System.Collections.Generic;

#nullable disable

namespace kmutt_x_covid.Models
{
    public partial class User
    {
        public User()
        {
            BuildingStampIns = new HashSet<BuildingStampIn>();
            Infections = new HashSet<Infection>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RiskId { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }
        public virtual Groupcovid Risk { get; set; }
        public virtual ICollection<BuildingStampIn> BuildingStampIns { get; set; }
        public virtual ICollection<Infection> Infections { get; set; }
    }
}
