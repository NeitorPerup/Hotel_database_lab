using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;

namespace BusinessLogic.BusinessLogic
{
    public class RoomLogic
    {
        private readonly IRoomStorage _roomStorage;

        public RoomLogic(IRoomStorage clientStorage)
        {
            _roomStorage = clientStorage;
        }

        public List<RoomViewModel> Read(RoomBindingModel model)
        {
            if (model == null)
            {
                return _roomStorage.GetFullList();
            }
            if (model.Id.HasValue || model.Number.HasValue)
            {
                return new List<RoomViewModel> { _roomStorage.GetElement(model) };
            }
            return _roomStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(RoomBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _roomStorage.Update(model);
            }
            else
            {
                if (_roomStorage.GetElement(model)?.Number == model.Number)
                    throw new Exception("Комната с таким номером уже существует");
                _roomStorage.Insert(model);
            }
        }

        public void Delete(RoomBindingModel model)
        {
            var element = _roomStorage.GetElement(new RoomBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _roomStorage.Delete(model);
        }
    }
}
