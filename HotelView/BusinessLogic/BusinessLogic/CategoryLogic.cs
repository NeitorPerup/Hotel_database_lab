using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;

namespace BusinessLogic.BusinessLogic
{
    public class CategoryLogic
    {
        private readonly ICategoryStorage _clientStorage;

        public CategoryLogic(ICategoryStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }

        public List<CategoryViewModel> Read(CategoryBindingModel model)
        {
            if (model == null)
            {
                return _clientStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CategoryViewModel> { _clientStorage.GetElement(model) };
            }
            return _clientStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CategoryBindingModel model)
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

        public void Delete(CategoryBindingModel model)
        {
            var element = _clientStorage.GetElement(new CategoryBindingModel
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
