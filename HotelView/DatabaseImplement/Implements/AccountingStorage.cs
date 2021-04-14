using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System.Linq;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseImplement.Implements
{
    public class AccountingStorage : IAccountingStorage
    {
        public List<AccountingViewModel> GetFullList()
        {
            using (var context = new HotelContext())
            {
                return context.Accounting.Select(rec => new AccountingViewModel
                {
                    Id = rec.Id,
                    Clientid = rec.Clientid,
                    Startdate = rec.Startdate,
                    Cost = rec.Cost,
                    Enddate = rec.Enddate,
                    Roomid = rec.Roomid
                })
                .ToList();
            }
        }

        public List<AccountingViewModel> GetFilteredList(AccountingBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new HotelContext())
            {
                return context.Accounting
                .Where(rec => rec.Enddate == model.Enddate)
                .Select(rec => new AccountingViewModel
                {
                    Id = rec.Id,
                    Clientid = rec.Clientid,
                    Startdate = rec.Startdate,
                    Cost = rec.Cost,
                    Enddate = rec.Enddate,
                    Roomid = rec.Roomid
                })
                .ToList();
            }
        }

        public AccountingViewModel GetElement(AccountingBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new HotelContext())
            {
                var accounting = context.Accounting
                .FirstOrDefault(rec => rec.Id == model.Id);
                return accounting != null ?
                new AccountingViewModel
                {
                    Id = accounting.Id,
                    Clientid = accounting.Clientid,
                    Startdate = accounting.Startdate,
                    Cost = accounting.Cost,
                    Enddate = accounting.Enddate,
                    Roomid = accounting.Roomid
                } :
                null;
            }
        }

        public void Insert(AccountingBindingModel model)
        {
            using (var context = new HotelContext())
            {
                context.Accounting.Add(CreateModel(model, new Accounting(), context));
                context.SaveChanges();
            }
        }

        public void Update(AccountingBindingModel model)
        {
            using (var context = new HotelContext())
            {
                var element = context.Accounting.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
            }
        }

        public void Delete(AccountingBindingModel model)
        {
            using (var context = new HotelContext())
            {
                Accounting element = context.Accounting.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Accounting.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        private Accounting CreateModel(AccountingBindingModel model, Accounting accounting, HotelContext database)
        {
            accounting.Clientid = model.Clientid;
            accounting.Startdate = model.Startdate;
            accounting.Cost = model.Cost;
            accounting.Enddate = model.Enddate;
            accounting.Roomid = model.Roomid;
            return accounting;
        }
    }
}
