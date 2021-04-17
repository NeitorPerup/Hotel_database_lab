using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;

namespace BusinessLogic.BusinessLogic
{
    public class PostLogic
    {
        private readonly IPostStorage _clientStorage;

        public PostLogic(IPostStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }

        public List<PostViewModel> Read(PostBindingModel model)
        {
            if (model == null)
            {
                return _clientStorage.GetFullList();
            }
            if (model.Id.HasValue || model.Name != null)
            {
                return new List<PostViewModel> { _clientStorage.GetElement(model) };
            }
            return _clientStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PostBindingModel model)
        {
            var element = _clientStorage.GetElement(new PostBindingModel
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая должность");
            }
            if (model.Id.HasValue)
            {
                _clientStorage.Update(model);
            }
            else
            {
                _clientStorage.Insert(model);
            }
        }

        public void Delete(PostBindingModel model)
        {
            var element = _clientStorage.GetElement(new PostBindingModel
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
