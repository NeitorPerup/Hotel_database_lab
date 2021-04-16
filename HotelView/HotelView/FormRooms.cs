using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Unity;
using BusinessLogic.BusinessLogic;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System.Windows.Forms;

namespace HotelView
{
    public partial class FormRooms : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private RoomLogic logic { get; set; }
        public FormRooms(RoomLogic roomLogic)
        {
            logic = roomLogic;
            InitializeComponent();
        }

        private void FormRooms_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var list = logic.Read(new RoomBindingModel { Available = true});
            //var list = logic.Read(null);
            if (list != null)
            {
                try
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in list)
                    {
                        dataGridView.Rows.Add(new object[]
                        { elem.Id, elem.Number, elem.Type, elem.Price, elem.RoomNumber, elem.Sleepingberths});
                        var av = elem.Available;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRoom>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormRoom>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Number = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                form.ShowDialog();
                LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                logic.Delete(new RoomBindingModel { Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value) });
                LoadData();
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
