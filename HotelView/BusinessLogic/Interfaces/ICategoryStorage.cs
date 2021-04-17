using System;
using System.Collections.Generic;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;


namespace BusinessLogic.Interfaces
{
    public interface ICategoryStorage
    {
        List<CategoryViewModel> GetFullList();

        List<CategoryViewModel> GetFilteredList(CategoryBindingModel model);

        CategoryViewModel GetElement(CategoryBindingModel model);

        void Insert(CategoryBindingModel model);

        void Update(CategoryBindingModel model);

        void Delete(CategoryBindingModel model);
    }
}
