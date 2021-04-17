using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace BusinessLogic.ViewModels
{
    public class StaffViewModel
    {
        public int Id { get; set; }

        [DisplayName("ФИО")]
        public string StaffFIO { get; set; }

        [DisplayName("Должность")]
        public string PostName { get; set; }

        [DisplayName("День рождения")]
        public DateTime Birthday { get; set; }

        [DisplayName("Принятие на работу")]
        public DateTime Employement { get; set; }       
        public int Postid { get; set; }
        public Dictionary<int, (int, BitArray)> Room { get; set; } // id, number, available
    }
}
