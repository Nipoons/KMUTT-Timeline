using System;
using System.Collections.Generic;

#nullable disable

namespace kmutt_x_covid.Models
{
    public partial class Building
    {
        public Building()
        {
            BuildingStampIns = new HashSet<BuildingStampIn>();
        }

        public string BuildingId { get; set; }
        public string BuildingName { get; set; }

        public virtual ICollection<BuildingStampIn> BuildingStampIns { get; set; }
    }
}
