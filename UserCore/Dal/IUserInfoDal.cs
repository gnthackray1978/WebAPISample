using System.Collections.Generic;

namespace UserCore.Dal
{
    public interface IUserInfoDal
    {
        UserInfo AddUser(UserInfo user);
        bool EditUser(UserInfo user);

        IEnumerable<UserInfo> GetUsers();
        UserInfo GetUser(int id);
        void DeleteUsers(List<UserInfo> userInfo);
        void DeleteUser(int userId);
    }
}