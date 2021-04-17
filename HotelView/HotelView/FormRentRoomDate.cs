using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelView
{
    public partial class FormRentRoomDate : Form
    {
        public DateTime RentDateFrom { get; private set; }

        public DateTime RentDateTo { get; private set; }

        public FormRentRoomDate()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var DateFrom = dateTimePickerFrom.Value;
            var DateTo = dateTimePickerTo.Value;
            if (DateFrom.Date >= DateTo.Date)
            {
                MessageBox.Show("Дата выселения должна быть больше даты заселения", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RentDateFrom = DateFrom;
            RentDateTo = DateTo;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
