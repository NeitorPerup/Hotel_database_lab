using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BusinessLogic.ViewModels.ReportModels
{
    public class ReportClientViewModel
    {
        public int ClientId { get; set; }

        [DisplayName("ФИО")]
        public string ClientFIO { get; set; }

        [DisplayName("Паспорт")]
        public string Pasport { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime Birthday { get; set; }

        [DisplayName("Номер комнаты")]
        public int RoomNumber { get; set; }

        [DisplayName("Дата заселения")]
        public DateTime StartDate { get; set; }

        [DisplayName("Дата выселения")]
        public DateTime EndDate { get; set; }
    }
}
