using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels.ReportModels;

namespace DatabaseImplement.Implements
{
    public class ReportStorage : IReportStorage
    {
        public List<ReportClientViewModel> GetClientInfo(ReportBindingModel model)
        {
            using (var context = new HotelContext())
            {
                var client = context.Client.Include(x => x.Accounting).ThenInclude(x => x.Room)
                    .FirstOrDefault(x => x.Id == model.ClientId);
                if (client == null)
                {
                    throw new Exception("Клиент не найден");
                }
                return client.Accounting.Select(x => new ReportClientViewModel
                {
                    ClientFIO = $"{client.Surname} {client.Name} {client.Middlename}",
                    ClientId = client.Id,
                    Birthday = client.Birthday,
                    Pasport = client.Pasport,
                    RoomNumber = x.Room.Number,
                    StartDate = x.Startdate,
                    EndDate = x.Enddate
                }).ToList();
            }
        }

        public List<ReportRoomViewModel> GetRoomInfo()
        {
            using (var context = new HotelContext())
            {
                return context.Room.Include(x => x.Category).Select(x =>
                    new ReportRoomViewModel
                    {
                        RoomId = x.Id,
                        Number = x.Number,
                        Type = x.Category.Type,
                        Price = x.Category.Price,
                        RoomNumber = x.Category.Roomnumber,
                        SleepingBerths = x.Category.Sleepingberths
                    }).ToList();
            }
        }

        public List<ReportAccountingViewModel> GetAccountingInfo(ReportBindingModel model)
        {
            using (var context = new HotelContext())
            {
                return context.Accounting.Include(x => x.Room).Include(x => x.Client)
                    .Where(x => x.Startdate.Date >= model.DateFrom.Value.Date
                    && x.Startdate.Date <= model.DateTo.Value.Date)
                    .Select(x => new ReportAccountingViewModel
                    {
                        ClientFIO = $"{x.Client.Surname} {x.Client.Name} {x.Client.Middlename}",
                        ClientId = x.Client.Id,
                        Number = x.Room.Number,
                        Cost = x.Cost,
                        StartDate = x.Startdate,
                        EndDate = x.Enddate
                    }).ToList();                
            }
        }
    }
}
