using System;
using System.Collections.Generic;
using BusinessLogic.Enums;

namespace BusinessLogic.BindingModels
{
    public class ClientBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime Birthday { get; set; }
        public string Pasport { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoles Status { get; set; }
        public Dictionary<int, decimal> Accounting { get; set; } // accountingId, cost
    }
}
