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
    public partial class FormClientRentRoom : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private RoomLogic LogicR { get; set; }

        public FormClientRentRoom(RoomLogic roomLogic)
        {
            LogicR = roomLogic;
            InitializeComponent();
        }

        private void ButtonRent_Click(object sender, EventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormClientRentRoom_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var list = LogicR.Read(new RoomBindingModel { Available = false});
            if (list != null)
            {
                try
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in list)
                    {
                        dataGridView.Rows.Add(new object[]
                        { elem.Number, elem.Type, elem.Price, elem.RoomNumber, elem.Sleepingberths});
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
