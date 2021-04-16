using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;

namespace BusinessLogic.BusinessLogic
{
    public class StaffLogic
    {
        private readonly IStaffStorage _clientStorage;

        public StaffLogic(IStaffStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }

        public List<StaffViewModel> Read(StaffBindingModel model)
        {
            if (model == null)
            {
                return _clientStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<StaffViewModel> { _clientStorage.GetElement(model) };
            }
            return _clientStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(StaffBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _clientStorage.Update(model);
            }
            else
            {
                _clientStorage.Insert(model);
            }
        }

        public void Delete(StaffBindingModel model)
        {
            var element = _clientStorage.GetElement(new StaffBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _clientStorage.Delete(model);
        }
    }
}
