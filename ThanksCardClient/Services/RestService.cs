using Comment_RirekiClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;

namespace ThanksCardClient.Services
{
    class RestService : IRestService
    {
        private HttpClient Client;
        private string BaseUrl;

        public RestService()
        {
            this.Client = new HttpClient();
            this.BaseUrl = "http://localhost:5000";
        }
        public async Task<User> LogonAsync(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Logon", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                // TODO
                System.Diagnostics.Debug.WriteLine("Exception in RestService.LogonAsync: " + e);
            }
            return responseUser;
        }

        /*public async Task<List<User>> GetDepartmentUsersAsync(long? DepartmentId)
        {
            List<User> responseUsers = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/DepartmentUsers/" + DepartmentId);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUsers = JsonConvert.DeserializeObject<List<User>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetUsersAsync: " + e);
            }
            return responseUsers;
        }*/

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> responseUsers = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Users");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUsers = JsonConvert.DeserializeObject<List<User>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetUsersAsync: " + e);
            }
            return responseUsers;
        }

        public async Task<User> PostUserAsync(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Users", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostUserAsync: " + e);
            }
            return responseUser;
        }

        public async Task<User> PutUserAsync(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Users/" + user.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutUserAsync: " + e);
            }
            return responseUser;
        }

        public async Task<User> DeleteUserAsync(long Id)
        {
            User responseUser = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Users/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteUserAsync: " + e);
            }
            return responseUser;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            List<Department> responseDepartments = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Departments");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartments = JsonConvert.DeserializeObject<List<Department>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetDepartmentsAsync: " + e);
            }
            return responseDepartments;
        }

        public async Task<Department> PostDepartmentAsync(Department department)
        {
            var jObject = JsonConvert.SerializeObject(department);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Department responseDepartment = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Departments", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartment = JsonConvert.DeserializeObject<Department>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        public async Task<Department> PutDepartmentAsync(Department department)
        {
            var jObject = JsonConvert.SerializeObject(department);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Department responseDepartment = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Departments/" + department.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartment = JsonConvert.DeserializeObject<Department>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        public async Task<Department> DeleteDepartmentAsync(long Id)
        {
            Department responseDepartment = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Departments/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartment = JsonConvert.DeserializeObject<Department>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        public async Task<List<ThanksCard>> GetThanksCardsAsync()
        {
            List<ThanksCard> responseThanksCards = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/ThanksCard");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseThanksCards = JsonConvert.DeserializeObject<List<ThanksCard>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetThanksCardsAsync: " + e);
            }
            return responseThanksCards;
        }

        public async Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard)
        {
            var jObject = JsonConvert.SerializeObject(thanksCard);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            ThanksCard responseThanksCard = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/ThanksCard", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseThanksCard = JsonConvert.DeserializeObject<ThanksCard>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostThanksCardAsync: " + e);
            }
            return responseThanksCard;
        }

        public async Task<List<Category>> GetCategorysAsync()
        {
            List<Category> responseCategorys = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Categorys");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseCategorys = JsonConvert.DeserializeObject<List<Category>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetCategorysAsync: " + e);
            }
            return responseCategorys;
        }

        public async Task<Category> PostCategoryAsync(Category Category)
        {
            var jObject = JsonConvert.SerializeObject(Category);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Category responseCategory = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Categorys", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseCategory = JsonConvert.DeserializeObject<Category>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostCategoryAsync: " + e);
            }
            return responseCategory;
        }

        public async Task<Category> PutCategoryAsync(Category Category)
        {
            var jObject = JsonConvert.SerializeObject(Category);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Category responseCategory = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Categorys/" + Category.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseCategory = JsonConvert.DeserializeObject<Category>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutCategoryAsync: " + e);
            }
            return responseCategory;
        }

        public async Task<Category> DeleteCategoryAsync(long Id)
        {
            Category responseCategory = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Categorys/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseCategory = JsonConvert.DeserializeObject<Category>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteCategoryAsync: " + e);
            }
            return responseCategory;
        }

        public async Task<List<User_Dep_Kanri>> GetUser_Dep_KanrisAsync()
        {
            List<User_Dep_Kanri> responseUser_Dep_Kanris = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/User_dep_Kanri");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser_Dep_Kanris = JsonConvert.DeserializeObject<List<User_Dep_Kanri>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetThanksCardsAsync: " + e);
            }
            return responseUser_Dep_Kanris;
        }

        public Task<User_Dep_Kanri> PostUser_Dep_KanriAsync(User_Dep_Kanri user_Dep_Kanri)
        {
            throw new NotImplementedException();
        }

        public Task<User_Dep_Kanri> PutUser_Dep_KanriAsync(User_Dep_Kanri user_Dep_Kanri)
        {
            throw new NotImplementedException();
        }

        public Task<User_Dep_Kanri> DeleteUser_Dep_KanriAsync(long Id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Section>> GetSectionsAsync()
        {
            List<Section> responseSections = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Sections");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseSections = JsonConvert.DeserializeObject<List<Section>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetSectionsAsync: " + e);
            }
            return responseSections;
        }

        public async Task<Section> PostSectionAsync(Section section)
        {
            var jObject = JsonConvert.SerializeObject(section);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Section responseSection = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Sections", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseSection = JsonConvert.DeserializeObject<Section>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostSectionAsync: " + e);
            }
            return responseSection;
        }

        public async Task<Section> PutSectionAsync(Section section)
        {
            var jObject = JsonConvert.SerializeObject(section);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Section responseSection = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Sections/" + section.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseSection = JsonConvert.DeserializeObject<Section>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutSectionAsync: " + e);
            }
            return responseSection;
        }

        public async Task<Section> DeleteSectionAsync(long Id)
        {
            Section responseSection = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Sections/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseSection = JsonConvert.DeserializeObject<Section>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteSectionAsync: " + e);
            }
            return responseSection;
        }

        /*public Task<List<Comment_Rireki>> GetComment_RirekisAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Comment_Rireki> PostComment_RirekiAsync(Comment_Rireki comment_Rireki)
        {
            throw new NotImplementedException();
        }*/
    }
}
