using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseImplement.Models
{
    public partial class Category
    {
        public Category()
        {
            Room = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Roomnumber { get; set; }
        public int Sleepingberths { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
