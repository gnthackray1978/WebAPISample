using System.Linq;
using System.Web.Mvc;
using MVCClient.Helper;
using MVCClient.Models;

namespace MVCClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService iUserService)
        {          
            _userService = iUserService;
        }

        public ActionResult Index()
        {
            var users = _userService.GetUsers();
            return View(users);
        }

        [HttpPost]       
        public ActionResult AddUser(UserInfoModel obj)
        {
            var newUser = new UserInfoModel();
 
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    newUser = _userService.AddUser(obj);
                }
                else
                {
                    _userService.UpdateUser(obj);
                    newUser = obj;
                }


            }

            ModelState.Clear();
         
            return PartialView("AddUserInfo", newUser);
        }

        [HttpPost]
        public ActionResult DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);

            var user = _userService.GetUsers().FirstOrDefault();

            return PartialView("AddUserInfo", user);
        }




        [HttpGet]
        public ActionResult GetUser(int userId)
        {
            var user = _userService.GetUser(userId);

            return PartialView("AddUserInfo", user);
        }

        [HttpGet]
        public ActionResult ListUsers()
        {
            var users = _userService.GetUsers();

            return PartialView("UserHistory", users);
        }


    }
}