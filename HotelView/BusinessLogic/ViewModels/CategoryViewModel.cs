using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Roomnumber { get; set; }
        public int Sleepingberths { get; set; }
        public Dictionary<int, int> Rooms { get; set; } // roomId, price
    }
}
