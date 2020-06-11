using ThanksCardClient.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace ThanksCardClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow>();
            containerRegistry.RegisterForNavigation<Header>();
            containerRegistry.RegisterForNavigation<Logon>();
            containerRegistry.RegisterForNavigation<Footer>();
            containerRegistry.RegisterForNavigation<ThanksCardCreate>();
            containerRegistry.RegisterForNavigation<ThanksCardList>();
            containerRegistry.RegisterForNavigation<UserMst>();
            containerRegistry.RegisterForNavigation<UserCreate>();
            containerRegistry.RegisterForNavigation<UserEdit>();
            containerRegistry.RegisterForNavigation<DepartmentMst>();
            containerRegistry.RegisterForNavigation<DepartmentCreate>();
            containerRegistry.RegisterForNavigation<DepartmentEdit>();
            containerRegistry.RegisterForNavigation<SectionMst>();
            containerRegistry.RegisterForNavigation<SectionCreate>();
            containerRegistry.RegisterForNavigation<SectionEdit>();
            containerRegistry.RegisterForNavigation<CategoryMst>();
            containerRegistry.RegisterForNavigation<CategoryCreate>();
            containerRegistry.RegisterForNavigation<CategoryEdit>();
            containerRegistry.RegisterForNavigation<Menu>();
            containerRegistry.RegisterForNavigation<User_Kanri_Menu>();

        }
    }
}
