using System;
using System.Collections.Generic;

#nullable disable

namespace kmutt_x_covid.Models
{
    public partial class Infection
    {
        public int Number { get; set; }
        public string Id { get; set; }
        public DateTime TimeInfection { get; set; }

        public virtual User IdNavigation { get; set; }
    }
}
