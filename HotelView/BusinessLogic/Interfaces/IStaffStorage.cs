using System;
using System.Collections.Generic;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;

namespace BusinessLogic.Interfaces
{
    public interface IStaffStorage
    {
        List<StaffViewModel> GetFullList();

        List<StaffViewModel> GetFilteredList(StaffBindingModel model);

        StaffViewModel GetElement(StaffBindingModel model);

        void Insert(StaffBindingModel model);

        void Update(StaffBindingModel model);

        void Delete(StaffBindingModel model);
    }
}
