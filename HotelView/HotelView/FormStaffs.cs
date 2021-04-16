using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity;
using BusinessLogic.BusinessLogic;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System.Windows.Forms;

namespace HotelView
{
    public partial class FormStaffs : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly StaffLogic logic;

        public FormStaffs(StaffLogic staff)
        {
            logic = staff;
            InitializeComponent();
        }

        private void LoadData()
        {
            var list = logic.Read(null);
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void FormStaffs_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStaff>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormStaff>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.ShowDialog();
                LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                logic.Delete(new StaffBindingModel { Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value) });
                LoadData();
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
