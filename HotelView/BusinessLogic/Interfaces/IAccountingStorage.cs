using System;
using System.Collections.Generic;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;


namespace BusinessLogic.Interfaces
{
    public interface IAccountingStorage
    {
        List<AccountingViewModel> GetFullList();

        List<AccountingViewModel> GetFilteredList(AccountingBindingModel model);

        AccountingViewModel GetElement(AccountingBindingModel model);

        void Insert(AccountingBindingModel model);

        void Update(AccountingBindingModel model);

        void Delete(AccountingBindingModel model);
    }
}
