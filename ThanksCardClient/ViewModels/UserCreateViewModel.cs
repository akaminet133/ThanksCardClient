using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class UserCreateViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region User_Dep_KanriProperty
        private User_Dep_Kanri _UDK;
        public User_Dep_Kanri UDK
        {
            get { return _UDK; }
            set { SetProperty(ref _UDK, value); }
        }
        #endregion

        #region UserProperty
        private User _User;
        public User User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }
        #endregion

        #region DepartmentsProperty
        private List<Department> _Departments;
        public List<Department> Departments
        {
            get { return _Departments; }
            set { SetProperty(ref _Departments, value); }
        }
        #endregion

        public UserCreateViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentAsync();

            this.User = new User();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            User createdUser = await User.PostUserAsync(this.User);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.UserMst));
        }
        #endregion
    }
}
