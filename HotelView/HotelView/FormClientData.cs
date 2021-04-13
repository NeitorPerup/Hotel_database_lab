﻿using System;
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
    public partial class FormClientData : Form
    {
        private readonly ClientLogic _clientLogic;

        public FormClientData(ClientLogic clientLogic)
        {
            _clientLogic = clientLogic;
            InitializeComponent();
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
            if (string.IsNullOrEmpty(textBoxPasport.Text))
            {
                MessageBox.Show("Заполните паспортные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ClientBindingModel client = new ClientBindingModel
                {
                    Id = Program.Client.Id,
                    Email = Program.Client.Email,
                    Password = Program.Client.Password,
                    Name = textBoxName.Text,
                    Surname = textBoxSurname.Text,
                    Middlename = textBoxMiddlename.Text,
                    Pasport = Convert.ToInt32(textBoxPasport.Text),
                    Birthday = dateTimePicker.Value
                };
                _clientLogic.CreateOrUpdate(client);
                MessageBox.Show("Изменено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}