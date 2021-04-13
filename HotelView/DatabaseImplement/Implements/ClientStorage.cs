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
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using (var context = new HotelContext())
            {
                return context.Client.Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                })
                .ToList();
            }
        }

        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new HotelContext())
            {
                return context.Client
                .Where(rec => rec.Birthday == model.Birthday)
                .Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Surname = rec.Surname,
                    Middlename = rec.Middlename,
                    Pasport = rec.Pasport,
                    Birthday = rec.Birthday
                })
                .ToList();
            }
        }

        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new HotelContext())
            {
                var client = context.Client
                .FirstOrDefault(rec => rec.Id == model.Id || rec.Email == model.Email);
                return client != null ?
                new ClientViewModel
                {
                    Id = client.Id,
                    Name = client.Name,
                    Surname = client.Surname,
                    Middlename = client.Middlename,
                    Pasport = client.Pasport,
                    Birthday = client.Birthday,
                    Email = client.Email,
                    Password = client.Password
                } :
                null;
            }
        }

        public void Insert(ClientBindingModel model)
        {
            using (var context = new HotelContext())
            {
                context.Client.Add(CreateModel(model, new Client()));
                context.SaveChanges();
            }
        }

        public void Update(ClientBindingModel model)
        {
            using (var context = new HotelContext())
            {
                var element = context.Client.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ClientBindingModel model)
        {
            using (var context = new HotelContext())
            {
                Client element = context.Client.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Client.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.Name = model.Name;
            client.Middlename = model.Middlename;
            client.Surname = model.Surname;
            client.Pasport = model.Pasport;
            client.Birthday = model.Birthday;
            client.Email = model.Email;
            client.Password = model.Password;
            return client;
        }
    }
}
