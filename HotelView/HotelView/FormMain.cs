using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Unity;
using BusinessLogic.ViewModels;
using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogic;

namespace HotelView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ClientLogic _clientLogic;

        public FormMain(ClientLogic clientLogic)
        {
            _clientLogic = clientLogic;
            Program.Client = _clientLogic.Read(new ClientBindingModel { Email = "user" })?[0];
            InitializeComponent();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRegister>();
            form.ShowDialog();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAutorization>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Успешно", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonClientData_Click(object sender, EventArgs e)
        {
            if (Program.Client == null)
            {
                MessageBox.Show("Необходимо авторизироваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = Container.Resolve<FormClientData>();
            form.ShowDialog();
        }
    }
}
