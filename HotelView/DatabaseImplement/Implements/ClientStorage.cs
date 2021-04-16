using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.Enums;
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
                return context.Client.Include(x => x.Accounting).Select(CreateModel)
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
                return context.Client.Include(x => x.Accounting)
                .Where(rec => rec.Birthday == model.Birthday)
                .Select(CreateModel)
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
                var client = context.Client.Include(x => x.Accounting)
                .FirstOrDefault(rec => rec.Id == model.Id || rec.Email == model.Email);
                return client != null ? CreateModel(client) : null;
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
            client.Status = Convert.ToInt32(model.Status);
            return client;
        }

        private ClientViewModel CreateModel(Client client)
        {
            ClientViewModel model = new ClientViewModel();
            model.Id = client.Id;
            model.Name = client.Name;
            model.Surname = client.Surname;
            model.Middlename = client.Middlename;
            model.Accounting = client.Accounting.ToDictionary(x => x.Id, x => x.Cost);
            model.Pasport = client.Pasport;
            model.Birthday = client.Birthday;
            model.Email = client.Email;
            model.Password = client.Password;
            model.Status = (UserRoles)client.Status;           
            return model;
        }
    }
}
