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
    public class PostStorage : IPostStorage
    {
        public List<PostViewModel> GetFullList()
        {
            using (var context = new HotelContext())
            {
                return context.Post.Include(x => x.Staff).Select(rec => new PostViewModel
                {
                    Id = rec.Id,
                    Count = rec.Count,
                    Salary = rec.Salary,
                    Name = rec.Name,
                    Staff = rec.Staff.ToDictionary(x => x.Id, x => x.Name)
                })
                .ToList();
            }
        }

        public List<PostViewModel> GetFilteredList(PostBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new HotelContext())
            {
                return context.Post
                .Where(rec => rec.Salary == model.Salary)
                .Select(rec => new PostViewModel
                {
                    Id = rec.Id,
                    Count = rec.Count,
                    Salary = rec.Salary,
                    Name = rec.Name,
                    Staff = rec.Staff.ToDictionary(x => x.Id, x => x.Name)
                })
                .ToList();
            }
        }

        public PostViewModel GetElement(PostBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new HotelContext())
            {
                var accounting = context.Post
                .FirstOrDefault(rec => rec.Id == model.Id);
                return accounting != null ?
                new PostViewModel
                {
                    Id = accounting.Id,
                    Count = accounting.Count,
                    Salary = accounting.Salary,
                    Name = accounting.Name,
                    Staff = accounting.Staff.ToDictionary(x => x.Id, x => x.Name)
                } :
                null;
            }
        }

        public void Insert(PostBindingModel model)
        {
            using (var context = new HotelContext())
            {
                context.Post.Add(CreateModel(model, new Post(), context));
                context.SaveChanges();
            }
        }

        public void Update(PostBindingModel model)
        {
            using (var context = new HotelContext())
            {
                var element = context.Post.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
            }
        }

        public void Delete(PostBindingModel model)
        {
            using (var context = new HotelContext())
            {
                Post element = context.Post.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Post.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        private Post CreateModel(PostBindingModel model, Post accounting, HotelContext database)
        {
            accounting.Count = model.Count;
            accounting.Salary = model.Salary;
            accounting.Name = model.Name;
            return accounting;
        }
    }
}
