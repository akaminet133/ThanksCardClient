using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class Category : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region NameProperty
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        #endregion

        #region Del_flgProperty
        private int _Del_flg;
        public int Del_flg
        {
            get { return _Del_flg; }
            set { SetProperty(ref _Del_flg, value); }
        }
        #endregion

        #region DepartmentIdProperty
        private long _DepartmentId;
        public long DepartmentId
        {
            get { return _DepartmentId; }
            set { SetProperty(ref _DepartmentId, value); }
        }
        #endregion

        #region DepartmentIdProperty
        private Department _Department;
        public Department Department
        {
            get { return _Department; }
            set { SetProperty(ref _Department, value); }
        }
        #endregion

        #region SelectedProperty
        private bool _Selected;

        // JSON シリアライズから除外する
        [JsonIgnore]
        public bool Selected
        {
            get { return _Selected; }
            set { SetProperty(ref _Selected, value); }
        }
        #endregion

        public async Task<List<Category>> GetCategorysAsync()
        {
            IRestService rest = new RestService();
            List<Category> Categorys = await rest.GetCategorysAsync();
            return Categorys;
        }

        public async Task<Category> PostCategoryAsync(Category Category)
        {
            IRestService rest = new RestService();
            Category createdCategory = await rest.PostCategoryAsync(Category);
            return createdCategory;
        }

        public async Task<Category> PutCategoryAsync(Category Category)
        {
            IRestService rest = new RestService();
            Category updatedCategory = await rest.PutCategoryAsync(Category);
            return updatedCategory;
        }

        public async Task<Category> DeleteCategoryAsync(long Id)
        {
            IRestService rest = new RestService();
            Category deletedCategory = await rest.DeleteCategoryAsync(Id);
            return deletedCategory;
        }


    }
}
