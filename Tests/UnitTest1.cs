using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCClient.Controllers;
using MVCClient.Helper;
using MVCClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Tests
{
    // sample unit tests that could be expanded to give complete coverage
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexViewName_Blank_AreEqual()
        {
            IEnumerable<UserInfoModel> usersModels = new List<UserInfoModel>
            {
                new UserInfoModel
                {
                    FirstName = "fn1",
                    LastName = "ln1",
                    DateOfBirth = DateTime.Today
                },
                new UserInfoModel
                {
                    FirstName = "fn2",
                    LastName = "ln2",
                    DateOfBirth = DateTime.Today
                }
            };


            var mockDao = MockRepository.GenerateMock<IUserService>();

            mockDao.Stub(m => m.GetUsers()).Return(usersModels);

            var controllerUnderTest = new HomeController(mockDao);

            var result = controllerUnderTest.Index() as ViewResult;

            if (result != null) Assert.AreEqual("", result.ViewName);
        }
     
        [TestMethod]
        public void IndexRecordCount_2_IsEqual()
        {
            IEnumerable<UserInfoModel> usersModels = new List<UserInfoModel>
            {
                new UserInfoModel
                {
                    FirstName = "fn1",
                    LastName = "ln1",
                    DateOfBirth = DateTime.Today
                },
                new UserInfoModel
                {
                    FirstName = "fn2",
                    LastName = "ln2",
                    DateOfBirth = DateTime.Today
                }
            };


            var mockDao = MockRepository.GenerateMock<IUserService>();

            mockDao.Stub(m => m.GetUsers()).Return(usersModels);

            var controllerUnderTest = new HomeController(mockDao);


            int recCount = 0;

            var result = controllerUnderTest.Index() as ViewResult;

            if (result != null)
            {
                var model = result.Model as IEnumerable<UserInfoModel>;

                recCount = model.Count();
            }


            Assert.AreEqual(2,recCount);
        }
      
        [TestMethod]
        public void AddUser_NewUser_IsEqual()
        {
         
            var userInfoModel = new UserInfoModel();

            var mockDao = MockRepository.GenerateMock<IUserService>();
      
            mockDao.Stub(m => m.AddUser(userInfoModel)).Return(userInfoModel);

            var controllerUnderTest = new HomeController(mockDao);

            var result = controllerUnderTest.AddUser(userInfoModel) as ViewResult;

            if (result != null)
            {
                userInfoModel = result.Model as UserInfoModel;
                 
            }


            Assert.AreEqual(0, userInfoModel.Id);
        }

    }
}
