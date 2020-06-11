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
    public class FooterViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }

        public FooterViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
        }

        #region GotopCommand
        private DelegateCommand _gotopCommand;
        public DelegateCommand GotopCommand =>
            _gotopCommand ?? (_gotopCommand = new DelegateCommand(ExecuteGotopCommand));

        void ExecuteGotopCommand()
        {
            // HeaderRegion, FooterRegion を破棄して、ContentRegion をログオン後の画面に遷移させる。
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
            this.regionManager.RequestNavigate("MenuRegion", nameof(Views.Menu));
        }
        #endregion

        #region OpenmanualCommand
        private DelegateCommand _openmanualCommand;
        public DelegateCommand OpenmanualCommand =>
            _openmanualCommand ?? (_openmanualCommand = new DelegateCommand(ExecuteOpenManualCommand));

        void ExecuteOpenManualCommand()
        {
            var win = new PdfView();
        }
        #endregion

        #region LogoffCommand
        private DelegateCommand _logoffCommand;
        public DelegateCommand LogoffCommand =>
            _logoffCommand ?? (_logoffCommand = new DelegateCommand(ExecuteLogoffCommand));

        void ExecuteLogoffCommand()
        {
            SessionService.Instance.AuthorizedUser = null;
            SessionService.Instance.IsAuthorized = false;

            // HeaderRegion, FooterRegion を破棄して、ContentRegion をログオン画面に遷移させる。
            this.regionManager.Regions["HeaderRegion"].RemoveAll();
            this.regionManager.RequestNavigate("LogonRegion", nameof(Views.Logon));
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.Regions["MenuRegion"].RemoveAll();
            this.regionManager.Regions["ContentRegion"].RemoveAll();
        }
        #endregion
    }
}
