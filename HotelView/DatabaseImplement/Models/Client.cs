using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseImplement.Models
{
    public partial class Client
    {
        public Client()
        {
            Accounting = new HashSet<Accounting>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime Birthday { get; set; }
        public int Pasport { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Accounting> Accounting { get; set; }
    }
}
