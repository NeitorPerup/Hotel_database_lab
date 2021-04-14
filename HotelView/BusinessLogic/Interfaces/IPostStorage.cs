using System;
using System.Collections.Generic;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;

namespace BusinessLogic.Interfaces
{
    public interface IPostStorage
    {
        List<PostViewModel> GetFullList();

        List<PostViewModel> GetFilteredList(PostBindingModel model);

        PostViewModel GetElement(PostBindingModel model);

        void Insert(PostBindingModel model);

        void Update(PostBindingModel model);

        void Delete(PostBindingModel model);
    }
}
