using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using BusinessLogic.BusinessLogic;
using DatabaseImplement.Implements;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using BusinessLogic.ViewModels;

namespace HotelView
{
    static class Program
    {
        public static ClientViewModel Client { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new UnityContainer().AddExtension(new Diagnostic());
            Application.Run(container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IAccountingStorage, AccountingStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientStorage, ClientStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICategoryStorage, CategoryStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPostStorage, PostStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRoomStorage, RoomStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStaffStorage, StaffStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportStorage, ReportStorage>(new
            HierarchicalLifetimeManager());

            currentContainer.RegisterType<AccountingLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ClientLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CategoryLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PostLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<RoomLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<StaffLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
