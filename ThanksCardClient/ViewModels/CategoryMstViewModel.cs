using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class CategoryMstViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region CategorysProperty
        private List<Category> _Categorys;
        public List<Category> Categorys
        {
            get { return _Categorys; }
            set { SetProperty(ref _Categorys, value); }
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

        public CategoryMstViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.UpdateCategorys();
        }

        private async void UpdateCategorys()
        {
            var Category = new Category();
            this.Categorys = await Category.GetCategorysAsync();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region CategoryCreateCommand
        private DelegateCommand _CategoryCreateCommand;
        public DelegateCommand CategoryCreateCommand =>
            _CategoryCreateCommand ?? (_CategoryCreateCommand = new DelegateCommand(ExecuteCategoryCreateCommand));

        void ExecuteCategoryCreateCommand()
        {
            System.Diagnostics.Debug.WriteLine("CategoryCreate");
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.CategoryCreate));
        }
        #endregion

        #region CategoryEditCommand
        private DelegateCommand<Category> _CategoryEditCommand;
        public DelegateCommand<Category> CategoryEditCommand =>
            _CategoryEditCommand ?? (_CategoryEditCommand = new DelegateCommand<Category>(ExecuteCategoryEditCommand));

        void ExecuteCategoryEditCommand(Category SelectedCategory)
        {
            // 対象のCategoryをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedCategory", SelectedCategory);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.CategoryEdit), parameters);
        }
        #endregion

        #region CategoryDeleteCommand
        private DelegateCommand<Category> _CategoryDeleteCommand;
        public DelegateCommand<Category> CategoryDeleteCommand =>
            _CategoryDeleteCommand ?? (_CategoryDeleteCommand = new DelegateCommand<Category>(ExecuteCategoryDeleteCommand));

        async void ExecuteCategoryDeleteCommand(Category SelectedCategory)
        {
            Category deletedCategory = await SelectedCategory.DeleteCategoryAsync(SelectedCategory.Id);

            // ユーザ一覧 Users を更新する。
            this.UpdateCategorys();
        }
        #endregion
    }
}
