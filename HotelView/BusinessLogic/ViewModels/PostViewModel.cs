using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BusinessLogic.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [DisplayName("Должность")]
        public string Name { get; set; }

        [DisplayName("Зарплата")]
        public decimal Salary { get; set; }   
        
        [DisplayName("Человек на должности")]
        public int Count { get; set; }

        public Dictionary<int, string> Staff { get; set; } // staffid, staffname
    }
}
