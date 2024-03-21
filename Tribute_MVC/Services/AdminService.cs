using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tribute_MVC.Models;
using System.Net.Http.Json;

namespace Tribute_MVC.Services
{
    public class AdminService : IAdminService
    {
        public bool Register(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                var contentData = new StringContent(JsonConvert.SerializeObject(user),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/Admin/AddUser", contentData).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode == true)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public User Login(string email, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/Login/"+email+"/"+password).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode == true)
                    return null;
                else
                {
                    User user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);
                    return user;
                }
            }
        }
        public List<TributeLogModel> GetTributeModificationDetails()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetTributesHistory").Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode == true)
                    return null;
                else
                {
                    List<TributeLogModel> list = JsonConvert.DeserializeObject<List<TributeLogModel>>(response.Content.ReadAsStringAsync().Result);
                    return list;
                }
            }
        }
        public List<Tribute> GetPendingTributes()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetPendingTributes").Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode == true)
                    return null;
                else
                {
                    List<Tribute> list = JsonConvert.DeserializeObject<List<Tribute>>(response.Content.ReadAsStringAsync().Result);
                    return list;
                }
            }
        }
        public bool UpdateUser(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                var contentData = new StringContent(JsonConvert.SerializeObject(user),
                System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("api/Admin/UpdateUser", contentData).Result;
                if (response.IsSuccessStatusCode == true)
                    return true;
                else
                    return false;
            }
        }

        public bool DeleteUser(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                HttpResponseMessage response = client.DeleteAsync("api/Admin/DeleteUser/" + id).Result;
                if (response.IsSuccessStatusCode == true)
                    return true;
                else
                    return false;
            }
        }

        public bool AddTribute(Tribute tribute)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                var contentData = new StringContent(JsonConvert.SerializeObject(tribute),
                  System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/Admin/Addtribute", contentData).Result;
                if (response.IsSuccessStatusCode == true)
                    return true;
                else
                    return false;
            }
        }

        public bool UpdateTribute(Tribute tribute)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                var contentData = new StringContent(JsonConvert.SerializeObject(tribute),
                System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("api/Admin/Updatetribute", contentData).Result;
                if (response.IsSuccessStatusCode == true)
                    return true;
                else
                    return false;
            }
        }

        public bool DeleteTribute(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                HttpResponseMessage response = client.DeleteAsync("api/Admin/Deletetribute/" + id).Result;
                if (response.IsSuccessStatusCode == true)
                    return true;
                else
                    return false;
            }
        }

        public bool ApproveTribute(int userId, int tributeId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/ApproveTribute/" + userId + "/" + tributeId).Result;
                if (response.IsSuccessStatusCode == true)
                    return true;
                else
                    return false;
            }
        }

        public List<TributeCategory> GetListofCategories()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetTributeCategories").Result;
                List<TributeCategory> list = JsonConvert.DeserializeObject<List<TributeCategory>>(response.Content.ReadAsStringAsync().Result);
                return list;
            }
        }

        public List<User> GetListofActiveUsers()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetUsers").Result;
                List<User> list = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
                return list;
            }
        }

        public User GetUserById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetUser/"+id).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode == true)
                    return null;
                else
                {
                    User user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);
                    return user;
                }
            }
        }

        public Tribute GetTributeById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetTribute/" + id).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode == true)
                    return null;
                else
                {
                    Tribute tribute = JsonConvert.DeserializeObject<Tribute>(response.Content.ReadAsStringAsync().Result);
                    return tribute;
                }
            }
        }

        public List<Tribute> GetTributes()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetTributes").Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode == true)
                    return null;
                else
                {
                    List<Tribute> list = JsonConvert.DeserializeObject<List<Tribute>>(response.Content.ReadAsStringAsync().Result);
                    return list;
                }
            }
        }

        public bool AddFeedback(TributeRating rating)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                var contentData = new StringContent(JsonConvert.SerializeObject(rating),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/Admin/AddFeedback", contentData).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode == true)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public int GetTotalRatingsofTribute(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetRating?id=" + id).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode == true)
                    return 0;
                else
                {
                    int ratings = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
                    return ratings;
                }
            }
        }

        public List<TributeLogModel> GetCommentsofTribute(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetTributeComments/"+id).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode == true)
                    return null;
                else
                {
                    List<TributeLogModel> list = JsonConvert.DeserializeObject<List<TributeLogModel>>(response.Content.ReadAsStringAsync().Result);
                    return list;
                }
            }
        }

        public List<Tribute> GetTributesByCategories(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetTributeOfSameCategory/"+id).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode == true)
                    return null;
                else
                {
                    List<Tribute> list = JsonConvert.DeserializeObject<List<Tribute>>(response.Content.ReadAsStringAsync().Result);
                    return list;
                }
            }
        }

        public bool RejectTribute(int userId, int tributeId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/RejectTribute/" + userId + "/" + tributeId).Result;
                if (response.IsSuccessStatusCode == true)
                    return true;
                else
                    return false;
            }
        }

        public int GetCountOfTributesOfUser(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetTributesCountOfUser/" + id).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode == true)
                    return 0;
                else
                {
                    int ratings = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
                    return ratings;
                }
            }
        }
    }
}
