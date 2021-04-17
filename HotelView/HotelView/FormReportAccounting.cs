using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogic;
using System.Windows.Forms;

namespace HotelView
{
    public partial class FormReportAccounting : Form
    {
        private readonly ReportLogic logic;

        public FormReportAccounting(ReportLogic report)
        {
            logic = report;
            InitializeComponent();
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата справа должна быть больше =)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var list = logic.GetAccountingInfo(new ReportBindingModel 
                { DateFrom = dateTimePickerFrom.Value, DateTo = dateTimePickerTo.Value});
            if (list == null) { return; }
            dataGridView.DataSource = list;
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
