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
    public partial class FormCategory : Form
    {
        private readonly CategoryLogic logic;

        public int? Id { get; set; }
        public FormCategory(CategoryLogic category)
        {
            logic = category;
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxType.Text))
            {
                MessageBox.Show("Заполните тип", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxRoomNumber.Text))
            {
                MessageBox.Show("Заполните количество комнат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSleepingBerths.Text))
            {
                MessageBox.Show("Заполните количество спальных мест", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal price;
            int roomNumber;
            int sleep;
            if (!int.TryParse(textBoxRoomNumber.Text, out roomNumber))
            {
                MessageBox.Show("Количество комнат - целое число", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxSleepingBerths.Text, out sleep))
            {
                MessageBox.Show("Спальные места - целое число", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(textBoxPrice.Text, out price))
            {
                MessageBox.Show("Количество комнат - число", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (price <= 0 || roomNumber <= 0 || sleep <= 0)
            {
                MessageBox.Show("Числа > 0", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                CategoryBindingModel model = new CategoryBindingModel
                {
                    Roomnumber = roomNumber,
                    Sleepingberths = sleep,
                    Price = price,
                    Type = textBoxType.Text
                };
                if (Id.HasValue)
                {
                    model.Id = Id;
                }
                logic.CreateOrUpdate(model);
                MessageBox.Show("Успешно", "Сохранено",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormCategory_Load(object sender, EventArgs e)
        {
            if (Id.HasValue)
            {
                var model = logic.Read(new CategoryBindingModel { Id = Id })?[0];
                if (model == null) { return; }
                textBoxPrice.Text = model.Price.ToString();
                textBoxRoomNumber.Text = model.Roomnumber.ToString();
                textBoxSleepingBerths.Text = model.Sleepingberths.ToString();
                textBoxType.Text = model.Type;
            }
        }
    }
}
