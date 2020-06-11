using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class ThanksCardCreateViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion

        #region FromUsersProperty
        private User _From;
        public User From
        {
            get { return _From; }
            set { SetProperty(ref _From, value); }
        }
        #endregion

        #region ToUsersProperty
        private List<User> _To;
        public List<User> To
        {
            get { return _To; }
            set { SetProperty(ref _To, value); }
        }
        #endregion

        /*
        #region SectionsProperty
        private List<Section> _Sections;
        public List<Section> Sections
        {
            get { return _Sections; }
            set { SetProperty(ref _Sections, value); }
        }
        #endregion
        */
        #region DepartmentsProperty
        private List<Department> _Departments;
        public List<Department> Departments
        {
            get { return _Departments; }
            set { SetProperty(ref _Departments, value); }
        }
        #endregion

        #region CategorysProperty
        private List<Category> _Categorys;
        public List<Category> Categorys
        {
            get { return _Categorys; }
            set { SetProperty(ref _Categorys, value); }
        }
        #endregion

        public ThanksCardCreateViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        // この画面に遷移し終わったときに呼ばれる。
        // それを利用し、画面表示に必要なプロパティを初期化している。
        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.ThanksCard = new ThanksCard();
            
            if (SessionService.Instance.AuthorizedUser != null)
            {
                this.From = SessionService.Instance.AuthorizedUser;
                this.ThanksCard.FromId = SessionService.Instance.AuthorizedUser.Id;
            }

            var User = new User();
            this.To = await User.GetUsersAsync();

            var Category = new Category();
            this.Categorys = await Category.GetCategorysAsync();

            //var sect = new Section();
            //this.Sections = await sect.GetSectionsAsync();

            //var dept = new Department();
            //this.Departments = await dept.GetDepartmentAsync();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
        /*
        #region FromDepartmentsChangedCommand
        private DelegateCommand<long?> _FromDepartmentsChangedCommand;
        public DelegateCommand<long?> FromDepartmentsChangedCommand =>
            _FromDepartmentsChangedCommand ?? (_FromDepartmentsChangedCommand = new DelegateCommand<long?>(ExecuteFromDepartmentsChangedCommand));

        async void ExecuteFromDepartmentsChangedCommand(long? FromDepartmentId)
        {
            this.FromUsers = await SessionService.Instance.AuthorizedUser.GetDepartmentUsersAsync(FromDepartmentId);
        }
        #endregion */

        /* #region ToDepartmentsChangedCommand
         private DelegateCommand<long?> _ToDepartmentsChangedCommand;
         public DelegateCommand<long?> ToDepartmentsChangedCommand =>
             _ToDepartmentsChangedCommand ?? (_ToDepartmentsChangedCommand = new DelegateCommand<long?>(ExecuteToDepartmentsChangedCommand));

         async void ExecuteToDepartmentsChangedCommand(long? ToDepartmentId)
         {
             this.ToUsers = await this.ToUsers.GetUsersAsync(ToDepartmentId);
         }
         #endregion */
        
        /*#region ToCategorysChangedCommand
        private DelegateCommand<long?> _ToCategorysChangedCommand;
        public DelegateCommand<long?> ToCategorysChangedCommand =>
        _ToCategorysChangedCommand ?? (_ToCategorysChangedCommand = new DelegateCommand<long?>(ExecuteToCategorysChangedCommand));

         async void ExecuteToCategorysChangedCommand(long? ToCategoryId)
        {
            this.Categorys = await this.Categorys.GetCategorysAsync(ToCategoryId);
         }
         #endregion*/

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            System.Diagnostics.Debug.WriteLine(this.Categorys);

            ThanksCard createdThanksCard = await ThanksCard.PostThanksCardAsync(this.ThanksCard);

            //TODO: Error handling
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));

        }
        #endregion
    }
}
