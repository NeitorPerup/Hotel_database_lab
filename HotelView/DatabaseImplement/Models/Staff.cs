using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseImplement.Models
{
    public partial class Staff
    {
        public Staff()
        {
            RoomStaff = new HashSet<RoomStaff>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Employement { get; set; }
        public int Postid { get; set; }

        public virtual Post Post { get; set; }
        public virtual ICollection<RoomStaff> RoomStaff { get; set; }
    }
}
