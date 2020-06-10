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
    public class Section : BindableBase
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

        #region DepartmentIdProperty
        private long _DepartmentId;
            public long DepartmentId
        {
                get { return _DepartmentId; }
                set { SetProperty(ref _DepartmentId, value); }
            }
        #endregion

        #region DepartmentProperty
        private Department _Department;
        public Department Department
        {
            get { return _Department; }
            set { SetProperty(ref _Department, value); }
        }
        #endregion

        #region User_Dep_KanriProperty
        private List<User_Dep_Kanri> _User_Dep_Kanri;
            public List<User_Dep_Kanri> User_Dep_Kanri
        {
                get { return _User_Dep_Kanri; }
                set { SetProperty(ref _User_Dep_Kanri, value); }
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

            public async Task<List<Section>> GetSectionsAsync()
            {
                IRestService rest = new RestService();
                List<Section> Sections = await rest.GetSectionsAsync();
                return Sections;
            }

            public async Task<Section> PostSectionAsync(Section Section)
            {
                IRestService rest = new RestService();
                Section createdSection = await rest.PostSectionAsync(Section);
                return createdSection;
            }

            public async Task<Section> PutSectionAsync(Section Section)
            {
                IRestService rest = new RestService();
                Section updatedSection = await rest.PutSectionAsync(Section);
                return updatedSection;
            }

            public async Task<Section> DeleteSectionAsync(long Id)
            {
                IRestService rest = new RestService();
                Section deletedSection = await rest.DeleteSectionAsync(Id);
                return deletedSection;
            }


        }
    }
