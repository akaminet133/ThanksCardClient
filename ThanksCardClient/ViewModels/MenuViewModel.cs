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
    public class MenuViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }

        public MenuViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
        }

        #region ShowThanksCardCreateCommand
        private DelegateCommand _ShowThanksCardCreateCommand;
        public DelegateCommand ShowThanksCardCreateCommand =>
            _ShowThanksCardCreateCommand ?? (_ShowThanksCardCreateCommand = new DelegateCommand(ExecuteShowThanksCardCreateCommand));

        void ExecuteShowThanksCardCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardCreate));
        }
        #endregion

        #region ShowThanksCardListCommand
        private DelegateCommand _ShowThanksCardListCommand;
        public DelegateCommand ShowThanksCardListCommand =>
            _ShowThanksCardListCommand ?? (_ShowThanksCardListCommand = new DelegateCommand(ExecuteShowThanksCardListCommand));

        void ExecuteShowThanksCardListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion

        #region ShowUsersCommand
        private DelegateCommand _ShowUser_Kanri_MenuCommand;
        public DelegateCommand ShowUser_Kanri_MenuCommand =>
            _ShowUser_Kanri_MenuCommand ?? (_ShowUser_Kanri_MenuCommand = new DelegateCommand(ExecuteShowUser_Kanri_MenuCommand));
        void ExecuteShowUser_Kanri_MenuCommand()
        {
            this.regionManager.Regions["ContentRegion"].RemoveAll();
            this.regionManager.RequestNavigate("MenuRegion", nameof(Views.User_Kanri_Menu));
        }
        #endregion

        /*
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
        #endregion*/

        /*#region ShowCategoryMstCommand
        private DelegateCommand _ShowCategoryMstCommand;
        public DelegateCommand ShowCategoryMstCommand =>
            _ShowCategoryMstCommand ?? (_ShowCategoryMstCommand = new DelegateCommand(ExecuteShowCategoryMstCommand));

        void ExecuteCreatePdfCommand()
        {
            
        }
        #endregion*/

        #region ShowManagementMstCommand
        private DelegateCommand _ShowManagementMstCommand;
        public DelegateCommand ShowManagementMstCommand =>
            _ShowManagementMstCommand ?? (_ShowManagementMstCommand = new DelegateCommand(ExecuteShowManagementMstCommand));

        void ExecuteShowManagementMstCommand()
        {
            System.Windows.Forms.MessageBox.Show("ファイルを上書きしますか？",
        "質問",
        MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Exclamation,
        MessageBoxDefaultButton.Button2);
        }
        #endregion
    }
}
