using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

//Departmentクラス
namespace ThanksCardClient.Models
{
    public class Department : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region CdProperty
        private string _Cd;
        public string Cd
        {
            get { return _Cd; }
            set { SetProperty(ref _Cd, value); }
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

        #region SectionsProperty
        private List<Section> _Sections;
        public List<Section> Sections
        {
            get { return _Sections; }
            set { SetProperty(ref _Sections, value); }
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

        public async Task<List<Department>> GetDepartmentAsync()
        {
            IRestService rest = new RestService();
            List<Department> Departments = await rest.GetDepartmentsAsync();
            return Departments;
        }

        public async Task<Department> PostDepartmentAsync(Department Department)
        {
            IRestService rest = new RestService();
            Department createdDepartment = await rest.PostDepartmentAsync(Department);
            return createdDepartment;
        }

        public async Task<Department> PutDepartmentAsync(Department department)
        {
            IRestService rest = new RestService();
            Department updatedDepartment = await rest.PutDepartmentAsync(department);
            return updatedDepartment;
        }

        public async Task<Department> DeleteDepartmentAsync(long Id)
        {
            IRestService rest = new RestService();
            Department deletedDepartment = await rest.DeleteDepartmentAsync(Id);
            return deletedDepartment;
        }
    }
}
