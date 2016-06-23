using System.Collections.Generic;
using System.Web.Http;
using UserCore;
using UserCore.Dal;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserInfoDal _userInfoDal;

        public UserController(IUserInfoDal userRepository)
        {
            _userInfoDal = userRepository;
        }

        public IEnumerable<UserInfo> Get()
        {
            return _userInfoDal.GetUsers();
        }

        public IHttpActionResult Get(int id)
        {
            var product = _userInfoDal.GetUser(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/values
        public UserInfo Post([FromBody]UserInfo value)
        {
            var newUser = _userInfoDal.AddUser(value);

            return newUser;
            
        }

        public IHttpActionResult Put([FromBody]UserInfo value)
        {
            _userInfoDal.EditUser(value);

            return Ok(true);

        }


        public IHttpActionResult Delete(int id)
        {
            _userInfoDal.DeleteUser(id);

            return Ok(true);
        }
    }
}
