using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Unity;
using BusinessLogic.Enums;
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
            Program.Client = _clientLogic.Read(new ClientBindingModel { Email = "Admin" })?[0];
            InitializeComponent();
        }

        private bool ClientDataCheck()
        {
            var client = Program.Client;
            if (string.IsNullOrEmpty(client.Name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(client.Middlename))
            {
                return false;
            }
            if (string.IsNullOrEmpty(client.Pasport))
            {
                return false;
            }
            if (client.Birthday == null)
            {
                return false;
            }
            return true;
        }

        private void комнатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = AdminCheck();
            if (message != null)
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = Container.Resolve<FormRooms>();
            form.ShowDialog();
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = AdminCheck();
            if (message != null){
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = Container.Resolve<FormCategories>();
            form.ShowDialog();
        }

        private void персоналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = AdminCheck();
            if (message != null)
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = Container.Resolve<FormStaffs>();
            form.ShowDialog();
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = AdminCheck();
            if (message != null)
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = Container.Resolve<FormPosts>();
            form.ShowDialog();
        }

        private string AdminCheck()
        {
            if (Program.Client == null){ return "Необходимо авторизироваться"; }
            if (Program.Client.Status != UserRoles.Администратор) { return "Недостаточно прав"; }
            return null;
        }

        private void личныеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.Client == null)
            {
                MessageBox.Show("Необходимо авторизироваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = Container.Resolve<FormClientData>();
            form.ShowDialog();
        }

        private void снятьКомнатуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.Client == null)
            {
                MessageBox.Show("Необходимо авторизироваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ClientDataCheck())
            {
                MessageBox.Show("Необходимо заполнить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = Container.Resolve<FormClientRentRoom>();
            form.ShowDialog();
        }

        private void отчёт1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void отчёт2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void входToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            var form = Container.Resolve<FormAutorization>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Успешно", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRegister>();
            form.ShowDialog();
        }
    }
}
