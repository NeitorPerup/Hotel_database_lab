using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;

namespace BusinessLogic.BusinessLogic
{
    public class AccountingLogic
    {
        private readonly IAccountingStorage _accountingStorage;

        public AccountingLogic(IAccountingStorage accountingStorage)
        {
            _accountingStorage = accountingStorage;
        }

        public List<AccountingViewModel> Read(AccountingBindingModel model)
        {
            if (model == null)
            {
                return _accountingStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<AccountingViewModel> { _accountingStorage.GetElement(model) };
            }
            return _accountingStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(AccountingBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _accountingStorage.Update(model);
            }
            else
            {
                _accountingStorage.Insert(model);
            }
        }

        public void Delete(AccountingBindingModel model)
        {
            var element = _accountingStorage.GetElement(new AccountingBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _accountingStorage.Delete(model);
        }
    }
}
