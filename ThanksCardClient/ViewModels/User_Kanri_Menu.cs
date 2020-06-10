using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;
using System.Speech;
using System.Windows.Forms;

namespace ThanksCardClient.ViewModels
{
    public class User_Kanri_MenuViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }

        public User_Kanri_MenuViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
        }

        #region ShowUserMstCommand
        private DelegateCommand _ShowUserMstCommand;
        public DelegateCommand ShowUserMstCommand =>
            _ShowUserMstCommand ?? (_ShowUserMstCommand = new DelegateCommand(ExecuteShowUserMstCommand));

        void ExecuteShowUserMstCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.UserMst));
        }
        #endregion

        #region ShowDepartmentMstCommand
        private DelegateCommand _ShowDepartmentMstCommand;
        public DelegateCommand ShowDepartmentMstCommand =>
            _ShowDepartmentMstCommand ?? (_ShowDepartmentMstCommand = new DelegateCommand(ExecuteShowDepartmentMstCommand));

        void ExecuteShowDepartmentMstCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentMst));
        }
        #endregion

        #region ShowSectionMstCommand
        private DelegateCommand _ShowSectionMstCommand;
        public DelegateCommand ShowSectionMstCommand =>
            _ShowSectionMstCommand ?? (_ShowSectionMstCommand = new DelegateCommand(ExecuteShowSectionMstCommand));

        void ExecuteShowSectionMstCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.SectionMst));
        }
        #endregion

        #region ShowCategoryMstCommand
        private DelegateCommand _ShowCategoryMstCommand;
        public DelegateCommand ShowCategoryMstCommand =>
            _ShowCategoryMstCommand ?? (_ShowCategoryMstCommand = new DelegateCommand(ExecuteShowCategoryMstCommand));

        void ExecuteShowCategoryMstCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.CategoryMst));
        }
        #endregion
    }
}
