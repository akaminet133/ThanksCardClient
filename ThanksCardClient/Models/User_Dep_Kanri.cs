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
    public class User_Dep_Kanri : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        /**#region Del_flgProperty
        private int _Del_flg;
        public int Del_flg
        {
            get { return _Del_flg; }
            set { SetProperty(ref _Del_flg, value); }
        }
        #endregion*/

        #region UserIdProperty
        private long _UserId;
        public long UserId
        {
            get { return _UserId; }
            set { SetProperty(ref _UserId, value); }
        }
        #endregion

        #region UserProperty
        private User _User;
        public User User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }
        #endregion

        #region SectionIdProperty
        private long _SectionId;
        public long SectionId
        {
            get { return _SectionId; }
            set { SetProperty(ref _SectionId, value); }
        }
        #endregion

        #region SectionProperty
        private Section _Section;
        public Section Section
        {
            get { return _Section; }
            set { SetProperty(ref _Section, value); }
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

        public async Task<List<User_Dep_Kanri>> GetUser_Dep_KanrisAsync()
        {
            IRestService rest = new RestService();
            List<User_Dep_Kanri> User_Dep_Kanris = await rest.GetUser_Dep_KanrisAsync();
            return User_Dep_Kanris;
        }

        public async Task<User_Dep_Kanri> PostUser_Dep_KanriAsync(User_Dep_Kanri User_Dep_Kanri)
        {
            IRestService rest = new RestService();
            User_Dep_Kanri createdUser_Dep_Kanri = await rest.PostUser_Dep_KanriAsync(User_Dep_Kanri);
            return createdUser_Dep_Kanri;
        }

        public async Task<User_Dep_Kanri> PutUser_Dep_KanriAsync(User_Dep_Kanri User_Dep_Kanri)
        {
            IRestService rest = new RestService();
            User_Dep_Kanri updatedUser_Dep_Kanri = await rest.PutUser_Dep_KanriAsync(User_Dep_Kanri);
            return updatedUser_Dep_Kanri;
        }

        public async Task<User_Dep_Kanri> DeleteUser_Dep_KanriAsync(long Id)
        {
            IRestService rest = new RestService();
            User_Dep_Kanri deletedUser_Dep_Kanri = await rest.DeleteUser_Dep_KanriAsync(Id);
            return deletedUser_Dep_Kanri;
        }
    }
}
