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
    public class CategoryStorage : ICategoryStorage
    {
        public List<CategoryViewModel> GetFullList()
        {
            using (var context = new HotelContext())
            {
                return context.Category.Include(x => x.Room).Select(CreateModel)
                .ToList();
            }
        }

        public List<CategoryViewModel> GetFilteredList(CategoryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new HotelContext())
            {
                return context.Category.Include(x => x.Room)
                .Where(rec => rec.Type == model.Type)
                .Select(CreateModel)
                .ToList();
            }
        }

        public CategoryViewModel GetElement(CategoryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new HotelContext())
            {
                var accounting = context.Category.Include(x => x.Room)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return accounting != null ? CreateModel(accounting) :
                null;
            }
        }

        public void Insert(CategoryBindingModel model)
        {
            using (var context = new HotelContext())
            {
                context.Category.Add(CreateModel(model, new Category(), context));
                context.SaveChanges();
            }
        }

        public void Update(CategoryBindingModel model)
        {
            using (var context = new HotelContext())
            {
                var element = context.Category.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
            }
        }

        public void Delete(CategoryBindingModel model)
        {
            using (var context = new HotelContext())
            {
                Category element = context.Category.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Category.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        private Category CreateModel(CategoryBindingModel model, Category accounting, HotelContext database)
        {
            accounting.Type = model.Type;
            accounting.Price = model.Price;
            accounting.Roomnumber = model.Roomnumber;
            accounting.Sleepingberths = model.Sleepingberths;
            return accounting;
        }

        private CategoryViewModel CreateModel(Category category)
        {
            CategoryViewModel model = new CategoryViewModel();
            model.Id = category.Id;
            model.Type = category.Type;
            model.Price = category.Price;
            model.Sleepingberths = category.Sleepingberths;
            model.Roomnumber = category.Roomnumber;
            model.Rooms = category.Room.ToDictionary(x => x.Id, x => x.Number);
            return model;
        }
    }
}
