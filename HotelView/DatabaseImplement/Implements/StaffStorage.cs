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
    public class StaffStorage : IStaffStorage
    {
        public List<StaffViewModel> GetFullList()
        {
            using (var context = new HotelContext())
            {
                return context.Staff.Include(x => x.Post).Select(CreateModel)
                .ToList();
            }
        }

        public List<StaffViewModel> GetFilteredList(StaffBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new HotelContext())
            {
                return context.Staff.Include(x => x.Post)
                .Where(rec => rec.Employement.Date == model.Employement.Date)
                .Select(CreateModel)
                .ToList();
            }
        }

        public StaffViewModel GetElement(StaffBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new HotelContext())
            {
                var accounting = context.Staff.Include(x => x.Post)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return accounting != null ? CreateModel(accounting) :
                null;
            }
        }

        public void Insert(StaffBindingModel model)
        {
            using (var context = new HotelContext())
            {
                context.Staff.Add(CreateModel(model, new Staff(), context));
                context.SaveChanges();
            }
        }

        public void Update(StaffBindingModel model)
        {
            using (var context = new HotelContext())
            {
                var element = context.Staff.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
            }
        }

        public void Delete(StaffBindingModel model)
        {
            using (var context = new HotelContext())
            {
                Staff element = context.Staff.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Staff.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        private Staff CreateModel(StaffBindingModel model, Staff staff, HotelContext database)
        {
            staff.Name = model.Name;
            staff.Surname = model.Surname;
            staff.Middlename = model.Middlename;
            staff.Postid = model.Postid;
            staff.Birthday = model.Birthday;
            staff.Employement = model.Employement;
            return staff;
        }

        private StaffViewModel CreateModel(Staff staff)
        {
            StaffViewModel model = new StaffViewModel();
            model.Id = staff.Id;
            model.StaffFIO = $"{staff.Surname} {staff.Name} {staff.Middlename}";
            model.PostName = staff.Post.Name;
            model.Postid = staff.Post.Id;
            model.Birthday = staff.Birthday;
            model.Employement = staff.Employement;
            return model;
        }
    }
}
