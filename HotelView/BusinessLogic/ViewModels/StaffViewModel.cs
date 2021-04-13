using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class StaffViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Employement { get; set; }
        public int Postid { get; set; }
        public Dictionary<int, (int, BitArray)> Room { get; set; } // id, number, available
    }
}
