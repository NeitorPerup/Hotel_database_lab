using System;
using System.Collections.Generic;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;

namespace BusinessLogic.Interfaces
{
    public interface IRoomStorage
    {
        List<RoomViewModel> GetFullList();

        List<RoomViewModel> GetFilteredList(RoomBindingModel model);

        RoomViewModel GetElement(RoomBindingModel model);

        void Insert(RoomBindingModel model);

        void Update(RoomBindingModel model);

        void Delete(RoomBindingModel model);
    }
}
