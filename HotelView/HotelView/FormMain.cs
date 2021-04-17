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

        private readonly ReportLogic _reportLogic;

        public FormMain(ClientLogic clientLogic, ReportLogic report)
        {
            _clientLogic = clientLogic;
            _reportLogic = report;
            Program.Client = _clientLogic.Read(new ClientBindingModel { Email = "Admin" })?[0];
            InitializeComponent();
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            var list = _reportLogic.GetClientInfo(new ReportBindingModel { ClientId = Program.Client?.Id });
            if (list == null) { return; }
            dataGridView.DataSource = list;
            dataGridView.Columns[0].Visible = false;
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
            if (form.ShowDialog() == DialogResult.OK)
                RefreshDataGrid();
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
            if (form.ShowDialog() == DialogResult.OK)
                RefreshDataGrid();
        }

        private void ВсеКомнатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportRooms>();
            form.ShowDialog();
        }

        private void СчетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportAccounting>();
            form.ShowDialog();
        }

        private void входToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            var form = Container.Resolve<FormAutorization>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Успешно", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataGrid();
            }
        }

        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRegister>();
            if (form.ShowDialog() == DialogResult.OK)
                RefreshDataGrid();
        }
    }
}
