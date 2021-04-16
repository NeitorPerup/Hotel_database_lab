using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BindingModels
{
    public class RoomBindingModel
    {
        public int? Id { get; set; }
        public int? Number { get; set; }
        public bool Available { get; set; }
        public int Categoryid { get; set; }
        public Dictionary<int, int> Accounting { get; set; } // id, cost
        public Dictionary<int, string> Staff { get; set; } // id, name
    }
}
