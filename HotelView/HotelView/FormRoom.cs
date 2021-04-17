using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using BusinessLogic.BusinessLogic;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System.Windows.Forms;

namespace HotelView
{
    public partial class FormRoom : Form
    {
        private readonly CategoryLogic logicC;

        private readonly RoomLogic logicR;

        public int? Id { get; set; }

        public string Number { get; set; }

        private int? CategoryId { get; set; }

        public FormRoom(CategoryLogic categoryLogic, RoomLogic roomLogic)
        {
            logicC = categoryLogic;
            logicR = roomLogic;
            InitializeComponent();
        }

        private void FormRoom_Load(object sender, EventArgs e)
        {
            if (Id.HasValue) { textBoxNumber.Text = Number; }
            var list = logicC.Read(null);
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[5].Visible = false;
            }
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                CategoryId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                MessageBox.Show("Успешно", "Категория выбрана", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNumber.Text))
            {
                MessageBox.Show("Введите номер комнаты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CategoryId == null)
            {
                MessageBox.Show("Выберите категорию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int number;
            if (!int.TryParse(textBoxNumber.Text, out number))
            {
                MessageBox.Show("Номер комнаты - целое число", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                RoomBindingModel model = new RoomBindingModel
                {
                    Categoryid = CategoryId.Value,
                    Available = true,
                    Number = number
                };
                if (Id.HasValue) { model.Id = Id.Value; }
                logicR.CreateOrUpdate(model);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
