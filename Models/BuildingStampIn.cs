using System;
using System.Collections.Generic;

#nullable disable

namespace kmutt_x_covid.Models
{
    public partial class BuildingStampIn
    {
        public int StampId { get; set; }
        public string Id { get; set; }
        public string BuildingId { get; set; }
        public int Floors { get; set; }
        public DateTime TimeIn { get; set; }

        public virtual Building Building { get; set; }
        public virtual User IdNavigation { get; set; }
    }
}
