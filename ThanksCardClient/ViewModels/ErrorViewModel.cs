using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;
using System.Runtime.InteropServices;
using ThanksCardClient.Views;


namespace ThanksCardClient.ViewModels
{
    class ErrorViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }

        public ErrorViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
        }

        #region BackCommand
        private DelegateCommand _gotopCommand;
        public DelegateCommand GotopCommand =>
            _gotopCommand ?? (_gotopCommand = new DelegateCommand(ExecuteBackCommand));

        void ExecuteBackCommand()
        {
            this.regionManager.RequestNavigate("LogonRegion", nameof(Views.Logon));
        }
        #endregion
    }
}
