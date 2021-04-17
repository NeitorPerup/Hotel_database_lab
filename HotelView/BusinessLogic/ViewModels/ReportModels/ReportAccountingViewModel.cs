using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BusinessLogic.ViewModels.ReportModels
{
    public class ReportAccountingViewModel
    {
        public int ClientId { get; set; }

        [DisplayName("ФИО")]
        public string ClientFIO { get; set; }

        [DisplayName("Номер комнаты")]
        public int Number { get; set; }

        [DisplayName("Дата заселения")]
        public DateTime StartDate { get; set; }

        [DisplayName("Дата выселения")]
        public DateTime EndDate { get; set; }

        [DisplayName("Стоимость проживания")]
        public decimal Cost { get; set; }
    }
}
