using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using BusinessLogic.ViewModels;
using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogic;
using System.Windows.Forms;

namespace HotelView
{
    public partial class FormAutorization : Form
    {
        private readonly ClientLogic _clientLogic;

        public FormAutorization(ClientLogic userLogic)
        {
            _clientLogic = userLogic;
            InitializeComponent();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните поле Email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните поле пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var client = _clientLogic.Read(new ClientBindingModel { Email = textBoxEmail.Text, Password = textBoxPassword.Text })?[0];
            if (client == null)
            {
                MessageBox.Show("Неверный Email или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Program.Client = client;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
