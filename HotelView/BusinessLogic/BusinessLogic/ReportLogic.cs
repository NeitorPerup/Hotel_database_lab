using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels.ReportModels;

namespace BusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        public readonly IReportStorage storage;

        public ReportLogic(IReportStorage report)
        {
            storage = report;
        }

        public List<ReportClientViewModel> GetClientInfo(ReportBindingModel model)
        {
            if (model == null || !model.ClientId.HasValue)
            {
                return null;
            }
            return storage.GetClientInfo(model);
        }

        public List<ReportRoomViewModel> GetRoomsInfo()
        {
            return storage.GetRoomInfo();
        }

        public List<ReportAccountingViewModel> GetAccountingInfo(ReportBindingModel model)
        {
            if (model == null || !model.DateFrom.HasValue || !model.DateTo.HasValue)
            {
                return null;
            }
            return storage.GetAccountingInfo(model);
        }
    }
}
