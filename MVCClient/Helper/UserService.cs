using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using MVCClient.Models;

// Add Usings:

namespace MVCClient.Helper
{
    public class UserService : IUserService
    {
        readonly string _hostUri;

        public UserService(string hostUri)
        {
            _hostUri = hostUri;
        }


        private HttpClient CreateClient()
        {
            var client = new HttpClient {BaseAddress = new Uri(new Uri(_hostUri), "api/User/")};
            return client;
        }


        public IEnumerable<UserInfoModel> GetUsers()
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.GetAsync(client.BaseAddress).Result;

            }
            var result = response.Content.ReadAsAsync<IEnumerable<UserInfoModel>>().Result;
            return result;
        }


        public UserInfoModel GetUser(int id)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.GetAsync(new Uri(client.BaseAddress, id.ToString())).Result;
            }
            var result = response.Content.ReadAsAsync<UserInfoModel>().Result;
            return result;
        }


        public UserInfoModel AddUser(UserInfoModel company)
        {
            HttpResponseMessage response;
            UserInfoModel newUser;

            using (var client = CreateClient())
            {
                response = client.PostAsJsonAsync(client.BaseAddress, company).Result;

                newUser = response.Content.ReadAsAsync<UserInfoModel>().Result;
            }


            return newUser;
        }


        public System.Net.HttpStatusCode UpdateUser(UserInfoModel company)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.PutAsJsonAsync(client.BaseAddress, company).Result;
            }
            return response.StatusCode;
        }


        public System.Net.HttpStatusCode DeleteUser(int id)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.DeleteAsync(new Uri(client.BaseAddress, id.ToString())).Result;
            }
            return response.StatusCode;
        }
    }
}