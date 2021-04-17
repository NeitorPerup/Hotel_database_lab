using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseImplement.Models
{
    public partial class Accounting
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int Clientid { get; set; }
        public int Roomid { get; set; }

        public virtual Client Client { get; set; }
        public virtual Room Room { get; set; }
    }
}
