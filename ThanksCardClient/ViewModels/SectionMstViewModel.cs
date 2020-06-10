using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class SectionMstViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

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

        public SectionMstViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.UpdateSections();
        }

        private async void UpdateSections()
        {
            Section dept = new Section();
            this.Sections = await dept.GetSectionsAsync();
        }

        #region SectionCreateCommand
        private DelegateCommand _SectionCreateCommand;
        public DelegateCommand SectionCreateCommand =>
            _SectionCreateCommand ?? (_SectionCreateCommand = new DelegateCommand(ExecuteSectionCreateCommand));

        void ExecuteSectionCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.SectionCreate));
        }
        #endregion

        #region SectionEditCommand
        private DelegateCommand<Section> _SectionEditCommand;
        public DelegateCommand<Section> SectionEditCommand =>
            _SectionEditCommand ?? (_SectionEditCommand = new DelegateCommand<Section>(ExecuteSectionEditCommand));

        void ExecuteSectionEditCommand(Section SelectedSection)
        {
            // 対象のSectionをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedSection", SelectedSection);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.SectionEdit), parameters);
        }
        #endregion

        #region SectionDeleteCommand
        private DelegateCommand<Section> _SectionDeleteCommand;
        public DelegateCommand<Section> SectionDeleteCommand =>
            _SectionDeleteCommand ?? (_SectionDeleteCommand = new DelegateCommand<Section>(ExecuteSectionDeleteCommand));

        async void ExecuteSectionDeleteCommand(Section SelectedSection)
        {
            Section deletedSection = await SelectedSection.DeleteSectionAsync(SelectedSection.Id);

            // 一覧 Sections を更新する。
            this.UpdateSections();
        }
        #endregion
    }
}
