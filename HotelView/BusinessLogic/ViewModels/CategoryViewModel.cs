using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BusinessLogic.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [DisplayName("Тип номера")]
        public string Type { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DisplayName("Количество комнат")]
        public int Roomnumber { get; set; }
        [DisplayName("Спальных мест")]
        public int Sleepingberths { get; set; }
        public Dictionary<int, int> Rooms { get; set; } // roomId, number
    }
}
