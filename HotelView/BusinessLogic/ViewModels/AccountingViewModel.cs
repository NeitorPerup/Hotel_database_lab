using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class AccountingViewModel
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int Clientid { get; set; }
        public int Roomid { get; set; }
    }
}
