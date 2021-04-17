using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BusinessLogic.BusinessLogic;
using System.Windows.Forms;

namespace HotelView
{
    public partial class FormReportRooms : Form
    {
        private readonly ReportLogic logic;

        public FormReportRooms(ReportLogic report)
        {
            logic = report;
            InitializeComponent();
        }

        private void LoadData()
        {
            var list = logic.GetRoomsInfo();
            if (list == null) { return; }
            dataGridView.DataSource = list;
            dataGridView.Columns[0].Visible = false;
        }

        private void FormAllRooms_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
