using System.Collections.Generic;
using System.Net.Http;
using MVCClient.Models;

namespace MVCClient.Helper
{
    public interface IUserService
    {
        
        IEnumerable<UserInfoModel> GetUsers();
        UserInfoModel GetUser(int id);
        UserInfoModel AddUser(UserInfoModel company);
        System.Net.HttpStatusCode UpdateUser(UserInfoModel company);
        System.Net.HttpStatusCode DeleteUser(int id);
    }
}