using System;
using System.Collections;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System.Linq;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseImplement.Implements
{
    public class RoomStorage : IRoomStorage
    {
        public List<RoomViewModel> GetFullList()
        {
            using (var context = new HotelContext())
            {
                return context.Room.Include(x => x.Category).Select(rec => new RoomViewModel
                {
                    Id = rec.Id,
                    Available = Convert.ToBoolean(rec.Available),
                    Categoryid = rec.Categoryid,
                    Number = rec.Number,
                    Type = rec.Category.Type,
                    RoomNumber = rec.Category.Roomnumber,
                    Price = rec.Category.Price,
                    Sleepingberths = rec.Category.Sleepingberths
                })
                .ToList();
            }
        }

        public List<RoomViewModel> GetFilteredList(RoomBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new HotelContext())
            {
                return context.Room.Include(x => x.Category)
                .Where(rec => Convert.ToBoolean(rec.Available) == model.Available)
                .Select(rec => new RoomViewModel
                {
                    Id = rec.Id,
                    Available = Convert.ToBoolean(rec.Available),
                    Categoryid = rec.Categoryid,
                    Number = rec.Number,
                    Type = rec.Category.Type,
                    RoomNumber = rec.Category.Roomnumber,
                    Price = rec.Category.Price,
                    Sleepingberths = rec.Category.Sleepingberths
                })
                .ToList();
            }
        }

        public RoomViewModel GetElement(RoomBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new HotelContext())
            {
                var client = context.Room
                .FirstOrDefault(rec => rec.Id == model.Id);
                return client != null ?
                new RoomViewModel
                {
                    Id = client.Id,
                    Available = Convert.ToBoolean(client.Available),
                    Categoryid = client.Categoryid,
                    Number = client.Number
                } :
                null;
            }
        }

        public void Insert(RoomBindingModel model)
        {
            using (var context = new HotelContext())
            {
                context.Room.Add(CreateModel(model, new Room()));
                context.SaveChanges();
            }
        }

        public void Update(RoomBindingModel model)
        {
            using (var context = new HotelContext())
            {
                var element = context.Room.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(RoomBindingModel model)
        {
            using (var context = new HotelContext())
            {
                Room element = context.Room.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Room.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        private Room CreateModel(RoomBindingModel model, Room client)
        {
            client.Available = new BitArray(1, model.Available);
            client.Categoryid = model.Categoryid;
            client.Number = model.Number;
            return client;
        }
    }
}
