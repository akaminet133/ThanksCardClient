using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class CategoryEditViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region CategoryProperty
        private Category _Category;
        public Category Category
        {
            get { return _Category; }
            set { SetProperty(ref _Category, value); }
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

        public CategoryEditViewModel(IRegionManager regionManager)
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

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentAsync();
            // 画面遷移元から送られる SelectedUser パラメーターを取得。
            this.Category = navigationContext.Parameters.GetValue<Category>("SelectedCategory");
        }

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            Category updatedCategory = await this.Category.PutCategoryAsync(this.Category);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.CategoryMst));
        }
        #endregion

    }
}
