using System;
using System.Collections.Generic;
using System.Collections;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseImplement.Models
{
    public partial class Room
    {
        public Room()
        {
            Accounting = new HashSet<Accounting>();
            RoomStaff = new HashSet<RoomStaff>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public bool Available { get; set; }
        public int Categoryid { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Accounting> Accounting { get; set; }
        public virtual ICollection<RoomStaff> RoomStaff { get; set; }
    }
}
