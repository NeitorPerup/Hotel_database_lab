using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using BusinessLogic.ViewModels;
using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogic;
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

            try
            {
                var t = _clientLogic.Read(null);
                ClientBindingModel model = new ClientBindingModel
                {
                    Email = textBoxEmail.Text,
                    Password = textBoxPassword.Text,
                    Name = "",
                    Surname = "",
                    Middlename = "",
                    Birthday = DateTime.Now,
                    Pasport = 0
                };
                _clientLogic.CreateOrUpdate(model);
                Program.Client = _clientLogic.Read(model)?[0];
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
