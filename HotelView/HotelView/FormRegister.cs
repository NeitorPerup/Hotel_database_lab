using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using BusinessLogic.ViewModels;
using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogic;
using BusinessLogic.Enums;
using Unity;
using System.Windows.Forms;

namespace HotelView
{
    public partial class FormRegister : Form
    {
        private readonly ClientLogic _clientLogic;

        public FormRegister(ClientLogic userLogic)
        {
            _clientLogic = userLogic;
            InitializeComponent();
            comboBoxRoles.Items.AddRange(new string[] { "Клиент", "Администратор" });
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните электронную почту", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните поле Пароль", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(comboBoxRoles.Text))
            {
                MessageBox.Show("Необходимо выбрать роль", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ClientBindingModel model = new ClientBindingModel
                {
                    Email = textBoxEmail.Text,
                    Password = textBoxPassword.Text,
                    Name = "",
                    Surname = "",
                    Middlename = "",
                    Birthday = DateTime.Now,
                    Pasport = "",
                    Status = (UserRoles)Enum.Parse(typeof(UserRoles), comboBoxRoles.Text)
                };
                _clientLogic.CreateOrUpdate(model);
                Program.Client = _clientLogic.Read(model)?[0];
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
