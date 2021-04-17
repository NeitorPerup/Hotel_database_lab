using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public Dictionary<int, int> Accounting { get; set; } // id, cost
        public Dictionary<int, string> Staff { get; set; } // id, name
        public int Number { get; set; }
        public bool Available { get; set; }
        public int Categoryid { get; set; }        
        public int? RoomNumber { get; set; }
        public string Type { get; set; }
        public decimal? Price { get; set; }
        public int? Sleepingberths { get; set; }
    }
}
