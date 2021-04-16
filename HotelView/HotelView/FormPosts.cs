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
    public partial class FormPosts : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly PostLogic logic;

        public FormPosts(PostLogic post)
        {
            logic = post;
            InitializeComponent();
        }

        private void LoadData()
        {
            var list = logic.Read(null);
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void FormPosts_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPost>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormPost>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.ShowDialog();
                LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                logic.Delete(new PostBindingModel { Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value) });
                LoadData();
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
