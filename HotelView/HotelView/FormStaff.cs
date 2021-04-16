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
    public partial class FormStaff : Form
    {
        private readonly PostLogic logicP;

        private readonly StaffLogic logic;

        public int? Id { get; set; }

        public FormStaff(PostLogic post, StaffLogic staff)
        {
            logicP = post;
            logic = staff;
            InitializeComponent();
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            var list = logicP.Read(null);
            if (list == null) { return; }
            foreach (var elem in list)
            {
                comboBox.DataSource = list;
                comboBox.ValueMember = "Id";
                comboBox.DisplayMember = "Name";
                comboBox.SelectedItem = null;
            }
            if (Id.HasValue)
            {
                var model = logic.Read(new StaffBindingModel { Id = Id.Value })?[0];
                if (model != null)
                {
                    string[] fio = model.StaffFIO.Split();
                    textBoxName.Text = fio[1];
                    textBoxSurname.Text = fio[0];
                    textBoxMiddlename.Text = fio.Length > 2 ? fio[2] : "";
                    comboBox.SelectedItem = list.FirstOrDefault(x => x.Id == model.Id);
                    dateTimePickerBirthday.Value = model.Birthday;
                    dateTimePickerEmployment.Value = model.Employement;
                }                
            }            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните Имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSurname.Text))
            {
                MessageBox.Show("Заполните Фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(comboBox.Text))
            {
                MessageBox.Show("Заполните должность", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((dateTimePickerEmployment.Value.Year - dateTimePickerBirthday.Value.Date.Year) < 17)
            {
                MessageBox.Show("Куда такой молодой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                StaffBindingModel model = new StaffBindingModel
                {
                    Name = textBoxName.Text,
                    Surname = textBoxSurname.Text,
                    Middlename = textBoxMiddlename.Text,
                    Postid = Convert.ToInt32(comboBox.SelectedValue),
                    Birthday = dateTimePickerBirthday.Value,
                    Employement = dateTimePickerEmployment.Value
                };
                if (Id.HasValue) { model.Id = Id.Value; }
                logic.CreateOrUpdate(model);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.InnerException?.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
