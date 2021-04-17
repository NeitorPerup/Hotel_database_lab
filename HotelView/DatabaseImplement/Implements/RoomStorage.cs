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
                return context.Room.Include(x => x.Category).Select(CreateFullModel)
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
                .Where(rec => rec.Available == model.Available)
                .Select(CreateFullModel)
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
                var client = context.Room.Include(x => x.Category)
                .FirstOrDefault(rec => rec.Id == model.Id || rec.Number == model.Number);
                return client != null ? CreateFullModel(client) : null;
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

        private Room CreateModel(RoomBindingModel model, Room room)
        {
            room.Available =  model.Available;
            room.Categoryid = model.Categoryid;
            room.Number = model.Number.Value;
            return room;
        }

        private RoomViewModel CreateModel(Room room)
        {
            RoomViewModel model = new RoomViewModel();
            model.Id = room.Id;
            model.Available = room.Available;
            model.Categoryid = room.Categoryid;
            model.Number = room.Number;
            return model;
        }

        private RoomViewModel CreateFullModel(Room room)
        {
            RoomViewModel model = CreateModel(room);
            model.Type = room.Category.Type;
            model.RoomNumber = room.Category.Roomnumber;
            model.Price = room.Category.Price;
            model.Sleepingberths = room.Category.Sleepingberths;
            return model;
        }
    }
}
