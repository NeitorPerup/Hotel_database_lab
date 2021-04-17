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
                return context.Post.Include(x => x.Staff).Select(CreateModel)
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
                .Select(CreateModel)
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
                .FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
                return accounting != null ? CreateModel(accounting) :
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

        private Post CreateModel(PostBindingModel model, Post post, HotelContext context)
        {
            post.Count = post.Count;
            post.Salary = model.Salary;
            post.Name = model.Name;
            return post;
        }

        private PostViewModel CreateModel(Post post)
        {
            PostViewModel model = new PostViewModel();
            model.Id = post.Id;
            model.Name = post.Name;
            model.Salary = post.Salary;
            model.Count = post.Count;
            model.Staff = post.Staff.ToDictionary(x => x.Id, x => x.Name);
            return model;
        }
    }
}
