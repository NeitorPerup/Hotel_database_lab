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
    public partial class FormCategories : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly CategoryLogic logic;
        public FormCategories(CategoryLogic categoryLogic)
        {
            logic = categoryLogic;
            InitializeComponent();
        }

        private void FormCategories_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var list = logic.Read(null);
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCategory>();
            form.ShowDialog();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormCategory>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.ShowDialog();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                logic.Delete(new CategoryBindingModel { Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value) });
                LoadData();
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
