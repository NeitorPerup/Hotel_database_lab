using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public BitArray Available { get; set; }
        public int Categoryid { get; set; }
        public Dictionary<int, int> Accounting { get; set; } // id, cost
        public Dictionary<int, string> Staff { get; set; } // id, name
    }
}
