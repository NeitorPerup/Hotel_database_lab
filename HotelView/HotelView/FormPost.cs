using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BusinessLogic.BusinessLogic;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System.Windows.Forms;

namespace HotelView
{
    public partial class FormPost : Form
    {
        private readonly PostLogic logic;

        public int? Id { get; set; }

        public FormPost(PostLogic post)
        {
            logic = post;
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSalary.Text))
            {
                MessageBox.Show("Заполните зарплату", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal salary;
            if (!decimal.TryParse(textBoxSalary.Text, out salary))
            {
                MessageBox.Show("Зарплата - число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (salary <= 0)
            {
                MessageBox.Show("Работникам нужно платить!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                PostBindingModel model = new PostBindingModel
                {
                    Name = textBoxName.Text,
                    Salary = salary
                };
                if (Id.HasValue) { model.Id = Id.Value; }
                logic.CreateOrUpdate(model);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message + '\n' + ex.InnerException?.Message, "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormPost_Load(object sender, EventArgs e)
        {
            if (Id.HasValue)
            {
                var post = logic.Read(new PostBindingModel { Id = Id.Value })?[0];
                if (post == null) { return; }
                textBoxName.Text = post.Name;
                textBoxSalary.Text = post.Salary.ToString();
            }
        }
    }
}
