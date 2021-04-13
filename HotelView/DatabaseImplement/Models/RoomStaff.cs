using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseImplement.Models
{
    public partial class RoomStaff
    {
        public int Roomid { get; set; }
        public int Staffid { get; set; }

        public virtual Room Room { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
