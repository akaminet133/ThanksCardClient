using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class User : BindableBase
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

        #region F_NameProperty
        private string _F_Name;
        public string F_Name
        {
            get { return _F_Name; }
            set { SetProperty(ref _F_Name, value); }
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

        #region PasswordProperty
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }
        #endregion

        #region TelProperty
        private string _Tel;
        public string Tel
        {
            get { return _Tel; }
            set { SetProperty(ref _Tel, value); }
        }
        #endregion

        #region E_mailProperty
        private string _E_mail;
        public string E_mail
        {
            get { return _E_mail; }
            set { SetProperty(ref _E_mail, value); }
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

        #region IsUsersProperty
        private bool _IsUsers;
        public bool IsUsers
        {
            get { return _IsUsers; }
            set { SetProperty(ref _IsUsers, value); }
        }
        #endregion

        #region IsManagementProperty
        private bool _IsManagement;
        public bool IsManagement
        {
            get { return _IsManagement; }
            set { SetProperty(ref _IsManagement, value); }
        }
        #endregion

        #region IsAdminProperty
        private bool _IsAdmin;
        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set { SetProperty(ref _IsAdmin, value); }
        }

        #region User_Dep_KanriProperty
        private List<User_Dep_Kanri> _User_Dep_Kanris;
        public List<User_Dep_Kanri> User_Dep_Kanris
        {
            get { return _User_Dep_Kanris; }
            set { SetProperty(ref _User_Dep_Kanris, value); }
        }
        #endregion

        #endregion
        public async Task<User> LogonAsync()
        {
            IRestService rest = new RestService();
            User authorizedUser = await rest.LogonAsync(this);
            return authorizedUser;
        }

        /*public async Task<List<User>> GetDepartmentUsersAsync(long? DepartmentId)
        {
            IRestService rest = new RestService();
            List<User> users = await rest.GetDepartmentUsersAsync(DepartmentId);
            return users;
        }*/

        public async Task<List<User>> GetUsersAsync()
        {
            IRestService rest = new RestService();
            List<User> users = await rest.GetUsersAsync();
            return users;
        }

        public async Task<User> PostUserAsync(User user)
        {
            IRestService rest = new RestService();
            User createdUser = await rest.PostUserAsync(user);
            return createdUser;
        }

        public async Task<User> PutUserAsync(User user)
        {
            IRestService rest = new RestService();
            User updatedUser = await rest.PutUserAsync(user);
            return updatedUser;
        }

        public async Task<User> DeleteUserAsync(long Id)
        {
            IRestService rest = new RestService();
            User deletedUser = await rest.DeleteUserAsync(Id);
            return deletedUser;
        }
    }
}
