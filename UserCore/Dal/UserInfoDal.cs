using System.Collections.Generic;
using System.Linq;
using UserCore.DB;

namespace UserCore.Dal
{
    public class UserInfoDal : IUserInfoDal
    {

        private readonly UserInfoContext _userInfoContext = new UserInfoContext();

        public UserInfo AddUser(UserInfo user)
        {
            var newRecord = _userInfoContext.Users.Add(user);

            _userInfoContext.SaveChanges();
             

            return newRecord;
        }

        public IEnumerable<UserInfo> GetUsers()
        {
            var ret = new List<UserInfo>();

            ret = _userInfoContext.Users.ToList();
            
            return ret;
        }

        public UserInfo GetUser(int id)
        {           
            var ret = _userInfoContext.Users.FirstOrDefault(p => p.ID == id);

            return ret;
        }

        public void DeleteUsers(List<UserInfo> userInfo)
        {

            _userInfoContext.Users.RemoveRange(userInfo);

            _userInfoContext.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _userInfoContext.Users.FirstOrDefault(p => p.ID == userId);

            if (user != null)
                _userInfoContext.Users.Remove(user);

            _userInfoContext.SaveChanges();
        }




        public bool EditUser(UserInfo user)
        {
            var ret = _userInfoContext.Users.FirstOrDefault(p => p.ID == user.ID);


            if (ret != null)
            {
                ret.DateOfBirth = user.DateOfBirth;
                ret.FirstName = user.FirstName;
                ret.LastName = user.LastName;
            }

            _userInfoContext.Entry(ret).State = System.Data.Entity.EntityState.Modified;   

            _userInfoContext.SaveChanges();

            return true;
        }
    }
}
