using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserCore;
using UserCore.Dal;
using UserCore.DB;

namespace IntegrationTests
{
    // sample integration tests that could be expanded to give complete coverage
    [TestClass]
    public class UnitTest1
    {
        private readonly UserInfoDal _userInfoDal = new UserInfoDal();

        private readonly List<UserInfo> _testUser = new List<UserInfo>();  


        [TestInitialize]
        public void Setup()
        {
            Debug.WriteLine("setup");

            AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Users\george\Documents\Visual Studio 2013\Projects\WEBAPI2\IntegrationTests\bin");

            var testUser = new UserInfo()
            {
                FirstName = "George",
                LastName = "IntegrationTest",
                DateOfBirth = DateTime.Today
            };
       
            this._testUser.Add(_userInfoDal.AddUser(testUser));
        }

        [TestMethod]
        public void GetsRecords()
        {

            var result = _userInfoDal.GetUsers();

            Assert.IsTrue(result.Any());
        }


        [TestMethod]
        public void AddsRecord()
        {
           
            var recordCount = _userInfoDal.GetUsers().Count();

            var testUser = new UserInfo()
            {
                FirstName = "George",
                LastName = "IntegrationTest",
                DateOfBirth = DateTime.Today
            };



            this._testUser.Add(_userInfoDal.AddUser(testUser));


            var newrecordCount = _userInfoDal.GetUsers().Count();

        
            Assert.IsTrue(recordCount + 1 == (newrecordCount));

        }

        [TestMethod]
        public void DeleteRecord()
        {
      
            var testUser = new UserInfo()
            {
                FirstName = "George",
                LastName = "DeletionTest",
                DateOfBirth = DateTime.Today
            };

            testUser = _userInfoDal.AddUser(testUser);
            
            _userInfoDal.DeleteUser(testUser.ID);

            var newrecordCount = _userInfoDal.GetUser(testUser.ID);

            Assert.IsNull(newrecordCount);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _userInfoDal.DeleteUsers(_testUser);

            Debug.WriteLine("cleanup");
        }
    }
}
