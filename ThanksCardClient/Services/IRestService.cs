using Comment_RirekiClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;

namespace ThanksCardClient.Services
{
    interface IRestService
    {
        // Logon REST API Client
        Task<User> LogonAsync(User user);

        // DepartmentUsers REST API Client
        //Task<List<User>> GetDepartmentUsersAsync(long? DepartmentId);

        // User_Dep_Kanri REST API Client
        Task<List<User_Dep_Kanri>> GetUser_Dep_KanrisAsync();
        Task<User_Dep_Kanri> PostUser_Dep_KanriAsync(User_Dep_Kanri user_Dep_Kanri);
        Task<User_Dep_Kanri> PutUser_Dep_KanriAsync(User_Dep_Kanri user_Dep_Kanri);
        Task<User_Dep_Kanri> DeleteUser_Dep_KanriAsync(long Id);

        // User REST API Client
        Task<List<User>> GetUsersAsync();
        Task<User> PostUserAsync(User user);
        Task<User> PutUserAsync(User user);
        Task<User> DeleteUserAsync(long Id);

        // Department REST API Client
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department> PostDepartmentAsync(Department department);
        Task<Department> PutDepartmentAsync(Department department);
        Task<Department> DeleteDepartmentAsync(long Id);

        // Section REST API Client
        Task<List<Section>> GetSectionsAsync();
        Task<Section> PostSectionAsync(Section department);
        Task<Section> PutSectionAsync(Section department);
        Task<Section> DeleteSectionAsync(long Id);

        // TanksCard REST API Client
        Task<List<ThanksCard>> GetThanksCardsAsync();
        Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard);

        /* Comment REST API Client
        Task<List<Comment_Rireki>> GetComment_RirekisAsync();
        Task<Comment_Rireki> PostComment_RirekiAsync(Comment_Rireki comment_Rireki);*/

        // Category REST API Client
        Task<List<Category>> GetCategorysAsync();
        Task<Category> PostCategoryAsync(Category Category);
        Task<Category> PutCategoryAsync(Category Category);
        Task<Category> DeleteCategoryAsync(long Id);
    }
}
