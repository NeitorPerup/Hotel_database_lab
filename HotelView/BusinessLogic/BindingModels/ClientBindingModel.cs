using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BusinessLogic.BindingModels
{
    [DataContract]
    public class ClientBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Middlename { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
        public int Pasport { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public Dictionary<int, int> Accounting { get; set; } // accountingId, cost
    }
}
