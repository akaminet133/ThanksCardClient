using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class SectionCreateViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region SectionProperty
        private Section _Section;
        public Section Section
        {
            get { return _Section; }
            set { SetProperty(ref _Section, value); }
        }
        #endregion

        #region SectionsProperty
        private List<Section> _Sections;
        public List<Section> Sections
        {
            get { return _Sections; }
            set { SetProperty(ref _Sections, value); }
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

        #region ErrorMessageProperty
        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { SetProperty(ref _ErrorMessage, value); }
        }
        #endregion

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 画面遷移元から送られる SelectedCategory パラメーターを取得。
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentAsync();

            this.Section = new Section();
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public async void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // 画面遷移元から送られる SelectedCategory パラメーターを取得。
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentAsync();

            //throw new NotImplementedException();
        }

        public SectionCreateViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            this.Section = new Section();
        }

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            Section createdCategory = await Section.PostSectionAsync(this.Section);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.SectionMst));
        }
        #endregion

    }
}
