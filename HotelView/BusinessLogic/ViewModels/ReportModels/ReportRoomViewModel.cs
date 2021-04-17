using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BusinessLogic.ViewModels.ReportModels
{
    public class ReportRoomViewModel
    {
        public int RoomId { get; set; }

        [DisplayName("Номер комнаты")]
        public int Number { get; set; }

        [DisplayName("Тип")]
        public string Type { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DisplayName("Количество комнат")]
        public int RoomNumber { get; set; }

        [DisplayName("Спальных мест")]
        public int SleepingBerths { get; set; }
    }
}
