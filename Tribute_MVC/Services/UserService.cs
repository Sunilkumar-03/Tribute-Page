using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Tribute_MVC.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Tribute_MVC.Services
{
    public class UserService:IUserService
    {
        public bool AddTribute(Tribute tribute)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                var contentData = new StringContent(JsonConvert.SerializeObject(tribute),
                  System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/User/AddTribute", contentData).Result;
                if (response.IsSuccessStatusCode == true)
                    return true;
                else
                    return false;
            }
        }

        public bool DeleteTribute(int tId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                HttpResponseMessage response = client.DeleteAsync("api/User/DeleteTribute/" + tId).Result;
                if (response.IsSuccessStatusCode == true)
                    return true;
                else
                    return false;
            }
        }

         public bool EditUser(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                var contentData = new StringContent(JsonConvert.SerializeObject(user),
                System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("api/User/EditUser/", contentData).Result;
                if (response.IsSuccessStatusCode == true)
                    return true;
                else
                    return false;
            }
        }

        public Tribute GetTributeById(int tId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/User/GetTributeById/" + tId).Result;
                Tribute tribute = JsonConvert.DeserializeObject<Tribute>(response.Content.ReadAsStringAsync().Result);
                return tribute;
            }
        }

        public Tribute GetTributeByName(string tName)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/User/GetTributeByName/" + tName).Result;
                Tribute tribute = JsonConvert.DeserializeObject<Tribute>(response.Content.ReadAsStringAsync().Result);
                return tribute;
            }
        }

        public List<Tribute> GetTributeByUser(int uId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/User/GetTributeByUser/" + uId).Result;
                List<Tribute> list = JsonConvert.DeserializeObject<List<Tribute>>(response.Content.ReadAsStringAsync().Result);
                return list;
            }
        }

        public List<Tribute> GetTributes()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/User/GetTributes").Result;
                List<Tribute> list = JsonConvert.DeserializeObject<List<Tribute>>(response.Content.ReadAsStringAsync().Result);
                return list;
            }
        }

        public List<Tribute> GetTributes(string searched_tributes)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/User/GetTributes/" + searched_tributes).Result;
                List<Tribute> list = JsonConvert.DeserializeObject<List<Tribute>>(response.Content.ReadAsStringAsync().Result);
                return list;
            }
        }

        public bool UpdateTribute(Tribute tribute)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                var contentData = new StringContent(JsonConvert.SerializeObject(tribute),
                System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("api/User/UpdateTribute", contentData).Result;
                if (response.IsSuccessStatusCode == true)
                    return true;
                else
                    return false;
            }
        }
        public User getUserById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23620/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/User/GetUser/" + id).Result;
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
    }
}
