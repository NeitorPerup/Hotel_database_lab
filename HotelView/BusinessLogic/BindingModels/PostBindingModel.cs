using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BindingModels
{
    public class PostBindingModel
    {
        public int? Id { get; set; }
        public int Count { get; set; }
        public decimal Salary { get; set; }
        public string Name { get; set; }
        public Dictionary<int, string> Staff { get; set; } // staffid, staffname
    }
}
