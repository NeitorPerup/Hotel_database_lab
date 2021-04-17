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

        private AccountingLogic LogicA { get; set; }

        public FormClientRentRoom(RoomLogic roomLogic, AccountingLogic accounting)
        {
            LogicR = roomLogic;
            LogicA = accounting;
            InitializeComponent();
        }

        private void ButtonRent_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormRentRoomDate>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var room = LogicR.Read(new RoomBindingModel { Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value) })?[0];
                        var dateFrom = form.RentDateFrom;
                        var dateTo = form.RentDateTo;
                        LogicA.CreateOrUpdate(new AccountingBindingModel
                        {
                            Clientid = Program.Client.Id,
                            Roomid = room.Id,
                            Cost = ((dateTo.Date - dateFrom.Date).Days * room.Price).Value,
                            Startdate = dateFrom,
                            Enddate = dateTo
                        });
                        MessageBox.Show("Успешно", "Комната снята", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var list = LogicR.Read(new RoomBindingModel { Available = true});
            if (list != null)
            {
                try
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in list)
                    {
                        dataGridView.Rows.Add(new object[]
                        {elem.Id, elem.Number, elem.Type, elem.Price, elem.RoomNumber, elem.Sleepingberths});
                        var av = elem.Available;
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
